using ImageMagick;

namespace Session_1.Niveau_1;

internal class AutoThumbnailer
{
    public void GenerateThumbnail(string filePathInput, string filePathOutput)
    {
        var images = Directory.GetFiles(filePathInput, "*.jpg").ToList();

        foreach (var image in images)
        {
            var img = new MagickImageInfo();

            img.Read(image);

            if (img.Width > 320 && img.Height > 320)
                using (var resizedImage = new MagickImage(image))
                {
                    resizedImage.Resize(250, 250);
                    resizedImage.Write(Path.Combine(filePathOutput, Path.GetFileName(image)));
                }
        }
    }
}