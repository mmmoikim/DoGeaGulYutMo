using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Appsetting : MonoBehaviour {
	private Camera _camera;

	void Start () {

		Screen.SetResolution(Screen.width, Convert.ToInt32 (Screen.width/1.777), false); 

		DontDestroyOnLoad (this);

		Application.runInBackground = true;
			
			if (Input.GetKey(KeyCode.Escape)) 
			{ 
				Application.Quit(); 
			} 
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
