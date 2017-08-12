using System;

namespace Snake.Framework
{
    public class Time : ITime
    {
        private long? gameStartedTicks;
        private long? sceneStartedTicks;

        internal Time()
        {
        }

        public float SinceGameStart { get; private set; }
        public float SinceSceneStart { get; private set; }

        public void Update(DateTime now)
        {
            if (gameStartedTicks.HasValue)
            {
                SinceGameStart = (now.Ticks - gameStartedTicks.Value) / TimeSpan.TicksPerSecond;

                if (sceneStartedTicks.HasValue)
                {
                    SinceSceneStart = (now.Ticks - sceneStartedTicks.Value) / TimeSpan.TicksPerSecond;
                }
            }
        }

        public void MarkAsGameStarted(DateTime now)
        {
            gameStartedTicks = now.Ticks;
        }

        public void MarkAsSceneStarted(DateTime now)
        {
            sceneStartedTicks = now.Ticks;
        }
    }
}
