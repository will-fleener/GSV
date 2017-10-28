using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOverlay : MonoBehaviour {
    private UnityEngine.UI.Text text;
    public GameObject player;
    public PlayerCharacterControl pcc;

	// Use this for initialization
	void Start () {
        text = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = player.GetComponent<PlayerCharacterControl>()._score.ToString();
	}
}
