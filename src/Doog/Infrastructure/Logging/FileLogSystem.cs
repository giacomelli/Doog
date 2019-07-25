using System;
using System.IO;

namespace Doog
{
    /// <summary>
    /// A very basic file log system.
    /// </summary>
    public class FileLogSystem : LogSystemBase, IDisposable
    {
        private readonly StreamWriter _file;
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogSystem"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="context">The context.</param>
        public FileLogSystem(string filePath, IWorldContext context)
            : base(context)
        {
            _file = File.CreateText(filePath);
            _file.AutoFlush = true;
        }

        /// <summary>
        /// Writes the specified full message.
        /// </summary>
        /// <param name="fullMessage">The full message.</param>
        protected override void Write(string fullMessage)
        {
            _file.WriteLine(fullMessage);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _file.Close();
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
