using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : ColorTriggerResponse
{
  public bool initialState = true; //If the wall will exist
  public bool invert = false;
  private bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        state = initialState;
        if (!state) {
          transform.Translate(0, -100, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void OnColorChange(bool val) {
      bool s;
      if (invert) s = !val;
      else s = val;
      
      if (!s && state) {
        transform.Translate(0, -100, 0);
      } else if (s && !state){
        transform.Translate(0, 100, 0);
      }
      state = s;
    }
}
