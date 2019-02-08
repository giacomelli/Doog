using System;
using System.IO;

namespace Doog
{
    /// <summary>
    /// A very basic file log system.
    /// </summary>
    public class FileLogSystem : LogSystemBase, IDisposable
    {
        private StreamWriter file;
        private bool disposedValue = false;

        public FileLogSystem(string filePath, IWorldContext context)
            : base(context)
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
