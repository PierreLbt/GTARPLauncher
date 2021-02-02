using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyServerLauncher
{
    class DirDeleter
    {
        private static List<string> DirList { get; set; }
        private static List<string> FileList { get; set; }
        private static readonly string cache = "\\FiveM.app\\cache\\";


        public static void Delete(string path)
        {
            string[] dirs = { "browser", "db", "priv", "servers", "subprocess", "unconfirmed" };
            string[] files = { "crashometry", "launcher_skip_mtl2" };
            DirList = new List<string>(dirs);
            FileList = new List<string>(files);

            foreach (string dir in DirList)
            {
                try
                {
                    string toDel = path + cache + dir;
                    Directory.Delete(toDel, true);
                }
                catch
                {

                }
                
            }
            foreach (string file in FileList)
            {
                try
                {
                    string toDel = path + cache + file;
                    File.Delete(toDel);
                }
                catch
                {

                }

            }
        }
    }
}
