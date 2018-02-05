using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mal_move : MonoBehaviour {

	int player_num;
	int mal_num;
	List<int []> move_list = new List<int[]>();
	int [] mal_data;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
	void get_data(int [] data)
	{
		mal_data = data;
		}
	void move(int [] temp)
	{
		player_num = temp [0];
		mal_num = temp [1];

		int dep_x = temp [2];
		int dep_y = temp [3];
		int dice = temp [4];

		int [] ori_index = new int[2]{-1,-1};
		int [] dep_index = new int[2]{dep_x,dep_y};
		int [] move_index = new int[2]{-1,-1};
		int [] start_index = new int[2]{-1,-1};


		Vector3 ori_posit = GameObject.Find("mal" + player_num + "_" + mal_num).transform.localPosition;

		for (int i=0; i<8; i++) {
			ori_index[1] = manage_static.pan_array [i].IndexOf (ori_posit);//지금 말 위치 찾기
			
			if (ori_index[1] != -1) {
				ori_index[0] = i;
				break;
			}
		}
		Debug.Log ("지금 위치 : "+ ori_index[0] + "  , "+ori_index[1] );

		if (ori_index [0] == 0 || ori_index [0] == -1) {
			start_index [0] = 1;
			start_index [1] = 0;
		} else {
			start_index [0] = ori_index [0];
			start_index [1] = ori_index [1];
		}

		move_list.Add (new int[2]{start_index [0],start_index [1]});

		if (dice == -1) { //백도
						if (start_index [0] == 1 && start_index [1] == 0) {
								move_index [0] = 4;
								move_index [1] = 4;
						} else if (start_index [0] == 2 && start_index [1] == 0) {
								move_index [0] = 1;
								move_index [1] = 4;
						} else if (start_index [0] == 3 && start_index [1] == 0) {
								move_index [0] = 2;
								move_index [1] = 4;
						} else if (start_index [0] == 4 && start_index [1] == 0) {
								move_index [0] = 3;
								move_index [1] = 4;
						} else if (start_index [0] == 5 && start_index [1] == 0) {
								move_index [0] = 2;
								move_index [1] = 0;
						} else if (start_index [0] == 6 && start_index [1] == 0) {
								move_index [0] = 3;
								move_index [1] = 0;
						} else {
								move_index [0] = start_index [0];
								move_index [1] = start_index [1] - 1;
						}
			move_list.Add (new int[2]{move_index [0],move_index [1]});
				} else {
			for(int i=0; i<dice; i++)
			{
				if (ori_index [0] == 3 && ori_index [1] == 0) {//1
				move_index [0] = 6;
				move_index [1] = 0;

					ori_index [0] = move_index [0];
					ori_index [1] = move_index [1];

				} else if (start_index [0] == 4 && start_index [1] == 4) {
			
				move_index [0] = 1;//골인
				move_index [1] = 0;
					
				} else if (ori_index [0] == 2 && ori_index [1] == 0) {//2
				move_index [0] = 5;
				move_index [1] = 0;

					ori_index [0] = move_index [0];
					ori_index [1] = move_index [1];
				}else if (start_index [0] == 1 && start_index [1] == 0) {//3
					if(ori_index[0] == 0 || ori_index[0] == -1)
					{
						move_index [0] = 1;
						move_index [1] = 1;

					}
					else
					{
				move_index [0] = 7;//골인
				move_index [1] = 0;

					ori_index [0] = move_index [0];
					ori_index [1] = move_index [1];
					}

				}else if (start_index [0] == 6 && start_index [1] == 4 ){
				move_index [0] = 1;
				move_index [1] = 0;
				} else if (ori_index [0] == 5 && ori_index [1] == 2) {
					move_index [0] = 6;
					move_index [1] = 3;

					ori_index [0] = move_index [0];
					ori_index [1] = move_index [1];

					} else if (start_index[0] == 5 && start_index [1] == 4) {
					move_index [1] = 0;
					move_index [0] = 4;
				}else {
					if ((start_index [1] + 1) > 4) {
					move_index [1] = start_index [1] + -4;
					move_index [0] = start_index [0] + 1;
					
						if (start_index [0] == 5 && start_index [1] == 0) {
						move_index [0] = 1;
						} else if (start_index [0] == 7 && start_index [1] == 0) {
						move_index [0] = 1;
					}
				} else {
					move_index [1] = start_index [1] + 1;
					move_index [0] = start_index [0];
					
				}
			}

				move_list.Add (new int[2] {move_index[0],move_index[1]});

				start_index[0] = move_list[move_list.Count-1][0]; 
				start_index[1] = move_list[move_list.Count-1][1]; 
				}
				}


		move_ani ();
	}




	void move_ani()
	{
		
		Vector3 desti =  manage_static.pan_array[move_list[0][0]][move_list[0][1]];	
		
		Hashtable hash = new Hashtable();
		hash.Add("position",desti);
		hash.Add("islocal",true);
		hash.Add("easetype",iTween.EaseType.easeInOutQuart);
		hash.Add("speed", 8.0f);

		if (move_list.Count != 1) {
			hash.Add ("oncomplete", "callback");

			Hashtable temp = new Hashtable();
			temp.Add("value",1);
			hash.Add("oncompletetarget",this.gameObject);
			hash.Add("oncompleteparams",temp);
				}

		iTween.MoveTo (GameObject.Find ("mal" + player_num + "_" + mal_num), hash);

		
	}





	
	void callback(object val)
	{
		Hashtable temp = (Hashtable)val;
		int index = (int)temp ["value"];
		Vector3 desti =  manage_static.pan_array[move_list[index][0]][move_list[index][1]];
		Hashtable hash = new Hashtable();
		hash.Add("position",desti);
		hash.Add("islocal",true);
		hash.Add("easetype",iTween.EaseType.easeInOutQuart);
		hash.Add("speed", 8.0f);
		if(move_list.Count != index+1)
		{
			hash.Add ("oncomplete", "callback");

			Hashtable data = new Hashtable();
			data.Add("value",index+1);
			hash.Add("oncompletetarget",this.gameObject);
			hash.Add("oncompleteparams",data);
		}
		
		iTween.MoveTo (GameObject.Find ("mal" + player_num + "_" + mal_num), hash);

		if (move_list [index] [0] >= 7) {
			GameObject.Find("goal_ani").SendMessage("goal_on_" + player_num);
			GameObject.Find ("mal" + player_num + "_" + mal_num).GetComponent<SpriteRenderer>().enabled = false;
		}

		if (index == move_list.Count-1) {

			StartCoroutine(time_fucn());
		}
		
	}

	private IEnumerator time_fucn()
	{
		yield return new WaitForSeconds (0.25f);

		move_list.Clear();
		
		if(manage_static.move_state[0] == 1)//잡았을때
		{
			GameObject.Find("move_mal").SendMessage("catch_mal",mal_data);
			manage_static.move_state[0] = 0;
		}
		if(manage_static.move_state[1] == 1)//업었을때
		{
			GameObject.Find("move_mal").SendMessage("piggy_mal",mal_data);
			manage_static.move_state[1] = 0;
		}
		if(manage_static.move_state[2] == 1)//가이드 마커 남아 있을때
		{
			GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
			manage_static.move_state[2] = 0;
		}
	}

}
