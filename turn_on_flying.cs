using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_on_flying : MonoBehaviour
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
            if (flyingComponent.enabled == false)
            {
                flyingComponent.enabled = true;
                thisAudioSource.Play();
            }

        }
    }
}
