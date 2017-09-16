using System;

namespace Doog.Framework
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

        /// <summary>
        /// Gets the time in seconds since last frame.
        /// </summary>
        float SinceLastFrame { get; }

        /// <summary>
        /// Gets the DateTime of the real world on the start of current update.
        /// </summary>
        DateTime Now { get; }
    }
}
