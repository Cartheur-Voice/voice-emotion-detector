using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Cartheur.Presents;
using Cartheur.Animals.Utilities;
using Cartheur.Animals.Core;

namespace App
{
    class Program
    {
        public static Recorder VoiceRecorder { get; private set; }
        public static int RecordingDuration { get; private set; }
        public static LoaderPaths Configuration;
        private static Aeon _thisAeon;
        public static string TrainingDataFiles { get; private set; }
        public static string FileName { get; private set; }
        public static bool UseFile { get; private set; }

        static async Task Main(string[] args)
{
            // Create the app with settings.
            Configuration = new LoaderPaths("Debug");
            _thisAeon = new Aeon("dot");
            // Load the given application configuration.
            _thisAeon.LoadSettings(Configuration.PathToSettings);
            TrainingDataFiles = _thisAeon.GlobalSettings.GrabSetting("trainingdatafiles");
            FileName = _thisAeon.GlobalSettings.GrabSetting("filename");
            UseFile = Convert.ToBoolean(_thisAeon.GlobalSettings.GrabSetting("usefile"));
            // Create an instance of the Classifier
            var classifier = new EmotionClassification.Classifier();
            classifier.LoadData(TrainingDataFiles);
            // Set the recording duration
            RecordingDuration = 1000;
            if (!UseFile)
            {
                VoiceRecorder = new Recorder();
                await VoiceRecorder.Record(ReturnRecordingFilePath("recorded"), RecordingDuration);
                Console.WriteLine("Started recording...");
                VoiceRecorder.RecordingFinished += RecordingEvent;
            }
            Console.WriteLine("Getting the file for analysis...");
            //string audioFilePath = ReturnRecordingFilePath("recorded");
            // Send over for the file for analysis and return the approximated emotion.
            try
            {
                //DetectEmotion = new Boagaphish.Analytics.DetectEmotion(ReturnRecordingFilePath(OutputDetectionFileName), "linux");
            }
            catch (Exception ex)
            {

            }

            //Thread.Sleep(2000);
            // Load the data

            // Train the model
            classifier.TrainModel();
            // Predict the emotion
            var emotion = classifier.PredictEmotion(FileName);

            // Display the classification result
            Console.WriteLine($"The predicted emotion is: {emotion}");

            static string ReturnRecordingFilePath(string filename)
            {
                return $"/home/cartheur/ame/aiventure/aiventure-github/voice/voice-emotion-detector/Composition/App/recordings/{filename}.wav";
            }
        }

        private static void RecordingEvent(object source, EventArgs e)
        {
            Console.WriteLine("Recording has completed.");
        }
    }
}
