using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOperator : MonoBehaviour
{
    [SerializeField] int level = 0;

    void Start(){}

    public void LoadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + level;
        Debug.Log(nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Wyjście!");
    }

}
