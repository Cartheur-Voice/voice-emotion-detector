using System;
using System.IO;
using System.Threading.Tasks;
using Cartheur.Presents.Interfaces;
using Cartheur.Presents.Players;

namespace Cartheur.Presents
{
    internal class LinuxRecorder : UnixPlayerBase, IRecorder
    {
        protected override string GetBashCommand(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower().Equals(".wav"))
            {
                return "mpg123 -q";
            }
            else
            {
                return "arecord -q -fdat -d 5";
            }
        }
        protected override string BashCommandRecording(string fileName, int duration)
        {
            return "arecord -q -fdat -d " + duration.ToString();
        }

        public override Task SetVolume(byte percent)
        {
            if (percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent can't exceed 100");

            var tempProcess = StartBashProcess($"amixer -M set 'Master' {percent}%");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }
    }
}
