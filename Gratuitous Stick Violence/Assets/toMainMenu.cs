using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class toMainMenu : MonoBehaviour {
   private Button _btn;
    // Use this for initialization
    void Start () {
        _btn = this.GetComponent<Button>();
        _btn.onClick.AddListener(goToMainMenu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
     void goToMainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
     void printStuff()
    {
        print("stuff");
    }
}
