using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMouseClick : MonoBehaviour
{
    public bool onMouse = false;

    private void OnMouseDown()
    {
        onMouse = !onMouse;
    }
}
