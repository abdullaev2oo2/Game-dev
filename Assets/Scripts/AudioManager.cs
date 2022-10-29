using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Audio s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach (Audio s in audios)
        {
            if (s.name == name)
                s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        foreach (Audio s in audios)
        {
            if (s.name == name)
                s.source.Stop();
        }
    }
}
