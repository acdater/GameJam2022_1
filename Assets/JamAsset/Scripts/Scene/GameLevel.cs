using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "GameLevelData", order = 3)]
public class GameLevel : ScriptableObject
{
    public int level;
}
