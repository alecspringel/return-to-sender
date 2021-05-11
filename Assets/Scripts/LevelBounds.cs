using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public Rigidbody player;
    public SpawnController spawnController;

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            player.position = spawnController.GetSpawn().transform.position;
            player.velocity = Vector3.zero;
        }
    }
}
