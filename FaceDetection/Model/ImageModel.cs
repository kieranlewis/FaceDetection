using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace FaceDetection.Model
{
    public class ImageModel
    {
        [JsonIgnore]
        public string Path { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ImageSource ImageSource { get; set; }
        public double Confidence { get; set; }
        public int FaceCount { get; set; }
        [JsonIgnore]
        public string JsonResult { get; set; }

        public ImageModel(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(path);
            ImageSource = new BitmapImage(new Uri(path));
            Confidence = 0.0;
            FaceCount = 0;
            JsonResult = "";

            ProcessImage();
        }

        public void ProcessImage()
        {
            var api = new GoogleCloudApi(this);
            Confidence = api.Confidence;
            FaceCount = api.FaceCount;

            CheckResult();
        }

        public void CheckResult()
        {
            if (Confidence < 70)
            {
                // Image has less than 70% chance to have a face
                // TODO: relevant action
            }
            else if (Confidence >= 70 && Confidence < 80)
            {
                // Image has between 70-80% chance to have a face
                // TODO: relevant action
            }
            else
            {
                // Output JSON file
                JsonResult = JsonConvert.SerializeObject(this);
            }
        }
    }
}
