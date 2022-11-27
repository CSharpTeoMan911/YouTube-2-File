﻿using System;
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

        


        private readonly List<string> resolutions = new List<string>();
        private string Resolution;
        private int resolution_index = 4;


        


        private static System.Timers.Timer content_update_timer;
        protected static bool Window_Closing;
        public static string video_link_buffer;
       


        public Video_Download_Window(int operation)
        {
            Operation = operation;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            content_update_timer = new System.Timers.Timer();
            content_update_timer.Elapsed += Content_update_timer_Elapsed;
            content_update_timer.Interval = 100;
            content_update_timer.Start();

            resolutions.Add("144p");
            resolutions.Add("240p");
            resolutions.Add("360p");
            resolutions.Add("480p");
            resolutions.Add("720p");


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
                                if (video_link_buffer != null)
                                {
                                    Video_Link_TextBox.Text = video_link_buffer;
                                    video_link_buffer = null;
                                }

                                switch(Downloading_Started == true)
                                {
                                    case true:
                                        Downloading_Dot_Index++;

                                        if (Downloading_Dot_Index == 1)
                                        {
                                            Downloading_TextBlock.Text = "Downloading .    ";
                                        }
                                        else if (Downloading_Dot_Index == 2)
                                        {
                                            Downloading_TextBlock.Text = "Downloading . .  ";
                                        }
                                        else
                                        {
                                            Downloading_TextBlock.Text = "Downloading . . .";

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


                            });
                        }
                        else
                        {
                            if (content_update_timer != null)
                            {
                                content_update_timer.Stop();
                                content_update_timer.Dispose();
                            }
                        }
                    }
                    else
                    {
                        if (content_update_timer != null)
                        {
                            content_update_timer.Stop();
                            content_update_timer.Dispose();
                        }
                    }
                }
                else
                {
                    if (content_update_timer != null)
                    {
                        content_update_timer.Stop();
                        content_update_timer.Dispose();
                    }
                }
            }
            else
            {
                if(content_update_timer != null)
                {
                    content_update_timer.Stop();
                    content_update_timer.Dispose();
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
                        }
                    }
                }
            }
        }
    }
}
