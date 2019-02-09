using System;
namespace Doog
{
    public interface ITransformable : IComponent
    {
        Transform Transform { get; }
    }
}
