﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float spatialBlend;

    public bool loop;

    public bool mute;

    [HideInInspector]
    public AudioSource source;
}
