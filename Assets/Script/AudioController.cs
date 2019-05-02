using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
  public GameObject[] loopedMusicList;
  public GameObject[] unloopedMusicList;
  
  private int currPlaying = -1;
  private bool isConcurrent = false;
  private bool isLooped = false;
  
  private int prev = -1;
  private ColorMonitor color;
    // Start is called before the first frame update
    void Start()
    {
        startLoops();
        color = gameObject.GetComponent<ColorMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        if (color.blue) i++;
        if (color.yellow) i++;
        if (color.red) i++;
        if (color.green) i++;
        
        if (i != prev) {
          print("Set to " + i);
          if (i < 4) setMusic(true, false, i);
          else setMusic(false, false, 0);
          prev = i;
        }
    }
    
    public void startLoops() {
      foreach (GameObject go in loopedMusicList) {
        AudioSource a = go.GetComponent<AudioSource>();
        a.volume = 0f;
        a.Play();
      }
    }
    
    // Sets the Music
    public void setMusic(bool looped, bool concurrent, int index) {
      if (index < 0 || (looped && index >= loopedMusicList.Length)) {
        return;
      }
      if (index < 0 || (!looped && index >= unloopedMusicList.Length)) {
        return;
      }
      if (!concurrent && !isConcurrent && isLooped && currPlaying != -1) {
        loopedMusicList[currPlaying].GetComponent<AudioSource>().volume = 0.0f;
      } else if (!concurrent && !isConcurrent && !isLooped && currPlaying != -1) {
        unloopedMusicList[currPlaying].GetComponent<AudioSource>().volume = 0.0f;
      } else if (!concurrent && isConcurrent && looped && currPlaying != -1) {
        muteAll();
      }
      if (looped) {
        loopedMusicList[index].GetComponent<AudioSource>().volume = 1f;
        currPlaying = index;
      } else {
        unloopedMusicList[index].GetComponent<AudioSource>().volume = 1f;
        currPlaying = index;
      }
      isLooped = looped;
      isConcurrent = concurrent;
    }
    
    public void muteAll() {
       foreach (GameObject go in loopedMusicList) {
         go.GetComponent<AudioSource>().volume = 0f;
       }
       foreach (GameObject go in unloopedMusicList) {
         go.GetComponent<AudioSource>().Stop();
       }
       currPlaying = -1;
       isConcurrent = false;
       isLooped = false;
    }
}
