using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Checkpoint []checkpoints;
    private Checkpoint current;

    void Start()
    {
        current = checkpoints[0];
        current.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }

    public void SetSpawn(Checkpoint spawn)
    {
        if (spawn != current)
        {
            current.ChangeColor(Color.red);
            spawn.ChangeColor(Color.green);
            current = spawn;
        }
    }

    public Checkpoint GetSpawn()
    {
        return current;
    }
}
