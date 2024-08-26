using Google.Cloud.Vision.V1;

namespace FaceDetection.Model
{
    internal class GoogleCloudApi
    {
        public int Confidence { get; }
        public int FaceCount { get; }

        public GoogleCloudApi(ImageModel imageModel)
        {
            var image = Image.FromFile(imageModel.Path);

            ImageAnnotatorClient client = ImageAnnotatorClient.Create();
            IReadOnlyList<FaceAnnotation> result = client.DetectFaces(image);

            foreach (FaceAnnotation face in result)
            {
                var resultConfidence = (int)(face.DetectionConfidence * 100);

                // Only update if the confidence result for the current face is bigger
                if (resultConfidence > Confidence)
                {
                    Confidence = resultConfidence;
                }
            }

            FaceCount = result.Count;
        }
    }
}
