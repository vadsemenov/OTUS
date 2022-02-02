using System.Collections.Generic;

namespace GuessTheNumber
{
    //
    public class ListLogger : Logger
    {
        List<string> Storage { get; set; }

        public ListLogger()
        {
            Storage = new List<string>();
        }

        public override void AddMessege(string message)
        {
            Storage.Add(message);
        }

        public override List<string> GetAllLog()
        {
            return Storage;
        }
    }
}