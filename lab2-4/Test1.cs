using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayOopTask;

namespace ArrayOopTask.Tests
{
    [TestClass]
    public class ArrayProcessorTests
    {
        [TestMethod]
        public void ControlExampleTest()
        {
            int[] inputData = { 5, -3, 9, -10, 8 };
            var processor = new ArrayProcessor(inputData);

            long actualSum = processor.GetSumOfAbsoluteNegativeElements();
            long? actualProduct = processor.GetProductBeforeLastNegative();

            Assert.AreEqual(13, actualSum);
            Assert.AreEqual(-135, actualProduct);
        }

        [TestMethod]
        public void NoNegativeElements_ReturnsZeroSumAndNullProduct()
        {
            int[] inputData = { 1, 2, 3, 4, 5 };
            var processor = new ArrayProcessor(inputData);

            long actualSum = processor.GetSumOfAbsoluteNegativeElements();
            long? actualProduct = processor.GetProductBeforeLastNegative();

            Assert.AreEqual(0, actualSum);
            Assert.IsNull(actualProduct);
        }

        [TestMethod]
        public void FirstElementIsLastNegative_ReturnsZeroProduct()
        {
            int[] inputData = { -5, 2, 3, 4 };
            var processor = new ArrayProcessor(inputData);

            long actualSum = processor.GetSumOfAbsoluteNegativeElements();
            long? actualProduct = processor.GetProductBeforeLastNegative();

            Assert.AreEqual(5, actualSum);
            Assert.AreEqual(0, actualProduct);
        }

        [TestMethod]
        public void AllNegativeElements_CalculatesCorrectly()
        {
            int[] inputData = { -2, -3, -4 };
            var processor = new ArrayProcessor(inputData);

            long actualSum = processor.GetSumOfAbsoluteNegativeElements();
            long? actualProduct = processor.GetProductBeforeLastNegative();

            Assert.AreEqual(9, actualSum);
            Assert.AreEqual(6, actualProduct);
        }
    }
}