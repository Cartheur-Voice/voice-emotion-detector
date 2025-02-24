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

        static async Task Main(string[] args)
        {
            // Create the app with settings.
            Configuration = new LoaderPaths("Debug");
            _thisAeon = new Aeon("1+2i");
            _thisAeon.LoadSettings(Configuration.PathToSettings);
            // Create an instance of the Classifier
            var classifier = new EmotionClassification.Classifier();
            // Set the recording duration
            RecordingDuration = 1000;
            // Load the dataset
            string datasetDirectoryPath = "/home/cartheur/ame/aiventure/aiventure-github/voice/voice-emotion-detector/datasets";
            classifier.LoadData(datasetDirectoryPath);

            VoiceRecorder = new Recorder();
                await VoiceRecorder.Record(ReturnRecordingFilePath("recorded"), RecordingDuration);
                Console.WriteLine("Started recording...");
                VoiceRecorder.RecordingFinished += RecordingEvent;
                // Send over for the file for analysis and return the approximated emotion.
                //DetectEmotion = new Boagaphish.Analytics.DetectEmotion(ReturnRecordingFilePath(OutputDetectionFileName), "linux");
            Thread.Sleep(2000);
            Console.WriteLine("Getting the file for analysis...");
            string audioFilePath = ReturnRecordingFilePath("recorded");

            // Predict the emotion
            var emotion = classifier.PredictEmotion(audioFilePath);

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
