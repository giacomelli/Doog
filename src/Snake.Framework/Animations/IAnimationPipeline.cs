using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Framework.Animations
{
	public enum PipelineKind
	{
		Once = 0,
		Loop,
		PingPong
	}

	public interface IAnimationPipeline<TOwner>
		where TOwner : IComponent
	{
		TOwner Owner { get;  }

        void Add(IAnimation<TOwner> animation);
        IAnimationPipelineController Once();
        IAnimationPipelineController PingPong();
        IAnimationPipelineController Loop();
	}
}
