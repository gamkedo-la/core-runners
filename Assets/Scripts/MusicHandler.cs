using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicHandler : MonoBehaviour
{
    public AudioClip StartMusic;
    public AudioClip LoopMusic;
    public AudioClip OutMusic;

    [SerializeField] MusicData StartMusicData;
    [SerializeField] MusicData LoopMusicData;
    [SerializeField] MusicData OutMusicData;

    [SerializeField] AudioSource[] sources;
    [SerializeField] int sourcesToCreate;
    int nextSourceIndex = 0;

    [SerializeField]
    private bool playIntro = false;

    public int bpm;
    public int lengthOfStartBars;

    private double nextStartTime;
    private float triggerDelay;
    [SerializeField] MusicTriggerReader musicTriggerReader;

    [SerializeField] AudioMixerGroup audioMixer;

    private void Awake()
    {
        if (StartMusic != null)
            playIntro = true;

        if (sources.Length < sourcesToCreate)
        {
            CreateAudioSourceArray();
        }

        if (musicTriggerReader == null)
            musicTriggerReader = GetComponent<MusicTriggerReader>();
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

    AudioSource GetNextSource()
    {
        nextSourceIndex = (nextSourceIndex + 1) % sources.Length;
        return sources[nextSourceIndex];
    }

    void Start()
    {
        nextStartTime = AudioSettings.dspTime + 1f;
        triggerDelay = 0f;

        if (playIntro)
        {
            var startMusic = GetNextSource();
            startMusic.clip = StartMusicData.GetTrack();
            startMusic.PlayScheduled(nextStartTime);

            nextStartTime += (double)GetTimeOfIntro();
            //if (AudioSettings.dspTime == nextStartTime)
            musicTriggerReader.SetMusicData(StartMusicData);
            triggerDelay = GetTimeOfIntro();
        }

        var loopMusic = GetNextSource();
        loopMusic.clip = LoopMusicData.GetTrack();
        loopMusic.loop = true;
        loopMusic.PlayScheduled(nextStartTime);
        triggerDelay = (float)(nextStartTime - AudioSettings.dspTime);
        //Debug.Log("delay time: " + triggerDelay);
        //if (AudioSettings.dspTime == nextStartTime)
        //    musicTriggerReader.SetMusicData(LoopMusicData);
        StartCoroutine(ScheduleTriggerReader(triggerDelay, LoopMusicData)); // TODO fix calculation of trigger time so it starts in sync, currently off by 1 beat
    }

    private float GetTimeOfIntro()
    {
        return triggerDelay = 60.0f / bpm * (lengthOfStartBars * 4);
    }

    public IEnumerator ScheduleTriggerReader(float waitTime, MusicData data)
    {
        Debug.Log("Entered Trigger Schedule");
        // yield return new WaitUntil(() => { return triggerSource.isPlaying; });
        yield return new WaitForSecondsRealtime((float)waitTime);
        musicTriggerReader.StopBeatCount();
        musicTriggerReader.SetMusicData(data);
        Debug.Log("Exit Trigger Schedule");
    }

    private void OnDestroy()
    {
        nextStartTime = AudioSettings.dspTime + 1f;
    }
}
