using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{

  // Set your parameters in the Inspector.
  public float waitSeconds = 60f;

  public Vector3 targetOffset = Vector3.forward * 10f;
  public float punchSpeed = 9f;
  public float retractSpeed = 5f;
  public float acceleration = 0.9f; // 0.5 would mean full acceleration in 2 seconds, .25 in 4 seconds, etc.

  private float CurrentSpeed;
  private float AccelerationSpeed;
  private Vector3 EndingPosition;
  private Vector3 StartingPosition;
  private bool IsPunching = true;
  private float Timer = 0.0f;
  private Rigidbody rigidbody;

  void Awake()
  {
    EndingPosition = transform.position + targetOffset;
    StartingPosition = transform.position;
    CurrentSpeed = punchSpeed;
    rigidbody = GetComponent<Rigidbody>();
  }

  void Update()
  {
    Timer += Time.deltaTime;
    Vector3 target = IsPunching ? EndingPosition : StartingPosition;

    if (transform.position != target)
    {
      if (Timer > waitSeconds)
      {
        AccelerationSpeed += Mathf.Min(acceleration * Time.deltaTime, 1);    // limit to 1 for "full speed"
        rigidbody.MovePosition(Vector3.MoveTowards(
              transform.position,
              target,
              CurrentSpeed * AccelerationSpeed * Time.deltaTime
         ));
      }
    }
    else
    {
      AccelerationSpeed = 0;
      IsPunching = !IsPunching;
      if (transform.position == StartingPosition)
      {
        Timer = 0;
        CurrentSpeed = punchSpeed;
      }
      else
      {
        CurrentSpeed = retractSpeed;
      }
    }
  }
}
