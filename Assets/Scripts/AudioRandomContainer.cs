using UnityEngine;

public class AudioRandomContainer : MonoBehaviour
{
    [SerializeField] AudioSourceController controller;
    [SerializeField] AudioClip[] audioClips;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<AudioSourceController>();
    }

    public void PlayRandomAudio()
    {
        var source = controller.GetNextSource();
        var clip = GetRandomClip();

        if (clip != null)
        {
            source.clip = clip;
            source.PlayOneShot(clip); Debug.Log("explosion!");

        }
    }

    public void PlayRandomAudio(out float clipLength)
    {
        var source = controller.GetNextSource();
        var clip = GetRandomClip();
        clipLength = clip.length;

        if (clip != null)
        {
            source.clip = clip;
            source.PlayOneShot(clip); Debug.Log("explosion!");

        }
    }

    AudioClip GetRandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length - 1)];
    }
}
