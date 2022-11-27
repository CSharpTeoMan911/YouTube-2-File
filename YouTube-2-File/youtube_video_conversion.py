import sys
import os


class YouTube_Video_Conversion:
    youtube_link = None
    path_to_save_file = None

    def __init__(self, youtube_link_init, path_to_save_file_init):
        self.youtube_link = youtube_link_init
        self.path_to_save_file = path_to_save_file_init

    def YouTube_Video_Conversion_Controller(self):
        self.__YouTube_Video_Conversion_Operation()

    def __YouTube_Video_Conversion_Operation(self):
        from pytube import YouTube

        youtube_object = YouTube(str(self.youtube_link))

        video_audio = youtube_object.streams.filter(
            only_audio=True).first()

        audio_path = video_audio.download(
            max_retries=30,
            output_path=str(self.path_to_save_file))

        os.rename(audio_path, audio_path + ".mp3")
        print(audio_path)

