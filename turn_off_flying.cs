using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_off_flying : MonoBehaviour
{
    public AudioSource thisAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        thisAudioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fly flyingComponent = other.gameObject.GetComponent<fly>();
            if (flyingComponent.enabled == true )
            {
                flyingComponent.enabled = false;
                thisAudioSource.Play();
            }

        }
    }
}
