using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", PathSetting.GetPath("path1"), "speed", 4.0f,"easeType", "easeQutQuint", "oncomplete", "destroy", "orienttopath", true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
