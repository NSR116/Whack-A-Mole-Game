using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float gameTime = 5;
    private float duration = 0f;
    private int score = 0;
    [SerializeField] private Mole []arrayMoles;
    [SerializeField] private float timeShow = 3f;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text totalPoint;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject theEnd;

    private void Start()
    {
        for(int i=0; i<arrayMoles.Length; i++)
        {
            arrayMoles[i].MoleClicked += setScore;
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        duration += Time.deltaTime;

        setTime(gameTime);

        if (gameTime <= 0)
        {
            setTime(0);
            endGame();
            return;
        }

        if(duration > timeShow)
        {
            duration = 0f;
            popUp();
        }
    }

    private void popUp()
    {
        for (int i = 0; i < arrayMoles.Length; i++)
        {
            int index = Random.Range(0, arrayMoles.Length);

            if (arrayMoles[index].Hides)
            {
                arrayMoles[index].Hides = false;          
            }
            else
            {
                arrayMoles[index].Hides = true;
            }
        }
    }

    private void setScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }

    private void setTime(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", min, sec); 
    }

    private void endGame()
    {
        totalPoint.text = score.ToString()+" Points";
        theEnd.SetActive(true);
        //LeanTween.scale(theEnd, new Vector3(4.539007f, 4.539007f, 4.539007f), 0.3f).setOnCompelete();
        
    }

}
