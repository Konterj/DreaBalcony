using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InterctiveSound : MonoBehaviour
{
    public List<AudioClip> InteractiveSound = new List<AudioClip>();
    public AudioSource source_interactive;

    public void ChekedAudio(int CurrentAudio)
    {
        source_interactive.clip = InteractiveSound[CurrentAudio];
        source_interactive.Play();
    }
}