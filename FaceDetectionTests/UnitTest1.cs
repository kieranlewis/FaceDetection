using FaceDetection.Model;

namespace FaceDetectionTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string ImagesPath = "C:\\Users\\KieranLewis\\source\\repos\\FaceDetection\\FaceDetection\\Images\\";

        [TestMethod]
        [DataRow("TestImage1.jpg", 70)]
        [DataRow("TestImage2.jpg", 97)]
        [DataRow("TestImage3.jpg", 64)]
        [DataRow("TestImage4.jpg", 0)]
        [DataRow("TestImage5.png", 96)]
        public void ConfidenceTest(string fileName, int confidence)
        {
            var filePath = ImagesPath + fileName;
            var imageModel = new ImageModel(filePath);

            Assert.AreEqual(confidence, imageModel.Confidence, "Confidence level is incorrect");
        }

        [TestMethod]
        [DataRow("TestImage1.jpg", 1)]
        [DataRow("TestImage2.jpg", 1)]
        [DataRow("TestImage3.jpg", 1)]
        [DataRow("TestImage4.jpg", 0)]
        [DataRow("TestImage5.png", 2)]
        public void FaceCountTest(string fileName, int faceCount)
        {
            var filePath = ImagesPath + fileName;
            var imageModel = new ImageModel(filePath);

            Assert.AreEqual(faceCount, imageModel.FaceCount, "Face count is incorrect");
        }

        [TestMethod]
        [DataRow("TestImage1.jpg", "")]
        [DataRow("TestImage2.jpg", @"{""Name"":""TestImage2.jpg"",""Confidence"":97.0,""FaceCount"":1}")]
        public void JsonTest(string fileName, string json)
        {
            var filePath = ImagesPath + fileName;
            var imageModel = new ImageModel(filePath);

            Assert.AreEqual(json, imageModel.JsonResult, "JSON result is incorrect");
        }
    }
}