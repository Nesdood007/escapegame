using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLightController : MonoBehaviour
{
  // Controls the Color of the Light of a Projectile
  [Header("Color Definitions")]
  public Color red;
  public Color blue;
  public Color green;
  public Color yellow;
  
  [Header("Light Settings")]
  public float delta = 0.25f;
  public float intensity = 1f;
  
  [Header("Only work with specified tag")]
  public string workOnTag = "Player";
  
  private Light localLight;
  private ColorMonitor color;
  
  private int currColor = 0;
  private float nextCycleTime = 0.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        localLight = gameObject.GetComponent<Light>();
        color = gameObject.GetComponent<ColorMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != workOnTag) return;
        
        // Check if time to change the color
        if (Time.time - nextCycleTime < 0f) return;
        
        //print("Changing Color... " + currColor);
        
        currColor = (currColor + 1) % 4;
        
        // Change the Color
        if (currColor == 0 && color.red) {
          //print("Red Light");
          localLight.color = red;
        } else if (currColor == 0 && !color.red) {
          currColor += 1;
        }
        if (currColor == 1 && color.blue) {
          localLight.color = blue;
          //print("Blue Light");
        } else if (currColor == 1 && !color.blue) {
          currColor += 1;
        }
        if (currColor == 2 && color.green) {
          localLight.color = green;
          //print("Green Light");
        } else if (currColor == 2 && !color.green) {
          currColor += 1;
        }
        if (currColor == 3 && color.yellow) {
          localLight.color = yellow;
          //print("Yellow Light");
        } else if (currColor == 3 && !color.yellow) {
          currColor += 1;
        }
        
        if (currColor >= 4) currColor = -1;
        
        localLight.intensity = intensity;
        nextCycleTime = Time.time + delta;
    }
}
