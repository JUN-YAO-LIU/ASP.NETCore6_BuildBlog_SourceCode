using BasicSample.Application;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_Car
    {
        [TestMethod]
        public void Test_FillingUp()
        {
            // Arrange
            var car = new CarService();

            // Act
            string result = car.FillingUp();

            // Assert
            Assert.IsNotNull(result, "1 should not be null.");
        }
    }
}