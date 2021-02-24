using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int points = 0;

    public Text scoreText;

    private void Start()
    {
        points = 0;
        scoreText.text = "" + points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        scoreText.text = "" + points;
    }
}
