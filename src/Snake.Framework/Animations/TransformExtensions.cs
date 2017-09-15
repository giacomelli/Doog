using Snake.Framework.Animations;
using Snake.Framework.Geometry;

/// <summary>
/// Transform extension methods.
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    /// Move the transfom between the from and to values using the duration and easing specified.
    /// </summary>
    /// <returns>The to.</returns>
    /// <param name="transform">Transform.</param>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="easing">Easing.</param>
    public static IAnimationPipeline<Transform> MoveTo(this Transform transform, float x, float y, float duration, IEasing easing = null)
    {
        return AnimationPipeline<Transform>.Create(CreateMoveToAnimation(transform, x, y, duration, easing));
    }

    /// <summary>
    /// Move the transfom between the from and to values using the duration and easing specified.
    /// </summary>
    /// <returns>The to.</returns>
    /// <param name="transform">Transform.</param>
    /// <param name="point">The point.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="easing">Easing.</param>
    public static IAnimationPipeline<Transform> MoveTo(this Transform transform, Point point, float duration, IEasing easing = null)
    {
        return transform.MoveTo(point.X, point.Y, duration, easing);
    }

    public static IAnimationPipeline<Transform> MoveTo(this IAnimationPipeline<Transform> pipeline, Point point, float duration, IEasing easing = null)
    {
        pipeline.Add(CreateMoveToAnimation(pipeline.Owner, point.X, point.Y, duration, easing));

        return pipeline;
    }

    public static IAnimationPipeline<Transform> MoveTo(this IAnimationPipeline<Transform> pipeline, float x, float y, float duration, IEasing easing = null)
    {
        return pipeline.MoveTo(new Point(x, y), duration, easing);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this Transform transform, float x, float y, float duration, IEasing easing = null)
    {
        return transform.ScaleTo(new Point(x, y), duration, easing);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this Transform transform, float scale, float duration, IEasing easing = null)
    {
        return transform.ScaleTo(new Point(scale), duration, easing);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this IAnimationPipeline<Transform> pipeline, float scale, float duration, IEasing easing = null)
    {
        return pipeline.ScaleTo(new Point(scale), duration, easing);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this Transform transform, Point to, float duration, IEasing easing = null)
    {
        var animation = new PointAnimation<Transform>(transform, t => t.Scale, to, duration, (v) =>
        {
            transform.Scale = v;
        });

        animation.Easing = easing;

        return AnimationPipeline<Transform>.Create(animation);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this IAnimationPipeline<Transform> pipeline, float x, float y, float duration, IEasing easing = null)
    {
        return pipeline.ScaleTo(new Point(x, y), duration, easing);
    }

    public static IAnimationPipeline<Transform> ScaleTo(this IAnimationPipeline<Transform> pipeline, Point to, float duration, IEasing easing = null)
    {
        var owner = pipeline.Owner;
        var animation = new PointAnimation<Transform>(owner, t => t.Scale, to, duration, (v) =>
        {
            owner.Scale = v;
        });

        animation.Easing = easing;
        pipeline.Add(animation);

        return pipeline;
    }

    public static IAnimationPipeline<Transform> RotateTo(this Transform owner, float rotation, float duration, IEasing easing = null)
    {
        var animation = new FloatAnimation<Transform>(owner, owner.Rotation, rotation, duration, (v) =>
	     {
	         owner.Rotation = v;
	     });

        animation.Easing = easing;

        return AnimationPipeline<Transform>.Create(animation);
    }

	public static IAnimationPipeline<Transform> RotateTo(this IAnimationPipeline<Transform> pipeline, float rotation, float duration, IEasing easing = null)
	{
        var owner = pipeline.Owner;

		var animation = new FloatAnimation<Transform>(owner, owner.Rotation, rotation, duration, (v) =>
		 {
			 owner.Rotation = v;
		 });

		animation.Easing = easing;

		pipeline.Add(animation);

        return pipeline;
	}

    private static IAnimation<Transform> CreateMoveToAnimation(Transform transform, float x, float y, float duration, IEasing easing = null)
    {
        var animation = new PositionAnimation(transform, new Point(x, y), duration);
        animation.Easing = easing;

        return animation;
    }
}

