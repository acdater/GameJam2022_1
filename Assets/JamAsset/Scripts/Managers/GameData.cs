using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "GameSessionData", order = 2)]
[System.Serializable]
public class GameData : ScriptableObject
{
    public List<UserSession> usersBoard = new List<UserSession>();
    public UserSession currentPlayerSession;

    public void RegisterUserSession(UserSession us)
    {
        foreach (var _user in usersBoard)
        {
            if (us.UserName.CompareTo(_user.UserName) == 0)
            {
                return;
            }
        }

        usersBoard.Add(us);
    }

    public void RemoveUserSession(UserSession us)
    {
        foreach (var _user in usersBoard)
        {
            if (us.UserName.CompareTo(_user.UserName) == 0)
            {
                if (currentPlayerSession.UserName == us.UserName)
                {
                    currentPlayerSession = null;
                }

                usersBoard.Remove(_user);

                if (usersBoard.Count > 0)
                    currentPlayerSession = usersBoard[0];
            }
        }

    }

    public void DeleteUserSession(UserSession _user)
    {
        foreach (var _u in usersBoard)
        {
            if (_u.UserName == _user.UserName)
            {
                Debug.Log(_user.name + " - adlready delted");

                usersBoard.Remove(_u);
            }
        }
    }

    public void UpdateUserSession(UserSession _user, int _sessionLvl, int _sessionScore)
    {
        foreach (var _u in usersBoard)
        {
            if (_u.UserName == _user.UserName)
            {
                _u.MaxLevel = _sessionLvl;
                _u.Score = _sessionScore;
            }
        }
    }

    public void SetCurrentPlayer(string _uName)
    {
        foreach (var _u in usersBoard)
        {
            if (_u.UserName == _uName)
            {
                currentPlayerSession = _u;
            }
        }
    }
}
