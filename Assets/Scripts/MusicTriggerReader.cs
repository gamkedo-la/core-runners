using UnityEngine;

[System.Serializable]
public class MusicTriggerReader : MonoBehaviour
{
    [SerializeField] MusicData data;
    [SerializeField] int currentBeat;
    public float beatsPerSecond { get; private set; }
    public float secondsPerBeat { get; private set; }

    public bool startReading;
    void Start()
    {
        //beatsPerSecond = data.GetBPM() / 60f;
        //secondsPerBeat = 60f / data.GetBPM();
        ResetBeatCount();
    }

    void Update()
    {
        //if (startReading)
        //    InvokeRepeating("ReadBeat", 0f, secondsPerBeat);
    }

    public void SetMusicData(MusicData data)
    {
        this.data = data;
        beatsPerSecond = data.GetBPM() / 60f;
        secondsPerBeat = 60f / data.GetBPM();
        startReading = true;
        InvokeRepeating("ReadBeat", 0f, secondsPerBeat);
    }

    public void StopBeatCount()
    {
        if (startReading)
        {
            CancelInvoke("ReadBeat");
            ResetBeatCount();
            startReading = false;
        }
    }

    void ReadBeat()
    {
        if (currentBeat <= data.beats.Count - 1)
        {
            // Debug.Log("Beat Data# " + data.beats[currentBeat].ToString() + " and Current Beat is: " + currentBeat);

            currentBeat++;
        }
        else
        {
            ResetBeatCount();
        }
    }

    public void ResetBeatCount()
    {
        currentBeat = 0;
    }
}
