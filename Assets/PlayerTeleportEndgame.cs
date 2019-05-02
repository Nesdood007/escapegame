using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTeleportEndgame : MonoBehaviour
{
  public bool activated = false;
  public string newSceneName = "";
  private ColorMonitor color;
  
  public Text textColors;
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<ColorMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (color.green && color.red && color.blue && color.yellow) {
          SceneManager.LoadScene(newSceneName, LoadSceneMode.Single);
        }
        
        string text = "Colors Collected:";
        if (color.green) {
          text = text + " Green";
        }
        if (color.red) {
          text = text + " Red";
        }
        if (color.blue) {
          text = text + " Blue";
        }
        if (color.yellow) {
          text = text + " Yellow";
        }
        if (textColors != null) {
          textColors.text = text;
        }
    }
}
