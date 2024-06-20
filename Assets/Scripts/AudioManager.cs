using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource, sfxSource;
    private static AudioManager instance;
    public List<AudioClip> SFXs;
    public List<AudioClip> musics;

    private int currentMusicIndex = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AudioManager Instance
    {
        get { return instance; }
    }

    void Start()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        RandomMusic();
    }

    private void PlaySong()
    {
        musicSource.clip = musics[currentMusicIndex];
        musicSource.loop = true;
        musicSource.Play();
    }

    public void NextMusic()
    {
        currentMusicIndex = (currentMusicIndex + 1) % musics.Count;
        PlaySong();
    }

    public void PreMusic()
    {
        currentMusicIndex = (currentMusicIndex - 1 + musics.Count) % musics.Count;
        PlaySong();
    }

    public void RandomMusic()
    {
        currentMusicIndex = Random.Range(0, musics.Count);
        PlaySong();
    }

    public void PlaySFX(int index)
    {
        sfxSource.PlayOneShot(SFXs[index]);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
