using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawn : MonoBehaviour
{
  [Header("Main GameObjects")]
  public GameObject player; //Player Object, used to Get Color Monitor
  
  [Header("Light Settings")]
  public GameObject dirLight; //Directional Light
  public float lightMax;
  public float lightMin;
  public float lightTime;
  
  [Header("Gameobjects to Enable on Color Collection")]
  public List<GameObject> red = new List<GameObject>();
  public List<GameObject> blue = new List<GameObject>();
  public List<GameObject> green = new List<GameObject>();
  public List<GameObject> yellow = new List<GameObject>();
  
  [Header("Gameobjects to Create on Color Collection")]
  public List<GameObject> red_i = new List<GameObject>();
  public List<GameObject> blue_i = new List<GameObject>();
  public List<GameObject> green_i = new List<GameObject>();
  public List<GameObject> yellow_i = new List<GameObject>();
  
  private ColorMonitor color;
  private Light light;
  private bool redEnable = false;
  private bool blueEnable = false;
  private bool greenEnable = false;
  private bool yellowEnable = false;
  
    // Start is called before the first frame update
    void Start()
    {
        enableGroup(red, false);
        enableGroup(blue, false);
        enableGroup(green, false);
        enableGroup(yellow, false);
        
        if (player != null) color = player.GetComponent<ColorMonitor>();
        else print("Warning: Player GameObject is Null!");
        if (dirLight != null) light = dirLight.GetComponent<Light>();
        else print("Warning: Light is Null!");
    }

    // Update is called once per frame
    void Update()
    {
        if (color == null) print("Color is Null!");
        bool changed = false;
        if (!redEnable && color.red) {
          redEnable = true;
          enableGroup(red, true);
          instGroup(red_i);
          changed = true;
        }
        if (!blueEnable && color.blue) {
          blueEnable = true;
          enableGroup(blue, true);
          instGroup(blue_i);
          changed = true;
        }
        if (!greenEnable && color.green) {
          greenEnable = true;
          enableGroup(green, true);
          instGroup(green_i);
          changed = true;
        }
        if (!yellowEnable && color.yellow) {
          yellowEnable = true;
          enableGroup(yellow, true);
          instGroup(yellow_i);
          changed = true;
        }
        if (changed) {
          float val = Mathf.Lerp(lightMin, lightMax, getValue());
          print("Light Changed" + val);
          light.intensity = val;
        }
    }
    
    float getValue() {
      int val = 0;
      if (color.red) val++;
      if (color.green) val++;
      if (color.blue) val++;
      if (color.yellow) val++;
      return 1f - ((float) val / 4);
    }
    
    void enableGroup(List<GameObject> list, bool state) {
      foreach (GameObject go in list) {
        setEnable(go, state);
      }
    }
    
    void instGroup(List<GameObject> list) {
      foreach (GameObject go in list) {
        Instantiate(go, Vector3.zero, Quaternion.identity);
      }
    }
    
    void setEnable(GameObject go, bool state) {
      Renderer r = go.GetComponent<Renderer>();
      if (r != null) r.enabled = state;
      go.SetActive(state);
    }
    
    public void addSelf(ColorMonitor cm, GameObject go) {
      if (cm.red) {
        red.Add(go);
        if (!redEnable) {
          setEnable(go, false);
        }
      }
      if (cm.green) {
        green.Add(go);
        if (!greenEnable) {
          setEnable(go, false);
        }
      }
      if (cm.blue) {
        blue.Add(go);
        if (!blueEnable) {
          setEnable(go, false);
        }
      }
      if (cm.yellow) {
        yellow.Add(go);
        if (!yellowEnable) {
          setEnable(go, false);
        }
      }
      
    }
}
