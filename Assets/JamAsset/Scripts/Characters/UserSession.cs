using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "ScriptableObject", menuName = "UserSessionData", order = 1)]
[System.Serializable]
public class UserSession : ScriptableObject
{
    [SerializeField] private int m_Score;
    [SerializeField] private string m_UserName;
    [SerializeField] private int m_MaxLevel;

    public int Score
    {
        get
        {
            return m_Score;
        }

        set
        {
            if (value > m_Score)
            {
                m_Score = value;
            }
        }
    }

    public int MaxLevel
    {
        get
        {
            return m_MaxLevel;
        }

        set
        {
            if (value > m_MaxLevel)
            {
                m_MaxLevel = value;
            }
        }
    }

    public string UserName
    {
        get
        {
            return m_UserName;
        }

        set
        {
            m_UserName = value;
        }
    }

    public void ResetSession()
    {
        m_Score = 0;
        m_UserName = "";
        m_MaxLevel = 0;
    }

}
