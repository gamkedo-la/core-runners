using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyrunner : MonoBehaviour
{

    //public GameObject racerobject;
    //public GameObject teleportexit;

    public AudioAsyncObject audioToPlay;

    private void OnTriggerEnter(Collider other)
    {
        //racerobject.transform.position = teleportexit.transform.position ;
        if (audioToPlay != null)
            audioToPlay.PlayAudioBeforeDestroy();
        RacerMovement.currentBoostValue = 5.0f;
        SceneManager.LoadScene(1);
    }

}
