using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessaractBehaviour : MonoBehaviour
{
  private ColorMonitor colors;
  private PingFrequency pf;
    // Start is called before the first frame update
    void Start()
    {
        colors = gameObject.GetComponent<ColorMonitor>();
        pf = gameObject.GetComponent<PingFrequency>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col) {
      // Check if this is actually the player, and not a projectile
      if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<ProjectileBehaviour>() == null) {
        ColorMonitor cm = col.gameObject.GetComponent<ColorMonitor>();
        if (colors.red) cm.red = true;
        if (colors.green) cm.green = true;
        if (colors.blue) cm.blue = true;
        if (colors.yellow) cm.yellow = true;
        
        //Disable the tessaract
        pf.enablePings = false;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Translate(0, -100, 0);
      }
    }
}
