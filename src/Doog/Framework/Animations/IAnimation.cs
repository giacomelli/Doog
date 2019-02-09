using System;

namespace Doog
{
	public enum AnimationState
	{
        NotPlayed = 0,
		Playing,
		Paused,
		Stopped
	}

    public enum AnimationDirection
    {
        Any = 0,
        Forward,
        Backward
    }

	public interface IAnimation
    {
		event EventHandler Started;
		event EventHandler Ended;

		AnimationState State { get; }
        AnimationDirection Direction { get; set; }
		IEasing Easing { get; set; }

		void Play();
		void Pause();
		void Resume();
		void Stop();
		void Reset();
		void Reverse();
	}

    public interface IAnimation<TComponent> : IAnimation
        where TComponent : IComponent
    {
        TComponent Owner { get; }
    }
}
