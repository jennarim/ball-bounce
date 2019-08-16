using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenuManager : MonoBehaviour
{
    public void PlayEasy()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayHard()
    {
        SceneManager.LoadScene(2);
    }
}
