using UnityEngine;
using System.Collections;
using System.Text;
using System.Linq;

public class throw_button : MonoBehaviour
{
		private string click_obj;
		private int yut_dice = -2;
		private bool clicked = true;
		private int[] currunt_index = new int[]{0,0} ;
		private int[] index = new int[]{0,0};
		private int rand = -2;
		int i = 0;
		int [] array = new int[50];

		void Start ()
		{

		}
	void enable_click(bool temp)
	{
		clicked = temp;
	}
		void Update ()
		{
		Random.seed = (int)(System.DateTime.Now.Ticks);
				throw_click ();
		}
		void throw_click ()
		{

				int confirm = 0;

				for (int i=0; i<4; i++) {
						if (manage_static.mal_state [i] != 0)//다 대기중일때
								confirm = 1;
				}


				if (click_event ()) {
		

			/*
			rand =  Random.Range(0,100);

			if (rand >= 98) {
								yut_dice = 0;
			} else if (rand >= 96) {
								yut_dice = 5;
			} else if (rand >= 92) {
								yut_dice = -1;
			} else if (rand >= 80) {
								yut_dice = 1;
			} else if (rand >= 68) {
				yut_dice = 4;
			} else if (rand >= 34) {
				yut_dice = 2;
			} else if (rand >= 0) {
								yut_dice = 3;
						}

*/

		
			if(manage_static.turn == 0 && i==0)
			{
				array = new int[]{2,4,4,4,3,4,4,2,4,5,3};
			}
			else if(manage_static.turn == 1 && i==0)
			{
				array = new int[]{5,1,3,4,2,5,3,5,5,3,0,4,5,3,2};
			}
			else if(manage_static.turn == 2 && i==0)
			{
				array = new int[]{2,5,1,4,4,5,2,4,3,5,4,4,1};
			}
			else if(manage_static.turn == 3 && i==0)
			{
				array = new int[]{0,5,5,3,1,4,5,-1,5,4,2,3,5,4};
			}
			yut_dice = array[i];
			++i;

		
			switch (yut_dice) {
						case -1:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (-1);
								manage_static.last_yut = -1;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#Bdo#"
										+ manage_static.room_num + "#" + manage_static.turn);
								clicked = false;
								break;
						case 0:
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#nack#"
										+ manage_static.room_num + "#" + manage_static.turn);
								clicked = false;
								break;
						case 1:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (1);
								manage_static.last_yut = 1;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#do#"
										+ manage_static.room_num + "#" + manage_static.turn);
								clicked = false;
								break;
						case 2:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (2);
								manage_static.last_yut = 2;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#gea#"
										+ manage_static.room_num + "#" + manage_static.turn);
								clicked = false;
								break;
						case 3:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (3);
								manage_static.last_yut = 3;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#gul#"
										+ manage_static.room_num + "#" + manage_static.turn);
								clicked = false;
								break;
						case 4:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (4);
								manage_static.last_yut = 4;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#yut#"
										+ manage_static.room_num + "#" + manage_static.turn);
								break;
						case 5:
								GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
								manage_static.dice.Add (5);
								manage_static.last_yut = 5;
								GameObject.Find ("intro").SendMessage ("write_message", "throw_yut#mo#"
										+ manage_static.room_num + "#" + manage_static.turn);
								break;
						}

				}
		}

		private bool click_event ()
		{
				if (manage_static.curr_turn == manage_static.turn) {
						if (clicked) {
								if (Input.GetMouseButtonDown (0)) {
										RaycastHit2D hit;
										hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			
										if (hit.collider) {
												click_obj = hit.collider.name; 
												if (true == click_obj.Equals (gameObject.name)) {

														return true;
												}
										}
								}
						}
				}

				return false;
		}
}
