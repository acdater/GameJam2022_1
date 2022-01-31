using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameData m_GameData;
    public GameLevel m_GameLvl;

    [SerializeField]
    private GameObject m_DeleteButton;
    [SerializeField]
    private GameObject m_RegisterForm;
    public Button[] playersUIButtons = new Button[7];
    public UserSession[] availableSessions = new UserSession[7];


    // Start is called before the first frame update
    void Start()
    {
        UpdateDataFromGame();
    }

    private void Update()
    {
        UpdateButtons();
        UpdateButtonsText();
    }

    public void SelectUserButton(int _idx)
    {
        MenuAudioManager.Instance.PlayClickSound();

        if (availableSessions[_idx].UserName != string.Empty)
        {
            m_GameData.currentPlayerSession = availableSessions[_idx];
            m_DeleteButton.transform.position = new Vector3(
                m_DeleteButton.transform.position.x,
                playersUIButtons[_idx].gameObject.transform.position.y,
                m_DeleteButton.transform.position.z);
        }
        else
        {
            m_RegisterForm.SetActive(true);
            m_RegisterForm.GetComponent<RegisterForm>().SetIndex(_idx);
        }
    }

    public void RemovePlayer()
    {
        MenuAudioManager.Instance.PlayClickSound();

        for (int i=0; i<availableSessions.Length; i++)
        {
            if (availableSessions[i].UserName == m_GameData.currentPlayerSession.UserName)
            {
                availableSessions[i].ResetSession();
            }
        }

        m_GameData.RemoveUserSession(m_GameData.currentPlayerSession);
    }

    public void LoadGame()
    {
        MenuAudioManager.Instance.PlayClickSound();

        if (m_GameData.currentPlayerSession == null)
        {
            if (m_GameData.usersBoard.Count > 0)
            {
                m_GameData.currentPlayerSession = m_GameData.usersBoard[0];
            }
            else
            {
                return;
            }
        }
        m_GameLvl.level = 0;
        SceneManager.Instance.LoadGameScene();
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    private void UpdateButtonsText()
    {
        for (int i=0; i<availableSessions.Length; i++)
        {
            if (availableSessions[i].UserName != string.Empty && playersUIButtons[i] != null)
            {
                playersUIButtons[i].GetComponentInChildren<TMP_Text>().text =
                    availableSessions[i].UserName + ": " + availableSessions[i].Score;
            }
        }
    }

    private void UpdateButtons()
    {
        foreach(var button in playersUIButtons)
        {
            button.gameObject.SetActive(false);
        }

        for (int i = 0; i < availableSessions.Length; i++)
        {
            if (availableSessions[i].UserName != string.Empty && playersUIButtons[i] != null)
            {
                playersUIButtons[i].gameObject.SetActive(true);
            }
            else if (availableSessions[i].UserName == string.Empty && playersUIButtons[i] != null)
            {
                playersUIButtons[i].gameObject.SetActive(true);

                playersUIButtons[i].GetComponentInChildren<TMP_Text>().text =
                    "Create new player...";
                return;
            }
        }
    }



    private void UpdateDataFromGame()
    {
        if (m_GameData.usersBoard.Count > 0)
        {
            foreach(var _user in m_GameData.usersBoard)
            {
                foreach(var _aSession in availableSessions)
                {
                    if (_aSession.UserName == _user.UserName)
                    {
                        _aSession.MaxLevel = _user.MaxLevel;
                        _aSession.Score = _user.Score;
                    }
                }
            }
        }
    }

    
}
