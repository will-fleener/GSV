using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreTextEditor : MonoBehaviour {
    public UnityEngine.UI.Text highScore;
    public UnityEngine.UI.Text yourScore;
    public UnityEngine.UI.Text yourScoreLabel;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore.text = PlayerPrefs.GetInt("highScore").ToString();
        }
        else
        {
            highScore.text = "0";
        }

        if (PlayerPrefs.HasKey("lastScore"))
        {
            yourScore.text = PlayerPrefs.GetInt("lastScore").ToString();
            if(PlayerPrefs.GetInt("lastScore") >= PlayerPrefs.GetInt("highScore"))
            {
                yourScore.color = new Color(1.0f, 0.0f, 0.5f);
                yourScoreLabel.color = new Color(1.0f, 0.0f, 0.5f);
            }
        }
        else
        {
            yourScore.text = "0";
        }
    }

}
