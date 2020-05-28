using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoad : MonoBehaviour
{
   // GameManager gm = GameManager.Instance;

    private void Start()
    {
        GameManager.Instance.MapLoad("asd");
    }
}
