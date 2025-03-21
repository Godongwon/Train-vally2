﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    public void GameSceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MapToolSceneChange()
    {
        SceneManager.LoadScene("Maptool");
    }


    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
