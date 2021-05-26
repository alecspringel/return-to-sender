using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScore : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private bool destroy = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void Update() {
        if (destroy) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            audioSource.Play();
            Collectable.theScore += 1;
            meshRenderer.enabled = false; // Make invisible

            // Wait until sound effect over to destroy
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3);
        destroy = true;
    }
}
