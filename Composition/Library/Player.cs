﻿using Cartheur.Presents.Interfaces;
using Cartheur.Presents.Players;
using System;
using System.Threading.Tasks;

namespace Cartheur.Presents
{
    /// <summary>
    /// The main class to handle playing audio files.
    /// </summary>
    /// <seealso cref="Cartheur.Presents.Interfaces.IPlayer" />
    public class Player : IPlayer
    {
        private readonly IPlayer _internalPlayer;
        /// <summary>
        /// Internally, sets Playing flag to false. Additional handlers can be attached to it to handle any custom logic.
        /// </summary>
        public event EventHandler PlaybackFinished;
        /// <summary>
        /// Indicates that the audio is currently playing.
        /// </summary>
        public bool Playing => _internalPlayer.Playing;
        /// <summary>
        /// Indicates that the audio playback is currently paused.
        /// </summary>
        public bool Paused => _internalPlayer.Paused;
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <exception cref="System.Exception">No implementation exist for the current OS</exception>
        public Player()
        {
             _internalPlayer = new LinuxPlayer();
            _internalPlayer.PlaybackFinished += OnPlaybackFinished;
        }
        /// <summary>
        /// Will stop any current playback and will start playing the specified audio file. The fileName parameter can be an absolute path or a path relative to the directory where the library is located. Sets Playing flag to true. Sets Paused flag to false.
        /// </summary>
        /// <param name="fileName"></param>
        public async Task Play(string fileName)
        {
            await _internalPlayer.Play(fileName);
        }
        /// <summary>
        /// Pauses any ongong playback. Sets Paused flag to true. Doesn't modify Playing flag.
        /// </summary>
        public async Task Pause()
        {
            await _internalPlayer.Pause();
        }
        /// <summary>
        /// Resumes any paused playback. Sets Paused flag to false. Doesn't modify Playing flag.
        /// </summary>
        public async Task Resume()
        {
            await _internalPlayer.Resume();
        }
        /// <summary>
        /// Stops any current playback and clears the buffer. Sets Playing and Paused flags to false.
        /// </summary>
        public async Task Stop()
        {
            await _internalPlayer.Stop();
        }
        private void OnPlaybackFinished(object sender, EventArgs e)
        {
            PlaybackFinished?.Invoke(this, e);
        }
        /// <summary>
        /// Sets the playing volume as percent
        /// </summary>
        public async Task SetVolume(byte percent)
        {
            await _internalPlayer.SetVolume(percent);
        }
    }
}
