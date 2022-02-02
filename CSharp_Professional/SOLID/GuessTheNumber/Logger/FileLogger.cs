using System.Collections.Generic;
using System.IO;

namespace GuessTheNumber
{
    public class FileLogger : Logger, IGetFilename
    {
        public string FileName { get; set; }

        public FileLogger()
        {
            FileName = "log.txt";
        }

        public override void AddMessege(string message)
        {
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                sw.WriteLine(message);
            }
        }

        public override List<string> GetAllLog()
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(FileName))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }

            return list;
        }
    }
}