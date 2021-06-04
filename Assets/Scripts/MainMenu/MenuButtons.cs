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
  public bool levelSelection;

  public Camera MainCamera;
  public Camera ControlsCamera;
  public Camera LevelSelectionCamera;

  void Awake()
  {
    MainCamera.enabled = true;
    ControlsCamera.enabled = false;
    LevelSelectionCamera.enabled = false;
  }
  void OnMouseUp()
  {
    if (newGame)
    {
      SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
    if (levelSelection)
    {
      LevelSelectionCamera.enabled = true;
      MainCamera.enabled = false;
      ControlsCamera.enabled = false;
    }
    if (controls)
    {
      MainCamera.enabled = false;
      ControlsCamera.enabled = true;
      LevelSelectionCamera.enabled = false;
    }
    if (controlsBack)
    {
      MainCamera.enabled = true;
      ControlsCamera.enabled = false;
      LevelSelectionCamera.enabled = false;
    }
    if (exitGame)
    {
      Application.Quit();
    }
  }
}
