using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSelfToColorManager : MonoBehaviour
{
  [Header("Color Manager")]
  public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        ColorSpawn cs = go.GetComponent<ColorSpawn>();
        ColorMonitor cm = gameObject.GetComponent<ColorMonitor>();
        
        cs.addSelf(cm, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
