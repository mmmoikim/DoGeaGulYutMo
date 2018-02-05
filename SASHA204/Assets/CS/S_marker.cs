using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_marker : MonoBehaviour
{
		private SpriteRenderer sprite_rander;
	public Sprite marker_img,cancel_sp;
		private string click_marker;
		private int first_check = 0;

		// Use this for initialization
		void Start ()
		{
				sprite_rander = this.gameObject.GetComponent<SpriteRenderer> ();
				sprite_rander.sprite = null;

		GameObject.Find ("cancel").GetComponent<SpriteRenderer> ().sprite = cancel_sp;
		GameObject.Find ("cancel").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("cancel").GetComponent<BoxCollider2D> ().enabled = false;
		
	}

	void cancel_bt_off()
	{
		GameObject.Find ("cancel").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("cancel").GetComponent<BoxCollider2D> ().enabled = false;
	}

		public void marker_on (string marker)
		{
				GameObject.Find (marker).gameObject.GetComponent<SpriteRenderer> ().sprite = marker_img;
				GameObject.Find (marker).gameObject.GetComponent<BoxCollider2D> ().enabled = true;


	}

		public void marker_off (string marker)
		{
		GameObject.Find (marker).gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		GameObject.Find (marker).gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		
	}

		public void marker_all_off ()
		{
				for (int i=0; i<4; i++) {
						GameObject.Find ("S_marker" + i).gameObject.GetComponent<SpriteRenderer> ().sprite = null;
						GameObject.Find ("S_marker" + i).gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				}
	}

		public void marker_set_position ()
		{

	
				for (int i=0; i<4; i++) {
						if (manage_static.mal_state [i] == 0
								|| manage_static.mal_state [i] == 1
								|| manage_static.mal_state [i] == 2) {

								GameObject.Find ("S_marker" + i).transform.localPosition = 
								new Vector3 (GameObject.Find ("mal" + manage_static.turn + "_" + i).transform.position.x,
					             (float)(GameObject.Find ("mal" + manage_static.turn + "_" + i).transform.position.y + 1), -6);

								marker_on ("S_marker" + i);
						}
				}
		}

		void Update ()
		{

				if (click_event ()) {

			GameObject.Find ("cancel").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("cancel").GetComponent<BoxCollider2D> ().enabled = true;

			Debug.Log ("클릭한 S 마커 : " + click_marker);
						manage_static.guide_list = route (click_marker);

						Debug.Log ("다이스 수 : " + manage_static.dice.Count);
						Debug.Log ("가이드 수  : " + manage_static.guide_list.Count);

						marker_all_off ();

						GameObject.Find ("Gmarker").SendMessage ("get_mal_name", click_marker);//클릭한 S마커의 말 이름 이져오기

						GameObject.Find ("Gmarker").SendMessage ("set_guide");
				}
		if(click_cancel())
		{
			GameObject.Find ("Gmarker").SendMessage("G_marker_destroy");
			GameObject.Find ("cancel").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("cancel").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("GoalBtn").GetComponent<SpriteRenderer> ().enabled = false;
			marker_set_position();
		}
	}

	private bool click_cancel ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			
			if (hit.collider) {
				string temp = hit.collider.name; 
				if (true == temp.Equals ("cancel")) {
					return true;
					
				}
			}
		}
		return false;
	}

	
	private bool click_event ()
	{
		if (Input.GetMouseButtonDown (0)) {
						RaycastHit2D hit;
						hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				
						if (hit.collider) {
								click_marker = hit.collider.name; 
								if (true == click_marker.Equals (gameObject.name)) {
										return true;
										
								}
						}
				}
				return false;
		}

		List<int []> route (string click_marker)
		{
				int[] ori_index = new int[]{-1,-1};
		int[] clicked_index = new int[]{-1,-1};

				List<int []> guide_index_list = new List<int[]> ();
				

				switch (click_marker) {
				case "S_marker0": 
			ori_index = manage_static.mal0_index;
						break;
				case "S_marker1": 
			ori_index = manage_static.mal1_index;
						break;
				case "S_marker2": 
			ori_index = manage_static.mal2_index;
						break;
				case "S_marker3": 
			ori_index = manage_static.mal3_index;
						break;
				}

		if (ori_index [0] == 0) {
						clicked_index [0] = 1;
						clicked_index [1] = 0;
				} else {
			clicked_index [0] = ori_index [0];
			clicked_index [1] = ori_index [1];
				}

				Debug.Log ("움직일 인덱트 : " + clicked_index [0] + "," + clicked_index [1]);


				for (int i=0; i<manage_static.dice.Count; i++) {
						int[] guide_index = new int[]{-1,-1};
						Debug.Log ("다이스 : " + manage_static.dice [i]);

			if(manage_static.dice [i] == -1) //백도
			{
				if(clicked_index [0] == 0)//턴 바꾸기
				{
					guide_index [0] = clicked_index [0];
					guide_index [1] = clicked_index [1];
				}
				else if (clicked_index [0] == 1 && clicked_index [1] == 0)
				{
					guide_index [0] = 4;
					guide_index [1] = 4;
				}
				else if (clicked_index [0] == 2 && clicked_index [1] == 0)
				{
					guide_index [0] = 1;
					guide_index [1] = 4;
				}
				else if (clicked_index [0] == 3 && clicked_index [1] == 0)
				{
					guide_index [0] = 2;
					guide_index [1] = 4;
				}
				else if (clicked_index [0] == 4 && clicked_index [1] == 0)
				{
					guide_index [0] = 3;
					guide_index [1] = 4;
				}
				else if (clicked_index [0] == 5 && clicked_index [1] == 0)
				{
					guide_index [0] = 2;
					guide_index [1] = 0;
				}
				else if (clicked_index [0] == 6 && clicked_index [1] == 0)
				{
					guide_index [0] = 3;
					guide_index [1] = 0;
				}
				else
				{
					guide_index [0] = clicked_index [0];
					guide_index [1] = clicked_index [1] - 1;
				}
			}
			else
			{
						if (clicked_index [0] == 3 && clicked_index [1] == 0) {//1
								guide_index [0] = 6;
								guide_index [1] = manage_static.dice [i] - 1;
						} else if (clicked_index [0] == 4 && (clicked_index [1] + manage_static.dice [i]) >= 6) {
								guide_index [0] = 7;//골인
				guide_index [1] = 0;
						} else if (clicked_index [0] == 2 && clicked_index [1] == 0) {//2
								guide_index [0] = 5;
								guide_index [1] = manage_static.dice [i] - 1;
						} else if (clicked_index [0] == 1 && clicked_index [1] == 0 && ori_index[0] != 0) {//3
									
								guide_index [0] = 7;//골인
								guide_index [1] = 0;
				}else if (clicked_index [0] == 6 && (clicked_index [1] + manage_static.dice [i]) >= 6) {//3
						
						guide_index [0] = 7;//골인
						guide_index [1] = 0;
				} else if (clicked_index [0] == 5) {						//4
								if (clicked_index [0] == 5 && clicked_index [1] == 2) {
										if (manage_static.dice [i] > 4) {
												guide_index [0] = 7;
												guide_index [1] = 0;
										} else {
												switch (manage_static.dice [i]) {
												case 1:
														guide_index [0] = 6;
														guide_index [1] = 3;
														break;
												case 2:
														guide_index [0] = 6;
														guide_index [1] = 4;
														break;
												case 3:
														guide_index [0] = 1;
														guide_index [1] = 0;
														break;
												}
										}
								} else if ((clicked_index [1] + manage_static.dice [i]) > 4) {
										guide_index [1] = clicked_index [1] + manage_static.dice [i] - 5;
										guide_index [0] = clicked_index [0] - 1;
								} else {
										guide_index [1] = clicked_index [1] + manage_static.dice [i];
										guide_index [0] = clicked_index [0];
								}
						} else {													//5
								if (clicked_index [0] == 1 && clicked_index [1] == 0 && ori_index[0] == 0)
										first_check++;

								if ((clicked_index [1] + manage_static.dice [i]) > 4) {
										guide_index [1] = clicked_index [1] + manage_static.dice [i] - 5;
										guide_index [0] = clicked_index [0] + 1;

										if (guide_index [0] == 5 && guide_index [1] == 0) {
												guide_index [0] = 1;
										} else if (guide_index [0] == 7 && guide_index [1] == 0) {
												guide_index [0] = 1;
										}
								} else {
										guide_index [1] = clicked_index [1] + manage_static.dice [i];
										guide_index [0] = clicked_index [0];

								}
						}
			}
						guide_index_list.Add (guide_index);
					
				}
				return guide_index_list;
		}
}
