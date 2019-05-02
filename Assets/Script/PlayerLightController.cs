using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    //Light Controller
  private float lightEndTime = 0.0f;
  public float lightIntensity = 1.0f;
  public float lightLength = 0.5f;
  public string activateTag = "Enemy";
  private Light local_light;
  private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        local_light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
      if (activated) {
        float val = (lightEndTime - Time.time) / lightLength;
        if (val < 0f) {
          val = 0f;
          activated = false;
        }
        local_light.intensity = Mathf.Lerp(0f, lightIntensity, val);
        //print("Light On: " + val);
      } else {
        //print("Light Stopped");
      }
    }
    
    void OnCollisionEnter(Collision col) {
      if (col.gameObject.tag == activateTag) {
        local_light.intensity = 0f;
        lightEndTime = Time.time + lightLength;
        activated = true;
        //print("Collision. Starting Light");
      }
    }
}
