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

        private bool Window_Is_Closing;

        private static System.Timers.Timer animation_timer;


        private bool Switch_Window_Handle_Offset;
        private int Window_Handle_Arithmetic;

        private bool Switch_Minimse_Button_Background_Offset;
        private int Minimse_Button_Background_Arithmetic;

        private bool Switch_Minimse_Button_Foreground_Offset;
        private int Minimse_Button_Foreground_Arithmetic;

        private bool Switch_Maximise_Or_Normalise_Button_Background_Offset;
        private int Maximise_Or_Normalise_Button_Background_Arithmetic;

        private bool Switch_Maximise_Or_Normalise_Button_Foreground_Offset;
        private int Maximise_Or_Normalise_Button_Foreground_Arithmetic;

        private bool Switch_Close_Button_Background_Offset;
        private int Close_Button_Background_Arithmetic;

        private bool Switch_Close_Button_Foreground_Offset;
        private int Close_Button_Foreground_Arithmetic;

        private bool Switch_Video_Selection_Button_Offset;
        private int Video_Selection_Button_Arithmetic;




        public Video_Search()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Embedded_Web_Browser_Engine.Height = this.Height - Window_Handle.Height;

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

                                    switch (Switch_Minimse_Button_Background_Offset)
                                    {
                                        case true:
                                            switch (Minimse_Button_Background_Arithmetic < 20)
                                            {
                                                case true:
                                                    Minimse_Button_Background_Arithmetic++;
                                                    Minimse_Button_Background_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimse_Button_Background_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Minimse_Button_Background_Arithmetic > 0)
                                            {
                                                case true:
                                                    Minimse_Button_Background_Arithmetic--;
                                                    Minimse_Button_Background_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimse_Button_Background_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Minimse_Button_Foreground_Offset)
                                    {
                                        case true:
                                            switch (Minimse_Button_Foreground_Arithmetic < 20)
                                            {
                                                case true:
                                                    Minimse_Button_Foreground_Arithmetic++;
                                                    Minimse_Button_Foreground_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimse_Button_Foreground_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Minimse_Button_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Minimse_Button_Foreground_Arithmetic--;
                                                    Minimse_Button_Foreground_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimse_Button_Foreground_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Maximise_Or_Normalise_Button_Background_Offset)
                                    {
                                        case true:
                                            switch (Maximise_Or_Normalise_Button_Background_Arithmetic < 20)
                                            {
                                                case true:
                                                    Maximise_Or_Normalise_Button_Background_Arithmetic++;
                                                    Maximise_Or_Normalise_Button_Background_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Maximise_Or_Normalise_Button_Background_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Maximise_Or_Normalise_Button_Background_Arithmetic > 0)
                                            {
                                                case true:
                                                    Maximise_Or_Normalise_Button_Background_Arithmetic--;
                                                    Maximise_Or_Normalise_Button_Background_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Maximise_Or_Normalise_Button_Background_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Maximise_Or_Normalise_Button_Foreground_Offset)
                                    {
                                        case true:
                                            switch (Maximise_Or_Normalise_Button_Foreground_Arithmetic < 20)
                                            {
                                                case true:
                                                    Maximise_Or_Normalise_Button_Foreground_Arithmetic++;
                                                    Maximise_Or_Normalise_Button_Foreground_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Maximise_Or_Normalise_Button_Foreground_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Maximise_Or_Normalise_Button_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Maximise_Or_Normalise_Button_Foreground_Arithmetic--;
                                                    Maximise_Or_Normalise_Button_Foreground_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Maximise_Or_Normalise_Button_Foreground_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Close_Button_Background_Offset)
                                    {
                                        case true:
                                            switch (Close_Button_Background_Arithmetic < 18)
                                            {
                                                case true:
                                                    Close_Button_Background_Arithmetic++;
                                                    Close_Button_Background_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Background_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Maximise_Or_Normalise_Button_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Close_Button_Background_Arithmetic--;
                                                    Close_Button_Background_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Background_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Close_Button_Foreground_Offset)
                                    {
                                        case true:
                                            switch (Close_Button_Foreground_Arithmetic < 18)
                                            {
                                                case true:
                                                    Close_Button_Foreground_Arithmetic++;
                                                    Close_Button_Foreground_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Foreground_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Maximise_Or_Normalise_Button_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Close_Button_Foreground_Arithmetic--;
                                                    Close_Button_Foreground_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Close_Button_Foreground_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Video_Selection_Button_Offset)
                                    {
                                        case true:
                                            switch (Video_Selection_Button_Arithmetic < 18)
                                            {
                                                case true:
                                                    Video_Selection_Button_Arithmetic++;
                                                    Video_Selection_Button_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Selection_Button_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Video_Selection_Button_Arithmetic > 0)
                                            {
                                                case true:
                                                    Video_Selection_Button_Arithmetic--;
                                                    Video_Selection_Button_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Selection_Button_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                }
                                else
                                {
                                    if (animation_timer != null)
                                    {
                                        animation_timer.Close();
                                    }
                                }
                            }
                            else
                            {
                                if (animation_timer != null)
                                {
                                    animation_timer.Close();
                                }
                            }
                        });
                    }
                    else
                    {
                        if (animation_timer != null)
                        {
                            animation_timer.Close();
                        }
                    }
                }
                else
                {
                    if (animation_timer != null)
                    {
                        animation_timer.Close();
                    }
                }
            }
            else
            {
                if(animation_timer != null)
                {
                    animation_timer.Close();
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
                            Window_Is_Closing = true;

                            if(Embedded_Web_Browser_Engine != null)
                            {
                                Embedded_Web_Browser_Engine.Dispose();
                            }

                            if(animation_timer != null)
                            {
                                animation_timer.Dispose();
                            }
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
