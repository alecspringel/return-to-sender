using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public bool newGame;
    public bool controls;
    public bool exitGame;
  void OnMouseUp()
  {
    if (newGame)
    {
      SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    if (exitGame)
    {
      Application.Quit();
    }
  }
}
