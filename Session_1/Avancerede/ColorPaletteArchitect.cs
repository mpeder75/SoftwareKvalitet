using ImageMagick;
using ImageMagick.Drawing;

namespace Session_1.Avancerede;

internal class ColorPaletteArchitect
{
    public List<string> AnalyzePictureColour(string filePath)
    {
        List<string> histogramColourResults = new List<string>();

        using (var picture = new MagickImage(filePath))
        {
            picture.Quantize(new QuantizeSettings
            {
                Colors = 5,
                DitherMethod = DitherMethod.No
            });

            var histogramColours = picture.Histogram();

            foreach (var colour in histogramColours)
            {
                histogramColourResults.Add(colour.Key.ToHexString());
            }
        }
        return histogramColourResults; 
    }

    public void GeneratePicture(List<string> hexColours, int height, int width ,string outputFilePath )
    {
        using (var newImage = new MagickImage(MagickColors.White, (uint)width, (uint)height))
        {
            int rectangleWidth = width / hexColours.Count;

            for (int i = 0; i < hexColours.Count; i++)
            {
                int x = i * rectangleWidth;


                // x = venstre kant(startpunkt x) 
                // 0 = toppen af billedet(startpunkt y)
                // x + rectangleWidth = højre kant(slutpunkt x)
                // height = bunden af billedet(slutpunkt y)
                // Så hvert rektangel går fra top til bund (fuld højde) og fylder sin "kolonne" i bredden.
                var drawables = new Drawables()
                    .FillColor(new MagickColor(hexColours[i]))
                    .Rectangle(x, 0, x + rectangleWidth, height);
                
                newImage.Draw(drawables);
            }
            newImage.Write(outputFilePath);
        }


    }
}