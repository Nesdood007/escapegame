using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Variables that can be set in the editor
  public float speed = 10.0F;  
  public float rotMod = 200.0F;
  public float jumpHeight = 2.0F;
  public float jumpVelocity = 1.0F;
  
  //PlayerPen, keeps the playercontroller from falling off of the world
  public float minX = 1.0F;
  public float minY = 1.0F;
  public float maxX = 49.0F;
  public float maxY = 49.0F;
  
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      float h = Input.GetAxis("Vertical") * speed * Time.deltaTime;
      float v = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Strafe
      float r = Input.GetAxis("Mouse X") * rotMod * Time.deltaTime; //Rotate with Mouse
      
      transform.Translate(v, 0, h);
      transform.Rotate(0, r, 0);
      
  }
}
