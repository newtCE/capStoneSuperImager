using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
//using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFormVersion
{
    public partial class SICA : Form
    {
        public SICA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<DirectoryInfo> inputAgentDirectoryList = new List<DirectoryInfo>();
        string outputTarget;
        int templateWidth;
        int templateHeight;
        int templateCount;
        bool renderingImage = false;
        bool notifySlack = false;
        bool generateScript = false;
        bool openDirectoryOnCompletion = false;
        string renderPassword = "abc123";

        public async Task PostToSlack()
        {
            var content = new { text = "Your SICA render has completed!\nResults saved to "+ outputTarget};
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://hooks.slack.com/services/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"))
            {
                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    var response = await client.SendAsync(request);
                }
            }
        }

        public void SetOutputDirectory()
        {
            using (FolderBrowserDialog addAgentBrowser = new FolderBrowserDialog() { Description = "Select the Output Directory." })
            {
                if (addAgentBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (ValidateAgainstDuplicateDirectories(addAgentBrowser.SelectedPath) == true)
                    {
                        outputTarget=(addAgentBrowser.SelectedPath);
                        ListViewItem item = new ListViewItem(addAgentBrowser.SelectedPath.ToString());
                        OutputList.Clear();
                        OutputList.Items.Add(item);
                    }
                    else
                    {
                        //this cannot be our template due to validation failure
                    }
                }
            }
        }


        public bool ValidateTemplate(string inputDirectoryToCheck)
        {
            //check to make sure all images in template directory share the same pixel dimensions
            bool haveChecked = false;
            var fCount = Directory.GetFiles(inputDirectoryToCheck, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in fCount)
            {
                var bmp = System.Drawing.Image.FromFile(file);
                if (haveChecked == false)
                {
                    //set the template dimesions to first file
                    haveChecked = true;
                    templateHeight = bmp.Height;
                    templateWidth = bmp.Width;
                    templateCount = fCount.Length;
                }
                else
                {
                    //this file isn't the first check dimensions against template
                    if (bmp.Height==templateHeight&&bmp.Width==bmp.Width)
                    {
                        //do nothing, this image met criteria
                    }
                    else
                    {
                        //this won't work as a template directory send a notice
                        return false;
                    }
                }
            }
            return true;    //all images had the same dimensions, we are cleared to be a template
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory01"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory02"));
            if (inputAgentDirectoryList.Count>1&&renderingImage==false)
            {
                DirectoryInfo directory = inputAgentDirectoryList[0];
                if (directory != null)
                {
                    FileInfo[] files = directory.GetFiles(); 
                    int agentCount = inputAgentDirectoryList.Count;
                    renderingImage = true;
                    CombineImages(files, agentCount);
                }
            }
        }
        private void CombineImages(FileInfo[] files, int agentCount)
        {
            if (PasswordField.Text == renderPassword)
            {
                //string outputTarget = @"C:\superTest\resultDirectory";
                //this sets what will be the 'canvas size' of individual output imgs
                foreach (FileInfo file in files)//for every image in our first folder perform ops
                {
                    Image img = Image.FromFile(inputAgentDirectoryList[0] + "/" + (file.Name));//this gets entire address
                    int targetWidth = img.Width * agentCount;
                    int targetHeight = img.Height;
                    float pixelResHorizontal = img.HorizontalResolution;
                    float pixelResVertical = img.VerticalResolution;
                    img.Dispose();

                    Bitmap compositedRender = new Bitmap(targetWidth, targetHeight); //create super image based on settings
                    compositedRender.SetResolution(pixelResHorizontal, pixelResVertical);
                    Graphics render = Graphics.FromImage(compositedRender);
                    render.Clear(SystemColors.AppWorkspace);
                    for (int i = 0; i < agentCount; i++)//do this for however many directories or 'agents' are active
                    {
                        Image imgComp = Image.FromFile(inputAgentDirectoryList[i] + "/" + (file.Name));//current directory
                        render.DrawImage(imgComp, new Point(imgComp.Width * i, 0));
                        imgComp.Dispose();
                    }
                    render.Dispose();
                    compositedRender.Save(outputTarget + "/" + file.Name, System.Drawing.Imaging.ImageFormat.Png);
                    compositedRender.Dispose();

                }
                renderingImage = false;
                PasswordField.Text = "";
                if (generateScript == true)
                {
                    GenerateSortingJavaScriptFile(templateWidth, agentCount);
                }
                if (notifySlack == true)
                {
                    PostToSlack();             
                }
                if (openDirectoryOnCompletion == true)
                {
                    System.Diagnostics.Process.Start(outputTarget);
                }
            }
            else
            {
                AppNotice errorMessage = new AppNotice("Incorrect or No Password entered. Render Aborted.");
                errorMessage.Show();
                renderingImage = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog addAgentBrowser = new FolderBrowserDialog() { Description = "Select an Input Directory." })
            {
                if (addAgentBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (inputAgentDirectoryList.Count == 0)
                    {
                        if (ValidateTemplate(addAgentBrowser.SelectedPath) == true)
                        {
                            inputAgentDirectoryList.Add(new DirectoryInfo(addAgentBrowser.SelectedPath));
                            ListViewItem item = new ListViewItem(addAgentBrowser.SelectedPath.ToString());
                            AgentViewList.Items.Add(item);
                        }
                        else
                        {
                            //this cannot be our template due to validation failure
                        }
                    }
                    else
                    {
                        DirectoryInfo inputCandidate = new DirectoryInfo(addAgentBrowser.SelectedPath);
                        if(ValidateInputAgentProcess(inputCandidate.ToString(),templateCount, templateWidth, templateHeight)==true)
                        {
                            inputAgentDirectoryList.Add(new DirectoryInfo(addAgentBrowser.SelectedPath));
                            ListViewItem item = new ListViewItem(addAgentBrowser.SelectedPath.ToString());
                            AgentViewList.Items.Add(item);
                        }
                    }
                }
            }
        }
        public bool ValidateAgainstDuplicateDirectories(string inputDirectoryToCheck)
        {
            DirectoryInfo directoryToValidate = new DirectoryInfo(inputDirectoryToCheck);
            foreach (DirectoryInfo inputDirectory in inputAgentDirectoryList)
            {              
                if (directoryToValidate.FullName==inputDirectory.FullName)
                {
                    return false; //we've found a duplicate directory
                }
            }
            return true; //no exact matches so we are not a duplicate
        }
        public bool ValidateInputAgentProcess(string inputDirectoryToCheck, int agentOneFileCount, int xWidth, int yHeight)
        {
            if (ValidateAgainstDuplicateDirectories(inputDirectoryToCheck) == true)
            {
                if (ValidateInputAgentFileCount(inputDirectoryToCheck, agentOneFileCount) == true)
                {
                    if (ValidateInputAgentFileDimensions(inputDirectoryToCheck, xWidth, yHeight) == true)
                    {
                        //directory will be good to use
                        return true;
                    }
                    else
                    {
                        AppNotice errorMessage = new AppNotice("Directory not assigned due to directory containing files that do not match the pixel dimensions defined by previous directories.\nOnly images with matching dimensions are allowed to be components.");
                        errorMessage.Show();
                        return false;
                    }
                }
                else
                {
                    AppNotice errorMessage = new AppNotice("Directory not assigned due to file count mismatch. Check to be sure all intended image components are in the directory.");
                    errorMessage.Show();
                    return false;
                }
            }
            else
            {
                AppNotice errorMessage = new AppNotice("Directory not assigned. Duplicate directories prohibited.");
                errorMessage.Show();
                return false;
            }

        }
        public bool ValidateInputAgentFileCount(string inputDirectoryToCheck, int templateCount)
        {
            //input directory to check has to come in as a string to be used as a paramenter for a method
            //string currentDirectoryString = inputDirectoryToCheck.ToString();
            //is how one would turn a directory into a string that describes itself
            int fCount = Directory.GetFiles(inputDirectoryToCheck, "*", SearchOption.TopDirectoryOnly).Length;
            if (fCount == templateCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateInputAgentFileDimensions(string inputDirectoryToCheck, int xWidth, int yHeight)
        {
            //input directory to check has to come in as a string to be used as a paramenter for a method
            var fCount = Directory.GetFiles(inputDirectoryToCheck, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in fCount)
            {
                //Windows.Storage.FileProperties.BasicProperties fileToCheck =
                //await file.GetBasicPropertiesAsync();
                var bmp = System.Drawing.Image.FromFile(file);
                if (bmp.Width == xWidth && bmp.Height == yHeight)
                {
                    //meets specifications so continue
                }
                else
                {
                    //failed to match height
                    return false;
                }
            }
            // all matched so we are good
            return true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SetOutput_Click(object sender, EventArgs e)//set output directory
        {
            SetOutputDirectory();
        }

        private void SlackCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (notifySlack == false)
            {
                notifySlack = true;
            }
            else
            {
                notifySlack = false;
            }
            
        }//toggle slack notification

        private void button1_Click_1(object sender, EventArgs e)//set focus to password
        {
            PasswordField.Focus();
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)//clear
        {
            inputAgentDirectoryList.Clear();
            AgentViewList.Clear();
        }
        private void GenerateSortingJavaScriptFile(int horizontalOffsetValue, int agentCount)
        {
            string agentCountString = agentCount.ToString();
            string horizontalOffsetValueString = horizontalOffsetValue.ToString();
            List<string> lines =new List<string> {
                "var docRef = app.activeDocument;",
                "docRef.activeLayer.name=\"0\";",
                "var currentLayer=docRef.activeLayer.duplicate(docRef.activeLayer,ElementPlacement.PLACEBEFORE);"
            };
            for (int i = 1; i < agentCount; i++)
            {
                string currentLayerName = (agentCount-i).ToString();
                lines.Add("docRef.activeLayer = currentLayer;");
                lines.Add("docRef.activeLayer.name=\"" + currentLayerName + "\";");
                lines.Add("currentLayer.applyOffset(UnitValue(\""+ horizontalOffsetValueString+"px\"),0,OffsetUndefinedAreas.WRAPAROUND);");
                if (i != agentCount - 1)
                {
                    lines.Add("currentLayer=currentLayer.duplicate(currentLayer,ElementPlacement.PLACEAFTER);");
                }
            }
            lines.Add("docRef.resizeCanvas(docRef.width/" + agentCountString + ", docRef.height, AnchorPosition.TOPLEFT);");
            lines.Add("var bounds = [0, 0, docRef.width, docRef.height];");
            lines.Add("docRef.crop(bounds);");
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(outputTarget+"/Sort_Layers_"+horizontalOffsetValueString+"px_"+agentCountString+"_Layers.jsx", lines);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//generate JavaScript Sorting
        {
            if (generateScript == false)
            {
                generateScript = true;
            }
            else
            {
                generateScript = false;
            }
        }

        private void openDirectoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (openDirectoryOnCompletion == false)
            {
                openDirectoryOnCompletion = true;
            }
            else
            {
                openDirectoryOnCompletion = false;
            }
        }
    }
}
