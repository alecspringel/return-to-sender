using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScore : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            Collectable.theScore += 1;
            Destroy(gameObject);
        }
    }
}
