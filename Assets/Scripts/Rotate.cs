using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Rotate : MonoBehaviour
{
    //Rotational Speed
    public float speed = 0f;
   
    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;
   
    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;

    private Rigidbody rigid;
    private float time = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
   
    void Update ()
    {
        time += Time.deltaTime;
        //Forward Direction
        if(ForwardX == true)
        {
            Vector3 euler = new Vector3(time * speed, 0f, 0f);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
        if(ForwardY == true)
        {
            Vector3 euler = new Vector3(0f, time * speed, 0f);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
        if(ForwardZ == true)
        {
            Vector3 euler = new Vector3(0f, 0f, time * speed);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
        //Reverse Direction
        if(ReverseX == true)
        {
            Vector3 euler = new Vector3(-time * speed, 0f, 0f);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
        if(ReverseY == true)
        {
            Vector3 euler = new Vector3(0f, -time * speed, 0f);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
        if(ReverseZ == true)
        {
            Vector3 euler = new Vector3(0f, 0f, time * speed);
            Quaternion rot = Quaternion.Euler(euler);
            rigid.MoveRotation(rot);
        }
       
    }
}
