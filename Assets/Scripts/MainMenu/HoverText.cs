using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverText : MonoBehaviour
{
  Renderer m_ObjectRenderer;
  void Start()
  {
    m_ObjectRenderer = GetComponent<Renderer>();
    m_ObjectRenderer.material.color = Color.white;
  }

  void OnMouseEnter()
  {
    m_ObjectRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.8f);
  }

  void OnMouseExit()
  {
    m_ObjectRenderer.material.color = Color.white;
  }
}
