import sys
import os

class YouTube_Video_Download:
    youtube_link = None
    youtube_video_quality = None
    path_to_save_file = None

    def __init__(self, youtube_link_init, youtube_video_quality_init, path_to_save_file_init):
        self.youtube_link = youtube_link_init
        self.youtube_video_quality = youtube_video_quality_init
        self.path_to_save_file = path_to_save_file_init


    def YouTube_Video_Download_Operational_Controller(self):
        self.__YouTube_Video_Download_Operation()


    def __YouTube_Video_Download_Operation(self):
        from pytube import YouTube

        youtube_object = YouTube(
            str(self.youtube_link))

        resolutions = []
        available_resolutions = ["144p", "360p", "720p"]

        for stream in youtube_object.streams.order_by("resolution"):
            for index in range(0, len(available_resolutions)):
                if available_resolutions[index] == stream.resolution:
                    exist = resolutions.count(stream.resolution)
                    if exist == 0:
                        resolutions.append(stream.resolution)
                    break

        maximum_available_resolution = resolutions[len(resolutions) - 1]

        try:
            maximum_available_resolution = resolutions[resolutions.index(self.youtube_video_quality)]
        except ValueError:
            pass

        video_audio = youtube_object.streams.filter(
            only_audio=False,
            res=maximum_available_resolution).first()

        video_path = video_audio.download(
            max_retries=30,
            output_path=str(self.path_to_save_file))

        os.rename(video_path, video_path + ".mp4")
        sys.exit(0)

