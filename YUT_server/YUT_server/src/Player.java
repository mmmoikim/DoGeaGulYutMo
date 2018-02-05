import java.util.ArrayList;
import java.util.List;

public class Player {

	private int room_num;
	private int turn;
	private int goalin_num;
	private List<Integer> dice_state;
	private Mal [] mal = new Mal[4];
	private String nick,cn;

	Player() {
		room_num = -1;
		turn = 0;
		goalin_num = 0;
		dice_state = new ArrayList<Integer>();
		cn = "";
		nick = "";
		
		for(int i=0; i<4; i++)
			mal[i] = new Mal();
		
	}
	
	public String out_nick()
	{
		return nick;
	}
	public String out_cn()
	{
		return cn;
	}
	public int out_goalin_num()
	{
		return goalin_num;
	}
	
	public void set_cn(String temp)
	{
		cn = temp;
	}
	public void set_nick(String temp)
	{
		nick = temp;
	}

	public void append_dice_num(int num) {
		dice_state.add(num);
	}

	public void change_goalin_num(int num) {
		goalin_num = num;
	}
	public void set_room_num(int num)
	{
		room_num = num;
	}
	public void set_turn(int num)
	{
		turn = num;
		
		for(int i=0; i<4; i++)
		{
		mal[i].set_player_num(num);
		mal[i].set_mal_num(i);
		}
	}
	public Mal out_mal(int num)
	{
		return mal[num];
	}


	
}
