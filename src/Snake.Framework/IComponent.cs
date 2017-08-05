using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework
{
    public interface IComponent
    {
        bool Enabled { get; set; }
		string Tag { get; }
    }
}
