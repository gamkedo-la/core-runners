using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicEvent
{
    [SerializeField] string name;
    [SerializeField] int eventIdentifier;
    [SerializeField] List<AudioClip> sounds;
    [SerializeField] GameObject objectToTrigger; //Todo Make this an Interface
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

    public int GetEventTypesRange()
    {
        return eventTypes.Count;
    }

    public void CreateBeatList()
    {
        beats = new List<int>();

        for (int beat = 0; beat < beatCountInTrack; beat++)
        {
            beats.Add(-1);
        }
    }
}
