using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static int highScore;

    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public int tileRatio;
    public int comboRatio;

    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    private int currentScore;

    private int bonusTime;
    public Text bonusText;

    private void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
        bonusText.text = "";
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);

        SoundManager.Instance.PlayScore(comboCount > 1);
    }

    public void IncerementDuration(int tileCount, int comboCount)
    {
        //algoritma bonus time
        bonusTime = (comboCount-1)*3+tileCount-1;
        TimeManager.Instance.duration += bonusTime;
        StartCoroutine(setBonusText());
    }

    //menampilkan text ke ui
    IEnumerator setBonusText()
    {
        bonusText.text = "+" + bonusTime + "s";
        yield return new WaitForSeconds(2);
        bonusText.text = "";
    }

    public void SetHighScore()
    {
        highScore = currentScore;
    }
}
