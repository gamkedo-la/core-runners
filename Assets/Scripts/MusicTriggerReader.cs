﻿using UnityEngine;

[System.Serializable]
public class MusicTriggerReader : MonoBehaviour
{
    [SerializeField] MusicData data;
    [SerializeField] int currentBeat;
    public float beatsPerSecond { get; private set; }
    public float secondsPerBeat { get; private set; }

    public bool startReading;

    [SerializeField] int eventFlag;

    [SerializeField] AudioSourceController controller;
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

    public int GetEventFlag() { return eventFlag; }
    public MusicData GetCurrentData() { return data; }
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
            ReportEvent(data.beats[currentBeat]);
            currentBeat++;

            if (currentBeat == data.beats.Count) //TODO The loop needs to be fixed so it's in sync
                ResetBeatCount();
        }
        //else
        //{
        //    ResetBeatCount();
        //}
    }

    private void ReportEvent(int beatEventInfo)
    {
        if (beatEventInfo > -1)
        {
            eventFlag = beatEventInfo;
            Debug.Log(data.GetEventFlagInfo(beatEventInfo));
        }
    }

    public void ResetBeatCount()
    {
        currentBeat = 0;
    }

    public void PlayCurrentTriggerOne()
    {
        controller = GetComponent<AudioSourceController>();
        data.GetEvent(eventFlag).GetTriggers().PlayTriggerOne(controller.GetNextSource());
    }

    public void PlayCurrentTriggerTwo()
    {
        controller = GetComponent<AudioSourceController>();
        data.GetEvent(eventFlag).GetTriggers().PlayTriggerTwo(controller.GetNextSource());
    }
}
