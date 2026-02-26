using ImageMagick;

namespace Session_1.Niveau_1
{
    internal class MemeMachine
    {

        public void PlaceTextOnImage(string text, string inputFileImage, string outputFileImage)
        {
        
            using (var image = new MagickImage(inputFileImage))
            {
                image.Settings.FontPointsize = 60;
                image.Settings.Font = "Impact";

                var whiteFont = MagickColor.FromRgb(255, 255, 255);
                var blackOutline = MagickColor.FromRgb(0, 0, 0);

                image.Settings.FillColor = whiteFont;

                image.Settings.StrokeWidth = 2;
                image.Settings.StrokeColor = blackOutline;


                image.Annotate(text, Gravity.South);

                image.Write(outputFileImage);
            }
        }
    }
}