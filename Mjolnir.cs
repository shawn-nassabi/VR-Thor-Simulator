using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public enum State { Throw, Return, Idle}

public class Mjolnir : MonoBehaviour
{

    public float hammerSpeed = 20;
    public AudioSource far_return_sound;
    public AudioSource short_return_sound;
    public AudioSource thud;

    public GameObject lightning1;
    public GameObject smoke;
    public GameObject box;
    public BoxCollider hitTrigger;

    public Transform playerHand;

    Rigidbody rb;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle; 
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Throw:
                {
                    if (rb.velocity.sqrMagnitude < 0.5)
                    {
                        state = State.Idle;
                    }
                    else
                    {
                        rb.useGravity = false;
                        rb.velocity = rb.velocity.normalized * hammerSpeed;
                        transform.up = rb.velocity * -1;
                    }

                }
                break;
            case State.Return:
                {
                    rb.useGravity = false;
                    if (Vector3.SqrMagnitude(playerHand.position - rb.position) > 4 && Vector3.SqrMagnitude(playerHand.position - rb.position) < 8)
                    {
                        Vector3 dir = (playerHand.position - rb.position).normalized;
                        rb.velocity = dir * hammerSpeed/2;
                        transform.up = rb.velocity;
                    }else if (Vector3.SqrMagnitude(playerHand.position - rb.position) > 4)
                    {
                        Vector3 dir = (playerHand.position - rb.position).normalized;
                        rb.velocity = dir * hammerSpeed;
                        transform.up = rb.velocity;
                    }
                    else
                    {
                        state = State.Idle;
                    }
                    
                }
                break;
            case State.Idle:
                {
                    rb.useGravity = true;
                    Debug.Log("Idle");
                }
                break;
            default:
                break;
        }
    }

    public void ThrowHammer()
    {
        state = State.Throw;
    }

    public void ReturnHammer()
    {
        if (Vector3.SqrMagnitude(playerHand.position - rb.position) > 4)
        {
            far_return_sound.Play();
        }
        state = State.Return;
    }
    public void IdleHammer()
    {
        far_return_sound.Stop();
        short_return_sound.Play();
        state = State.Idle;
    }

    public void Lightning_At_Box()
    {
        GameObject newLight = Instantiate(lightning1, box.transform);
        GameObject newSmoke = Instantiate(smoke, box.transform);
        Destroy(newLight, 1f);
        Destroy(newSmoke, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        thud.Play();
    }

}
