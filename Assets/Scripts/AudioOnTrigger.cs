using UnityEngine;

public class AudioOnTrigger : MonoBehaviour
{
    public AudioSourceController controller;
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
        source = controller.GetNextSource();
    }

    private void OnTriggerEnter(Collider other)
    {
        next = Random.Range(0, audioClips.Length - 1);
        source = controller.GetNextSource();
        source.spatialBlend = 0;
        source.PlayOneShot(audioClips[next]);
    }
}
