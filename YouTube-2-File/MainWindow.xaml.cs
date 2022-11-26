using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace YouTube_2_File
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public delegate void Video_Download_Operation_Terminated();
        public static Video_Download_Operation_Terminated Video_Download_Operation_Terminated_Delegate_Object = Video_Download_Operation_Terminated_Implementation;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimse_The_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if(Application.Current.Dispatcher != null)
                {
                    if(Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if(Application.Current.MainWindow != null)
                        {
                            Application.Current.MainWindow.WindowState = WindowState.Minimized;
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
                        if (Application.Current.MainWindow != null)
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
                        if (Application.Current.MainWindow != null)
                        {
                            this.DragMove();
                        }
                    }
                }
            }
        }

        private void Window_Size_Changed(object sender, SizeChangedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            Window_Geometry.Rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
                        }
                    }
                }
            }
        }

        private void Video_Conversion(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            Video_Download_Window video_Download_Window = new Video_Download_Window(1);
                            this.Hide();
                            video_Download_Window.Show();
                        }
                    }
                }
            }
        }

        private void Video_Download(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            Video_Download_Window video_Download_Window = new Video_Download_Window(2);
                            this.Hide();
                            video_Download_Window.Show();
                        }
                    }
                }
            }
        }

        
        public static void Video_Download_Operation_Terminated_Implementation()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Application.Current.MainWindow.Show();
            });
        }


    }
}
