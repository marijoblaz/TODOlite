using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TODOlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            InitializeComponent();
            UpdateDB(true);
        }

        private void InitializeTags(List<tagModel> tagModels)
        {
            foreach (var item in tagModels)
            {
                //Create and set tag
                setTag(item.Priority, item.Content);
            }
        }

        /// <summary>
        /// True to read, false to write
        /// </summary>
        /// <param name="readWrite"></param>
        private void UpdateDB(bool readWrite)
        {
            try
            {
                //Connect to DB
                DB dB = new DB(ConfigurationManager.ConnectionStrings["MyConnectionStringKey"].ConnectionString);

                //Get DATA
                List<tagModel> tagModels = dB.GetTagModels();

                //Display or push to DB
                if (readWrite) InitializeTags(tagModels);
                else dB.Push(tagPanel.Children);

            }
            catch { if (readWrite) Growl.WarningGlobal($"Database could not be accessed!");}
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Drag window
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) => this.Close();
        
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && textBox.Text.Length > 0)
            {
                //Clear the tip image
                imageTip.IsEnabled = false;
                imageTip.Visibility = Visibility.Hidden;

                //Create and set tag
                setTag(decryppter.GetPriority(textBox.Text), decryppter.GetContent(textBox.Text));

                //Clear the textfield
                textBox.Text = String.Empty;
                
            }
        }

        private void setTag(int prior, string content)
        {
            Tag tag = new Tag();

            tag.Content = content;

            switch (prior)
            {
                case 1:
                    tag.Background = new SolidColorBrush(Color.FromRgb(130, 228, 140));
                    break;

                case 2:
                    tag.Background = new SolidColorBrush(Color.FromRgb(130, 191, 229));
                    break;

                case 3:
                    tag.Background = new SolidColorBrush(Color.FromRgb(255, 124, 138));
                    break;
            }
            tagPanel.Children.Add(tag);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => UpdateDB(false);

        private void pinBox_Completed(object sender, RoutedEventArgs e)
        {
            if(pinBox.Password == "1234")
            {
                pinBox.Visibility = Visibility.Hidden;
                textBox.IsEnabled = true;
                scrollView.Visibility = Visibility.Visible;
                logutButton.IsEnabled = true;
                pinBox.Password = "";

                if (tagPanel.Children.Count == 0)
                {
                    imageTip.Visibility = Visibility.Visible;
                }
            }
        }

        private void logutButton_Click(object sender, RoutedEventArgs e)
        {
            pinBox.Visibility = Visibility.Visible;
            scrollView.Visibility = Visibility.Hidden;
            imageTip.Visibility = Visibility.Hidden;

            textBox.IsEnabled = false;
            logutButton.IsEnabled = false;
        }
    }
}
