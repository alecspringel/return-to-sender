using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public Rigidbody player;
    public GameObject spawnPoint;

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            player.position = spawnPoint.transform.position;
        }
    }
}
