using System;

namespace Doog
{
    /// <summary>
    /// Animation state.
    /// </summary>
	public enum AnimationState
	{
        /// <summary>
        /// Anination not played.
        /// </summary>
        NotPlayed = 0,

        /// <summary>
        /// Animations is playing.
        /// </summary>
		Playing,

        /// <summary>
        /// Animation is paused.
        /// </summary>
		Paused,

        /// <summary>
        /// Animation is stopped.
        /// </summary>
		Stopped
	}

    /// <summary>
    /// Animation direction.
    /// </summary>
    public enum AnimationDirection
    {
        /// <summary>
        /// Any animation direction.
        /// </summary>
        Any = 0,

        /// <summary>
        /// Forward animation direction.
        /// </summary>
        Forward,

        /// <summary>
        /// Backward animation direction.
        /// </summary>
        Backward
    }

    /// <summary>
    /// Defines an interface for an animation.
    /// </summary>
	public interface IAnimation
    {
        /// <summary>
        /// Occurs when animation started.
        /// </summary>
		event EventHandler Started;

        /// <summary>
        /// Occurs when animation ended.
        /// </summary>
		event EventHandler Ended;

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
		AnimationState State { get; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        AnimationDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the easing.
        /// </summary>
        /// <value>The easing.</value>
		IEasing Easing { get; set; }

        /// <summary>
        /// Play the animation.
        /// </summary>
		void Play();

        /// <summary>
        /// Pause the animation.
        /// </summary>
		void Pause();

        /// <summary>
        /// Resume the animation.
        /// </summary>
		void Resume();

        /// <summary>
        /// Stop the animation.
        /// </summary>
		void Stop();

        /// <summary>
        /// Reset the animation.
        /// </summary>
		void Reset();

        /// <summary>
        /// Reverse the animation.
        /// </summary>
		void Reverse();
	}

    /// <summary>
    /// Defines an interface for an generic animation.
    /// </summary>
    public interface IAnimation<out TComponent> : IAnimation
        where TComponent : IComponent
    {
        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
        TComponent Owner { get; }
    }
}
