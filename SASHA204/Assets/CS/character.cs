using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {
	private GameObject character_0,character_1,character_2,character_3;
	private SpriteRenderer myRenderer;
	public Sprite character0_sp,character1_sp,character2_sp,character3_sp,start_sp,turn_sp;
	private bool clicked = false;
	private string click_obj;

	// Use this for initialization
	void Start () {

		GameObject.Find ("my turn").GetComponent<SpriteRenderer> ().enabled = false;
				character_0 = GameObject.Find ("character0");
				character_1 = GameObject.Find ("character1");
				character_2 = GameObject.Find ("character2");
				character_3 = GameObject.Find ("character3");

				character_all_off ();

		 manage_static.turn_posit.Add(new Vector3((float)-7.77514, (float)3.370496, (float)-3));
		manage_static.turn_posit.Add(new Vector3((float)-7.77514, (float)0.9999831, (float)-3));
		manage_static.turn_posit.Add(new Vector3((float)-7.77514, (float)-1.353474, (float)-3));
		manage_static.turn_posit.Add(new Vector3((float)-7.77514, (float)-3.706929, (float)-3));

		if (manage_static.turn != -1)
						for (int i=0; i<= manage_static.turn; i++) {
								character_on (i);
						}
				GameObject.Find ("start").GetComponent<SpriteRenderer> ().sprite = null;
				GameObject.Find ("turn").GetComponent<SpriteRenderer> ().sprite = null;

		}

	public void start_on()
	{
		GameObject.Find ("start").GetComponent<SpriteRenderer> ().sprite = start_sp;
}

	public void turn_set_position(int num)
	{
		GameObject.Find ("my turn").GetComponent<SpriteRenderer> ().enabled = false;		
		GameObject.Find("turn").GetComponent<SpriteRenderer>().sprite = turn_sp;
		GameObject.Find ("turn").gameObject.transform.localPosition = manage_static.turn_posit[num];

		if (manage_static.turn == manage_static.curr_turn) {
			GameObject.Find ("my turn").GetComponent<SpriteRenderer> ().enabled = true;	
			GameObject.Find("ThrowYutBtn").SendMessage("enable_click",true);
		}



	}
	public void character_on(int num)
	{
		switch (num) {
				
			case 0 :
			character_0.gameObject.GetComponent<SpriteRenderer>().sprite = character0_sp;
			break;
		case 1 :
			character_1.gameObject.GetComponent<SpriteRenderer>().sprite = character1_sp;
			break;
		case 2 :
			character_2.gameObject.GetComponent<SpriteRenderer>().sprite = character2_sp;
			break;
		case 3 :
			character_3.gameObject.GetComponent<SpriteRenderer>().sprite = character3_sp;
			break;
		}
	}
	public void character_off(int num)
	{
		switch (num) {
			
		case 0 :
			character_0.gameObject.GetComponent<SpriteRenderer>().sprite = null;
			break;
		case 1 :
			character_1.gameObject.GetComponent<SpriteRenderer>().sprite = null;
			break;
		case 2 :
			character_2.gameObject.GetComponent<SpriteRenderer>().sprite = null;
			break;
		case 3 :
			character_3.gameObject.GetComponent<SpriteRenderer>().sprite = null;
			break;
		}
	}
	public void character_all_off()
	{
		character_0.gameObject.GetComponent<SpriteRenderer>().sprite = null;
		character_1.gameObject.GetComponent<SpriteRenderer>().sprite = null;
		character_2.gameObject.GetComponent<SpriteRenderer>().sprite = null;
		character_3.gameObject.GetComponent<SpriteRenderer>().sprite = null;
	}
	
	public void marker_off(string marker)
	{
		GameObject.Find (marker).gameObject.GetComponent<SpriteRenderer>().sprite = null;
	}
	
	// Update is called once per frame
	void Update () {

		if (click_event ()) {
			Debug.Log("game start!! ");
			GameObject.Find("start").GetComponent<SpriteRenderer>().sprite = null;
			Debug.Log(manage_static.curr_turn);
			GameObject.Find ("intro").SendMessage ("write_message", "game_start#"
			                                       + manage_static.room_num);

		}
	
	}


	private bool click_event ()
	{
		if (clicked == false) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit;
				hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				
				if (hit.collider) {
					click_obj = hit.collider.name; 
					if (true == click_obj.Equals ("start")) {
						clicked = true;
						return true;
					}
				}
			}
		}
		return false;
	}

}
