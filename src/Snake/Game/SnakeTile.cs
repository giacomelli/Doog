using System;
using System.Collections;
using System.Collections.Generic;

namespace Snake.Game
{
    public class SnakeTile : IEnumerable<SnakeTile>, IEnumerator<SnakeTile>
    {
        private SnakeTile enumeratorCurrent;

        public int X { get; set; }

        public int Y { get; set; }

        public SnakeTile Next { get; set; }

        public SnakeTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void CopyPosition(SnakeTile other)
        {
            X = other.X;
            Y = other.Y;
        }

        public IEnumerator<SnakeTile> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            if (enumeratorCurrent == null)
            {
                enumeratorCurrent = this;
            }
            else
            {
                enumeratorCurrent = enumeratorCurrent.Next;
            }

            return enumeratorCurrent.Next != null;
        }

        SnakeTile IEnumerator<SnakeTile>.Current
        {
            get
            {
                return enumeratorCurrent;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return enumeratorCurrent;
            }
        }

        void IEnumerator.Reset()
        {
            enumeratorCurrent = this;
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    enumeratorCurrent = null;
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SnakeTile() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}