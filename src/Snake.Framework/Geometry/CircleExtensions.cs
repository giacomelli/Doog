using System;
using Snake.Framework.Geometry;

/// <summary>
/// Circle extension methods.
/// </summary>
public static class CircleExtensions
{
    // http://www.mathopenref.com/coordcirclealgorithm.html
    public static void Iterate(this ICircle circle, Action<float, float> step, float radiusStep = 1f, float degreesStepSize = 1f)
    {
        if (radiusStep <= 0) 
        {
            throw new ArgumentOutOfRangeException("radiusStep", "radiusStep should be a non-zero positive value.");
        }

		if (degreesStepSize <= 0)
		{
			throw new ArgumentOutOfRangeException("degreesStepSize", "radiusStep should be a non-zero positive value.");
		}

        var center = circle.GetCenter();
		var h = center.X;      // x coordinate of circle center
		var k = center.Y;      // y coordinate of circle center
		var x = 0f;
		var y = 0f;

		for (var r = circle.Radius; r > 0; r -= radiusStep)
        { 
	        for (var theta = 0f; theta < 360f; theta += degreesStepSize)
	        {
	            x = h + r * (float)Math.Cos(theta);
	            y = k + r * (float)Math.Sin(theta);

	            step(x, y);
	        }
		}

	}
}

