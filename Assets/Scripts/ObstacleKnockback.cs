using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKnockback : MonoBehaviour
{
    public float knockback = 0.0f;

    private Rigidbody rigid;
    private Vector3 newDirection = Vector3.zero;
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            rigid = other.collider.GetComponent<Rigidbody>();
            //newDirection = Vector3.Reflect(rigid.velocity, other.GetContact(0).normal);
            //rigid.AddForce(newDirection * knockback);
            rigid.AddForce(Vector3.up * knockback);
        }
    }
}