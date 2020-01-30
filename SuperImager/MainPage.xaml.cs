using System;
using System.Drawing;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SuperImager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void ValidateInputAgentProcess (string inputDirectoryToCheck, int agentOneFileCount, int xWidth, int yHeight)
        {
            if (ValidateInputAgentFileCount(inputDirectoryToCheck, agentOneFileCount)==true)
            {
                if (ValidateInputAgentFileDimensions(inputDirectoryToCheck, xWidth,yHeight)==true)
                {
                    //directory will be good to use
                }
            }

        }

        public bool ValidateInputAgentFileCount(string inputDirectoryToCheck, int agentOneFileCount)
        {
            //input directory to check has to come in as a string to be used as a paramenter for a method
            //string currentDirectoryString = inputDirectoryToCheck.ToString();
            //is how one would turn a directory into a string that describes itself
            int fCount = Directory.GetFiles(inputDirectoryToCheck, ".png", SearchOption.TopDirectoryOnly).Length;
            if (fCount == agentOneFileCount)
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
            //string currentDirectoryString = inputDirectoryToCheck.ToString();
            //is how one would turn a directory into a string that describes itself
            var fCount = Directory.GetFiles(inputDirectoryToCheck, ".png", SearchOption.TopDirectoryOnly);
            foreach(var file in fCount)
            {
                //Windows.Storage.FileProperties.BasicProperties fileToCheck =
                //await file.GetBasicPropertiesAsync();
                var bmp = System.Drawing.Image.FromFile(inputDirectoryToCheck + "/" + file);
                
                    int fileWidth = bmp.Width;
                    int fileHeight = bmp.Height;
                
                if (fileWidth == xWidth&&fileHeight==yHeight)
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
