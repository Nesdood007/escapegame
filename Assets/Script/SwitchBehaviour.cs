using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
  public GameObject[] toAlert = new GameObject[0]; //Gameobjects to alert of change
  public bool initialValue = false;
  public float aniTime = 1f;
  public float rotAmt = 90.0f;
  public float lightIntensity = 1.0f;
  
  private List<ColorTriggerResponse> ctr = new List<ColorTriggerResponse>();
  private float aniStartTime = -1f;
  private enum State {Moving, Idle};
  private State state = State.Idle;
  private bool val;
  private Light light;
  private AudioSource audio;
  private ColorMonitor color;
    // Start is called before the first frame update
    void Start()
    {
      light = gameObject.GetComponent<Light>();
      state = State.Moving;
      val  = initialValue;
      audio = gameObject.GetComponent<AudioSource>();
      color = gameObject.GetComponent<ColorMonitor>();
      foreach (GameObject go in toAlert) {
        ColorTriggerResponse c = go.GetComponent<ColorTriggerResponse>();
        if (c != null) {
          ctr.Add(c);
        }
      }
      if (val) {
        state = State.Moving;
        aniStartTime = Time.time;
      }
      notifyAll();
    }

    // Update is called once per frame
    void Update()
    {
      if (state == State.Moving) {
        float rot = ((Time.time - aniStartTime) / aniTime);
        if (rot > 1.0f) {
          state = State.Idle;
          rot = 1.0f;
        }
        if (!val) {
          rot = 1.0f - rot;
        }
        light.intensity = Mathf.Lerp(0f, lightIntensity, rot);
        gameObject.transform.rotation = Quaternion.Euler(Mathf.Lerp(0f, rotAmt, rot), 0f, 0f);
      }
    }
    
    // Uses Global Value to Set Value and Look
    void OnCollisionEnter(Collision col) {
      //print(col.gameObject.tag);
      if (col.gameObject.tag == "Player") {
        //Check Color
        ColorMonitor cm = col.gameObject.GetComponent<ColorMonitor>();
        if (color.blue && !cm.blue) return;
        if (color.red && !cm.red) return;
        if (color.green && !cm.green) return;
        if (color.yellow && !cm.yellow) return;
        
        val = !val;
        //print(val);
        state = State.Moving;
        aniStartTime = Time.time;
        audio.Play();
        notifyAll(); //This should be done in a new thread
      }
    }
    
    void notifyAll() {
      //print(ctr);
      foreach (ColorTriggerResponse c in ctr) {
        c.OnColorChange(val);
      }
    }
}
