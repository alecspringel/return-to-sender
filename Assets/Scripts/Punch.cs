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

private float currentSpeed;
private float accelerationSpeed;
  private Vector3 endingPosition;
  private Vector3 startingPosition;
  private bool isPunching = true;
  private float timer = 0.0f;

  void Awake()
  {
    endingPosition = transform.position + targetOffset;
    startingPosition = transform.position;
    currentSpeed = punchSpeed;
  }

  // Make Start a coroutine that begins 
  // as soon as our object is enabled.
  void Update()
  {

    timer += Time.deltaTime;
    // Then, pick our destination point offset from our current location.
    Vector3 target = isPunching ? endingPosition : startingPosition;

    // Loop until we're within Unity's vector tolerance of our target.
    if (transform.position != target)
    {
      if (timer > waitSeconds)
      {
        accelerationSpeed += Mathf.Min(acceleration * Time.deltaTime, 1);    // limit to 1 for "full speed"
        // Move one step toward the target at our given speed.
        transform.position = Vector3.MoveTowards(
              transform.position,
              target,
              currentSpeed * accelerationSpeed * Time.deltaTime
         );
      }
    }
    else
    {
        accelerationSpeed = 0;
      isPunching = !isPunching;
      if (transform.position == startingPosition)
      {
        timer = 0;
        currentSpeed = punchSpeed;
      } else {
          currentSpeed = retractSpeed;
      }
    }
  }
}

// public class Punch : MonoBehaviour
// {
//   private Vector3 startPosition;
//   private float nextFire;
//   public Vector3 endPosition;
//   public float speed = 0.25f;
//   public float delaySeconds = 5.0f;

//   void Awake()
//   {
//     startPosition = this.transform.position;
//   }

//   void Update()
//   {
//     if(Input.GetButton("Fire1") && Time.time > nextFire)
//     {
//       nextFire = Time.time + delaySeconds;
//       transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed, 1.0f));
//     } else if (startPosition == transform.position) {

//     }
//   }
// }
