using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Com.Ericmas001.Diagrams.Xaml.Shapes
{
    public class TextShape : Shape
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", typeof(string), typeof(TextShape),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register(
                "Foreground", typeof(Color), typeof(TextShape),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Color Foreground
        {
            get => (Color)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty TextSizeProperty =
            DependencyProperty.Register(
                "TextSize", typeof(float), typeof(TextShape),
                new FrameworkPropertyMetadata(
                    12f,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public float TextSize
        {
            get => (float)GetValue(TextSizeProperty);
            set => SetValue(TextSizeProperty, value);
        }

        public static readonly DependencyProperty TextFamilyProperty =
            DependencyProperty.Register(
                "TextFamily", typeof(string), typeof(TextShape),
                new FrameworkPropertyMetadata(
                    "Arial",
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string TextFamily
        {
            get => (string)GetValue(TextFamilyProperty);
            set => SetValue(TextFamilyProperty, value);
        }

        protected override Geometry DefiningGeometry => Geometry.Empty;

        public override void EndInit()
        {
            ((INotifyPropertyChanged)DataContext).PropertyChanged += (sender, args) => InvalidateVisual();
        }

        protected override void OnRender
            (DrawingContext drawingContext)
        {
            FormattedText ft = new FormattedText
            (Text, new CultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(
                    new FontFamily(TextFamily),
                    FontStyles.Normal,
                    FontWeights.Bold,
                    new FontStretch()),
                TextSize,
                new SolidColorBrush(Foreground))
                { TextAlignment = TextAlignment.Center };
            drawingContext.DrawText
                (ft, new Point(0, 0));
            //base.OnRender(drawingContext);
        }
    }
}
