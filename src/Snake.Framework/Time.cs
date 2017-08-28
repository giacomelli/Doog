using System;

namespace Snake.Framework
{
    public class Time : ITime
    {
        private long? gameStartedTicks;
        private long? sceneStartedTicks;
        private long lastFrameTicks;

        internal Time()
        {
        }

        public float SinceGameStart { get; private set; }
        public float SinceSceneStart { get; private set; }
        public float SinceLastFrame { get; private set; }
        public DateTime Now { get; private set; }

        public void Update(DateTime now)
        {
            Now = now;
            var ticks = now.Ticks;

            if (gameStartedTicks.HasValue)
            {
                SinceGameStart = (float)(ticks - gameStartedTicks.Value) / TimeSpan.TicksPerSecond;

                if (sceneStartedTicks.HasValue)
                {
                    SinceSceneStart = (float)(ticks - sceneStartedTicks.Value) / TimeSpan.TicksPerSecond;
                }

                SinceLastFrame = (float)(ticks - lastFrameTicks) / TimeSpan.TicksPerSecond;
                lastFrameTicks = ticks;
            }
        }

        public void MarkAsGameStarted(DateTime now)
        {
            gameStartedTicks = now.Ticks;
            lastFrameTicks = gameStartedTicks.Value;
        }

        public void MarkAsSceneStarted(DateTime now)
        {
            sceneStartedTicks = now.Ticks;
        }
    }
}
