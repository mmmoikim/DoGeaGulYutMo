using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class G_marker : MonoBehaviour
{
		private SpriteRenderer sprite_rander;
		public Sprite marker_img, goalin_img, do_img,gea_img,gul_img,yut_img,mo_img,Bdo_img;
		private string click_marker;
		private int mal_num = -1;
		private List<GameObject> gmarker;

		// Use this for initialization
		void Start ()
		{

				gmarker = new List<GameObject> ();
		GameObject.Find ("GoalBtn").GetComponent<SpriteRenderer> ().sprite = goalin_img;
		GameObject.Find ("GoalBtn").GetComponent<SpriteRenderer> ().enabled  = false;
		

		
		}

		public void get_mal_name (string temp)
		{
				Debug.Log ("클릭한 마커 이름 : " + temp);
				switch (temp) {
				case "S_marker0":
						mal_num = 0;
						break;
				case "S_marker1":
						mal_num = 1;
						break;
				case "S_marker2":
						mal_num = 2;
						break;
				case "S_marker3":
						mal_num = 3;
						break;
				}

		}

		public void marker_on (string marker)
		{
				GameObject.Find (marker).gameObject.GetComponent<SpriteRenderer> ().sprite = marker_img;
		}
	
		public void marker_off (string marker)
		{
				GameObject.Find (marker).gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		}

	public void G_marker_destroy()
	{
		
		for (int i=0; i<gmarker.Count; i++) {
			Destroy (gmarker [i]);
		}
		gmarker.Clear ();

	}
	
	public void set_guide ()
		{
	
				for (int i = 0; i<manage_static.guide_list.Count; i++) {

			if (manage_static.guide_list [i] [0] >= 7 || manage_static.guide_list [i] [1] == -1) {
				GameObject.Find ("GoalBtn").GetComponent<SpriteRenderer>().sprite = goalin_img;
				GameObject.Find ("GoalBtn").GetComponent<SpriteRenderer> ().enabled  = true;

				Debug.Log ("가이드 0 :" + manage_static.guide_list [i] [0] +
				           "가이드 0 :" + manage_static.guide_list [i] [1] + "mal : " + mal_num);
						} else {
								Debug.Log ("가이드 0 :" + manage_static.guide_list [i] [0] +
										"가이드 0 :" + manage_static.guide_list [i] [1]);

								GameObject marker = new GameObject ();
								marker.gameObject.transform.localScale = new Vector3 ((float)2.2, (float)2.2);

								marker.gameObject.transform.localPosition 
								= manage_static.pan_array [manage_static.guide_list [i] [0]] [manage_static.guide_list [i] [1]];

								marker.AddComponent<SpriteRenderer> ();

								switch(manage_static.dice[i])
								{
								case -1:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = Bdo_img;
									break;
								case 1:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = do_img;
									break;
								case 2:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = gea_img;
									break;
								case 3:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = gul_img;
									break;
								case 4:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = yut_img;
									break;
								case 5:
									marker.gameObject.GetComponent<SpriteRenderer> ().sprite = mo_img;
									break;
								}

								marker.AddComponent<BoxCollider2D> ();
								marker.gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)0.32, (float)0.5);
								marker.gameObject.GetComponent<BoxCollider2D> ().center = new Vector2 ((float)0, (float)-0.15);

								marker.name = "G_marker_" + i;
				
								gmarker.Add (marker);




			

						}
				}
				
		}

		private int click_event ()
		{
				if (Input.GetMouseButtonDown (0)) {
						RaycastHit2D hit;
						hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
						if (hit.collider) {
								click_marker = hit.collider.name; 
								for (int i=0; i<gmarker.Count; i++) {
										if (true == click_marker.Equals ("G_marker_" + i)) {
												return 1;
										}
								}
								if (true == click_marker.Equals ("GoalBtn")) {
					GameObject.Find("S_marker0").SendMessage("marker_all_off");
					if(mal_num == -1)
					{
						return 0;
					}
												return 2;

										

								}

						}
				}
				return 0;
		}
		// Update is called once per frame
		void Update ()
		{
				if (click_event () == 1) {

						marker_off (click_marker);

						Debug.Log (click_marker);

						Vector3 searchindex = new Vector3 (GameObject.Find (click_marker).gameObject.transform.localPosition.x,
			                                  GameObject.Find (click_marker).gameObject.transform.localPosition.y,
			                                  GameObject.Find (click_marker).gameObject.transform.localPosition.z);

						Debug.Log (searchindex);

						int index_0 = -1, index_1 = -1;

						for (int i=1; i<8; i++) {
								index_1 = manage_static.pan_array [i].IndexOf (searchindex);//지금 클릭한 좌표 인덱스 찾기

								if (index_1 != -1) {
										index_0 = i;
										break;
								}
						}

						Debug.Log (index_0 + " , " + index_1);

			int remove_index = -1;

			for (int i=0; i<manage_static.guide_list.Count; i++) {//지금 클릭한 좌표 가이드 리스트에서 찾기
				Debug.Log ("glist : " + manage_static.guide_list [i] [0] + " , " + manage_static.guide_list [i] [1]);
				if (manage_static.guide_list [i] [0] == index_0 && manage_static.guide_list [i] [1] == index_1)
					remove_index = i;
			}
			int dice = manage_static.dice[remove_index];
			
			
			if (mal_num == 0) {
								manage_static.mal0_index = new int[]{index_0, index_1};
				manage_static.mal_state[0] = 1;
						} else if (mal_num == 1) {
								manage_static.mal1_index = new int[]{index_0, index_1};
				manage_static.mal_state[1] = 1;
						} else if (mal_num == 2) {
								manage_static.mal2_index = new int[]{index_0, index_1};
				manage_static.mal_state[2] = 1;
						} else if (mal_num == 3) {
								manage_static.mal3_index = new int[]{index_0, index_1};
				manage_static.mal_state[3] = 1;
						} else {
								Debug.Log ("말 인텍스 옮기기 실패");
						}
				
						int hand = hand_over (index_0, index_1);

						for (int i=0; i<gmarker.Count; i++) {
								Destroy (gmarker [i]);
						}
						gmarker.Clear ();
			GameObject.Find("S_marker0").SendMessage("cancel_bt_off");


						GameObject.Find ("intro").SendMessage ("write_message", "mal_move#"
								+ manage_static.room_num + "#" + manage_static.turn
								+ "#" + mal_num + "#" + index_0 + "#" + index_1 + "#" + hand + "#" + dice);

						mal_num = -1;



				}
				if (click_event () == 2) {
			GameObject.Find("S_marker0").SendMessage("cancel_bt_off");
			GameObject.Find (click_marker).GetComponent<SpriteRenderer> ().sprite = null;

			Debug.Log("dddd : " + mal_num);


						if (mal_num == 0) {
								manage_static.mal0_index = new int[]{7, 0};
				manage_static.mal_state[0] = 4;
						} else if (mal_num == 1) {
								manage_static.mal1_index = new int[]{7, 0};
				manage_static.mal_state[1] = 4;
						} else if (mal_num == 2) {
								manage_static.mal2_index = new int[]{7, 0};
				manage_static.mal_state[2] = 4;
						} else if (mal_num == 3) {
								manage_static.mal3_index = new int[]{7, 0};
				manage_static.mal_state[3] = 4;
						} else {
								Debug.Log ("말 인텍스 옮기기 실패");
						}
			int search_temp = 0;

			for(int i=0; i<manage_static.guide_list.Count; i++)
			{
				if(manage_static.guide_list[i][0] == -1)
				{
					search_temp = -1;
				}
				else if(manage_static.guide_list[i][0] == 7)
				{
					search_temp = 7;
				}
			}

			int hand = 0;
			int dice = -2;
			if(search_temp == -1)
			{
				int remove_index = -1;
				
				for (int i=0; i<manage_static.guide_list.Count; i++) {//지금 클릭한 좌표 가이드 리스트에서 찾기
					Debug.Log ("glist : " + manage_static.guide_list [i] [0] + " , " + manage_static.guide_list [i] [1]);
					if (manage_static.guide_list [i] [0] == -1 && manage_static.guide_list [i] [1] == -1)
						remove_index = i;
				}
				dice = manage_static.dice[remove_index];

						hand = hand_over (-1, -1);
			}
			else
			{

				int remove_index = -1;
				
				for (int i=0; i<manage_static.guide_list.Count; i++) {//지금 클릭한 좌표 가이드 리스트에서 찾기
					Debug.Log ("glist : " + manage_static.guide_list [i] [0] + " , " + manage_static.guide_list [i] [1]);
					if (manage_static.guide_list [i] [0] == 7 && manage_static.guide_list [i] [1] == 0)
						remove_index = i;
				}
				dice = manage_static.dice[remove_index];


				hand = hand_over (7, 0);
			}
			
						for (int i=0; i<gmarker.Count; i++) {
								Destroy (gmarker [i]);
						}
						gmarker.Clear ();


			GameObject.Find ("intro").SendMessage ("write_message","goalin#" 
								+ manage_static.room_num + "#" + manage_static.turn
								+ "#" + mal_num + "#" + hand + "#" + dice);


						mal_num = -1;

				}
	
		}

		public int hand_over (int index_0, int index_1)
		{
				int remove_index = -1;
				int dice = -2;

						for (int i=0; i<manage_static.guide_list.Count; i++) {//지금 클릭한 좌표 가이드 리스트에서 찾기
								Debug.Log ("glist : " + manage_static.guide_list [i] [0] + " , " + manage_static.guide_list [i] [1]);
								if (manage_static.guide_list [i] [0] == index_0 && manage_static.guide_list [i] [1] == index_1)
										remove_index = i;
						}

		
				if (remove_index != -1) {//클릭한거 가이드에서 빼기
						dice = manage_static.dice [remove_index];
						manage_static.guide_list.RemoveAt (remove_index);
						manage_static.dice.RemoveAt (remove_index);
				} else {
						Debug.Log ("remove error");
				}

				if (manage_static.guide_list.Count == 0 && (dice != 4 && dice != 5)) {
						Debug.Log ("핸드오버");
						return 1;
				} else if (manage_static.guide_list.Count == 0 && (dice == 4 || dice == 5)) {
						if(manage_static.last_yut != 5 && manage_static.last_yut != 4)
			{
				return 1;
			}
						return 0;		
				} else if (manage_static.guide_list.Count != 0) {
						Debug.Log ("가이드 남음");
						return 2;
				}
				return 0;
		}


}
