using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_voice : MonoBehaviour
{
    public AudioSource voice;

    // Start is called before the first frame update
    void Start()
    {
        voice = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            voice.Play();
            
        }
    }

}
