using System;

namespace Snake.Framework
{
    /// <summary>
    /// Defines an interface for time information of game.
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// Gets the time in seconds since the game started.
        /// </summary>
        float SinceGameStart { get; }

        /// <summary>
        /// Gets the time in seconds since the current scene started.
        /// </summary>
        float SinceSceneStart { get;  }
    }
}
