using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public SpawnController spawnController;
    private Rigidbody player;
    public AudioSource audioSource;

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            audioSource.Play();
            player = other.GetComponent<Rigidbody>();
            player.position = spawnController.GetSpawn().transform.position;
            player.velocity = Vector3.zero;
        }
    }
}
