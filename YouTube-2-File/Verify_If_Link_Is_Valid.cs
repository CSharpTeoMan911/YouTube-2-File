using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YouTube_2_File
{
    internal class Verify_If_Link_Is_Valid:Video_Download_Window
    {
        public Verify_If_Link_Is_Valid(int operation) : base(operation)
        {
        }

        public static async Task<bool> Link_Validation_Initiator(string youtube_link)
        {
            return await Link_Validation(youtube_link);
        }

        private static Task<bool> Link_Validation(string youtube_link)
        {
            bool link_validation_result = true;

            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Window_Closing == false)
                        {
                            if (youtube_link.Contains("youtube") == true)
                            {
                                if (youtube_link.Contains("/watch") == true)
                                {
                                    video_link_buffer = youtube_link;
                                }
                                else
                                {
                                    link_validation_result = false;
                                    video_link_buffer = String.Empty;
                                }
                            }
                            else
                            {
                                link_validation_result = false;
                                video_link_buffer = String.Empty;
                            }
                        }
                    }
                }
            }

            return Task.FromResult(link_validation_result);
        }
    }
}
