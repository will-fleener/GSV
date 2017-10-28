using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToOptions : MonoBehaviour {

    public Canvas optionsMenu;
    public Button optionsButton;
    public Button startButton;
    public Button returnToMainMenu;
    public Button muteButton;

	// Use this for initialization
	void Start () {
        optionsMenu = optionsMenu.GetComponent<Canvas> ();
        optionsMenu.enabled = false;
        returnToMainMenu = returnToMainMenu.GetComponent<Button>();
        returnToMainMenu.enabled = false;

        optionsButton = optionsButton.GetComponent<Button>();
        startButton = startButton.GetComponent<Button>();

        muteButton = optionsMenu.GetComponent<Button>();
	}

    public void optionsPress()
    {
        optionsMenu.enabled = true;
        optionsButton.enabled = false;
        startButton.enabled = false;
        returnToMainMenu.enabled = true;
    }

    public void returnToMain()
    {
        optionsMenu.enabled = false;
        optionsButton.enabled = true;
        startButton.enabled = true;
        returnToMainMenu.enabled = false;
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
