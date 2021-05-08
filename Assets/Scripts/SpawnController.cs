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
    }

    public void SetSpawn(Checkpoint spawn)
    {
        current = spawn;
    }

    public Checkpoint GetSpawn()
    {
        return current;
    }
}
