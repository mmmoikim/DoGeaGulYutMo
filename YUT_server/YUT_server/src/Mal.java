import java.util.List;


public class Mal {

	private int mal_position[];
	private int piggy_num;
	private int player_num;
	private int mal_num;
	private int state;// 0 = ������, 1= ������, 2=����, 3 = ��������, 4=����

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

	public void be_caught_mal()// ������ �� �ʱ�ȭ
	{
		state = 0;
		mal_position[0] = 0;
		mal_position[1] = 0;
		piggy_num = 1;
	}

	public void goal_in_mal()//����
	{
		state = 3;
		mal_position[0] = 7;
		mal_position[1] = 7;
	}
	
	public void piggy_mal(int num)//�������� ���� ���� ��� �����־���
	{
		state = 2;
		piggy_num= piggy_num + num;
		
	}
public void ride_on_other()//Ż��
{
	state = 3;
	change_mal_position(8,8);//���� ���ϸ� 8,8
	piggy_num = 1;
	}
}