using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MovingPlatform : MonoBehaviour {
     public Vector3 startPosition = new Vector3(-26,0,17);
     public Vector3 endPosition = new Vector3(-42,0,17);
     public float speed = 0.25f;

     private Rigidbody rigid;

     void Start()
     {
         rigid = GetComponent<Rigidbody>();
     }
 
     void Update() {
        rigid.MovePosition(Vector3.Lerp (startPosition, endPosition, Mathf.PingPong(Time.time*speed, 1.0f)));
    }

     void OnTriggerStay(Collider other)
     {
        if (other.tag == "Player")
        {
            other.transform.parent = transform;
            other.transform.localScale = Vector3.one * 2;
        }
     }

     void OnTriggerExit(Collider other)
     {
         if (other.tag == "Player")
        {
            other.transform.parent = null;
            other.transform.localScale = Vector3.one;
        }
     }
 }
