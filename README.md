## voice-emotion-detector

What is the emotion of the participant at this measure of time?

## About

This project is an _emotional classification_ example to illustrate the sophistication of an _Emotional Toys_ product that trains upon an audio-only RAVDESS dataset leveraging machine learning to classify the emotions of the person sitting-at the microphone. It consists of a classifier algorithm library and a console application - it is easily convertible to a Test.

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

1. Clone the repository
   ```
   git clone https://github.com/Cartheur-Voice/voice-emotion-detector.git
   cd Composition
   ```

2. Restore the dependencies
   ```
   dotnet restore
   ```

### Running the code

To run the console application, navigate to the `App` directory and execute the following command

```
dotnet run
```

### Behaviour

The application will train on the local RAVDESS dataset and predict the participant (you) emotion based upon a sampled-input at the microphone, printing it to the terminal. The length of the recording is set on line 19 of `Program.cs`. A future version will load a configuration file.

### Utility

Manifest as a part of capabilities demonstration by the team at Cartheur Research.

#### Errata

Ensure that Nuget Microsoft.ML package is installed _first_ before the Accord packages, should `dotnet restore` fail.