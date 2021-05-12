using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
  public bool newGame;
  public bool controls;
  public bool exitGame;
  public bool controlsBack;

  public Camera MainCamera;
  public Camera ControlsCamera;

  void Awake()
  {
    MainCamera.enabled = true;
    ControlsCamera.enabled = false;
  }
  void OnMouseUp()
  {
    if (newGame)
    {
      SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    if (controls)
    {
      MainCamera.enabled = false;
      ControlsCamera.enabled = true;
    }
    if (controlsBack)
    {
      MainCamera.enabled = true;
      ControlsCamera.enabled = false;
    }
    if (exitGame)
    {
      Application.Quit();
    }
  }
}
