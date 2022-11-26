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
using System.Windows.Shapes;

namespace YouTube_2_File
{
    /// <summary>
    /// Interaction logic for Video_Search.xaml
    /// </summary>
    public partial class Video_Search : Window
    {
        private int maximised_or_normalised;

        public Video_Search()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Embedded_Web_Browser_Engine.Height = this.Height - Window_Handle.Height;
        }

        private void Window_Size_Changed(object sender, SizeChangedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            Window_Geometry.Rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);

                            Embedded_Web_Browser_Engine.Height = this.ActualHeight - Window_Handle.ActualHeight;
                        }
                    }
                }
            }
        }

        private void Minimise_The_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            this.WindowState = WindowState.Minimized;
                        }
                    }
                }
            }
        }

        private void Maximise_Or_Normalise_The_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            maximised_or_normalised++;

                            switch(maximised_or_normalised)
                            {
                                case 1:
                                    this.WindowState = WindowState.Maximized;
                                    Maximise_Or_Normalise_The_Window_Button.Content = "\xEF2F";
                                    break;

                                case 2:
                                    this.WindowState = WindowState.Normal;
                                    Maximise_Or_Normalise_The_Window_Button.Content = "\xEF2E";
                                    maximised_or_normalised = 0;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void Close_The_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

       
        private void Move_The_Window(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            this.DragMove();
                        }
                    }
                }
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            Embedded_Web_Browser_Engine.Dispose();
                        }
                    }
                }
            }
        }

        private async void Select_Video(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            await Verify_If_Link_Is_Valid.Link_Validation_Initiator(Embedded_Web_Browser_Engine.CoreWebView2.Source);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
