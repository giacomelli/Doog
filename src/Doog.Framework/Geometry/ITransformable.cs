using System;
namespace Doog.Framework.Geometry
{
    public interface ITransformable : IComponent
    {
        Transform Transform { get; }
    }
}
