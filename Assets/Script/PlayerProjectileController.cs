using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
  private float nextShoot = -1f;
  public float coolDown = 0.5f;
  public GameObject projectile;
  
  private ColorMonitor color;
    // Start is called before the first frame update
    void Start()
    {
        nextShoot = Time.time;
        color = gameObject.GetComponent<ColorMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
      bool lmb = Input.GetButton("Fire1");
      if (lmb && Time.time >= nextShoot) {
        GameObject go = Instantiate(projectile, transform.position, transform.rotation);
        go.tag = gameObject.tag;
        ColorMonitor cm = go.GetComponent<ColorMonitor>();
        cm.red = color.red;
        cm.blue = color. blue;
        cm.green = color.green;
        cm.yellow = color.yellow;
        nextShoot = Time.time + coolDown;
      }
    }
}
