using CsvHelper;
using System;
using System.IO;
using System.Text;
using System.Globalization;

namespace ConsoleAppTest
{
    public class Metadata
    {
        public string bufferLenght;
        public string bufferVideoFormat;
        public DateTime bufferTimestamp;

    }

    public class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.UtcNow;
            Console.Write("start: ");
            Console.WriteLine(start);
            var result = "";

            while (start.AddSeconds(5) > DateTime.UtcNow)
            {
                SaveMetadata(/*...*/);

                Console.Write("time now: ");
                Console.WriteLine(DateTime.UtcNow);
                
            }
            Console.ReadLine();
        }

        private static void SaveMetadata()
        {
            Console.Write("----------------------");
            Console.Write("recording metadata at: " + DateTime.UtcNow.ToString());
            Console.Write("----------------------");

        }

        static void Main2(string[] args)
        {
            var data = new[]
            {
                new Metadata { bufferLenght = "Big Corp", bufferVideoFormat = "CRM updates" },
                new Metadata { bufferLenght = "Imaginary Corp", bufferVideoFormat = "Sales system" }
            };

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Configuration.Delimiter = ";";

                csvWriter.WriteField("Customer");
                csvWriter.WriteField("Title");
                csvWriter.WriteField("Deadline");
                csvWriter.WriteField("Data");
                csvWriter.WriteField("Buffer.Lenght");
                csvWriter.NextRecord();

                foreach (var project in data)
                {
                    csvWriter.WriteField(project.bufferLenght);
                    csvWriter.WriteField(project.bufferVideoFormat);
                    csvWriter.NextRecord();
                }

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}
