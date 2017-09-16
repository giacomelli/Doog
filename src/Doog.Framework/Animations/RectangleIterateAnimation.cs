using System;
using Doog.Framework;

namespace Doog.Framework
{
    public class RectangleIterateAnimation<TOwner> : AnimationBase<TOwner, float>
        where TOwner : IComponent
    {
        Rectangle r;
        float x;
        float y;
        float dec;
        private readonly Action<float, float> callback;
        private Action<float> currentUpdateValue;
        private bool filled;

		public RectangleIterateAnimation(TOwner owner, Rectangle rectangle, bool filled, float duration, Action<float, float> callback)
            : this(owner, rectangle, rectangle.LeftTopPoint(), filled, duration, callback)
        {
            
        }

        public RectangleIterateAnimation(TOwner owner, Rectangle rectangle, Point fromPoint, bool filled, float duration, Action<float, float> callback)
            : base(owner, duration)
        {
            this.callback = callback;
            r = rectangle;
            this.filled = filled;
            From = 1f;
            To = filled ? r.Width * r.Height + r.Width : r.Width * 2 + r.Height * 2 - 2;
            x = fromPoint.X;
            y = fromPoint.Y;
            ChooseCurrentUpdateValue();
        }

        protected override void UpdateValue(float time)
        {
            currentUpdateValue(time);
        }

        private void UpdateValueForwardFilled(float time)
        {
            var v = Easing.Calculate(From, To, time);
            y = r.Top + v - dec;
          
            if (y >= r.Bottom)
            {
                dec = v;
                x++;
                y = r.Bottom;
            }

			callback(x, y);
		}

        private void UpdateValueBackward(float time)
        {
            var v = Easing.Calculate(To, From, time);
            y = r.Bottom - v + dec;
            callback(x, y);

            if (y < r.Top)
            {
                dec = v;
                x--;
            }
        }

        private void UpdateValueForwardNotFilled(float time)
        {
            var v = Easing.Calculate(From, To, time);

            if (y <= r.Top)
            {
                x = r.Left + v;

                if (x >= r.Right - 1)
                {
                    x = r.Right - 1;
                    y = r.Top + 1;
					dec = v;
				}
            }
            else if (x >= r.Right - 1)
            {
                y = r.Top + v - dec;

                if (y >= r.Bottom - 1)
                {
                    y = r.Bottom - 1;
                    x = r.Right - 2;
					dec = v;
				}
            }
            else if (y >= r.Bottom - 1)
            {
                x = r.Right - 1 - (v - dec);

                if (x <= r.Left)
                {
                    x = r.Left;
                    y = r.Bottom - 2;
					dec = v;
				}
            }
            else
            {
                y = r.Bottom - 2 - v + dec;

                if (y < r.Top)
                {
                    y = r.Top;
                }
            }

            callback(x, y);
        }

		private void UpdateValueBackwardNotFilled(float time)
		{
			var v = Easing.Calculate(To, From, time);

            if (x <= r.Left)
            {
                y = r.Top + v;

                if (y >= r.Bottom - 1)
                {
                    y = r.Bottom - 1;
                    x = r.Left + 1;
                    dec = v;
                }
            }
            else if (y >= r.Bottom - 1)
            {
                x = r.Left + v - dec;

                if (x >= r.Right - 1)
                {
                    x = r.Right - 1;
                    y = r.Bottom - 2;
                    dec = v;
                }
            }
            else if (x >= r.Right - 1)
            {
                y = r.Bottom - 2 - (v - dec);

                if (y <= r.Top)
                {
                    y = r.Top;
                    x = r.Right - 2;
                    dec = v;
                }
            }
            else 
            {
                x = r.Right - 2 - (v - dec);
            }
			
			callback(x, y);
		}

        private void ChooseCurrentUpdateValue()
        {
            if (filled)
            {
                currentUpdateValue = From <= To ? (Action<float>)UpdateValueForwardFilled : UpdateValueBackward;
            }
            else
            {
                currentUpdateValue = From <= To ? (Action<float>)UpdateValueForwardNotFilled : UpdateValueBackwardNotFilled;
            }
        }

        public override void Reset()
        {
            base.Reset();
            x = r.Left;
            y = r.Top;
        }

        public override void Reverse()
        {
            base.Reverse();

            dec = 0;

            if (From <= To)
            {
                x = r.Left;
                y = r.Top;
                ChooseCurrentUpdateValue();
            }
            else
            {
                if (filled)
                {
                    x = r.Right;
                    y = r.Bottom;
                }
                else
                {
					x = r.Left;
					y = r.Top;
                }
                ChooseCurrentUpdateValue();
            }
        }
    }
}
