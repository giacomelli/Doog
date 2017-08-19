using System;
using System.IO;
using Snake.Framework.Logging;

namespace Snake.Runners.Console
{
    // TODO: move to a Framework.IO project.
    public class FileLogSystem : LogSystemBase, IDisposable
    {
        private StreamWriter m_file;
		private bool disposedValue = false;

		public FileLogSystem(string filePath)
        {
            m_file = File.CreateText(filePath);
            m_file.AutoFlush = true;
        }

        protected override void Write(string fullMessage)
        {
            m_file.WriteLine(fullMessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    m_file.Close();
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
