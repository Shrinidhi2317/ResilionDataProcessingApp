
using DataProcessingApp.Models;
using DataProcessingApp.Services;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var worker = new DataProcessingWorker();



        var inputs = new[]
        {
            new DataObject { Id = 1, InputData = "CSharp" },
            new DataObject { Id = 2, InputData = "Dotnet" },
            new DataObject { Id = 3, InputData = "Angular" }
        };

        foreach (var input in inputs)
        {
            var result = worker.ProcessSingle(input);
            Console.WriteLine($"Result for Id {result.Id}: {result.OutputData}");
        }

        //var worker = new DataProcessingWorker();
        //var result = worker.ProcessSingle(new DataObject { Id = 1, InputData = "Test input" });
        //Console.WriteLine($"Result Id: {result.Id}, Data: {result.OutputData}");
    }
}
