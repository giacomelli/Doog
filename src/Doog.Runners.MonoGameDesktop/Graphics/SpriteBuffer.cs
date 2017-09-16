namespace Doog.Runners.MonoGameDesktop.Graphics
{
    public class SpriteBuffer
    {
        private readonly int m_capacity;
        private readonly SpriteBufferItem[] m_buffer;
        private int m_headIndex;

        public SpriteBuffer(int capacity)
        {
            m_capacity = capacity;
            m_headIndex = 0;
            m_buffer = new SpriteBufferItem[m_capacity];
        }

        public int Length
        {
            get
            {
                return m_headIndex;
            }
        }

        public SpriteBufferItem this[int index]
        {
            get { return m_buffer[index]; }
        }

        public void Add(float x, float y, char content)
        {
            m_buffer[m_headIndex++] = new SpriteBufferItem(x, y, content);
            if (m_headIndex >= m_capacity - 1)
            {
                Clear();
            }
        }

        public void Clear()
        {
            m_headIndex = 0;
        }
    }
}
