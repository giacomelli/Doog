using System.Text;

namespace Doog.Tests.Framework.Logging
{
    public class StubLogSystem : LogSystemBase
    {
        private StringBuilder m_builder = new StringBuilder();

        public StubLogSystem(IWorldContext context)
            : base(context)
        {

        }

        protected override void Write(string fullMessage)
        {
            m_builder.Append(fullMessage);
        }

        public override string ToString()
        {
            return m_builder.ToString();
        }
    }
}
