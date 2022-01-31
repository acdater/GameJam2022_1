using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private static WinManager winManager;
    public static WinManager Instance
    {
        get
        {
            if (winManager == null)
            {
                winManager = GameObject.FindObjectOfType<WinManager>();

                if (winManager == null)
                {
                    winManager = new GameObject().AddComponent<WinManager>();
                }
            }

            return winManager;
        }
    }

    [SerializeField]
    private GameObject m_WinUIPanel;

    public void Win()
    {
        m_WinUIPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
