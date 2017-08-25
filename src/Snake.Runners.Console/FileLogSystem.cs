using System;
using System.IO;
using Snake.Framework.Logging;

namespace Snake.Runners.Console
{
    // TODO: move to a Framework.IO project.
    public class FileLogSystem : LogSystemBase, IDisposable
    {
        private StreamWriter file;
		private bool disposedValue = false;

		public FileLogSystem(string filePath)
        {
            file = File.CreateText(filePath);
            file.AutoFlush = true;
        }

        protected override void Write(string fullMessage)
        {
            file.WriteLine(fullMessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    file.Close();
                }
           
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
