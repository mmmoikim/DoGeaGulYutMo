using UnityEngine;
using System.Collections;




public class Mal  : MonoBehaviour{


	
	private GameObject [] mal0 = new GameObject[4];
	private GameObject [] mal1 = new GameObject[4];
	private GameObject [] mal2 = new GameObject[4];
	private GameObject [] mal3 = new GameObject[4];

	private string click_obj;
	private int[] currunt_index = new int[]{0,0} ;

	private SpriteRenderer myRenderer;
	public Sprite mal0_sp, mal1_sp, mal2_sp, mal3_sp,
					mal0x2, mal0x3 ,mal0x4,
					mal1x2, mal1x3 ,mal1x4,
					mal2x2, mal2x3 ,mal2x4,
					mal3x2, mal3x3 ,mal3x4,sp;


	void Start()
	{
		mal_init ();
		
	}
	void set_mal_sp(int [] temp)
			{	
				sp = null;
		switch (temp [0])
		{//mal num
		case 0 ://플레이어 0번
			switch(temp[1])//마리수
			{
			case 1:
				sp = mal0_sp;
				break;
			case 2:
				sp = mal0x2;
				break;
			case 3:
				sp = mal0x3;
				break;
			case 4:
				sp = mal0x4;
				break;
			}
			mal0[temp [2]].gameObject.GetComponent<SpriteRenderer>().sprite = sp;
			break;

		case 1 :
			switch(temp[1])//마리수
			{
			case 1:
				sp = mal1_sp;
				break;
			case 2:
				sp = mal1x2;
				break;
			case 3:
				sp = mal1x3;
				break;
			case 4:
				sp = mal1x4;
				break;
			}
			mal1[temp [2]].gameObject.GetComponent<SpriteRenderer>().sprite = sp;
			break;

		case 2 :
			switch(temp[1])//마리수
			{
			case 1:
				sp = mal2_sp;
				break;
			case 2:
				sp = mal2x2;
				break;
			case 3:
				sp = mal2x3;
				break;
			case 4:
				sp = mal2x4;
				break;
			}
			mal2[temp [2]].gameObject.GetComponent<SpriteRenderer>().sprite = sp;
			break;
		case 3 :
			switch(temp[1])//마리수
			{
			case 1:
				sp = mal3_sp;
				break;
			case 2:
				sp = mal3x2;
				break;
			case 3:
				sp = mal3x3;
				break;
			case 4:
				sp = mal3x4;
				break;
			}
			mal3[temp [2]].gameObject.GetComponent<SpriteRenderer>().sprite = sp;
			break;
		}


		}


	// Use this for initialization
	void mal_init () {

		for (int i=0; i<4; i++) {
			mal0[i] = GameObject.Find("mal0_" + i);
			mal1[i] = GameObject.Find("mal1_" + i);
			mal2[i] = GameObject.Find("mal2_" + i);
			mal3[i] = GameObject.Find("mal3_" + i);

			mal0[i].gameObject.GetComponent<SpriteRenderer>().sprite = mal0_sp;
			mal1[i].gameObject.GetComponent<SpriteRenderer>().sprite = mal1_sp;
			mal2[i].gameObject.GetComponent<SpriteRenderer>().sprite = mal2_sp;
			mal3[i].gameObject.GetComponent<SpriteRenderer>().sprite = mal3_sp;

			mal0[i].transform.localPosition = manage_static.pan_array[0][4];
			mal1[i].transform.localPosition = manage_static.pan_array[0][4];
			mal2[i].transform.localPosition = manage_static.pan_array[0][4];
			mal3[i].transform.localPosition = manage_static.pan_array[0][4];
		}

		switch(manage_static.turn)
		{
		case 0 :
			mal0[0].transform.localPosition = manage_static.pan_array [manage_static.mal0_index[0]] [manage_static.mal0_index[1]];
			mal0[1].transform.localPosition = manage_static.pan_array [manage_static.mal1_index[0]] [manage_static.mal1_index[1]];
			mal0[2].transform.localPosition = manage_static.pan_array [manage_static.mal2_index[0]] [manage_static.mal2_index[1]];
			mal0[3].transform.localPosition = manage_static.pan_array [manage_static.mal3_index[0]] [manage_static.mal3_index[1]];
			break;
		case 1 :
		mal1[0].transform.localPosition = manage_static.pan_array [manage_static.mal0_index[0]] [manage_static.mal0_index[1]];
		mal1[1].transform.localPosition = manage_static.pan_array [manage_static.mal1_index[0]] [manage_static.mal1_index[1]];
		mal1[2].transform.localPosition = manage_static.pan_array [manage_static.mal2_index[0]] [manage_static.mal2_index[1]];
		mal1[3].transform.localPosition = manage_static.pan_array [manage_static.mal3_index[0]] [manage_static.mal3_index[1]];
			break;
		case 2 :
			mal2[0].transform.localPosition = manage_static.pan_array [manage_static.mal0_index[0]] [manage_static.mal0_index[1]];
			mal2[1].transform.localPosition = manage_static.pan_array [manage_static.mal1_index[0]] [manage_static.mal1_index[1]];
			mal2[2].transform.localPosition = manage_static.pan_array [manage_static.mal2_index[0]] [manage_static.mal2_index[1]];
			mal2[3].transform.localPosition = manage_static.pan_array [manage_static.mal3_index[0]] [manage_static.mal3_index[1]];
			break;
		case 3 :
			mal3[0].transform.localPosition = manage_static.pan_array [manage_static.mal0_index[0]] [manage_static.mal0_index[1]];
			mal3[1].transform.localPosition = manage_static.pan_array [manage_static.mal1_index[0]] [manage_static.mal1_index[1]];
			mal3[2].transform.localPosition = manage_static.pan_array [manage_static.mal2_index[0]] [manage_static.mal2_index[1]];
			mal3[3].transform.localPosition = manage_static.pan_array [manage_static.mal3_index[0]] [manage_static.mal3_index[1]];
			break;
		}

	}

	public void mal0_move(int [] temp)
	{
		int num = temp [0];
		int x = temp [1];
		int y = temp [2];
		Debug.Log ("num : " + num + "x : " + x + "y : " + y);
		mal0[num].transform.localPosition = manage_static.pan_array [x] [y];

		}
	public void mal1_move(int [] temp)
	{
		int num = temp [0];
		int x = temp [1];
		int y = temp [2];
		mal1[num].transform.localPosition = manage_static.pan_array [x] [y];
		
	}
	public void mal2_move(int [] temp)
	{
		int num = temp [0];
		int x = temp [1];
		int y = temp [2];
		mal2[num].transform.localPosition = manage_static.pan_array [x] [y];
		
	}
	public void mal3_move(int [] temp)
	{
		int num = temp [0];
		int x = temp [1];
		int y = temp [2];
		mal3[num].transform.localPosition = manage_static.pan_array [x] [y];
		
	}

	void set_first_coordi()
	{
		manage_static.mal0_index [0] = 1;
		manage_static.mal0_index [1] = 0;
		manage_static.mal1_index [0] = 1;
		manage_static.mal1_index [1] = 0;
		manage_static.mal2_index [0] = 1;
		manage_static.mal2_index [1] = 0;
		manage_static.mal3_index [0] = 1;
		manage_static.mal3_index [1] = 0;
	}
	

}
