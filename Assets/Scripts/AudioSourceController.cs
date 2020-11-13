using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField] AudioSource[] sources;
    [SerializeField] int sourcesToCreate;
    int nextSourceIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateAudioSourceArray();
    }
    void CreateAudioSourceArray()
    {
        sources = new AudioSource[sourcesToCreate];
        for (int i = 0; i < sourcesToCreate; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    public AudioSource GetNextSource()
    {
        nextSourceIndex = (nextSourceIndex + 1) % sourcesToCreate;
        return sources[nextSourceIndex];
    }


}
