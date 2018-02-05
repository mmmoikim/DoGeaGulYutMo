import java.util.List;


public class Mal {

	private int mal_position[];
	private int piggy_num;
	private int player_num;
	private int mal_num;
	private int state;// 0 = 시작전, 1= 게임중, 2=업음, 3 = 업힘당함, 4=골인

	Mal() {
		mal_position = new int[] { 0, 0 };
		piggy_num = 1;
		state = 0;
		player_num = 0;
		mal_num = 0;

	}

	public void set_player_num(int num)
	{
		player_num = num;
	}
	public void set_mal_num(int num)
	{
		mal_num = num;
	}

	
	public int out_plyer_num()
	{
		return player_num;
	}
	public int out_mal_num()
	{
		return mal_num;
	}
	 public int out_state()
	 {
		 return state;
	 }
	public int[] out_position()
	{
		return mal_position;
	}
	public int out_piggy_num()
	{
		return piggy_num;
	}


	 public void change_mal_state(int num) 
	 {
		 state = num;
	 }
	
	public void change_mal_position(int x, int y) {
		mal_position[0] = x;
		mal_position[1] = y;
	}

	public void be_caught_mal()// 잡혔을 때 초기화
	{
		state = 0;
		mal_position[0] = 0;
		mal_position[1] = 0;
		piggy_num = 1;
	}

	public void goal_in_mal()//골인
	{
		state = 3;
		mal_position[0] = 7;
		mal_position[1] = 7;
	}
	
	public void piggy_mal(int num)//업었을때 원래 말에 몇명 업혀있었나
	{
		state = 2;
		piggy_num= piggy_num + num;
		
	}
public void ride_on_other()//탈때
{
	state = 3;
	change_mal_position(8,8);//엎힘 당하면 8,8
	piggy_num = 1;
	}
}
