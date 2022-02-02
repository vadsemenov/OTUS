using System;
using System.Diagnostics;
using System.Reflection;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //======================CSV serialize==============================
            stopwatch.Start();
            string csv = SerializationCSV.SerializeFromObjectToCSV(new TestClass());
            stopwatch.Stop();

            Console.WriteLine(csv);

            WriteTime(stopwatch.Elapsed, "сериализацию в CSV");

            //======================CSV Deserialize==============================
            stopwatch.Restart();
            TestClass testClass = (TestClass)SerializationCSV.DeserializeFromCSVToObject(csv.ToString());
            stopwatch.Stop();

            WriteTime(stopwatch.Elapsed, "десериализацию из CSV");

            //======================Json Serialize=============================

            stopwatch.Restart();
            string json = SerializationJson.SerializeFromObjectToJSON(new TestClass());
            stopwatch.Stop();

            Console.WriteLine(json);

            WriteTime(stopwatch.Elapsed, "сериализацию в Json");

            //======================Json Deserialize=============================

            stopwatch.Restart();
            TestClass testClass2 = (TestClass)SerializationJson.DeserializeFromJSONToObject(json);
            stopwatch.Stop();

            WriteTime(stopwatch.Elapsed, "десериализацию из Json");
        }


        static void WriteTime(TimeSpan ts, string serDeser)
        {

            // Format and display the TimeSpan value.
            string elapsedTimeCSV = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("На " + serDeser + " потрачено: " + elapsedTimeCSV);
        }


    }
}
