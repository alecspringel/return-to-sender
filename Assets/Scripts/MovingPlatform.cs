using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MovingPlatform : MonoBehaviour {
     private Vector3 pos1 = new Vector3(-26,0,17);
     private Vector3 pos2 = new Vector3(-42,0,17);
     public float speed = 0.25f;
 
     void Update() {
         transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
     }
 }
