using System;

namespace Snake.Framework
{
    /// <summary>
    /// Defines an interface for time information of game.
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// Gets the time since the game started.
        /// </summary>
        TimeSpan SinceGameStart { get; }

        /// <summary>
        /// Gets the time since the current scene started.
        /// </summary>
        TimeSpan SinceSceneStart { get;  }
    }
}
