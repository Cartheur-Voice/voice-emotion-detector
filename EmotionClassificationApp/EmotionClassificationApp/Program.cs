using System;

namespace EmotionClassificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Classifier
            var classifier = new EmotionClassificationLib.Classifier();

            // Load the dataset
            Console.WriteLine("Enter the path to the dataset directory:");
            string datasetDirectoryPath = Console.ReadLine();
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