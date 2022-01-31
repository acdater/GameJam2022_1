using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RegisterForm : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] private int m_IndexToRegister;
    [SerializeField] private MainMenuManager m_MenuManager;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterName()
    {
        if (inputField.text != string.Empty)
        {
            m_MenuManager.availableSessions[m_IndexToRegister].UserName = inputField.text;
            m_MenuManager.m_GameData.usersBoard.Add(m_MenuManager.availableSessions[m_IndexToRegister]);
        }
    }

    public void SetIndex(int _idx)
    {
        m_IndexToRegister = _idx;
    }
}
