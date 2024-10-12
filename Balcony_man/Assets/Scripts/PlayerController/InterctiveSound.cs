using System.Collections.Generic;
using UnityEngine;


public class InterctiveSound : MonoBehaviour
{
    public AudioSource source_interactive;
    public ElementAudio[] elements;

    public void LaunchAudio(int nameAudio, int CurrentAudio)
    {
        source_interactive.clip = elements[nameAudio].interactiveSound[CurrentAudio];
        source_interactive.Play();
    }
    
}

[System.Serializable]
public class ElementAudio
{
    public string nameInteractive;
    public List<AudioClip> interactiveSound = new List<AudioClip>();
    private InterctiveSound Setting;

    public ElementAudio(int CurrentAudio, string name)
    {
        name = nameInteractive;
        AudioSource source = Setting.source_interactive;
        source.clip = interactiveSound[CurrentAudio];
        source.Play();
    }
}