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
                    inputAgentDirectoryList.Add(new DirectoryInfo(addAgentBrowser.SelectedPath));
                    //txtPath.Text = fbd.SelectedPath;
                    //foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    //{
                    //}

                }
            }
        }
    }
}
