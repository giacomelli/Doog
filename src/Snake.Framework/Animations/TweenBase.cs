using System;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// A base classe for tweenings.
    /// </summary>
    public abstract class TweenBase : ComponentBase, ITween
    {
        public event EventHandler<TweenEndedEventArgs> Ended;

        private float playStartedTime;
        private float duration;

        protected TweenBase(float duration, IWorldContext context)
            : base(context)
        {
            this.duration = duration;
            Ease = LinearEase.Default;
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

        public virtual void Play()
        {
            playStartedTime = Context.Time.SinceSceneStart;
            State = TweenState.Playing;
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
        }

        public virtual void Reset()
        {
            Play();
        }

        public abstract void Reverse();

        public void Update()
        {
            if(State == TweenState.Playing)
            {
                var time = (Context.Time.SinceSceneStart - playStartedTime) / duration;

                if (time <= 1)
                {
                    UpdateValue(time);
                }
                else 
                {
                    Stop();
                    OnEnded(new TweenEndedEventArgs(this));
                }
            }
        }

        protected virtual void OnEnded(TweenEndedEventArgs args)
        {
            if(Ended != null)
            {
                Ended(this, args);
            }
        }

        protected abstract void UpdateValue(float time);
    }
}
