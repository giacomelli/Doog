using System;

namespace Doog.Samples
{
    public class SamplesWorld : World
    {
        public override void Initialize(IGraphicSystem graphicSystem, IPhysicSystem physicSystem, ITextSystem textSystem, IInputSystem inputSystem, Action exitAction)
        {
            base.Initialize(graphicSystem, physicSystem, textSystem, inputSystem, exitAction);

            this.OpenScene<MainScene>();
        }
    }
}
