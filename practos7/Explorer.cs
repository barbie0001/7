using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practos7
{

    static public class Explorer
    {
        static public bool dr = true;
        static public string path;
        static public DriveInfo[] drives;
        static public string[] paths;
        static public void ReadDrives()
        {
            drives = DriveInfo.GetDrives();
            Menu.options = new string[drives.Length];

            for (int i = 0; i < drives.Length; i++)
            {

                long freeSpace = drives[i].TotalFreeSpace / 1073741824;
                long totalSize = drives[i].TotalSize / 1073741824;
                Menu.options[i] = $"{drives[i].Name} {freeSpace} ГБ свободно {totalSize}";
            }
        }
        static public void ReadDirectory()
        {
            Menu.options = Directory.GetFileSystemEntries(path);
            paths = Menu.options;
            for (int i = 0; i < Menu.options.Length; i++)
            {
                FileInfo cfile = new FileInfo(Menu.options[i]);
                Menu.options[i] = $"{Menu.options[i].PadRight(40)}{Directory.GetCreationTime(Menu.options[i])}\t\t{cfile.Extension}";
            }
        }

    }
}