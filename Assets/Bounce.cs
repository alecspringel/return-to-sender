using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            anim.SetTrigger("Bounce");
        }
    }
}
