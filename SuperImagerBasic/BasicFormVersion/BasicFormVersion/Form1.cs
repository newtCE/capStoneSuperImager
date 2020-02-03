using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFormVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<DirectoryInfo> inputAgentDirectoryList = new List<DirectoryInfo>();
        int templateWidth;
        int templateHeight;
        int templateCount;

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
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory03"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory02"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory02"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory02"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory02"));
            //inputAgentDirectoryList.Add(new DirectoryInfo(@"C:\superTest\directory03"));
            if (inputAgentDirectoryList.Count>1)
            {

                DirectoryInfo directory = inputAgentDirectoryList[0];
                if (directory != null)
                {
                    FileInfo[] files = directory.GetFiles();
                    
                    int agentCount = inputAgentDirectoryList.Count;
                    CombineImages(files, agentCount);
                }

            }
        }
        private void CombineImages(FileInfo[] files, int agentCount)
        {
            string outputTarget = @"C:\superTest\resultDirectory";
            //this sets what will be the 'canvas size' of individual output imgs
            foreach (FileInfo file in files)//for every image in our first folder perform ops
            {
                Image img = Image.FromFile(inputAgentDirectoryList[0]+"/"+(file.Name));//this gets entire address
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
                        Image imgComp = Image.FromFile(inputAgentDirectoryList[i]+"/"+(file.Name));//current directory
                        render.DrawImage(imgComp, new Point(imgComp.Width * i, 0));
                        imgComp.Dispose();
                    }
                render.Dispose();
                compositedRender.Save(outputTarget + "/" + file.Name, System.Drawing.Imaging.ImageFormat.Png);
                compositedRender.Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
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
                        }
                        else
                        {
                            //this cannot be our template due to validation failure
                        }
                    }
                    else
                    {
                        DirectoryInfo inputCandidate = new DirectoryInfo(addAgentBrowser.SelectedPath);
                        ValidateInputAgentProcess(inputCandidate.ToString(),templateCount, templateWidth, templateHeight);
                    }
                }
            }
        }

        public void ValidateInputAgentProcess(string inputDirectoryToCheck, int agentOneFileCount, int xWidth, int yHeight)
        {
            if (ValidateInputAgentFileCount(inputDirectoryToCheck, agentOneFileCount) == true)
            {
                if (ValidateInputAgentFileDimensions(inputDirectoryToCheck, xWidth, yHeight) == true)
                {
                    //directory will be good to use
                }
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

    }
}
