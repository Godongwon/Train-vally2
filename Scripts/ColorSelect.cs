using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelect : MonoBehaviour
{
    public bool onMouse = false;

    public void change()
    {
        onMouse = !onMouse;
    }
}
