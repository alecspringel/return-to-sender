using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Rigidbody player;
    public SpawnController spawnController;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnController.SetSpawn(this);
        }
    }
}
