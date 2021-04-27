using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject player;
    Rigidbody m_Rigidbody;
    bool m_IsPlayerAtExit;

    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update ()
    {
        //If player enters finish line
        if (m_IsPlayerAtExit)
        {
            EndLevel (false);
        }
    }

    void EndLevel (bool doRestart)
    {
        if(doRestart)
        {
            //This would be when the character falls off
            SceneManager.LoadScene (0);
        }
        else
        {
            //Currently restarting when you cross the finish line
            SceneManager.LoadScene (0);
            //Application.Quit();
        }
    }
}
