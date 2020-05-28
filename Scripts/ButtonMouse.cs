using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMouse : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void EventOver()
    {
        ani.SetBool("Onmouse", true);
    }
    public void EventExit()
    {
        ani.SetBool("Onmouse", false);

    }
}
