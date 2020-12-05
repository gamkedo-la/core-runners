using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField] AudioMixerGroup audioMixer;
    [SerializeField] AudioSource[] sources;
    [SerializeField] int sourcesToCreate;
    int nextSourceIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (sources.Length < 1)
            CreateAudioSourceArray();
    }
    void CreateAudioSourceArray()
    {
        sources = new AudioSource[sourcesToCreate];
        for (int i = 0; i < sourcesToCreate; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].outputAudioMixerGroup = audioMixer;
        }
    }

    public AudioSource GetNextSource()
    {
        nextSourceIndex = (nextSourceIndex + 1) % sources.Length;
        return sources[nextSourceIndex];
    }

    public AudioSource[] GetSources()
    {
        return sources;
    }
}
