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
        private Material videoMaterial;
        public Sprite playButton, pauseButton;

        [SerializeField] Button playVideoBtn;

        Button m_Button;
        bool isPlaying = false;

        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            playVideoBtn.onClick.AddListener(TogglePlayPause);
        }

        void VideoPlayerOnPrepareCompleted(VideoPlayer source)
        {
            videoMaterial.mainTexture = videoPlayer.texture;
        }

        public void TogglePlayPause()
        {
            if(isPlaying)
            {
                videoPlayer.Pause();
                playVideoBtn.image.sprite = playButton;
            }
            else
            {
                videoPlayer.Play();
                playVideoBtn.image.sprite = pauseButton;
            }

            isPlaying = !isPlaying;
        }

        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerOnPrepareCompleted;
        }

        public async void Prepare()
        {
            Debug.Log("Loading video...");
            //await youtubePlayer.PrepareVideoAsync();
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