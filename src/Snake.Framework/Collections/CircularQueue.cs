using System.Collections;
using System.Collections.Generic;

namespace Snake.Framework.Collections
{
    public class CircularQueue<TItem> : IEnumerable<TItem>
    {
        private readonly int m_capacity;
        private int m_nextItemIndex;
        private TItem[] m_buffer;

        public CircularQueue(int capacity)
        {
            m_capacity = capacity;
            m_buffer = new TItem[m_capacity];
            m_nextItemIndex = 0;
        }

        public void Add(TItem item)
        {
            m_buffer[m_nextItemIndex++] = item;
            if (m_nextItemIndex == m_capacity)
            {
                m_nextItemIndex = 0;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < m_capacity; i++)
            {
                m_buffer[i] = default(TItem);
            }

            m_nextItemIndex = 0;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return ((IEnumerable<TItem>)m_buffer).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TItem>)m_buffer).GetEnumerator();
        }
    }
}
