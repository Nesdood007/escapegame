using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisable : MonoBehaviour
{
  
  public float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time) Destroy(gameObject);
    }
}
