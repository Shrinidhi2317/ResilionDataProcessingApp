using DataProcessingApp.Interface;
using DataProcessingApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApp.Services
{
    public class DataProcessingWorker : IDataProcessingWorker
    {
        private ConcurrentQueue<DataObject> _queue = new ConcurrentQueue<DataObject>();

        public Result ProcessSingle(DataObject obj)
        {
            _queue.Enqueue(obj);

            // Process up to 4 objects together if available
            var batchProcess = new DataObject[4];
            int count = 0;
            while (count < 4 && _queue.TryDequeue(out var item))
            {
                batchProcess[count++] = item;
            }
            // If only one item, make batch of one
            var toProcess = new DataObject[count];
            Array.Copy(batchProcess, toProcess, count);

            var results = DataProcessor.Instance.ProcessData(toProcess);
            // Return result corresponding to current object
            foreach (var res in results)
                if (res.Id == obj.Id) return res;
            return null;
        }
    }
}
