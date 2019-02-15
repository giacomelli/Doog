using System;

namespace Doog
{
    /// <summary>
    /// The default ITime's implementation.
    /// </summary>
    /// <seealso cref="Doog.ITime" />
    public class Time : ITime
    {
        private long? _gameStartedTicks;
        private long? _sceneStartedTicks;
        private long _lastFrameTicks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        internal Time()
        {
        }

        /// <summary>
        /// Gets the time in seconds since the game started.
        /// </summary>
        public float SinceGameStart { get; private set; }

        /// <summary>
        /// Gets the time in seconds since the current scene started.
        /// </summary>
        public float SinceSceneStart { get; private set; }

        /// <summary>
        /// Gets the time in seconds since last frame.
        /// </summary>
        public float SinceLastFrame { get; private set; }

        /// <summary>
        /// Gets the DateTime of the real world on the start of current update.
        /// </summary>
        public DateTime Now { get; private set; }

        /// <summary>
        /// Updates the specified now.
        /// </summary>
        /// <param name="now">The now.</param>
        public void Update(DateTime now)
        {
            Now = now;
            var ticks = now.Ticks;

            if (ticks != _lastFrameTicks && _gameStartedTicks.HasValue)
            {
                SinceGameStart = (float)(ticks - _gameStartedTicks.Value) / TimeSpan.TicksPerSecond;

                if (_sceneStartedTicks.HasValue)
                {
                    SinceSceneStart = (float)(ticks - _sceneStartedTicks.Value) / TimeSpan.TicksPerSecond;
                }

                SinceLastFrame = (float)(ticks - _lastFrameTicks) / TimeSpan.TicksPerSecond;
                _lastFrameTicks = ticks;
            }
        }

        /// <summary>
        /// Marks as game started.
        /// </summary>
        /// <param name="now">The now.</param>
        public void MarkAsGameStarted(DateTime now)
        {
            _gameStartedTicks = now.Ticks;
            _lastFrameTicks = _gameStartedTicks.Value;
        }

        /// <summary>
        /// Marks as scene started.
        /// </summary>
        /// <param name="now">The now.</param>
        public void MarkAsSceneStarted(DateTime now)
        {
            _sceneStartedTicks = now.Ticks;
        }
    }
}
