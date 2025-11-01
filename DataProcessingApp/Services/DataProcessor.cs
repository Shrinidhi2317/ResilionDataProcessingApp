using DataProcessingApp.Interface;
using DataProcessingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApp.Services
{
    public class DataProcessor: IDataProcessorService
    {
        private static readonly Lazy<DataProcessor> _instance = new Lazy<DataProcessor>(() => new DataProcessor());
        private static readonly object _lock = new object();

        private DataProcessor() { }

        public static DataProcessor Instance => _instance.Value;

        // Not re-entrant method, (Singleton Instance) takes 1 second regardless of the array size(1-4)
        public Result[] ProcessData(DataObject[] input)
        {
            lock (_lock)
            {
                Thread.Sleep(1000); // Simulate GPU processing
                var results = new Result[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    results[i] = new Result
                    {
                        Id = input[i].Id,
                        OutputData = $"Processed: {input[i].InputData}"
                    };
                }
                return results;
            }
        }
    }
}
