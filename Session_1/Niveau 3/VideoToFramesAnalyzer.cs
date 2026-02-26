using FFMpegCore;
using ImageMagick;

namespace Session_1.Niveau_3;

internal class VideoToFramesAnalyzer
{
    public void AnalyzeVideoForSceneChanges(string videoInputPath, string videoOutputPath, double threshold)
    {
        List<string> frames = new List<string>();

        // Loader video fra filePath
        var videoInfo = FFProbe.Analyse(videoInputPath);

        // Få video duration i sekunder
        var videoDuration = (int)videoInfo.Duration.TotalSeconds;

        // Loop gennem videoen og gem hver frame som billede
        for (int i = 0; i < videoDuration; i++)
        {
            string fileName = $"frame_{i}.png";
            string frameOutputPath = Path.Combine(videoOutputPath, fileName);

            FFMpeg.Snapshot(videoInputPath, frameOutputPath, captureTime:TimeSpan.FromSeconds(i));

            frames.Add(frameOutputPath);
        }

        // Analyser hver frame for at finde scene ændringer
        for (int i = 1; i < frames.Count; i++)
        {
            using (var previousImage = new MagickImage(frames[i - 1]))
            {

                using (var currentImage = new MagickImage(frames[i]))
                {
                    var differenceInFrames = currentImage.Compare(previousImage, ErrorMetric.RootMeanSquared);
                    
                    if (differenceInFrames > threshold)
                    {
                        Console.WriteLine($"Scene ændring fundet ved frame {i} med en forskel på {differenceInFrames}");
                    }
                }
            }
        }
    }
}