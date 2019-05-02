using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is what is triggered when a color changes.
public class ColorTriggerResponse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void OnColorChange(bool val) {
      print("Changed to "+ val);
    }
}
