using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
  public bool tutorial;
  public bool level1;
  public bool level2;
  public bool level3;
  public bool controlsBack;


  public Camera MainCamera;

  void Awake()
  {
    MainCamera.enabled = true;
  }
  void OnMouseUp()
  {
    if (tutorial)
    {
      SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
    if (level1)
    {
      SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    if (level2)
    {
      SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    if (level3)
    {
      SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }
    if (controlsBack)
    {
      MainCamera.enabled = true;
    }
  }
}
