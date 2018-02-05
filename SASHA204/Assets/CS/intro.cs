using UnityEngine;
using System;
using System.Collections;
using System.Net.Sockets;

public class intro : MonoBehaviour
{

		public GUISkin enter_skin, create_skin, two_p, three_p, four_p;
		int message_confirm = 0, i=0;

	void set_message_confirm()
	{
		message_confirm = 0;
		GameObject.Find ("room_full").GetComponent<SpriteRenderer> ().enabled = true;
		i = 1;
		}
	void Start()
	{
		GameObject.Find ("room_full").GetComponent<SpriteRenderer> ().enabled = false;
	}
	void Update()
	{
		if (GameObject.Find ("room_full").GetComponent<SpriteRenderer> ().enabled == true && i >= 1) {
			i++;
			if(i == 80)
			{
				i=0;
				GameObject.Find ("room_full").GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
		}

		void OnGUI ()
		{

				GUI.skin = two_p;
				if (GUI.Button (new Rect ((float)(Screen.width / 1.75), (float)(Screen.height / 1.55), Screen.width / 10, Screen.height / 10), "")) {
						Application.LoadLevel ("game");
			manage_static.maxplayer = 2;
						if (message_confirm == 0) {
						Debug.Log("보냄");
								GameObject.Find ("intro").SendMessage ("write_message", "room_create#2#" + manage_static.cn + "#" + manage_static.nick);
								message_confirm = 1;
						}
				
						two_p.button.normal.background = (Texture2D)Resources.Load ("None");
						three_p.button.normal.background = (Texture2D)Resources.Load ("None");
						four_p.button.normal.background = (Texture2D)Resources.Load ("None");

				}
				GUI.skin = three_p;
				if (GUI.Button (new Rect ((float)(Screen.width / 1.46), (float)(Screen.height / 1.55), Screen.width / 10, Screen.height / 10), "")) {
						Application.LoadLevel ("game");
			manage_static.maxplayer = 3;
						if (message_confirm == 0) {
				GameObject.Find ("intro").SendMessage ("write_message", "room_create#3#" + manage_static.cn + "#" + manage_static.nick);
								message_confirm = 1;
						}

						two_p.button.normal.background = (Texture2D)Resources.Load ("None");
						three_p.button.normal.background = (Texture2D)Resources.Load ("None");
						four_p.button.normal.background = (Texture2D)Resources.Load ("None");
				}
				GUI.skin = four_p;
				if (GUI.Button (new Rect ((float)(Screen.width / 1.25), (float)(Screen.height / 1.55), Screen.width / 10, Screen.height / 10), "")) {
						Application.LoadLevel ("game");
			manage_static.maxplayer = 4;
						if (message_confirm == 0) {
				GameObject.Find ("intro").SendMessage ("write_message", "room_create#4#" + manage_static.cn + "#" + manage_static.nick);
								message_confirm = 1;
						}

						two_p.button.normal.background = (Texture2D)Resources.Load ("None");
						three_p.button.normal.background = (Texture2D)Resources.Load ("None");
						four_p.button.normal.background = (Texture2D)Resources.Load ("None");
				}


				GUI.skin = enter_skin;
				if (GUI.Button (new Rect (Screen.width / 7, (float)(Screen.height / 2.7), Screen.width / 3, Screen.height / 4), "")) {
						if (message_confirm == 0) {
				GameObject.Find ("intro").SendMessage ("write_message", "room_enter##" + manage_static.cn + "#" + manage_static.nick);
								message_confirm = 1;
						}
		

				}


				GUI.skin = create_skin;
				if (GUI.Button (new Rect ((float)(Screen.width / 1.75), (float)(Screen.height / 2.7), Screen.width / 3, Screen.height / 4), "")) {
						two_p.button.normal.background = (Texture2D)Resources.Load ("2p");
						three_p.button.normal.background = (Texture2D)Resources.Load ("3p");
						four_p.button.normal.background = (Texture2D)Resources.Load ("4p");
				}
		}


}
