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
    /// Interaction logic for Download_Result_Window.xaml
    /// </summary>
    public partial class Download_Result_Window : Window
    {

        private readonly string download_result;

        private bool Window_Is_Closing = false;

        private static System.Timers.Timer animation_timer;


        private bool Switch_Window_Handle_Offset;
        private int Window_Handle_Arithmetic;

        private bool Switch_Window_Offset;
        private int Window_Arithmetic;

        private bool Switch_Close_Button_Offset;
        private int Close_Button_Arithmetic;

        private bool Switch_Result_Textblock_Offset;
        private int Result_Textblock_Arithmetic;




        public Download_Result_Window(string download_result_parameter)
        {
            download_result = download_result_parameter;
            InitializeComponent();
        }

        private void Move_The_Window(object sender, MouseEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Video_Conversion_Or_Download_result.Text = download_result;

            animation_timer = new System.Timers.Timer();
            animation_timer.Elapsed += Animation_timer_Elapsed;
            animation_timer.Interval = 60;
            animation_timer.Start();
        }

        private void Animation_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if(Window_Is_Closing == false)
                            {
                                if (this != null)
                                {
                                    switch(Switch_Window_Handle_Offset)
                                    {
                                        case true:
                                            switch(Window_Handle_Arithmetic < 20)
                                            {
                                                case true:
                                                    Window_Handle_Arithmetic++;
                                                    Window_Handle_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Handle_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Window_Handle_Arithmetic > 0)
                                            {
                                                case true:
                                                    Window_Handle_Arithmetic--;
                                                    Window_Handle_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Handle_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                   

                                    switch (Switch_Window_Offset)
                                    {
                                        case true:
                                            switch (Window_Arithmetic < 20)
                                            {
                                                case true:
                                                    Window_Arithmetic++;
                                                    Window_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Window_Arithmetic > 0)
                                            {
                                                case true:
                                                    Window_Arithmetic--;
                                                    Window_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Window_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Close_Button_Offset)
                                    {
                                        case true:
                                            switch (Close_Button_Arithmetic < 20)
                                            {
                                                case true:
                                                    Close_Button_Arithmetic++;
                                                    Close_Button_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Close_Button_Arithmetic > 0)
                                            {
                                                case true:
                                                    Close_Button_Arithmetic--;
                                                    Close_Button_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Result_Textblock_Offset)
                                    {
                                        case true:
                                            switch (Result_Textblock_Arithmetic < 20)
                                            {
                                                case true:
                                                    Result_Textblock_Arithmetic++;
                                                    Result_Textblock_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Result_Textblock_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Result_Textblock_Arithmetic > 0)
                                            {
                                                case true:
                                                    Result_Textblock_Arithmetic--;
                                                    Result_Textblock_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Result_Textblock_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                }
                                else
                                {
                                    if (animation_timer != null)
                                    {
                                        animation_timer.Stop();
                                    }
                                }
                            }
                            else
                            {
                                if (animation_timer != null)
                                {
                                    animation_timer.Stop();
                                }
                            }
                        });
                    }
                    else
                    {
                        if (animation_timer != null)
                        {
                            animation_timer.Stop();
                        }
                    }
                }
                else
                {
                    if (animation_timer != null)
                    {
                        animation_timer.Stop();
                    }
                }
            }
            else
            {
                if(animation_timer != null)
                {
                    animation_timer.Stop();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;
            
            if(animation_timer != null)
            {
                animation_timer.Dispose();
            }
        }
    }
}
