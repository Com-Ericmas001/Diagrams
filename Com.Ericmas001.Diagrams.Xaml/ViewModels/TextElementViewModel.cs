using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Xaml.ViewModels
{
    public class TextElementViewModel : ViewModelBase, IElementViewModel
    {
        private string m_Text = string.Empty;
        private string m_Color = "Black";
        private float m_TextSize = 12;
        private string m_TextFamily = "Arial";
        public IElement Element { get; set; }

        public FormattedText FormattedText => new FormattedText(
            Text, 
            new CultureInfo("en-us"),
            FlowDirection.LeftToRight,
            new Typeface(
                new FontFamily(TextFamily),
                FontStyles.Normal,
                FontWeights.Bold,
                new FontStretch()),
            TextSize,
            Brushes.Black){TextAlignment = TextAlignment.Center};

        public float TextSize
        {
            get => m_TextSize;
            set => Set(ref m_TextSize, value);
        }
        public string Text
        {
            get => m_Text;
            set => Set(ref m_Text, value);
        }

        public string TextFamily
        {
            get => m_TextFamily;
            set => Set(ref m_TextFamily, value);
        }

        public string Color
        {
            get => m_Color;
            set => Set(ref m_Color, value);
        }
    }
}
