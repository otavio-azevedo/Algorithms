using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text.Json;

namespace Algorithms.OOP
{
    public static class BnpParibas
    {
        /// <summary>
        /// Write a program to import data files using OOP best practices
        /// Considering CSV and FixedLength format
        /// Write output to Console.
        /// </summary>
        public static string ImportContent(string inputContent)
        {
            string result = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(inputContent))
                    throw new ArgumentException();

                string[] lines = inputContent.Split('\n');
                IDataParser dataParser = IDataParser.CreateDataParser(lines[0]);
                IEnumerable<TransactionRecord> transactionRecords = dataParser.ParseContent(lines);
                result = JsonSerializer.Serialize(transactionRecords);

                Console.Write(result);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing content: {ex.Message}");
            }
            
            return result;
        }

    }

    public class TransactionRecord
    {
        public string? OriginalSourceId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Value { get; set; }
        public decimal Rate { get; set; }
    }

    public interface IDataParser
    {
        IEnumerable<TransactionRecord> ParseContent(string[] content);

        //In a real environment I think we could use the extension of the file to choose the parser
        static IDataParser CreateDataParser(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("The input is not in a valid format");

            if (content.Contains(',') || content.Contains(';'))
            {
                return new CsvDataParser();
            }
            else
            {
                return new FixedWidthDataParser();
            }
        }
    }

    public class CsvDataParser : IDataParser
    {
        public IEnumerable<TransactionRecord> ParseContent(string[] content)
        {
            List<TransactionRecord> result = new List<TransactionRecord>();

            for (int i = 1; i < content.Length; i++)
            {
                string[] fields = content[i].Split(';');
                if (fields.Length != 4)
                {
                    throw new InvalidOperationException("The input is not in a valid format");
                }

                result.Add(new TransactionRecord
                {
                    OriginalSourceId = fields[0],
                    TransactionDate = DateTime.ParseExact(fields[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Value = decimal.Parse(fields[2], CultureInfo.InvariantCulture),
                    Rate = decimal.Parse(fields[3], CultureInfo.InvariantCulture)
                });
            }

            return result;
        }
    }

    public class FixedWidthDataParser : IDataParser
    {
        public IEnumerable<TransactionRecord> ParseContent(string[] content)
        {
            List<TransactionRecord> result = new();

            foreach (var line in content)
            {
                result.Add(new TransactionRecord
                {
                    OriginalSourceId = line.Substring(0, 4),
                    TransactionDate = DateTime.ParseExact(line.Substring(4, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Value = decimal.Parse(line.Substring(14, 8), CultureInfo.InvariantCulture),
                    Rate = decimal.Parse(line.Substring(22, 5), CultureInfo.InvariantCulture)
                });

            }

            return result;
        }
    }
}