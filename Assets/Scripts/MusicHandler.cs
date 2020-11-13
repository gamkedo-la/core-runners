using System.Collections;
using UnityEngine;

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

    [SerializeField] MusicTriggerReader musicTriggerReader;

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
            startMusic.clip = StartMusicData.GetTrack();
            startMusic.PlayScheduled(nextStartTime);

            nextStartTime += 60.0f / bpm * (lengthOfStartBars * 4);
            //if (AudioSettings.dspTime == nextStartTime)
            musicTriggerReader.SetMusicData(StartMusicData);
        }

        var loopMusic = GetNextSource();
        loopMusic.clip = LoopMusicData.GetTrack();
        loopMusic.loop = true;
        loopMusic.PlayScheduled(nextStartTime);
        //if (AudioSettings.dspTime == nextStartTime)
        //    musicTriggerReader.SetMusicData(LoopMusicData);
        StartCoroutine(ScheduleTriggerReader(nextStartTime, LoopMusicData));
    }
    public IEnumerator ScheduleTriggerReader(double waitTime, MusicData data)
    {
        Debug.Log("Entered Trigger Schedule");
        // yield return new WaitUntil(() => { return triggerSource.isPlaying; });
        yield return new WaitForSecondsRealtime((float)waitTime);
        musicTriggerReader.CancelInvoke("ReadBeat");
        musicTriggerReader.ResetBeatCount();
        musicTriggerReader.SetMusicData(data);
        Debug.Log("Exit Trigger Schedule");
    }

    private void OnDestroy()
    {
        nextStartTime = AudioSettings.dspTime + 1f;
    }
}
