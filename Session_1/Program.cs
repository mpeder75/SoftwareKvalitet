

using Session_1.Avancerede;

string input = @"C:\Users\mpede\source\repos\mpeder75\Bachelor\Semester 1\Softwareudvikling\Session 1-2\Hackaton\Hackaton\Input";
string output = @"C:\Users\mpede\source\repos\mpeder75\Bachelor\Semester 1\Softwareudvikling\Session 1-2\Hackaton\Hackaton\Output";


// -------------------------------------------------------------------------------- //


// Niveau 1: AutoThumbnailer
/*var thumbnailer = new AutoThumbnailer();
thumbnailer.GenerateThumbnail(input, output);*/


// -------------------------------------------------------------------------------- //


// Niveau 1: MemeMachine
//string fileInputPath = Path.Combine(input, "Cow_female_black_white.jpg");
//string fileOutputPath = Path.Combine(output, "MemeMachineImage.jpg");

//var memeMachine = new MemeMachine();
//memeMachine.PlaceTextOnImage("Helloooo", fileInputPath, fileOutputPath);*/


// -------------------------------------------------------------------------------- //


// Niveau 2: IntelligentWatermark
//string fileInputPath = Path.Combine(input, "sealion.jpg");
//string fileOutputPath = Path.Combine(output, "SymmetryGeneratorImage.jpg");

//var watermarker = new IntelligentWatermark();
//watermarker.CreateWatermark("Halloooo", fileInputPath, fileOutputPath);

// Niveau 2: SymmetryGenerator
//var symmetry = new SymmetryGenerator();
//symmetry.PictureSymmetryGenerator(fileInputPath, fileOutputPath);


// -------------------------------------------------------------------------------- //


// Niveau 3: VideoToFramesAnalyzer
//var videoToFramesAnalyzer = new VideoToFramesAnalyzer();
//string inputVideo = @"C:\Users\mpede\source\repos\mpeder75\Bachelor\Semester 1\Softwareudvikling\Session 1-2\Hackaton\Hackaton\Input\The FUNNIEST Cat Videos! - The Pet Collective (360p, h264).mp4";
//videoToFramesAnalyzer.AnalyzeVideoForSceneChanges(inputVideo, output, 0.4);

// Niveau 3: GreenScreenEngine
//string foregroundInputPath = Path.Combine(input, "eagle_green_screen.jpg");
//string backgroundInputPath = Path.Combine(input, "eagle_green_screen_landscape.jpg");
//string greenScreenOutputPath = Path.Combine(output, "GreenScreenResult.jpg");

//var greenScreenEngine = new GreenScreenEngine();
//greenScreenEngine.ApplyChromaKey(foregroundInputPath, backgroundInputPath, 0.3, greenScreenOutputPath);


// Niveau 3: ParallelProcessing - metoderne kaldes sekventielt, så vi skal ikek tænke på thread scheldueling
//string imagePath = Path.Combine(input, "Cow_female_black_white.jpg");

//var sequentialProcessing = new ParallelProcessing();
//sequentialProcessing.ProcessSequential(imagePath, "helloo", 1000);

//var parallelProcessing = new ParallelProcessing();
//parallelProcessing.ProcessParallel(imagePath, "HELLOO", 1000);


// -------------------------------------------------------------------------------- //

string colorPaletteInputPath = Path.Combine(input, "sealion.jpg");
var colorPaletteArchitect = new ColorPaletteArchitect();
var analyzedPicture = colorPaletteArchitect.AnalyzePictureColour(colorPaletteInputPath);
colorPaletteArchitect.GeneratePicture(analyzedPicture, 500, 500, Path.Combine(output, "ColorPaletteArchitectImage.jpg"));
