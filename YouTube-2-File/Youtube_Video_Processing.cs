using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_2_File
{
    internal class Youtube_Video_Processing
    {
        public Task<bool> YouTube_Video_Processing_Initialisation(int option, string youtube_video_link, string video_resolution, string path_to_save_file)
        {
            System.Threading.Thread ParallelProcessing;

            switch(option)
            {
                case 1:
                    ParallelProcessing = new System.Threading.Thread(async() =>
                    {
                        await YouTube_Video_Conversion(youtube_video_link, path_to_save_file);
                    });
                    ParallelProcessing.SetApartmentState(System.Threading.ApartmentState.MTA);
                    ParallelProcessing.Priority = System.Threading.ThreadPriority.AboveNormal;
                    ParallelProcessing.IsBackground = true;
                    ParallelProcessing.Start();
                    break;

                case 2:
                    ParallelProcessing = new System.Threading.Thread(async () =>
                    {
                        await YouTube_Video_Download(youtube_video_link, video_resolution, path_to_save_file);
                    });
                    ParallelProcessing.SetApartmentState(System.Threading.ApartmentState.MTA);
                    ParallelProcessing.Priority = System.Threading.ThreadPriority.AboveNormal;
                    ParallelProcessing.IsBackground = true;
                    ParallelProcessing.Start();
                    break;
            }

            return Task.FromResult(true);
        }

        private Task<bool> YouTube_Video_Conversion(string youtube_video_link, string path_to_save_file)
        {
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = Environment.CurrentDirectory + "\\python.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.Arguments = "youtube_video_operational_controller.py -i1 \"1\" -i2 \"" + youtube_video_link + "\" -i3 \"\" -i4 \"" + path_to_save_file +"\"";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();


                using (StreamReader program_output_stream_reader = process.StandardOutput)
                {
                    using (StreamReader program_error_stream_reader = process.StandardError)
                    {
                        string program_output = program_output_stream_reader.ReadLine();

                        string program_error = program_error_stream_reader.ReadLine();

                        System.Diagnostics.Debug.WriteLine("OUTPUT:  " + program_output);
                    }
                }
            }

            return Task.FromResult(true);
        }

        private Task<bool> YouTube_Video_Download(string youtube_video_link, string video_resolution, string path_to_save_file)
        {
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = Environment.CurrentDirectory + "\\python.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.Arguments = "youtube_video_operational_controller.py -i1 \"2\" -i2 \"" + youtube_video_link + "\" -i3 \"" + video_resolution + "\" -i4 \"" + path_to_save_file + "\"";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                using (StreamReader program_output_stream_reader = process.StandardOutput)
                {
                    using (StreamReader program_error_stream_reader = process.StandardError)
                    {
                        string program_output = program_output_stream_reader.ReadLine();

                        string program_error = program_error_stream_reader.ReadLine();

                        System.Diagnostics.Debug.WriteLine("OUTPUT:  " + program_output);
                    }
                }
            }

            return Task.FromResult(true);
        }
    }
}
