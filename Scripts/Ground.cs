using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool mouseCheck = false;
    public int index = 0;

    private void OnMouseDown()
    {
        mouseCheck = true;
    }

    private void OnMouseUp()
    {
        mouseCheck = false;
    }
}
