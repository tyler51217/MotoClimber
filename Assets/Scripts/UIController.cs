using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TMP_Text minutesText;
    public TMP_Text secondsText;
    public TMP_Text millisecondsText;
    private float minutesTimer;
    private float secondsTimer;
    private float millisecondsTimer;


    public TMP_Text scoreText;
    public static int scoreInt;
    public static Action onAddScore;
    public static bool alive;

    public RectTransform winPanelTransform;
    public TMP_Text winTimeText;
    private bool youWin = false;

    private void Start()
    {
        onAddScore += addScore;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        if (youWin)
        {
            Vector3 fastTarget = new Vector3(10f, 1.5f);
            float targetTime = 0.1f;
            Vector3 velocity = Vector3.zero;
            Vector3 targetPosition = new Vector3(322, 181.5f, 0);
            winPanelTransform.transform.position = Vector3.SmoothDamp(winPanelTransform.transform.position, targetPosition, ref velocity, targetTime);
        }
    }

    

    public void addScore()
    {
        scoreInt += 1;
        scoreText.text = scoreInt.ToString();
        if(scoreInt == 50)
        {
            Debug.Log("you win");
            winTimeText.text = minutesText.text + secondsText.text + "." + millisecondsText.text;
            youWin = true;
            
        }
    }

    public void updateTimer()
    {
        if (!alive)
        {
            return;
        }

        millisecondsTimer += Time.deltaTime;

        if (millisecondsTimer >= 1)
        {
            millisecondsTimer -= 1;
            secondsTimer += 1;
        }
        if (secondsTimer >= 60)
        {
            secondsTimer -= 60;
            minutesTimer += 1;
        }

        millisecondsText.text = millisecondsTimer.ToString().Remove(0, 2);
        millisecondsText.text = millisecondsText.text.Remove(3);

        if (secondsTimer < 10)
        {
            secondsText.text = secondsTimer.ToString().Insert(0, "0");
        }
        else
        {
            secondsText.text = secondsTimer.ToString();
        }
        if (minutesTimer < 10)
        {
            minutesText.text = minutesTimer.ToString().Insert(0, "0") + ":";
        }
        else
        {
            minutesText.text = minutesTimer.ToString() + ":";
        }
    }

    private void OnDestroy()
    {
        onAddScore -= addScore;
    }
}
