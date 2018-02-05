using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class manage_static {

	public static List<List<Vector3>> pan_array;
	public static List<string> read_data = new List<string>();
	public static int room_num = -1;
	public static int turn = -1;
	public static int grade = 0;
	public static int curr_turn = 0;
	public static int maxplayer = 0;
	public static int[] mal_state = new int[] {0,0,0,0};
	public static int[] mal0_index = new int[]{0,0} ;
	public static int[] mal1_index = new int[]{0,1} ;
	public static int[] mal2_index = new int[]{0,2} ;
	public static int[] mal3_index = new int[]{0,3} ;
	public static List<int> dice = new List<int>();
	public static List<int[]> guide_list = new List<int[]> ();
	public static List<Vector3> turn_posit = new List<Vector3>();
	public static int last_yut = -2;
	public static string cn = " ",nick = " ";
	public static int [] move_state = new int[]{0,0,0};
	

	void Start () {
	}

	// Update is called once per frame
	void Update () {
	
	}
}
