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
        public async Task<List<string>> GetUpdate(Str.FileWatcher root)
        {
            List<string> r = root.oldfiles;
            List<string> updated = new List<string>();
            await Task.Delay(1000);
            List<string> ur = await GetFilesUpdate(root.root);
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
        public static async Task<List<string>> GetFilesUpdate(string rootPath, List<string> alreadyFound = null)
        {
            if (alreadyFound == null) alreadyFound = new List<string>();
            DirectoryInfo di = new DirectoryInfo(rootPath);
            var dirs = di.EnumerateDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    alreadyFound = await GetFilesUpdate(dir.FullName, alreadyFound);
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
            public async void Initialize(string rootp)
            {
                root = rootp;
                oldfiles = await Watcher.GetFilesUpdate(rootp);
            }
        }
    }
}
