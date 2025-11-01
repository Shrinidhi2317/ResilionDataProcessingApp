using DataProcessingApp.Interface;
using DataProcessingApp.Models;
using DataProcessingApp.Services;
using Moq;
using System.Diagnostics;
using Xunit;

namespace Tests
{
    
    public class DataProcessingWorkerTests
    {

        [Fact]
        public void ProcessData_ShouldReturnExpectedResults()
        {
            // Arrange
            var mockService = new Mock<IDataProcessorService>();
            var input = new[] { new DataObject { Id = 1, InputData = "Test" } };
            var expected = new[] { new Result { Id = 1, OutputData = "Processed: Test" } };

            mockService.Setup(s => s.ProcessData(input)).Returns(expected);

            // Act
            var actual = mockService.Object.ProcessData(input);

            // Assert
            Assert.NotNull(actual);
            Assert.Single(actual);
            Assert.Equal(expected[0].Id, actual[0].Id);
            Assert.Equal(expected[0].OutputData, actual[0].OutputData);

            mockService.Verify(s => s.ProcessData(input), Times.Once);
        }

        [Fact]
        public void ProcessSingle_ReturnsResultWithinTwoSeconds()
        {
            var worker = new DataProcessingWorker();
            var input = new DataObject { Id = 1, InputData = "UnitTest Input" };

            var sw = Stopwatch.StartNew();
            var result = worker.ProcessSingle(input);
            sw.Stop();

            Assert.NotNull(result);
            Assert.Equal(input.Id, result.Id);
            Assert.True(sw.ElapsedMilliseconds <= 2000, "Processing time exceeded 2 seconds");
        }

        [Fact]
        public void ProcessMultiple_ShouldReturnCorrectResults()
        {
            // Arrange
            var worker = new DataProcessingWorker();
            var inputs = new[]
            {
            new DataObject { Id = 1, InputData = "Input 1" },
            new DataObject { Id = 2, InputData = "Input 2" },
            new DataObject { Id = 3, InputData = "Input 3" }
        };

            // Act
            var results = new Result[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                results[i] = worker.ProcessSingle(inputs[i]);
            }

            // Assert
            for (int i = 0; i < inputs.Length; i++)
            {
                Assert.NotNull(results[i]);
                Assert.Equal(inputs[i].Id, results[i].Id);
                Assert.Equal($"Processed: {inputs[i].InputData}", results[i].OutputData);
            }
        }
    }
}
