using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Custom.Controls.RangeSlider
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SliderControl : UserControl, INotifyPropertyChanged
    {
        public SliderControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Maximum
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(SliderControl), new FrameworkPropertyMetadata(1.0));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        #endregion

        #region Minimum
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(SliderControl), new FrameworkPropertyMetadata(0.0));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        #endregion

        #region LowerValue
        public static readonly DependencyProperty LowerValueProperty = DependencyProperty.Register("LowerValue", typeof(double), typeof(SliderControl), new FrameworkPropertyMetadata(0.0));

        public double LowerValue
        {
            get { return (double)GetValue(LowerValueProperty); }
            set { SetValue(LowerValueProperty, value); }
        }
        #endregion

        #region UpperValue
        public static readonly DependencyProperty UpperValueProperty = DependencyProperty.Register("UpperValue", typeof(double), typeof(SliderControl), new FrameworkPropertyMetadata(0.0));
        public double UpperValue
        {
            get { return (double)GetValue(UpperValueProperty); }
            set { SetValue(UpperValueProperty, value); }
        }
        #endregion

        #region Delta
        public static readonly DependencyProperty DeltaProperty = DependencyProperty.Register("Delta", typeof(double), typeof(SliderControl), new PropertyMetadata(0.0));
        public double Delta
        {
            get { return (double)GetValue(DeltaProperty); }
            set { SetValue(DeltaProperty, value); }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LowerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var s = sender as Slider;
            var lim = UpperValue - Delta;
            if (s != null)
            {
                if (s.Value >= lim)
                {
                    s.Value = lim;
                }
            }
        }

        private void UpperSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var s = sender as Slider;
            var lim = LowerValue + Delta;
            if (s != null)
            {
                if (s.Value <= lim)
                {
                    s.Value = lim;
                }
            }
        }
    }
}
