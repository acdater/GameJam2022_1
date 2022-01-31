using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public LevelManager levelManager;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText();
        UpdateScoreText();
        UpdateLevelText();
    }

    private void UpdateTimeText()
    {
        int _time = levelManager.GetMaxLevelTime();
        timeText.text = _time.ToString();
    }

    private void UpdateScoreText()
    {
        int _score = levelManager.CalculateFinalScore();
        scoreText.text = "SCORE: " + _score.ToString();
    }

    private void UpdateLevelText()
    {
        int _level = levelManager.GetCurrentLevel();
        levelText.text = "LEVEL: " + _level.ToString();
    }


}
