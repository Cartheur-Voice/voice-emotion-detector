using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using Accord.MachineLearning.VectorMachines.Learning;

namespace EmotionClassificationLib
{
    public class Classifier
    {
        private List<string> audioFiles;
        private Dictionary<string, string> emotionLabels;
        private SupportVectorMachine<Gaussian> svm;

        public Classifier()
        {
            audioFiles = new List<string>();
            emotionLabels = new Dictionary<string, string>();
        }

        public void LoadData(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                audioFiles.AddRange(Directory.GetFiles(directoryPath, "*.wav"));
                LoadEmotionLabels();
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory {directoryPath} does not exist.");
            }
        }

        private void LoadEmotionLabels()
        {
            foreach (var file in audioFiles)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var parts = fileName.Split('-');
                if (parts.Length == 7)
                {
                    var emotionCode = parts[2];
                    var emotion = GetEmotionFromCode(emotionCode);
                    emotionLabels[file] = emotion;
                }
            }
        }

        private string GetEmotionFromCode(string code)
        {
            return code switch
            {
                "01" => "neutral",
                "02" => "calm",
                "03" => "happy",
                "04" => "sad",
                "05" => "angry",
                "06" => "fearful",
                "07" => "disgust",
                "08" => "surprised",
                _ => "unknown"
            };
        }

        public void TrainModel()
        {
            // Extract features from audio files
            var features = new List<double[]>();
            var labels = new List<int>();

            foreach (var file in audioFiles)
            {
                var featureVector = ExtractFeatures(file);
                features.Add(featureVector);

                var emotion = emotionLabels[file];
                var label = GetLabelFromEmotion(emotion);
                labels.Add(label);
            }

            // Convert lists to arrays
            var featureArray = features.ToArray();
            var labelArray = labels.ToArray();

            // Train the SVM model
            var teacher = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 100 // Regularization parameter
            };

            svm = teacher.Learn(featureArray, labelArray);
        }

        private double[] ExtractFeatures(string filePath)
        {
            // Implement feature extraction logic here
            // For simplicity, let's return a dummy feature vector
            return new double[] { 0.0, 0.0, 0.0 };
        }

        private int GetLabelFromEmotion(string emotion)
        {
            return emotion switch
            {
                "neutral" => 0,
                "calm" => 1,
                "happy" => 2,
                "sad" => 3,
                "angry" => 4,
                "fearful" => 5,
                "disgust" => 6,
                "surprised" => 7,
                _ => -1
            };
        }

        public string PredictEmotion(string audioFilePath)
        {
            var featureVector = ExtractFeatures(audioFilePath);
            var predictedLabel = svm.Decide(featureVector);
            return GetEmotionFromLabel(predictedLabel);
        }

        private string GetEmotionFromLabel(int label)
        {
            return label switch
            {
                0 => "neutral",
                1 => "calm",
                2 => "happy",
                3 => "sad",
                4 => "angry",
                5 => "fearful",
                6 => "disgust",
                7 => "surprised",
                _ => "unknown"
            };
        }
    }
}