using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace YoutubePlayer
{
    public class PlayVideo : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        public YoutubePlayer youtubePlayer;

        Button m_Button;


        void Awake()
        {
            Prepare();
            m_Button = GetComponent<Button>();

            // playButton.interactable = videoPlayer.isPrepared;
            // videoPlayer.prepareCompleted += VideoPlayerOnPrepareCompleted;
        }

        void VideoPlayerOnPrepareCompleted(VideoPlayer source)
        {
            m_Button.interactable = videoPlayer.isPrepared;
        }

        public void Play()
        {
            print("play");
            videoPlayer.Play();
        }

        public void PauseVideo()
        {
            print("pause");
            videoPlayer.Pause();
        }

        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerOnPrepareCompleted;
        }

        public async void Prepare()
        {
            Debug.Log("Loading video...");
            await youtubePlayer.PrepareVideoAsync();
            Debug.Log("Video ready");
        }
    }
}