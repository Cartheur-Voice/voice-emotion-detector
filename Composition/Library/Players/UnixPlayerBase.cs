using Cartheur.Presents.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cartheur.Presents.Players
{
    internal abstract class UnixPlayerBase : IPlayer, IRecorder
    {
        private Process _process = null;

        internal const string PauseProcessCommand = "kill -STOP {0}";
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        public event EventHandler PlaybackFinished;
        public event EventHandler RecordingFinished;

        public bool Playing { get; private set; }
        public bool Recording { get; private set; }

        public bool Paused { get; private set; }

        protected abstract string GetBashCommand(string fileName);
        protected abstract string BashCommandRecording(string fileName, int duration);

        public async Task Record(string filePath, int duration)
        {
            await Stop();
            var BashToolName = BashCommandRecording(filePath, duration);
            _process = StartBashProcess($"{BashToolName} '{filePath}'");
            _process.EnableRaisingEvents = true;
            _process.Exited += HandleRecordingFinished;
            _process.ErrorDataReceived += HandleRecordingFinished;
            _process.Disposed += HandleRecordingFinished;
            Recording = true;
        }

        public async Task Play(string fileName)
        {
            await Stop();
            var BashToolName = GetBashCommand(fileName);
            _process = StartBashProcess($"{BashToolName} '{fileName}'");
            _process.EnableRaisingEvents = true;
            _process.Exited += HandlePlaybackFinished;
            _process.ErrorDataReceived += HandlePlaybackFinished;
            _process.Disposed += HandlePlaybackFinished;
            Playing = true;
        }

        public Task Pause()
        {
            if (Playing && !Paused && _process != null)
            {
                var tempProcess = StartBashProcess(string.Format(PauseProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = true;
            }

            return Task.CompletedTask;
        }

        public Task Resume()
        {
            if (Playing && Paused && _process != null)
            {
                var tempProcess = StartBashProcess(string.Format(ResumeProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = false;
            }

            return Task.CompletedTask;
        }

        public Task Stop()
        {
            if (_process != null)
            {
                _process.Kill();
                _process.Dispose();
                _process = null;
            }

            Playing = false;
            Paused = false;

            return Task.CompletedTask;
        }

        protected Process StartBashProcess(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            return process;
        }

        internal void HandlePlaybackFinished(object sender, EventArgs e)
        {
            if (Playing)
            {
                Playing = false;
                PlaybackFinished?.Invoke(this, e);
            }
        }
        internal void HandleRecordingFinished(object sender, EventArgs e)
        {
            if (Recording)
            {
                Recording = false;
                RecordingFinished?.Invoke(this, e);
            }
        }

        public abstract Task SetVolume(byte percent);
    }
}
