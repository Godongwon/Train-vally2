﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneGo : MonoBehaviour
{
    public void StartSceneChange()
    {
        SceneManager.LoadScene("StartScene");
    }
}
