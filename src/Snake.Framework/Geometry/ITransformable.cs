using System;
namespace Snake.Framework.Geometry
{
    public interface ITransformable : IComponent
    {
        Transform Transform { get; }
    }
}
