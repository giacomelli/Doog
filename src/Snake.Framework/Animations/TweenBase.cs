using System;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A base classe for tweenings.
    /// </summary>
    public abstract class TweenBase : ComponentBase, ITween
    {
        public event EventHandler Started;
        public event EventHandler Ended;

        private float playStartedTime;
        private float duration;
        private float originalDelay;

        protected TweenBase(float duration, IWorldContext context)
            : base(context)
        {
            this.duration = duration;
            Ease = Easing.Linear;
        }

        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;

                if(value)
                {
                    Resume();
                }
                else 
                {
                    Pause();   
                }
            }
        }

        public TweenState State { get; private set; }
        public IEase Ease { get; set; }
        public float Delay { get; set; }

        public virtual void Play()
        {
            originalDelay = Delay;
            playStartedTime = Context.Time.SinceSceneStart;
            State = TweenState.Playing;

            OnStarted(EventArgs.Empty);
        }

        public void Pause()
        {
            State = TweenState.Paused;
        }

        public void Resume()
        {
            State = TweenState.Playing;
        }

        public void Stop()
        {
            State = TweenState.Stopped;
            Delay = 0;
        }

        public virtual void Reset()
        {
            Delay = originalDelay;
            Play();
        }

        public abstract void Reverse();

        public void Update()
        {
            if(State == TweenState.Playing)
            {
                var elapsed = (Context.Time.SinceSceneStart - playStartedTime) - Delay;

                if(elapsed < 0)
                {
                    return;
                }

                var time = elapsed  / duration;

                if (time <= 1)
                {
                    UpdateValue(time);
                }
                else 
                {
                    Stop();
                    OnEnded(EventArgs.Empty);
                }
            }
        }

		protected virtual void OnStarted(EventArgs args)
		{
			if (Started != null)
			{
				Started(this, args);
			}
		}

        protected virtual void OnEnded(EventArgs args)
        {
            if(Ended != null)
            {
                Ended(this, args);
            }
        }

        protected abstract void UpdateValue(float time);
    }
}
