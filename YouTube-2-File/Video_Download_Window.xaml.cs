using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Video_Download_Window.xaml
    /// </summary>
    public partial class Video_Download_Window : Window
    {
        private static int Operation;

        public static bool Downloading_Started;

        public static bool Display_Download_Result;

        public static string Download_Result;

        public static int Downloading_Dot_Index;



        private bool Switch_Window_Handle_Offset;
        private int Window_Handle_Arithmetic;

        private bool Switch_Minimise_Button_Offset;
        private int Minimise_Button_Arithmetic;

        private bool Switch_Close_Button_Offset;
        private int Close_Button_Arithmetic;

        private bool Switch_Video_Search_Background_Offset;
        private int Video_Search_Background_Arithmetic;

        private bool Switch_Video_Search_Foreground_Offset;
        private int Video_Search_Foreground_Arithmetic;

        private bool Switch_Download_Button_Background_Offset;
        private int Download_Button_Background_Arithmetic;

        private bool Switch_Download_Button_Foreground_Offset;
        private int Download_Button_Foreground_Arithmetic;

        private bool Switch_Download_Main_Stackpanel_Offset;
        private int Main_Stackpanel_Arithmetic;

        private bool Switch_Download_Secondary_Stackpanel_Offset;
        private int Download_Secondary_Stackpanel_Arithmetic;

        private bool Switch_Warning_Textblock_Offset;
        private int Warning_Textblock_Arithmetic;

        private bool Switch_Downloading_TextBlock_Offset;
        private int Downloading_TextBlock_Arithmetic;






        private readonly List<string> resolutions = new List<string>();
        private string Resolution;
        private int resolution_index;


        


        private static System.Timers.Timer content_update_timer;
        private static System.Timers.Timer animation_timer;
        protected static bool Window_Closing;
        public static string video_link_buffer;
       


        public Video_Download_Window(int operation)
        {
            Operation = operation;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window_Closing = false;

            content_update_timer = new System.Timers.Timer();
            content_update_timer.Elapsed += Content_update_timer_Elapsed;
            content_update_timer.Interval = 100;
            content_update_timer.Start();

            animation_timer = new System.Timers.Timer();
            animation_timer.Elapsed += Animation_timer_Elapsed;
            animation_timer.Interval = 80;
            animation_timer.Start();

            resolutions.Add("144p");
            resolutions.Add("240p");
            resolutions.Add("360p");
            resolutions.Add("720p");

            resolution_index = resolutions.Count() - 1;

            Resolution = resolutions[resolution_index];
            Video_Resolution_Display.Text = Resolution;

            switch (Operation)
            {
                case 1:
                    Video_Resolution_Stackpanel.Height = 0;
                    Video_Conversion_Or_Download.Content = "Convert Video";
                    break;

                case 2:
                    Video_Resolution_Stackpanel.Height = 50;
                    Video_Conversion_Or_Download.Content = "Download Video";
                    break;
            }
        }

        private void Animation_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Video_Download_Window.Window_Closing == false)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                            
                                if(Window_Closing == false)
                                {
                                    switch (Switch_Window_Handle_Offset)
                                    {
                                        case true:
                                            switch (Window_Handle_Arithmetic < 14)
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

                                    switch(Switch_Minimise_Button_Offset)
                                    {
                                        case true:
                                            switch (Minimise_Button_Arithmetic < 14)
                                            {
                                                case true:
                                                    Minimise_Button_Arithmetic++;
                                                    Minimse_Button_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Minimise_Button_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Minimise_Button_Arithmetic > 0)
                                            {
                                                case true:
                                                    Minimise_Button_Arithmetic--;
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
                                            switch (Close_Button_Arithmetic < 14)
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


                                    switch (Switch_Video_Search_Background_Offset)
                                    {
                                        case true:
                                            switch (Video_Search_Background_Arithmetic < 14)
                                            {
                                                case true:
                                                    Video_Search_Background_Arithmetic++;
                                                    Video_Search_Background_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Search_Background_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Video_Search_Background_Arithmetic > 0)
                                            {
                                                case true:
                                                    Video_Search_Background_Arithmetic--;
                                                    Video_Search_Background_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Search_Background_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }


                                    switch (Switch_Video_Search_Foreground_Offset)
                                    {
                                        case true:
                                            switch (Video_Search_Foreground_Arithmetic < 14)
                                            {
                                                case true:
                                                    Video_Search_Foreground_Arithmetic++;
                                                    Video_Search_Foreground_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Search_Foreground_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Video_Search_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Video_Search_Foreground_Arithmetic--;
                                                    Video_Search_Foreground_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Video_Search_Foreground_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }


                                    switch (Switch_Download_Button_Background_Offset)
                                    {
                                        case true:
                                            switch (Download_Button_Background_Arithmetic < 14)
                                            {
                                                case true:
                                                    Download_Button_Background_Arithmetic++;
                                                    Video_Download_Background_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Button_Background_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Download_Button_Background_Arithmetic > 0)
                                            {
                                                case true:
                                                    Download_Button_Background_Arithmetic--;
                                                    Video_Download_Background_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Button_Background_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }


                                    switch (Switch_Download_Button_Foreground_Offset)
                                    {
                                        case true:
                                            switch (Download_Button_Foreground_Arithmetic < 14)
                                            {
                                                case true:
                                                    Download_Button_Foreground_Arithmetic++;
                                                    Video_Download_Foreground_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Button_Foreground_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Download_Button_Foreground_Arithmetic > 0)
                                            {
                                                case true:
                                                    Download_Button_Foreground_Arithmetic--;
                                                    Video_Download_Foreground_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Button_Foreground_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }


                                    switch (Switch_Download_Main_Stackpanel_Offset)
                                    {
                                        case true:
                                            switch (Main_Stackpanel_Arithmetic < 14)
                                            {
                                                case true:
                                                    Main_Stackpanel_Arithmetic++;
                                                    Download_Main_Stackpanel_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Main_Stackpanel_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Main_Stackpanel_Arithmetic > 0)
                                            {
                                                case true:
                                                    Main_Stackpanel_Arithmetic--;
                                                    Download_Main_Stackpanel_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Main_Stackpanel_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Download_Secondary_Stackpanel_Offset)
                                    {
                                        case true:
                                            switch (Download_Secondary_Stackpanel_Arithmetic < 14)
                                            {
                                                case true:
                                                    Download_Secondary_Stackpanel_Arithmetic++;
                                                    Download_Secondary_Stackpanel_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Secondary_Stackpanel_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Download_Secondary_Stackpanel_Arithmetic > 0)
                                            {
                                                case true:
                                                    Download_Secondary_Stackpanel_Arithmetic--;
                                                    Download_Secondary_Stackpanel_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Download_Secondary_Stackpanel_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Warning_Textblock_Offset)
                                    {
                                        case true:
                                            switch (Warning_Textblock_Arithmetic < 14)
                                            {
                                                case true:
                                                    Warning_Textblock_Arithmetic++;
                                                    Warning_Textblock_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Warning_Textblock_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Warning_Textblock_Arithmetic > 0)
                                            {
                                                case true:
                                                    Warning_Textblock_Arithmetic--;
                                                    Warning_Textblock_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Warning_Textblock_Offset = true;
                                                    break;
                                            }
                                            break;
                                    }

                                    switch (Switch_Downloading_TextBlock_Offset)
                                    {
                                        case true:
                                            switch (Downloading_TextBlock_Arithmetic < 14)
                                            {
                                                case true:
                                                    Downloading_TextBlock_Arithmetic++;
                                                    Downloading_TextBlock_Offset.Offset += 0.1;
                                                    break;

                                                case false:
                                                    Switch_Downloading_TextBlock_Offset = false;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            switch (Downloading_TextBlock_Arithmetic > 0)
                                            {
                                                case true:
                                                    Downloading_TextBlock_Arithmetic--;
                                                    Downloading_TextBlock_Offset.Offset -= 0.1;
                                                    break;

                                                case false:
                                                    Switch_Downloading_TextBlock_Offset = true;
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

        private void Content_update_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if(Video_Download_Window.Window_Closing == false)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                if(Window_Closing == false)
                                {
                                    if (video_link_buffer != null)
                                    {
                                        Video_Link_TextBox.Text = video_link_buffer;
                                        video_link_buffer = null;
                                    }

                                    switch (Downloading_Started == true)
                                    {
                                        case true:
                                            Downloading_Dot_Index++;

                                            if (Downloading_Dot_Index == 1)
                                            {
                                                Downloading_TextBlock.Text = "DOWNLOADING .    ";
                                            }
                                            else if (Downloading_Dot_Index == 2)
                                            {
                                                Downloading_TextBlock.Text = "DOWNLOADING . .  ";
                                            }
                                            else
                                            {
                                                Downloading_TextBlock.Text = "DOWNLOADING . . .";

                                                Downloading_Dot_Index = 0;
                                            }
                                            break;

                                        case false:
                                            Video_Conversion_Or_Download.IsEnabled = true;
                                            Downloading_Content_Message_Stackpanel.Height = 0;
                                            break;
                                    }


                                    if (Display_Download_Result == true)
                                    {
                                        Display_Download_Result = false;

                                        Download_Result_Window download_Result_Window = new Download_Result_Window(Download_Result);
                                        download_Result_Window.ShowDialog();

                                        Download_Result = null;
                                    }
                                }
                                else
                                {
                                    if (content_update_timer != null)
                                    {
                                        content_update_timer.Stop();
                                    }
                                }

                            });
                        }
                        else
                        {
                            if (content_update_timer != null)
                            {
                                content_update_timer.Stop();
                            }
                        }
                    }
                    else
                    {
                        if (content_update_timer != null)
                        {
                            content_update_timer.Stop();
                        }
                    }
                }
                else
                {
                    if (content_update_timer != null)
                    {
                        content_update_timer.Stop();
                    }
                }
            }
            else
            {
                if (content_update_timer != null)
                {
                    content_update_timer.Stop();
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

        private void Search_YouTube_Video(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            Video_Search video_search = new Video_Search();
                            video_search.ShowDialog();
                        }
                    }
                }
            }
        }




        private async void Download_Or_Convert_Video(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {

                            bool link_validation_result = await Verify_If_Link_Is_Valid.Link_Validation_Initiator(Video_Link_TextBox.Text);

                            if (link_validation_result == true)
                            {
                                Youtube_Video_Processing video_Processing = new Youtube_Video_Processing();

                                using (System.Windows.Forms.FolderBrowserDialog file_path_extractor = new System.Windows.Forms.FolderBrowserDialog())
                                {
                                    if (file_path_extractor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        Downloading_Content_Message_Stackpanel.Height = this.ActualHeight;

                                        Downloading_Started = true;

                                        switch (Operation)
                                        {
                                            case 1:
                                                await video_Processing.YouTube_Video_Processing_Initialisation(1, Video_Link_TextBox.Text, null, file_path_extractor.SelectedPath);
                                                Video_Conversion_Or_Download.IsEnabled = false;
                                                break;



                                            case 2:
                                                await video_Processing.YouTube_Video_Processing_Initialisation(2, Video_Link_TextBox.Text, Resolution, file_path_extractor.SelectedPath);
                                                Video_Conversion_Or_Download.IsEnabled = false;
                                                break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }

        private void Lower_The_Video_Resolution(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            if (Operation == 2)
                            {
                                if (resolution_index > 0)
                                {
                                    resolution_index--;
                                    Resolution = resolutions[resolution_index];
                                    Video_Resolution_Display.Text = Resolution;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Increase_The_Video_Resolution(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            if (Operation == 2)
                            {
                                if (resolution_index < resolutions.Count() - 1)
                                {
                                    resolution_index++;
                                    Resolution = resolutions[resolution_index];
                                    Video_Resolution_Display.Text = Resolution;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Window_Is_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (this != null)
                        {
                            video_link_buffer = null;
                            Window_Closing = false;

                            MainWindow.Video_Download_Operation_Terminated_Delegate_Object();

                            if (content_update_timer != null)
                            {
                                content_update_timer.Dispose();
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
    }
}
