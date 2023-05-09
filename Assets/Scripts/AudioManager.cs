using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
    }

    public static AudioManager Instance;

    public Sound[] MusicSounds, SFXSounds;
    public AudioSource MusicSource, SFXSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(MusicSounds, x => x.Name == name);

        if (sound == null) Debug.LogError($"Sound \"{name}\" not found.");
        else
        {
            MusicSource.clip = sound.Clip;
            MusicSource.Play();
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(SFXSounds, x => x.Name == name);

        if (sound == null) Debug.LogError($"Sound \"{name}\" not found.");
        else SFXSource.PlayOneShot(sound.Clip);
    }
}
