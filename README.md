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
│        └── recorded.wav
├── Library
│   ├── EmotionClassification.csproj
|   ├── Interfaces
|        ├── IPlayer.cs
│        └── IRecorder.cs
|   └── Players
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

### Behaviour

The application will train on the local RAVDESS dataset and predict the participant (you) emotion based upon a samled-input at the microphone, printing it to the terminal. The length of the recording is `1s`, hardcoded presently. A future version will load a configuration file for initialized parameters.

### Utility

Manifest as a part of capabilities demonstration by the team at Cartheur Research.