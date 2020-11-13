using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicEvent
{
    [SerializeField] string name;
    [SerializeField] int eventIdentifier;
    [SerializeField] List<AudioClip> sounds;
    [SerializeField] GameObject objectToTrigger; //Todo Make this an Interface

    public string GetName() { return name; }
    public int SoundsCount() { return sounds.Count; }

    public AudioClip GetClip() { return sounds[Random.Range(0, SoundsCount())]; }
}

[CreateAssetMenu(menuName = "CoreRunners/MusicData", fileName = "New Music Data.asset")]
public class MusicData : ScriptableObject
{
    [SerializeField] AudioClip musicTrack;
    [SerializeField] int bpm;
    [SerializeField] int beatCountInTrack;
    //[SerializeField] int numberOfEventTypes;

    [SerializeField] List<MusicEvent> eventTypes;

    [HideInInspector] public List<int> beats = new List<int>();

    public AudioClip GetTrack() { return musicTrack; }

    public AudioClip GetRandomEventClip(int index)
    {
        return eventTypes[index].GetClip();
    }

    public int GetEventTypesRange() { return eventTypes.Count; }

    public int GetBPM() { return bpm; }
    public int GetTotalBeatCount() { return beatCountInTrack; }


    public string GetEventFlagInfo(int index)
    {
        return eventTypes[index].GetName();
    }

    public void CreateBeatList()
    {
        beats = new List<int>();

        for (int beat = 0; beat < beatCountInTrack; beat++)
        {
            beats.Add(-1);
        }
    }

    public void TrimBeats()
    {
        beats.RemoveRange(beatCountInTrack, beats.Count - beatCountInTrack);
    }
}
