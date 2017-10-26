using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToOptions : MonoBehaviour {

    private Button btn;

	// Use this for initialization
	void Start () {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(showOptionsMenu);
        		
	}
	
    void showOptionsMenu ()
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
