using UnityEngine;
using System.Collections;

public class yut_func : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
void catch_mal(int [] data)
{

		int caught_p = data [0];
		int caught_m= data [1];
		int caught_mnum= data [2];
		int catch_p= data [3];
		int catch_m= data [4];


	int [] setsp = new int[]{caught_p, 1, caught_m};
	GameObject.Find ("mal0_0").SendMessage ("set_mal_sp",setsp);//잡힌 말 이미지 1
	
	
	int [] temp = new int[3];
	temp [0] = caught_m;
	temp [1] = 0;
	temp [2] = caught_m;
	
	if(manage_static.turn == caught_p)//내꺼 잡힌거면
	{
		GameObject.Find ("mal0_0").SendMessage ("mal" +caught_p + "_move",temp);//잡은애 포지션 대기로 옮기기
		
		for(int i=0; i<caught_mnum; i++)//인덱스 옮기기
		{
			
			if(i==0)
			{
				switch(caught_m)
				{
				case 0 :
					manage_static.mal0_index[0] = 0;
					manage_static.mal0_index[1] = 0;
					manage_static.mal_state[0] = 0;
					break;
				case 1 :
					manage_static.mal1_index[0] = 0;
					manage_static.mal1_index[1] = 1;
					manage_static.mal_state[1] = 0;
					break;
				case 2 :
					manage_static.mal2_index[0] = 0;
					manage_static.mal2_index[1] = 2;
					manage_static.mal_state[2] = 0;
					break;
				case 3 :
					manage_static.mal3_index[0] = 0;
					manage_static.mal3_index[1] = 3;
					manage_static.mal_state[3] = 0;
					break;
					
				}
			}
			else
			{
				for(int j=0; j<4; j++)
				{
					if(manage_static.mal_state[j] == 3)//j = 업힘당한 애들 번호
					{
						
						int [] posi = new int[3];
						posi [0] = j;
						posi [1] = 0;
						posi [2] = j;
						GameObject.Find ("mal0_0").SendMessage ("mal" + caught_p + "_move",posi);//업혀있던 말 대기로
						
						int [] setsp1 = new int[]{caught_p,1,j};
						
						GameObject.Find ("mal0_0").SendMessage ("set_mal_sp",setsp1);//대기로 간 말 이미지 1로
						
						switch(j)//인덱스 바꾸기
						{
						case 0 :
							manage_static.mal0_index[0] = 0;
							manage_static.mal0_index[1] = 0;
							manage_static.mal_state[0] = 0;
							break;
						case 1 :
							manage_static.mal1_index[0] = 0;
							manage_static.mal1_index[1] = 1;
							manage_static.mal_state[1] = 0;
							break;
						case 2 :
							manage_static.mal2_index[0] = 0;
							manage_static.mal2_index[1] = 2;
							manage_static.mal_state[2] = 0;
							break;
						case 3 :
							manage_static.mal3_index[0] = 0;
							manage_static.mal3_index[1] = 3;
							manage_static.mal_state[3] = 0;
							break;
							
						}
						
						break;
					}
				}
			}
		}
		
	}
	else//상대방꺼
	{
		temp [1] = 8;
		temp [2] = 0;
		GameObject.Find ("mal0_0").SendMessage ("mal" + caught_p + "_move",temp);
	}
	
}






	void piggy_mal(int [] data)//플레이어8, 업은말9, 업힌말10, 업혀있던 수11, 총 수12
	{

		int p_num = data [0];
		int piggy_m = data [1];
		int ride_on_m = data [2];
		int ride_on_num = data [3];
		int total_num = data [4];

		int [] send_data = new int[]{p_num,total_num,piggy_m};
		
		GameObject.Find ("mal0_0").SendMessage ("set_mal_sp",send_data);//업을떄 이미지 바꾸기
		
		
		if(manage_static.turn == p_num)//내꺼일때
		{
			
			int [] temp3 = new int[3];
			temp3 [0] = ride_on_m;//업힌말 넘버
			temp3 [1] = 8;
			temp3 [2] = 0;
			GameObject.Find ("mal0_0").SendMessage ("mal" + p_num + "_move", temp3);//업힌애 옮기기
			
			
			switch(temp3 [0])//업힌애 인덱스
			{
			case 0 :
				manage_static.mal0_index[0] = 8;
				manage_static.mal0_index[1] = 0;
				manage_static.mal_state[0] = 3;
				break;
			case 1 :
				manage_static.mal1_index[0] = 8;
				manage_static.mal1_index[1] = 0;
				manage_static.mal_state[1] = 3;
				break;
			case 2 :
				manage_static.mal2_index[0] = 8;
				manage_static.mal2_index[1] = 0;
				manage_static.mal_state[2] = 3;
				break;
			case 3 :
				manage_static.mal3_index[0] = 8;
				manage_static.mal3_index[1] = 0;
				manage_static.mal_state[3] = 3;
				break;
			}
			
			manage_static.mal_state[piggy_m] = 2;//업은애
			
		}
		else//남꺼 일때
		{
			
			int [] temp3 = new int[3];
			temp3 [0] = ride_on_m;//업힌애
			temp3 [1] = 8;
			temp3 [2] = 0;
			GameObject.Find ("mal0_0").SendMessage ("mal" + p_num + "_move", temp3);
			
		}
		
	}







}