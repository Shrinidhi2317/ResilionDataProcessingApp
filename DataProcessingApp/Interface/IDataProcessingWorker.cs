using DataProcessingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApp.Interface
{
    public interface IDataProcessingWorker
    {
        Result ProcessSingle(DataObject obj);
    }
}
