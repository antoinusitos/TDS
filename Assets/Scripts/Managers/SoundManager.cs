using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name = "";
    public AudioSource source = null;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public List<Sound> audioSources = new List<Sound>();

    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(string name)
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            if(audioSources[i].name == name)
            {
                audioSources[i].source.Play();
                return;
            }
        }
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].name == name)
            {
                audioSources[i].source.Stop();
                return;
            }
        }
    }
}
