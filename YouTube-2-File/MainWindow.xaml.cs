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

        private static System.Timers.Timer Animation_Timer;

        private bool Switch_Window_Handle_Offset;
        private int Window_Handle_Gradient_Arithmetic;

        private bool Switch_Minimise_Button_Offset;
        private int Minimise_Button_Gradient_Arithmetic;

        private bool Switch_Close_Button_Offset;
        private int Close_Button_Gradient_Arithmetic;

        private bool Switch_Window_Offset;
        private int Window_Gradient_Arithmetic;

        private bool Window_Is_Closing;


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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Animation_Timer = new System.Timers.Timer();
            Animation_Timer.Elapsed += Animation_Timer_Elapsed;
            Animation_Timer.Interval = 50;
            Animation_Timer.Start();
        }

        private void Animation_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (Application.Current.MainWindow != null)
                            {
                                if(Window_Is_Closing != true)
                                {
                                    switch (Switch_Window_Handle_Offset)
                                    {
                                        case true:
                                            switch (Window_Handle_Gradient_Arithmetic < 20)
                                            {
                                                case true:
                                                    Window_Handle_Gradient_Arithmetic++;
                                                    Window_Handle_Offset.Offset += 0.05;
                                                    break;

                                                case false:
                                                    Switch_Window_Handle_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Window_Handle_Gradient_Arithmetic > 0)
                                            {
                                                case true:
                                                    Window_Handle_Gradient_Arithmetic--;
                                                    Window_Handle_Offset.Offset -= 0.05;
                                                    break;

                                                case false:
                                                    Switch_Window_Handle_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Minimise_Button_Offset)
                                    {
                                        case true:
                                            switch (Minimise_Button_Gradient_Arithmetic < 20)
                                            {
                                                case true:
                                                    Minimise_Button_Gradient_Arithmetic++;
                                                    Minimse_Button_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimise_Button_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Minimise_Button_Gradient_Arithmetic > 0)
                                            {
                                                case true:
                                                    Minimise_Button_Gradient_Arithmetic--;
                                                    Minimse_Button_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimise_Button_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Close_Button_Offset)
                                    {
                                        case true:
                                            switch (Close_Button_Gradient_Arithmetic < 20)
                                            {
                                                case true:
                                                    Close_Button_Gradient_Arithmetic++;
                                                    Close_Button_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Close_Button_Gradient_Arithmetic > 0)
                                            {
                                                case true:
                                                    Close_Button_Gradient_Arithmetic--;
                                                    Close_Button_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Window_Offset)
                                    {
                                        case true:
                                            switch (Window_Gradient_Arithmetic < 20)
                                            {
                                                case true:
                                                    Window_Gradient_Arithmetic++;
                                                    Window_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Window_Gradient_Arithmetic > 0)
                                            {
                                                case true:
                                                    Window_Gradient_Arithmetic--;
                                                    Window_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    if (Animation_Timer != null)
                                    {
                                        Animation_Timer.Stop();
                                        Animation_Timer.Close();
                                    }
                                }
                            }
                            else
                            {
                                if (Animation_Timer != null)
                                {
                                    Animation_Timer.Stop();
                                    Animation_Timer.Close();
                                }
                            }
                        });
                    }
                    else
                    {
                        if (Animation_Timer != null)
                        {
                            Animation_Timer.Stop();
                            Animation_Timer.Close();
                        }
                    }
                }
                else
                {
                    if (Animation_Timer != null)
                    {
                        Animation_Timer.Stop();
                        Animation_Timer.Close();
                    }
                }
            }
            else
            {
                if(Animation_Timer != null)
                {
                    Animation_Timer.Stop();
                    Animation_Timer.Close();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;

            if(Animation_Timer != null)
            {
                Animation_Timer.Dispose();
            }
        }
    }
}
