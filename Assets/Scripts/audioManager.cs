using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public Sounds[] sound;
    // Start is called before the first frame update
    void Awake()
    {

        foreach (Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.mute = s.mute;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    private void Start()
    {
        Play("theme");
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        s.source.Play();

        if (s == null)
        {
            Debug.LogWarning("iets mis met " + name);
            return;
        }
    }
    

    public void Stop (string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        s.source.Stop();
    }
}
