using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
