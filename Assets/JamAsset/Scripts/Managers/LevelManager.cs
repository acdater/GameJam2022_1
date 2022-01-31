using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameLevel m_GameLevel;
    [SerializeField] private GameData m_GameData;
    [SerializeField] int m_CurrentLevel;
    [SerializeField] int m_CountOfSavings;
    [SerializeField] int m_CurrentScore;
    [SerializeField] UserSession m_CurrentUser;
    [SerializeField] float m_TimeCounter = 0;
    [SerializeField] float m_MaxLevelTime = 30; // seconds


    void Start()
    {
        m_CurrentLevel = m_GameLevel.level;
        m_CurrentUser = m_GameData.currentPlayerSession;
    }

    private void Update()
    {
        CountTimeOfLevel();
    }

    private void CountTimeOfLevel()
    {
        m_TimeCounter += Time.deltaTime;

        if (m_TimeCounter >= 1.0f)
        {
            m_MaxLevelTime -= m_TimeCounter;
            
            if (m_MaxLevelTime < 0)
            {
                m_MaxLevelTime = 0;

                WinManager.Instance.Win();
            }

            m_TimeCounter = 0;

        }
    }

    public int CalculateFinalScore()
    {
        m_CurrentScore = 2 * m_CurrentLevel + m_CountOfSavings;

        return m_CurrentScore;
    }



    public void UpdateUserSessionData()
    {
        if (m_CurrentUser != null)
        {
            m_GameData.UpdateUserSession(m_CurrentUser, m_CurrentLevel, CalculateFinalScore());
        }
    }

    public void AddSaving(int _val)
    {
        Debug.Log("Add: " + _val + " point to player!");
        m_CountOfSavings += _val;
    }

    public int GetMaxLevelTime()
    {
        return (int)m_MaxLevelTime;
    }

    public int GetCurrentLevel()
    {
        return m_CurrentLevel;
    }

    public void ResetScore()
    {
        m_CurrentScore = 0;
    }
}
