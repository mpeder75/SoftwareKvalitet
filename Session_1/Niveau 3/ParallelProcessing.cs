using System.Diagnostics;
using ImageMagick;

namespace Session_1.Niveau_3
{
    internal class ParallelProcessing
    {
        public void ProcessSequential(string imagePath, string watermarkText, int iterations)
        {
            // Billede lægges i Heapen, pointer/reference lægges på Stack, så det ikke skal indlæses for hver iteration
            byte[] imageBytes = File.ReadAllBytes(imagePath);

            var process = Process.GetCurrentProcess();
            var startCpuTime = process.TotalProcessorTime;
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            

            for (int i = 0; i < iterations; i++)
            {
                using (var image = new MagickImage(imageBytes))
                {
                    image.Settings.FontPointsize = 60;
                    image.Settings.Font = "Impact";
                    image.Settings.FillColor = MagickColor.FromRgb(255, 255, 255);

                    image.Settings.StrokeWidth = 2;
                    image.Settings.StrokeColor = MagickColor.FromRgb(0, 0, 0);

                    image.Annotate(watermarkText, Gravity.South);
                }
            }

            stopWatch.Stop();

            var endCpuTime = process.TotalProcessorTime;
            var cpuTimeUsed = (endCpuTime - startCpuTime).TotalSeconds;

            Console.WriteLine($"CPU tid brugt: {cpuTimeUsed} sekunder");
            Console.WriteLine($"Sekventiel behandling færdig efter {stopWatch.Elapsed.TotalSeconds} sekunder");
        }


        public void ProcessParallel(string imagePath, string watermarkText, int iterations)
        {

            // Billede lægges i Heapen, pointer/reference lægges på Stack, så det ikke skal indlæses for hver iteration
            byte[] imageBytes = File.ReadAllBytes(imagePath);

            var process = Process.GetCurrentProcess();
            var startCpuTime = process.TotalProcessorTime;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Parallel.For(0, iterations, (i) =>
            {
                using (var image = new MagickImage(imageBytes))
                {
                    image.Settings.FontPointsize = 60;
                    image.Settings.Font = "Impact";
                    image.Settings.FillColor = MagickColor.FromRgb(255, 255, 255);

                    image.Settings.StrokeWidth = 2;
                    image.Settings.StrokeColor = MagickColor.FromRgb(0, 0, 0);

                    image.Annotate(watermarkText, Gravity.South);
                }

            });

            stopWatch.Stop();

            var endCpuTime = process.TotalProcessorTime;
            var cpuTimeUsed = (endCpuTime - startCpuTime).TotalSeconds;

            Console.WriteLine($"CPU tid brugt: {cpuTimeUsed} sekunder");
            Console.WriteLine($"Parrallel behandling færdig efter {stopWatch.Elapsed.TotalSeconds} sekunder");
        }

    }
}
