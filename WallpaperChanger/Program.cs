using System;
using System.Net;
using System.Runtime.InteropServices;

namespace WallpaperChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var filename = "desktop.jpg";
            //dowload file
            new WebClient().DownloadFile("https://images.pexels.com/photos/1054289/pexels-photo-1054289.jpeg", filename);
            //get current path
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //call function changeWallpaper
            changeWallpaper(path+filename);
        }

        //set infomation for image
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        //function change wallpapers
        static void changeWallpaper(string filename)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, filename, SPIF_UPDATEINIFILE);
        }
    }
}
