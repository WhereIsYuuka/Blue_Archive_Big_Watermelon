using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
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
        audioSource = gameObject.GetComponent<AudioSource>();
        PlaySong();
    }

    private void PlaySong()
    {
        audioSource.clip = musics[currentMusicIndex];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void NextMusic()
    {
        currentMusicIndex++;
        PlaySong();
    }

    public void PreviousMusic()
    {
        currentMusicIndex--;
        PlaySong();
    }

    public void RandomMusic()
    {
        currentMusicIndex = Random.Range(0, musics.Count);
        PlaySong();
    }

    public void PlaySFX(int index)
    {
        audioSource.PlayOneShot(SFXs[index]);
    }
}
