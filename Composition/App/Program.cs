using System;
using System.Threading.Tasks;
using Cartheur.Presents;

namespace App
{
    class Program
    {
        public static Recorder VoiceRecorder { get; private set; }

        static async Task Main(string[] args)
        {
            // Create an instance of the Classifier
            var classifier = new EmotionClassification.Classifier();

            // Load the dataset
            string datasetDirectoryPath = "/home/cartheur/ame/aiventure/aiventure-github/voice/voice-emotion-detector/datasets";
            classifier.LoadData(datasetDirectoryPath);

            VoiceRecorder = new Recorder();
                await VoiceRecorder.Record(ReturnRecordingFilePath("recorded"), 500);
                Console.WriteLine("Started recording...");
                VoiceRecorder.RecordingFinished += RecordingEvent;
                // Send over for the file for analysis and return the approximated emotion.
                //DetectEmotion = new Boagaphish.Analytics.DetectEmotion(ReturnRecordingFilePath(OutputDetectionFileName), "linux");

            Console.WriteLine("Enter the path to the audio file for emotion classification:");
            string audioFilePath = Console.ReadLine();

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
