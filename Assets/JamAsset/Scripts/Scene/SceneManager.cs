using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager sceneManager;

    public static SceneManager Instance
    {
        get
        {
            if (sceneManager == null)
            {
                sceneManager = GameObject.FindObjectOfType<SceneManager>();

                if (sceneManager == null)
                {
                    sceneManager = new GameObject().AddComponent<SceneManager>();
                }
            }

            return sceneManager;
        }
    }

    public LevelManager levelManager;
    public GameLevel m_GameLevel;

    public void ReloadScene()
    {
        levelManager.UpdateUserSessionData();
        m_GameLevel.level = 0;
        levelManager.UpdateUserSessionData();

        int _curSceneIdx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(_curSceneIdx);

        Time.timeScale = 1.0f;
    }

    public void LoadGameScene()
    {
        int sceneIdx = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIdx);

        Time.timeScale = 1.0f;
    }

    public void LoadSceneUnderNum(int _idx)
    {
        levelManager.UpdateUserSessionData();
        UnityEngine.SceneManagement.SceneManager.LoadScene(_idx);

    }

    public void LoadNextRandomGameScene()
    {
        m_GameLevel.level += 1;
        int _idx = Random.Range(1,5);
        levelManager.UpdateUserSessionData();
        UnityEngine.SceneManagement.SceneManager.LoadScene(_idx);

        Time.timeScale = 1.0f;
    }

}
