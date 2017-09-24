using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	bool Message;

	// Use this for initialization
	void Start () {
		print("Game Start~!");
		Message = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3 && Message == false) {
			print("It has been three seconds! uwu");
			Message = true;
			}

	}
}
