using System.Collections;
using UnityEngine;

public class AudioAsyncObject : MonoBehaviour
{
    [SerializeField] AudioRandomContainer audioToPlay;
    //[SerializeField] bool safeToDestroy = false;

    private void Start()
    {
        if (audioToPlay != null)
            DontDestroyOnLoad(this);
    }


    public void PlayOnDelay(int delay)
    {
        StartCoroutine(DelayedPlay(delay));
    }

    public IEnumerator DelayedPlay(int delay)
    {
        yield return new WaitForSeconds(delay);
        PlayAudioBeforeDestroy();
    }

    public void PlayAudioBeforeDestroy()
    {
        float timeBeforeDestroy = 0;

        if (audioToPlay != null)
        {
            audioToPlay.PlayRandomAudio(out timeBeforeDestroy);

            Debug.Log("Delay destroy " + timeBeforeDestroy);
        }
        else
        {
            Debug.LogError("No audio to play");
        }

        Destroy(this.gameObject, timeBeforeDestroy);
    }
}
