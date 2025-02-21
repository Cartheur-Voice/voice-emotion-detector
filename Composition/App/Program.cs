using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Classifier
            var classifier = new EmotionClassification.Classifier();

            // Load the dataset
            string datasetDirectoryPath = "/home/cartheur/ame/aiventure/aiventure-github/voice/voice-emotion-detector/datasets";
            classifier.LoadData(datasetDirectoryPath);

            Console.WriteLine("Enter the path to the audio file for emotion classification:");
            string audioFilePath = Console.ReadLine();

            // Predict the emotion
            var emotion = classifier.PredictEmotion(audioFilePath);

            // Display the classification result
            Console.WriteLine($"The predicted emotion is: {emotion}");
        }
    }
}