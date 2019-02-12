﻿using System;
using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// Represents an animation.
    /// </summary>
    [DebuggerDisplay("{Name}: {State}")]
    public abstract class AnimationBase<TComponent, TValue> : ComponentBase, IAnimation<TComponent>, IUpdatable
        where TComponent : IComponent
    {
        /// <summary>
        /// Occurs when animation started.
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// Occurs when animation ended.
        /// </summary>
        public event EventHandler Ended;

        private float playStartedTime;
        private float pauseStartedTime;
        private IEasing easing;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.AnimationBase`2"/> class.
        /// </summary>
        /// <param name="owner">The animation owner.</param>
        /// <param name="duration">The animation duration.</param>
        protected AnimationBase(TComponent owner, float duration)
            : base(owner.Context)
        {
            Owner = owner;
       
            this.Duration = duration;
            easing = Doog.Easing.Linear;
            owner.AddChild(this);
            State = AnimationState.NotPlayed;
            Direction = AnimationDirection.Any;
        }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public TComponent Owner { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public AnimationState State { get; private set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public AnimationDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the easing.
        /// </summary>
        /// <value>The easing.</value>
        public IEasing Easing
        {
            get
            {
                return easing;
            }

            set
            {
                easing = value ?? Doog.Easing.Linear;
            }
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>The duration.</value>
        protected float Duration { get; private set; }

        /// <summary>
        /// Gets or sets from (the value where animation starts).
        /// </summary>
        /// <value>From.</value>
		protected TValue From { get; set; }

        /// <summary>
        /// Gets or sets to (the value where animation ends).
        /// </summary>
        /// <value>To.</value>
        protected TValue To { get; set; }

        /// <inheritdoc />
        public virtual void Play()
        {
            if (State == AnimationState.NotPlayed || State == AnimationState.Stopped)
            {
                Log.Debug("{0}: play", this);

                playStartedTime = Context.Time.SinceSceneStart;
                State = AnimationState.Playing;

                OnStarted(EventArgs.Empty);
            }
        }

        /// <inheritdoc />
        public void Pause()
        {
            if (State == AnimationState.Playing)
            {
                Log.Debug("{0}: pause", this);
                pauseStartedTime = Context.Time.SinceSceneStart;
                State = AnimationState.Paused;
            }
        }

        /// <inheritdoc />
        public void Resume()
        {
            if (State == AnimationState.Paused)
            {
                Log.Debug("{0}: resume", this);
                playStartedTime = Context.Time.SinceSceneStart - (pauseStartedTime - playStartedTime);
                State = AnimationState.Playing;
            }
        }

        /// <inheritdoc />
        public void Stop()
        {
            if (State != AnimationState.NotPlayed)
            {
                Log.Debug("{0}: stop", this);
                State = AnimationState.Stopped;
            }
        }

        /// <inheritdoc />
        public virtual void Reset()
        {
            Log.Debug("{0}: reset", this);
            playStartedTime = 0;
            State = AnimationState.NotPlayed;
        }

        /// <inheritdoc />
        public virtual void Reverse()
        {
			var temp = From;
			From = To;
			To = temp;
        }
      
        /// <summary>
        /// Update the animation.
        /// </summary>
        public void Update()
        {
            if (State == AnimationState.Playing)
            {
                var elapsed = (Context.Time.SinceSceneStart - playStartedTime);

                if (elapsed < 0)
                {
                    return;
                }

                var time = elapsed / Duration;

                if (time <= 1)
                {
                    UpdateValue(time);
                }
                else
                {
                    UpdateValue(1);
                    Stop();
                    OnEnded(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Doog.AnimationBase`2"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Doog.AnimationBase`2"/>.</returns>
        public override string ToString()
        {
            return "{0}<{1}>({2}..{3} in {4}s)".With(
                GetType().Name.TrimEnd('`', '1'), 
                Owner.GetType().Name, 
                From, 
                To, 
                Duration);
        }

        /// <inheritdoc />
        protected override void OnEnabled()
        {
            Resume();
        }

        /// <inheritdoc />
        protected override void OnDisabled()
        {
            Pause();
        }

        /// <summary>
        /// Called when animation starts.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnStarted(EventArgs args)
        {
            Started?.Invoke(this, args);
        }

        /// <summary>
        /// Called when animation ends.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnEnded(EventArgs args)
        {
            Ended?.Invoke(this, args);
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">The animation time.</param>
        protected abstract void UpdateValue(float time);
    }
}
