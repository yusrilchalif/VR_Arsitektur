using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

namespace YoutubePlayer
{
    public class PlayVideo : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
    { 
        public VideoPlayer videoPlayer;
        public YoutubePlayer youtubePlayer;
        public Material videoMaterial;

        [SerializeField] Button playVideoBtn;

        Button m_Button;


        void Awake()
        {
            videoPlayer.prepareCompleted += VideoPlayerOnPrepareCompleted;
            Prepare();
            m_Button = GetComponent<Button>();

            // playButton.interactable = videoPlayer.isPrepared;
            // videoPlayer.prepareCompleted += VideoPlayerOnPrepareCompleted;

            playVideoBtn.onClick.AddListener(() =>
            {
                print("Clicked");
                TogglePlayPause();
            });
        }

        void VideoPlayerOnPrepareCompleted(VideoPlayer source)
        {
            videoMaterial.mainTexture = videoPlayer.texture;
        }

        public void TogglePlayPause()
        {
            if (videoPlayer.isPlaying)
            {
                PauseVideo();
            }
            else
            {
                Play();
            }
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

        public void OnPointerClick(PointerEventData eventData)
        {
            print("video play");
            TogglePlayPause();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            print("Pointer Down");
        }
    }
}