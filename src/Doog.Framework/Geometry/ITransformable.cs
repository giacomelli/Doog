using System;
namespace Doog.Framework
{
    public interface ITransformable : IComponent
    {
        Transform Transform { get; }
    }
}
