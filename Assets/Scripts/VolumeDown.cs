using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VolumeDown : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private float time = 25.0f;
    private float _volume;
    
    private void Awake() {
        videoPlayer = GetComponent<VideoPlayer>();
    
    }
    void Start()
    {
        // GameObject.FindWithTag("AudioManager").GetComponent<AudioSource>().mute = true;
        _volume = AudioManager.Instance.musicSource.volume;
        AudioManager.Instance.musicSource.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            if(time < 10.0f)
            {
                float thisVolume = Mathf.Lerp(1.0f, 0.0f, (10.0f - time) / 10.0f);
                videoPlayer.SetDirectAudioVolume(0, thisVolume);
                //让下面比上面晚五秒声音变大
                if(time < 5.0f)
                {
                    AudioManager.Instance.musicSource.volume = Mathf.Lerp(0.0f, _volume, (5.0f - time) / 5.0f);
                }
                // float musicVolume = Mathf.Lerp(0.0f, _volume, (10.0f - time) / 10.0f);
                // AudioManager.Instance.musicSource.volume = musicVolume;
            }
            
        }
    }
}
