using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> audioClips;

    private void Awake() {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioClips = new Dictionary<string, AudioClip>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //加载音效
    public AudioClip LoadAudio(string path)
    {
        return Resources.Load<AudioClip>(path);
    }

    //存储音效
    private AudioClip GetAudioClip(string path)
    {
        if(!audioClips.ContainsKey(path))
        {
            audioClips[path] = LoadAudio(name);
        }
        return audioClips[path];
    }

    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.clip = GetAudioClip(name);
        audioSource.volume = volume;
        audioSource.Play();
    }

    public void PlaySE(string path, float volume = 1.0f) => audioSource.PlayOneShot(LoadAudio(path), volume);

    public void PlaySE(AudioSource audioSource, string path, float volume = 1.0f) => audioSource.PlayOneShot(LoadAudio(path), volume);
}
