using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKnockback : MonoBehaviour
{
    public float knockback = 0.0f;

    public AudioClip[] sounds;
    public AudioSource audioSource;

    private Rigidbody rigid;
    private Vector3 newDirection = Vector3.zero;
    private int currentSound = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            rigid = other.collider.GetComponent<Rigidbody>();
            rigid.AddForce(other.GetContact(0).normal * knockback);

            Sound();
        }
    }

    void Sound() {
        audioSource.clip = sounds[currentSound];
        audioSource.Play();
        currentSound = (currentSound + 1) % sounds.Length;
    }
}
