﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ericmas001.Diagrams.Models.Interfaces
{
    public interface IGraph
    {
        IEnumerable<IElementViewModel> Elements { get; }
        double Left { get; }
        double Right { get; }
        double Top { get; }
        double Bottom { get; }
        double Width { get; }
        double Height { get; }
    }
}