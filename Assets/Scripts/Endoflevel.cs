using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endoflevel : MonoBehaviour
{

    public Rigidbody rb;
    public TextMeshProUGUI endmessage;
    public AudioAsyncObject audioToPlay;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gate trigger");
        //stop ship going forward
        rb.mass = 10000;
        rb.drag = 1000;

        // check what text to display
        if (RacerMovement.currentBoostValue > 4.5)
        {
            endmessage.text = "You collected enough power cores on the way to power the cannons the planet is saved!";

        }
        else
        {
            endmessage.text = "The cannons briefly power up but then fade out, looks like it's going to be a big impact";

        }


        StartCoroutine(Returntomainmenu());
    }

    IEnumerator Returntomainmenu()
    {
        yield return new WaitForSeconds(4.0f);

        if (audioToPlay != null)
            audioToPlay.PlayAudioBeforeDestroy();
        RacerMovement.currentBoostValue = 5.0f;
        SceneManager.LoadScene(0);
    }
}
