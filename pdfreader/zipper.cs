using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SevenZip.Compression.LZMA;
using System.IO;
using SevenZip;
using System.Diagnostics;

namespace VHD_Director
{
    public class My7Zip
    {

        public static void CreateZipFolder(string sourceName, string targetName)
        {
            ProcessStartInfo p = new ProcessStartInfo
                                     {
                                         FileName = @"C:\Program Files\7-Zip\7z.exe",
                                         Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9",
                                         WindowStyle = ProcessWindowStyle.Hidden
                                     };
            Process x = Process.Start(p);
            x.WaitForExit();
        }



    }
}