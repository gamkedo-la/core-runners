using UnityEngine;

public class AudioOnTrigger : MonoBehaviour
{
    public AudioSourceController controller;
    [SerializeField] MusicTriggerReader musicTriggerReader;
    public AudioClip[] audioClips;
    public AudioSource source;
    [SerializeField] int next;
    // Start is called before the first frame update
    void Start()
    {
        //if (source == null)
        //{
        //    source = gameObject.AddComponent<AudioSource>();
        //}

        controller = FindObjectOfType<AudioSourceController>();
        //  source = controller.GetNextSource();

        if (musicTriggerReader == null)
            musicTriggerReader = FindObjectOfType<MusicTriggerReader>();

    }

    private void OnTriggerEnter(Collider other)
    {
        //TriggerAudio();
        TriggerEventAudio();

    }

    void TriggerEventAudio()
    {
        var clipToPlay = musicTriggerReader.GetCurrentData().GetRandomEventClip(musicTriggerReader.GetEventFlag());
        source = controller.GetNextSource();
        source.spatialBlend = 0;
        source.PlayOneShot(clipToPlay);

        Debug.LogWarning("Played Trigger " + musicTriggerReader.GetCurrentData().GetEventFlagInfo(musicTriggerReader.GetEventFlag()));
    }

    private void TriggerAudio()
    {
        //next = Random.Range(0, audioClips.Length - 1);
        source = controller.GetNextSource();
        source.spatialBlend = 0;
        source.PlayOneShot(audioClips[next]);
    }
}
