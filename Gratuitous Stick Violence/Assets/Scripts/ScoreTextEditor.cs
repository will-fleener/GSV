using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextEditor : MonoBehaviour {
    private UnityEngine.UI.Text score;
    // Use this for initialization
    void Start () {
        score = GetComponent<UnityEngine.UI.Text>();
        if (PlayerPrefs.HasKey("highScore"))
        {
            changeText(PlayerPrefs.GetInt("highScore").ToString());
        }
        else
        {
            changeText("0");
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void changeText(string text)
    {
        score.text = text;
    }
}
