# Emotion Classification Application

This project is an Emotion Classification Application that utilizes the RAVDESS dataset to classify emotions from audio files. It consists of a library for handling the emotion classification logic and a console application for user interaction.

## Project Structure

```
EmotionClassificationApp
├── EmotionClassificationLib
│   ├── EmotionClassificationLib.csproj
│   ├── Classifier.cs
│   └── RAVDESS
│       └── RAVDESSParser.cs
├── EmotionClassificationApp
│   ├── EmotionClassificationApp.csproj
│   └── Program.cs
├── EmotionClassificationApp.sln
└── README.md
```

## Getting Started

### Prerequisites

- .NET SDK (version 5.0 or higher)
- A compatible IDE or text editor (e.g., Visual Studio Code)

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   cd EmotionClassificationApp
   ```

2. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the Application

To run the console application, navigate to the `EmotionClassificationApp` directory and execute the following command:

```
dotnet run
```

### Usage

Upon running the application, you will be prompted to load the RAVDESS dataset. The application will then classify the emotions based on the audio files provided in the dataset.

### Library Overview

- **EmotionClassificationLib**: Contains the core functionality for emotion classification.
  - **Classifier.cs**: Implements methods for loading data, training the model, and predicting emotions.
  - **RAVDESS/RAVDESSParser.cs**: Handles parsing of RAVDESS audio files and extracting metadata.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License

This project is licensed under the MIT License - see the LICENSE file for details.