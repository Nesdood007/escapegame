using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingFrequency : MonoBehaviour
{
  public bool enablePings = false;
  public float delta = 3f;
  private float nextTime = 0f;
  private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enablePings && nextTime < Time.time) {
          audio.Play();
          nextTime = Time.time + delta;
        }
    }
}
