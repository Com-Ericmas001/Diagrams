﻿using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;

namespace Com.Ericmas001.Diagrams.Xaml.Models
{
    public class TextElement : IElement
    {
        public string Text { get; }
        public IElementViewModel ElementViewModel { get; }
        public double Left { get; }
        public double Top { get; }
        public double Right => Left + Width;
        public double Bottom => Top + Height;
        public double Width => ((TextElementViewModel)ElementViewModel).FormattedText.Width;
        public double Height => ((TextElementViewModel) ElementViewModel).FormattedText.Height;

        public TextElement(string text, double left, double top, IElementViewModel viewModel)
        {
            Left = left;
            Top = top;
            Text = text;
            ElementViewModel = viewModel;
            ElementViewModel.Element = this;
        }
    }
}