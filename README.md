## voice-emotion-detector

What is the emotion of the participant at this measure of time? No peeking!

## About this project

This project is an Emotional Classification application to demonstrate Emotional Toys that utilizes the RAVDESS dataset to classify emotions from audio files. It consists of a library for handling the emotion classification logic and a console application for user interaction.

## Project structure

```
Composition
├── App
│   ├── App.csproj
│   ├── Program.cs
|   └── recordings
├── Library
│   ├── EmotionClassification.csproj
|   ├── Interfaces
|        ├── IPlayer.cs
│        └── IRecorder.cs
|   ├── Players
|        ├── LinuxPlayer.cs
│        └── UnixPlayerBase.cs
│   ├── Classifier.cs
│   ├── LinuxRecorder.cs
│   ├── Parser.cs
│   ├── Player.cs
│   └── Recorder.cs
├── Compsoition.sln
└── README.md
```

## Getting started

### Prerequisites

- .NET SDK 9.0
- VSCode or terminal

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/Cartheur-Voice/voice-emotion-detector.git
   cd Composition
   ```

2. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the code

To run the console application, navigate to the `App` directory and execute the following command:

```
dotnet run
```

### Usage

Upon running the application, you will be prompted to load the RAVDESS dataset. The application will then classify the emotions based on the audio files provided in the dataset. It will be able to get the information from a live recording.

### Library Overview

- **EmotionClassification**: Contains the core functionality for emotion classification.
  - **Classifier.cs**: Implements methods for loading data, training the model, and predicting emotions.
  - **RAVDESS/RAVDESSParser.cs**: Handles parsing of RAVDESS audio files and extracting metadata.

### Utility

Planned as a part of demonstrating capabilities of Cartheur Research.