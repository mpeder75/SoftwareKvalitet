using ImageMagick;

namespace Session_1.Niveau_2;

internal class SymmetryGenerator
{
    public void PictureSymmetryGenerator(string inputFilePath, string outputFilePath)
    {
        using (var image = new MagickImage(inputFilePath))
        {
            var imageCenterPoint = image.Width / 2;

            var croppedImage = image.Clone();
            croppedImage.Crop(new MagickGeometry(0, 0, imageCenterPoint, image.Height));
            croppedImage.Flop();

            var clonedImage = image.Clone();
            clonedImage.Crop(new MagickGeometry(0, 0, imageCenterPoint, image.Height));


            var floppedImage = new MagickImageCollection();
            floppedImage.Add(clonedImage);
            floppedImage.Add(croppedImage);
            var symmetryImage = floppedImage.AppendHorizontally();

            symmetryImage.Write(outputFilePath);
        }
    }
}