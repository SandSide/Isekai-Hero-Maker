using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundGroup
{
    public string groupName;

    [Range(0f, 1f)]
    public float volume = 1.0f;

    public Sound[] sounds;

    [HideInInspector]
    public Sound previousSound;
}
