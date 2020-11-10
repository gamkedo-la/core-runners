using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip StartMusic;
    public AudioClip LoopMusic;
    public AudioClip OutMusic;

    [SerializeField] AudioSource[] sources;
    [SerializeField] int sourcesToCreate;
    int nextSourceIndex = 0;

    [SerializeField]
    private bool playIntro = false;

    public int bpm;
    public int lengthOfStartBars;

    private double nextStartTime;

    private void Awake()
    {
        if (StartMusic != null)
            playIntro = true;

        if (sources.Length < sourcesToCreate)
        {
            CreateAudioSourceArray();
        }
    }

    void CreateAudioSourceArray()
    {
        sources = new AudioSource[sourcesToCreate];
        for (int i = 0; i < sourcesToCreate; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    AudioSource GetNextSource()
    {
        nextSourceIndex = (nextSourceIndex + 1) % sources.Length;
        return sources[nextSourceIndex];
    }

    void Start()
    {
        nextStartTime = AudioSettings.dspTime + 1f;

        if (playIntro)
        {
            var startMusic = GetNextSource();
            startMusic.clip = StartMusic;
            startMusic.PlayScheduled(nextStartTime);

            nextStartTime += 60.0f / bpm * (lengthOfStartBars * 4);
        }

        var loopMusic = GetNextSource();
        loopMusic.clip = LoopMusic;
        loopMusic.PlayScheduled(nextStartTime);
    }

    private void OnDestroy()
    {
        nextStartTime = AudioSettings.dspTime + 1f;
    }
}
