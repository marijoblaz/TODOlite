using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TODOlight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        List<tagModel> tagModels = new List<tagModel>();
        public MainWindow()
        {
            InitializeComponent();

           

           System.Windows.MessageBox.Show(ConfigurationManager.ConnectionStrings["MyConnectionStringKey"].ConnectionString);


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Tag_Closing(object sender, EventArgs e)
        {
            //Tag is closing do stuff
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && textBox.Text.Length > 0)
            {
                Tag tag = new Tag();
                tag.Content = textBox.Text;



                if ((bool)rb1.IsChecked) tag.Background = new SolidColorBrush(Color.FromRgb(130, 228, 140));
                else if ((bool)rb2.IsChecked) tag.Background = new SolidColorBrush(Color.FromRgb(130, 191, 229));
                else tag.Background = new SolidColorBrush(Color.FromRgb(255, 124, 138));

                textBox.Text = String.Empty;
                tagPanel.Children.Add(tag);
            }
        }
    }
}
