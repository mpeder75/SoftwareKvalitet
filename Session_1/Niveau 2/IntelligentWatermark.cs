using ImageMagick;

namespace Session_1.Niveau_2;

internal class IntelligentWatermark
{
    public void CreateWatermark(string text, string filePathInput, string filePathOutput)
    {
        using (var image = new MagickImage(filePathInput))
        {
            var stats = image.Statistics();
            var composite = stats.Composite();
            var brightness = composite.Mean;

            image.Settings.Font = "Impact";
            image.Settings.StrokeWidth = 2;

            if (brightness > Quantum.Max / 2)
            {
                image.Settings.FillColor = MagickColor.FromRgb(0, 0, 0);
                image.Settings.StrokeColor = MagickColor.FromRgb(255, 255, 255);
            }
            else
            {
                image.Settings.FillColor = MagickColor.FromRgb(255, 255, 255);
                image.Settings.StrokeColor = MagickColor.FromRgb(0, 0, 0);
            }

            image.Settings.FontPointsize = 60;

            image.Annotate(text, Gravity.South);

            image.Write(filePathOutput);
        }
    }
}