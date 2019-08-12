using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusesManager
{
    static StatusesManager _statusesManager;

    public static void init()
    {
        _statusesManager = new StatusesManager(
                GameObject.Find(StringConstants.SceneObjects.CanvasScore).GetComponent<Text>(),
                GameObject.Find(StringConstants.SceneObjects.CanvasHearths).GetComponent<Text>());
    }

    public static StatusesManager getInstance()
    {
        return _statusesManager;
    }

    Text txtScore;
    Text txtHearth;

    public static int Score;
    public static int Health;


    public StatusesManager(Text instScore, Text instHearth)
    {
        this.txtScore = instScore;
        this.txtHearth = instHearth;
    }

    public void UpdateUI(PlayerStats stats)
    {
        this.txtScore.text = stats.totalScore.ToString();
        this.txtHearth.text = stats.lives.ToString();
    }
}