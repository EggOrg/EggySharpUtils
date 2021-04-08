using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchy
{
    public class Watcher
    {
        public List<string> GetUpdate(Str.FileWatcher root)
        {
            List<string> r = root.oldfiles;
            List<string> updated = new List<string>();
            List<string> ur = GetFilesUpdate(root.root);
            if (r != ur)
            {
                    
                foreach (string ufpath in ur)
                {
                    foreach (string ufupath in r)
                    {
                        if (ufpath != ufupath)
                        {
                            updated.Add(ufpath);
                        }
                    }
                }
            }
            return updated;
        }
        public static List<string> GetFilesUpdate(string rootPath, List<string> alreadyFound = null)
        {
            if (alreadyFound == null) alreadyFound = new List<string>();
            DirectoryInfo di = new DirectoryInfo(rootPath);
            var dirs = di.EnumerateDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    alreadyFound = GetFilesUpdate(dir.FullName, alreadyFound);
                }
            }
            var files = Directory.GetFiles(rootPath);
            foreach (string s in files)
            {
                alreadyFound.Add(s);
            }
            return alreadyFound;
        }
    }
    public class Str
    {
        public struct FileWatcher
        {
            public List<string> oldfiles { get; set; }
            public string root { get; set; }
            public void Initialize(string rootp)
            {
                root = rootp;
                oldfiles = Watcher.GetFilesUpdate(rootp);
            }
        }
    }
}
