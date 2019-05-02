using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeToDarkWorld : MonoBehaviour
{
  
  public string newSceneName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col) {
      if (col.gameObject.tag == "Player") {
        print("Player Found, Changing Scene...");
        SceneManager.LoadScene(newSceneName, LoadSceneMode.Single);
      }
    }
}
