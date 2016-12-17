using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBeta.Controls
{
    /// <summary>
    /// IconButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconButton : UserControl
    {
        public IconButton()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconButton), new PropertyMetadata(string.Empty));




        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.Register("BackColor", typeof(Color), typeof(IconButton), new PropertyMetadata(Colors.LightGray));




        public Color ForeColor
        {
            get { return (Color)GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForeColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(Color), typeof(IconButton), new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnForeColorChangedCallback)));


        public static void OnForeColorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                var uc = d as IconButton;
                uc.lbl.Foreground = new SolidColorBrush((Color)e.NewValue);
            }
        }
        private ICommand _IconButtonClickedCommand;
        public ICommand IconButtonClickedCommand
        {
            get
            {
                if(_IconButtonClickedCommand==null)
                {
                    _IconButtonClickedCommand = new RelayCommand(OnIconButtonClickedCommandExecute);
                }
                return _IconButtonClickedCommand;
            }
        }
        public void OnIconButtonClickedCommandExecute()
        {
            if(BackColor==Color.)
        }
    }
}
