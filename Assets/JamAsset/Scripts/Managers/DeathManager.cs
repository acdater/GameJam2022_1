using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private static DeathManager deathManager;
    public static DeathManager Instance
    {
        get
        {
            if (deathManager == null)
            {
                deathManager = GameObject.FindObjectOfType<DeathManager>();

                if (deathManager == null)
                {
                    deathManager = new GameObject().AddComponent<DeathManager>();
                }
            }

            return deathManager;
        }
    }

    [SerializeField]
    private GameObject m_DefeatUI;

    public void Defeat()
    {
        m_DefeatUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

}
