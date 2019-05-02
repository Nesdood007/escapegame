using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalMovement : MonoBehaviour
{
  public float rotSpeed = 0.0F;
  
  // Euler Angle Limits
  public float viewPort = 90.0F;
  
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      float r = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime * -1.0F;
      print(r);
      float angle = transform.eulerAngles.x;
      float x = (angle + r); //Adjust so that I can modify Values correctly
      print(x);
      //TODO Clamp Rotation of the Camera. How the fuck do I do that?
      if (x > viewPort) {
        x -= 360;
      }
      x = Mathf.Clamp(x, -viewPort, viewPort);
      transform.Rotate(x - angle, 0, 0);
  }
}
