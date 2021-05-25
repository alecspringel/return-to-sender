using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpawnController spawnController;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnController.SetSpawn(this);
        }
    }

    public void ChangeColor(Color c)
    {
        meshRenderer.material.SetColor("_Color", c);
    }
}
