using System;

namespace Snake.Framework
{
    public class Time : ITime
    {
        private DateTime? gameStartedTime;
        private DateTime? sceneStartedTime;

        internal Time()
        {
        }

        public TimeSpan SinceGameStart { get; private set; }
        public TimeSpan SinceSceneStart { get; private set; }

        public void Update(DateTime now)
        {
            if (gameStartedTime.HasValue)
            {
                SinceGameStart = now - gameStartedTime.Value;

                if (sceneStartedTime.HasValue)
                {
                    SinceSceneStart = now - sceneStartedTime.Value;
                }
            }
        }

        public void MarkAsGameStarted(DateTime now)
        {
            gameStartedTime = now;
        }

        public void MarkAsSceneStarted(DateTime now)
        {
            sceneStartedTime = now;
        }
    }
}
