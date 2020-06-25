using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for TextBoxLogin.xaml
    /// </summary>
    public partial class TextBoxLogin : UserControl
    {
        public TextBoxLogin()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        public static readonly RoutedEvent TextChangedEvent =
               EventManager.RegisterRoutedEvent("TabItemSelected",
               RoutingStrategy.Bubble, typeof(RoutedEventHandler),
               typeof(TextBoxLogin));

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register(
               "Text",
               typeof(string),
               typeof(TextBoxLogin),
               new FrameworkPropertyMetadata(null)
           );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        void RaiseTextChanged()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(TextBoxLogin.TextChangedEvent);
            RaiseEvent(newEventArgs);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox))
                return;

            TextBox box = (TextBox)sender;

            if (box.Text == "")
                box.BorderBrush = Brushes.Red;
            else
                box.BorderBrush = Brushes.Black;

            RaiseTextChanged();
        }
    }
}
