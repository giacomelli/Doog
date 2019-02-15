using System;
using System.Collections.Generic;
using System.Text;

namespace Doog
{
    public static partial class PixelExtensions
    {
  //      public static IAnimationPipeline<IPixelable> ColorTo(this IPixelable owner, Color to, float duration, IEasing easing)
  //      {
  //          var animation = new PixelAnimation(owner, new Pixel(owner.Pixel.Char, to, to), duration)
  //          {
  //              Easing = easing
  //          };

  //          return AnimationPipeline<IPixelable>.Create(animation);
  //      }

  //      public static IAnimationPipeline<IPixelable> ColorTo(this IAnimationPipeline<IPixelable> pipeline, Color to, float duration, IEasing easing)
  //      {
  //          var owner = pipeline.Owner;
  //          var animation = new PixelAnimation(owner, new Pixel(owner.Pixel.Char, to, to), duration)
  //          {
  //              Easing = easing
  //          };

  //          pipeline.Add(animation);

  //          return pipeline;

  //      }

  //      public static IAnimationPipeline<IPixelable> ForegroundColorTo(this IPixelable owner, Color to, float duration, IEasing easing)
  //      {
  //          var animation = new PixelAnimation(owner, new Pixel(owner.Pixel.Char, to, owner.Pixel.BackgroundColor), duration)
  //          {
  //              Easing = easing
  //          };

  //          return AnimationPipeline<IPixelable>.Create(animation);
  //      }

		//public static IAnimationPipeline<IPixelable> ForegroundColorTo(this IAnimationPipeline<IPixelable> pipeline, Color to, float duration, IEasing easing)
  //      {
  //          var owner = pipeline.Owner;
  //          var animation = new PixelAnimation(owner, new Pixel(owner.Pixel.Char, to, owner.Pixel.BackgroundColor), duration)
  //          {
  //              Easing = easing
  //          };

  //          pipeline.Add(animation);

  //          return pipeline;
  //      }

        public static IAnimationPipeline<IPixelable> CharTo(this IPixelable owner, char[] chars, float duration, IEasing easing)
        {
            var animation = new PixelAnimation(owner, chars.Pixels(owner.Pixel) , duration)
            {
                Easing = easing
            };

            return AnimationPipeline<IPixelable>.Create(animation);
        }

        //public static IAnimationPipeline<IPixelable> CharTo(this IAnimationPipeline<IPixelable> pipeline, Color to, float duration, IEasing easing)
        //{
        //    var owner = pipeline.Owner;
        //    var animation = new PixelAnimation(owner, new Pixel(owner.Pixel.Char, to, owner.Pixel.BackgroundColor), duration)
        //    {
        //        Easing = easing
        //    };

        //    pipeline.Add(animation);

        //    return pipeline;
        //}
    }
}
