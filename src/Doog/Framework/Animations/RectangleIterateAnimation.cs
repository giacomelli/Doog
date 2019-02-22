using System;

namespace Doog
{
    /// <summary>
    /// Rectangle iterate animation.
    /// </summary>
    public class RectangleIterateAnimation<TOwner> : AnimationBase<TOwner, float>
        where TOwner : IComponent
    {
        readonly Rectangle _rect;
        float _x;
        float _y;
        float dec;
        private readonly Action<float, float> _callback;
        private Action<float> _currentUpdateValue;
        readonly private bool _filled;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.RectangleIterateAnimation`1"/> class.
        /// </summary>
        /// <param name="owner">Owner.</param>
        /// <param name="rectangle">Rectangle.</param>
        /// <param name="filled">If set to <c>true</c> filled.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="callback">Callback.</param>
		public RectangleIterateAnimation(TOwner owner, Rectangle rectangle, bool filled, float duration, Action<float, float> callback)
            : this(owner, rectangle, rectangle.LeftTopPoint(), filled, duration, callback)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Doog.RectangleIterateAnimation`1"/> class.
        /// </summary>
        /// <param name="owner">Owner.</param>
        /// <param name="rectangle">Rectangle.</param>
        /// <param name="fromPoint">From point.</param>
        /// <param name="filled">If set to <c>true</c> filled.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="callback">Callback.</param>
        public RectangleIterateAnimation(TOwner owner, Rectangle rectangle, Point fromPoint, bool filled, float duration, Action<float, float> callback)
            : base(owner, duration)
        {
            this._callback = callback;
            _rect = rectangle;
            this._filled = filled;
            From = 1f;
            To = filled ? _rect.Width * _rect.Height + _rect.Width : _rect.Width * 2 + _rect.Height * 2 - 2;
            _x = fromPoint.X;
            _y = fromPoint.Y;
            ChooseCurrentUpdateValue();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="time">Time.</param>
        protected override void UpdateValue(float time)
        {
            _currentUpdateValue(time);
        }

        private void UpdateValueForwardFilled(float time)
        {
            var v = Easing.Calculate(From, To, time);
            _y = _rect.Top + v - dec;
          
            if (_y >= _rect.Bottom)
            {
                dec = v;
                _x++;
                _y = _rect.Bottom;
            }

			_callback(_x, _y);
		}

        private void UpdateValueBackward(float time)
        {
            var v = Easing.Calculate(To, From, time);
            _y = _rect.Bottom - v + dec;
            _callback(_x, _y);

            if (_y < _rect.Top)
            {
                dec = v;
                _x--;
            }
        }

        private void UpdateValueForwardNotFilled(float time)
        {
            var v = Easing.Calculate(From, To, time);

            if (_y <= _rect.Top)
            {
                _x = _rect.Left + v;

                if (_x >= _rect.Right - 1)
                {
                    _x = _rect.Right - 1;
                    _y = _rect.Top + 1;
					dec = v;
				}
            }
            else if (_x >= _rect.Right - 1)
            {
                _y = _rect.Top + v - dec;

                if (_y >= _rect.Bottom - 1)
                {
                    _y = _rect.Bottom - 1;
                    _x = _rect.Right - 2;
					dec = v;
				}
            }
            else if (_y >= _rect.Bottom - 1)
            {
                _x = _rect.Right - 1 - (v - dec);

                if (_x <= _rect.Left)
                {
                    _x = _rect.Left;
                    _y = _rect.Bottom - 2;
					dec = v;
				}
            }
            else
            {
                _y = _rect.Bottom - 2 - v + dec;

                if (_y < _rect.Top)
                {
                    _y = _rect.Top;
                }
            }

            _callback(_x, _y);
        }

		private void UpdateValueBackwardNotFilled(float time)
		{
			var v = Easing.Calculate(To, From, time);

            if (_x <= _rect.Left)
            {
                _y = _rect.Top + v;

                if (_y >= _rect.Bottom - 1)
                {
                    _y = _rect.Bottom - 1;
                    _x = _rect.Left + 1;
                    dec = v;
                }
            }
            else if (_y >= _rect.Bottom - 1)
            {
                _x = _rect.Left + v - dec;

                if (_x >= _rect.Right - 1)
                {
                    _x = _rect.Right - 1;
                    _y = _rect.Bottom - 2;
                    dec = v;
                }
            }
            else if (_x >= _rect.Right - 1)
            {
                _y = _rect.Bottom - 2 - (v - dec);

                if (_y <= _rect.Top)
                {
                    _y = _rect.Top;
                    _x = _rect.Right - 2;
                    dec = v;
                }
            }
            else 
            {
                _x = _rect.Right - 2 - (v - dec);
            }
			
			_callback(_x, _y);
		}

        private void ChooseCurrentUpdateValue()
        {
            if (_filled)
            {
                _currentUpdateValue = From <= To ? (Action<float>)UpdateValueForwardFilled : UpdateValueBackward;
            }
            else
            {
                _currentUpdateValue = From <= To ? (Action<float>)UpdateValueForwardNotFilled : UpdateValueBackwardNotFilled;
            }
        }

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            _x = _rect.Left;
            _y = _rect.Top;
        }

        /// <summary>
        /// Reverse the animation.
        /// </summary>
        public override void Reverse()
        {
            base.Reverse();

            dec = 0;

            if (From <= To)
            {
                _x = _rect.Left;
                _y = _rect.Top;
                ChooseCurrentUpdateValue();
            }
            else
            {
                if (_filled)
                {
                    _x = _rect.Right;
                    _y = _rect.Bottom;
                }
                else
                {
					_x = _rect.Left;
					_y = _rect.Top;
                }
                ChooseCurrentUpdateValue();
            }
        }
    }
}
