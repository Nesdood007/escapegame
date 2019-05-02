using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnemies : MonoBehaviour
{
  public GameObject prefab = null;
  public int amount = 100;
    // Start is called before the first frame update
    void Start()
    {
      if (prefab != null) {
        for (int i = 0 ; i < amount; i++) {
          Instantiate(prefab, new Vector3(Mathf.Lerp(100.0f, 400.0f, Random.value), 1.0f, Mathf.Lerp(100.0f, 400.0f, Random.value)), Quaternion.identity);
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
