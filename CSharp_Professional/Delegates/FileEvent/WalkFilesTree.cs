using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileEvent
{
    //https://coderoad.ru/14977927/%D0%9A%D0%B0%D0%BA-%D0%BF%D0%B5%D1%80%D0%B5%D0%B4%D0%B0%D1%82%D1%8C-%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82%D1%8B-%D0%B2-EventArgs
    //https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/file-system/how-to-iterate-through-a-directory-tree
    //https://otus.ru/learning/113712/

    public class FileArgs : EventArgs
    {
        private readonly string _fileName;

        public FileArgs(string fileName)
        {
            _fileName = fileName;
        }

        public override string ToString()
        {
            return _fileName;
        }
    }

    public class WalkFilesTree
    {
        private event EventHandler<FileArgs> FileFound;
        private CancellationToken ct;


        public WalkFilesTree(DirectoryInfo path, CancellationToken ct)
        {
            this.ct = ct;
            try
            {
                FileFound += FileFoundEvent;
                WalkTree(path);

            }
            catch (Exception exp)
            {
                Console.WriteLine($"Some error: {exp.Message}");
            }
            finally
            {
                FileFound -= FileFoundEvent;
            }
        }


        void WalkTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDir = null;
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (DirectoryNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (ct.IsCancellationRequested) return;

                    if (FileFound != null) FileFound(this, new FileArgs(file.Name));
                }

            }


            subDir = root.GetDirectories();

            foreach (var dir in subDir)
            {
                WalkTree(dir);
            }


        }



        void FileFoundEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Found file: {e}");
        }
    }
}
