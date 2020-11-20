using UnityEngine;

//public interface AudioTriggers
//{
//    public void PlayTriggerOne();
//    public void PlayTriggerTwo();
//}

public class AudioTriggerObject : MonoBehaviour
{
    [SerializeField] AudioClip[] triggerOne;
    [SerializeField] AudioClip[] triggerTwo;
    //AudioSourceController controller;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        // controller = GetComponent<AudioSourceController>();
    }

    public void PlayTriggerOne(AudioSource source)
    {
        index = RandomIndex(triggerOne);
        PlayAudioThroughSource(source, triggerOne[index]);
    }

    public void PlayTriggerTwo(AudioSource source)
    {
        index = RandomIndex(triggerTwo);
        PlayAudioThroughSource(source, triggerTwo[index]);
    }

    void PlayAudioThroughSource(AudioSource source, AudioClip clip)
    {
        //var source = controller.GetNextSource();

        source.PlayOneShot(clip);
    }

    int RandomIndex(AudioClip[] audioClipArray)
    {
        return Random.Range(0, audioClipArray.Length);
    }
}
