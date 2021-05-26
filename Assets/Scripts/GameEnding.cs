using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public Object nextScene;
    public AudioSource audioSource;

    Rigidbody m_Rigidbody;
    bool m_IsPlayerAtExit;
    private bool endLevel = false;


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_IsPlayerAtExit = true;
            other.GetComponent<NewPlayerMovement>().pauseTimer = true;
        }
    }

    void Update ()
    {
        //If player enters finish line
        if (m_IsPlayerAtExit)
        {
            EndLevel (false);
        }

        if (endLevel == true)
        {
            SceneManager.LoadScene (nextScene.name);
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
            if (audioSource.isPlaying == false) {
                audioSource.Play();
            }
            StartCoroutine(Wait());
            //Application.Quit();
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5.5f);
        endLevel = true;
    }
}
