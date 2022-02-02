using System.Collections.Generic;

namespace GuessTheNumber
{
    public interface ILogger
    {
        public void AddMessege(string message);

        public List<string> GetAllLog();
    }
}