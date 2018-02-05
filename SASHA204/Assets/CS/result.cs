using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.IO;

public class result : MonoBehaviour {

	public Sprite win_sp, lose_sp,BG_sp,grade_1_sp,grade_2_sp,grade_3_sp,grade_4_sp;
	public GUIText id_0,win_0,lose_0,winning_rate_0,
					id_1,win_1,lose_1,winning_rate_1,
					id_2,win_2,lose_2,winning_rate_2,
					id_3,win_3,lose_3,winning_rate_3;

	// Use this for initialization
	void Start () {

		id_0.text = "";
		win_0.text = "";
		lose_0.text = "";
		winning_rate_0.text = "";

		id_1.text = "";
		win_1.text = "";
		lose_1.text = "";
		winning_rate_1.text = "";

		id_2.text = "";
		win_2.text = "";
		lose_2.text = "";
		winning_rate_2.text = "";

		id_3.text = "";
		win_3.text = "";
		lose_3.text = "";
		winning_rate_3.text = "";
		
		GameObject.Find ("resultBG").GetComponent<SpriteRenderer> ().sprite = null;
		GameObject.Find ("result").GetComponent<SpriteRenderer> ().sprite = null;
		GameObject.Find ("result").GetComponent<BoxCollider2D> ().enabled = false;

		GameObject.Find ("1st").GetComponent<SpriteRenderer> ().sprite = grade_1_sp;
		GameObject.Find ("2st").GetComponent<SpriteRenderer> ().sprite = grade_2_sp;
		GameObject.Find ("3st").GetComponent<SpriteRenderer> ().sprite = grade_3_sp;
		GameObject.Find ("4st").GetComponent<SpriteRenderer> ().sprite = grade_4_sp;

		GameObject.Find ("1st").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("2st").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("3st").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("4st").GetComponent<SpriteRenderer> ().enabled = false;

	}

	void put_text(string [] temp)
	{
		id_0.text = temp[0];
		win_0.text = temp[1];
		lose_0.text = temp[2];
		if (temp [0] != " ") {
						double win = Convert.ToDouble (temp [1]);
						double lose = Convert.ToDouble (temp [2]);
						winning_rate_0.text = Math.Round((win / (win + lose) * 100),2).ToString () + "%";
				}
		id_1.text = temp[3];
		win_1.text = temp[4];
		lose_1.text = temp[5];
		if(temp[3] != " ")
		{
			double win = Convert.ToDouble (temp [4]);
			double lose = Convert.ToDouble (temp [5]);
			winning_rate_1.text = Math.Round((win / (win + lose) * 100),2).ToString () + "%";
			}
		id_2.text = temp[6];
		win_2.text = temp[7];
		lose_2.text = temp[8];
		if(temp[6] != " ")
		{
			double win = Convert.ToDouble (temp [7]);
			double lose = Convert.ToDouble (temp [8]);
			winning_rate_2.text = Math.Round((win / (win + lose) * 100),2).ToString () + "%";
		}
		
		id_3.text = temp[9];
		win_3.text = temp[10];
		lose_3.text = temp[11];
		if(temp[9] != " ")
		{
			double win = Convert.ToDouble (temp [10]);
			double lose = Convert.ToDouble (temp [11]);
			winning_rate_3.text= Math.Round((win / (win + lose) * 100),2).ToString () + "%";
		}
	}

	void win_on ()
	{
		GameObject.Find ("resultBG").GetComponent<SpriteRenderer> ().sprite = BG_sp;
		GameObject.Find ("result").GetComponent<SpriteRenderer> ().sprite = win_sp;
		GameObject.Find ("result").GetComponent<BoxCollider2D> ().enabled = true;

	}

	void lose_on ()
	{
		GameObject.Find ("resultBG").GetComponent<SpriteRenderer> ().sprite = BG_sp;
		GameObject.Find ("result").GetComponent<SpriteRenderer> ().sprite = lose_sp;
		GameObject.Find ("result").GetComponent<BoxCollider2D> ().enabled = true;

	}
	void player_grade_0(int grade)
	{
		GameObject.Find (grade + "st").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find (grade + "st").transform.localPosition = new Vector3(GameObject.Find ("character0").transform.localPosition.x,
		                                                                     GameObject.Find ("character0").transform.localPosition.y,
		                                                                     GameObject.Find ("character0").transform.localPosition.z-1);
		}
	void player_grade_1(int grade)
	{
		GameObject.Find (grade + "st").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find (grade + "st").transform.localPosition = new Vector3(GameObject.Find ("character1").transform.localPosition.x,
		                                                                     GameObject.Find ("character1").transform.localPosition.y,
		                                                                     GameObject.Find ("character1").transform.localPosition.z-1);
	}
	void player_grade_2(int grade)
	{
		GameObject.Find (grade + "st").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find (grade + "st").transform.localPosition = new Vector3(GameObject.Find ("character2").transform.localPosition.x,
		                                                                     GameObject.Find ("character2").transform.localPosition.y,
		                                                                     GameObject.Find ("character2").transform.localPosition.z-1);
	}
	void player_grade_3(int grade)
	{
		GameObject.Find (grade + "st").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find (grade + "st").transform.localPosition = new Vector3(GameObject.Find ("character3").transform.localPosition.x,
		                                                                     GameObject.Find ("character3").transform.localPosition.y,
		                                                                     GameObject.Find ("character3").transform.localPosition.z-1);
	}

	// Update is called once per frame
	void Update () {
		if (click_event ()) {

			GameObject.Find ("intro").SendMessage ("write_message","quit#" + manage_static.room_num + "#" + manage_static.turn);
			GameObject.Find ("result").SendMessage ("static_init");
			Application.LoadLevel ("intro");
		}
	
	}

	void static_init()
	{
		manage_static.read_data.Clear ();
		manage_static.room_num = -1;
		manage_static.turn = -1;
		manage_static.grade = 0;
		manage_static.curr_turn = 0;
		manage_static.maxplayer = 0;
		manage_static.mal_state = new int[] {0,0,0,0};
		manage_static.mal0_index = new int[]{0,0};
		manage_static.mal1_index = new int[]{0,1};
		manage_static.mal2_index = new int[]{0,2};
		manage_static.mal3_index = new int[]{0,3};
		manage_static.dice.Clear();
		manage_static.guide_list.Clear();
		manage_static.turn_posit.Clear ();
		manage_static.last_yut = -2;
		
	}


	private bool click_event ()
	{
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit;
				hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				
				if (hit.collider) {
					string click_obj = hit.collider.name; 
					if (true == click_obj.Equals (gameObject.name)) {
						
						return true;
					}
				}
			}

		return false;
	}
}
