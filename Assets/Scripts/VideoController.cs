using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private string videoURL = "";
    [SerializeField] private GameObject texture;
    private VideoPlayer videoPlayer;
    [SerializeField] GameObject VirtualCursor;


    private void Awake()
    {
        texture.gameObject.SetActive(true);
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer)
        {
            videoPlayer.url=videoURL;
            videoPlayer.playOnAwake = false;
            videoPlayer.Prepare();

            videoPlayer.prepareCompleted += OnVideoPrepared;
        }
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        VirtualCursor.SetActive(false);

        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {
        StartCoroutine(LowAlpha());
    }

    IEnumerator LowAlpha()
    {
        float timePassed = 0f;
        Color myColor = texture.GetComponent<RawImage>().color;

        while (timePassed < 2)
        {            
            yield return new WaitForEndOfFrame();

            timePassed+=Time.deltaTime;

            myColor.a = 1.0f - Mathf.Clamp01(timePassed / 2);
            texture.GetComponent<RawImage>().color =myColor;
        }
        texture.gameObject.SetActive(false);
    }
}
