using System.Collections;
using UnityEngine;
using System;


/// <summary>
/// Stores all sounds in the game and has diferent modes on how to play the sounds
/// </summary>
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public SoundGroup[] soundGroups;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        // Make the object singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Add a AudioSource component for each sound
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.time = s.time;
            s.source.loop = s.looped;
        }

        foreach (SoundGroup g in soundGroups)
        {
            foreach (Sound s in g.sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = g.volume;
                s.source.pitch = s.pitch;
            }
        }
    }

    /// <summary>
    /// Player sound once
    /// </summary>
    /// <param name="name">Name of the sound</param>
    public void Play(string name)
    {
        // Find sound
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound [" + name + "] not found!");
            return;
        }
        s.source.Play();
    }


    /// <summary>
    /// Pause sound
    /// </summary>
    /// <param name="name">Name of the sound</param>
    public void Pause(string name)
    {
        // Find sound
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound [" + name + "] not found!");
            return;
        }
        s.source.Pause();
    }


    public void PlayGroup(string name)
    {
        SoundGroup group = Array.Find(soundGroups, g => g.groupName == name);
        if (group == null)
        {
            //Debug.Log("Sound Group: [" + name + "] not found!");
            return;
        }

        Sound s;

        do{
            int i = UnityEngine.Random.Range(0, group.sounds.Length - 1);
            s = group.sounds[i];

        } while (s == group.previousSound);

        s.source.Play();
        group.previousSound = s;
    }

    /// <summary>
    /// Play sound in a coroutine, which allows for the same sound to be played overlapped
    /// </summary>
    /// <param name="name">Name of the sound</param>
    public void PlaySimultaneous(string name)
    {

        StartCoroutine(PlayNew(name));

    }
    
    /// <summary>
    /// Play sound looped
    /// </summary>
    /// <param name="name"></param>
    public void PlayLooped(string name)
    {
        // Find sound
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.Log("Sound " + name + " not found!");
            return;
        }

        s.source.loop = true;
        s.source.Play();
    }

    /// <summary>
    /// Play sound 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IEnumerator PlayNew(string name)
    {
        // Find sound
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {       
            //Debug.Log("Sound " + name + " not found!");
            yield return null;
        }

        s.source.PlayOneShot(s.clip);
        yield return null;
    }

    /// <summary>
    /// Change the volume of each sound by %
    /// </summary>
    /// <param name="percentage"></param>
    public void ChangeMasterVolume(float percentage)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * percentage;
        }
    }



}
