using UnityEngine;

public class MeteoriteHitTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject meterorite;
    private void OnTriggerEnter(Collider other)
    {

        meterorite.SetActive(true);
        var audio = meterorite.GetComponent<AudioRandomContainer>();

        if (audio != null)
            audio.PlayRandomAudio();
    }
}
