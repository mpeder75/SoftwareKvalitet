using ImageMagick;

namespace Session_1.Niveau_3
{
    internal class GreenScreenEngine
    {
        public void ApplyChromaKey(string inputForegroundImagePath, string inputBackgroundImagePath, double colorThreshold, string outputPath)
        {
            colorThreshold = colorThreshold * Quantum.Max;

            using (var foregroundImage = new MagickImage(inputForegroundImagePath))
            using (var backgroundImage = new MagickImage(inputBackgroundImagePath))
            {
                foregroundImage.Alpha(AlphaOption.On);

                var foregroundPixels = foregroundImage.GetPixels();

                for (int y = 0; y < foregroundImage.Height; y++)
                {
                    for (int x = 0; x < foregroundImage.Width; x++)
                    {
                        var checkPixelColor = foregroundPixels.GetPixel(x,y).ToColor();

                        if (checkPixelColor.G - checkPixelColor.R > colorThreshold && checkPixelColor.G - checkPixelColor.B > colorThreshold)
                        {
                            foregroundPixels.SetPixel(x, y, [0,0,0,0]);
                        }
                    }
                }

                backgroundImage.Composite(foregroundImage, CompositeOperator.Over);
                backgroundImage.Write(outputPath);
            }

        }
    }
}
