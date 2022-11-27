import youtube_video_conversion
import youtube_video_download
import sys


def Main_Entry_Point(option, youtube_link, youtube_video_quality, path_to_save_file):
    if option == 1:
        video_conversion = youtube_video_conversion.YouTube_Video_Conversion(youtube_link, path_to_save_file)
        video_conversion.YouTube_Video_Conversion_Controller()


    elif option == 2:
        video_download = youtube_video_download.YouTube_Video_Download(youtube_link, youtube_video_quality, path_to_save_file)
        video_download.YouTube_Video_Download_Operational_Controller()


if __name__ == "__main__":
    Main_Entry_Point(int(sys.argv[2]), sys.argv[4], sys.argv[6], sys.argv[8])

