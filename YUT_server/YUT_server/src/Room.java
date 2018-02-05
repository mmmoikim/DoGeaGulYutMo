import java.io.BufferedWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Room {
	private List<BufferedWriter> list_writer;
	private int room_num;
	private int state; // 0 = empty, 1 = ready, 2 = ing, 3 = quit
	private int maxplayer;
	private List<Player> player;
	private int currplayer;
	private Mal board[][];
	private int grade[];

	Room() {
		room_num = -1;
		state = 0;
		maxplayer = 0;
		player = new ArrayList<Player>();
		currplayer = -1;
		list_writer = Collections
				.synchronizedList(new ArrayList<BufferedWriter>());
		board = new Mal[9][9];
		grade = new int[]{0,0,0,0};
		
	}
	
	public void put_state(int num)
	{
		state = num;
	}
	
	public int out_grade(int num)
	{
		return grade[num];
	}


	public void send_Room_member(String message, int turn) {
		//turn -1�̸� ��, �ƴϸ� �׹�ȣ�� ���� ����
		try {
		if (turn == -1) {
		
				for (BufferedWriter writer : list_writer) {
					writer.write(message);
					writer.flush();
				}
		}
		else
		{
			for (int i=0; i<list_writer.size(); i++) {
				if(i != turn)
				{
					System.out.println("���� : " + message);
					list_writer.get(i).write(message);
					list_writer.get(i).flush();
				}
		}
		}
			} catch (IOException e) {
				System.out.println("send failed" + e);
			}

	}

	public String golin_mal(int player_num, int mal_num) {
		int piggy_num = player.get(player_num).out_mal(mal_num).out_piggy_num();
		
		player.get(player_num).out_mal(mal_num).goal_in_mal();
		player.get(player_num).change_goalin_num(player.get(player_num).out_goalin_num() + piggy_num);
		
		int total = player.get(player_num).out_goalin_num();
		System.out.println(player_num + "�� �÷��̾�" + piggy_num + "���� �����ִ� "
				+ mal_num + "���� ����" + "�� : " + total);
		
		
		if(total == 4)//������ ���� ����
		{
			int count = 1;
			
			for(int i=0; i<4; i++)
			{
				if(grade[i] != 0)
				{
					count++;
				}
			}
			grade[player_num] = count;
			
			int check = 0;
		for(int i=0; i<maxplayer; i++)//������ �ȳ����� üũ
		{
			if(grade[i] != 0)
			{
			check++;
			}
		}
		if(check == maxplayer -1)
			state = 3;
			
		}
		return player_num + "#" + mal_num + "#" + piggy_num + "#" + total  + "#" + grade[player_num];
		
		
	}
	public void remove_from_board(int player, int mal)
	{
		for(int i=0; i<7; i++)
		{
			for(int j=0; j<6; j++)
			{
				if(board[i][j] != null)
				{
				if(board[i][j].out_plyer_num() == player
						&& board[i][j].out_mal_num() == mal)
				{
					board[i][j] = null;
				}
				}
			}
		}
	}

	public String set_board(int x, int y, int player_num, int mal_num) {
		String result = "none# # # # #";
		
		if(x == 5 && y == 2)
		{
			if(board[6][2] != null)
				x=6;
		}
		if(x == 6 && y == 2)
		{
			if(board[5][2] != null)
				x=5;
		}

		
		if (board[x][y] != null)// ���忡 ���� ������
		{
			if (player.get(board[x][y].out_plyer_num())
					.out_mal(board[x][y].out_mal_num()).out_plyer_num() != player_num) {
				// ���� �ƴϸ� ����
				System.out.println(board[x][y].out_plyer_num() + "�� �÷��̾���");
				System.out.println(board[x][y].out_piggy_num() + "���� �����ִ�");
				System.out.println(board[x][y].out_mal_num() + "�� ����");
				System.out.println(player_num + "�� �÷��̾� " + mal_num
						+ "�� �� ���� ����\n");
				
				
				int caught_player = board[x][y].out_plyer_num();
				int caught_num = board[x][y].out_piggy_num();
				int caught_mal = board[x][y].out_mal_num();
				int catch_player = player_num;
				int catch_mal = mal_num;
				
				
				result = "catch#" + caught_player +"#"+ caught_num +"#"+ caught_mal
						+"#"+ catch_player +"#"+ catch_mal;
				
				player.get(board[x][y].out_plyer_num())
						.out_mal(board[x][y].out_mal_num()).be_caught_mal();
				
				board[x][y] = null;
				board[x][y] = player.get(player_num).out_mal(mal_num);
				
				return result;
				
			} else {
				// �����̸� ����
				int ori_piggy_num = player.get(board[x][y].out_plyer_num())
						.out_mal(board[x][y].out_mal_num()).out_piggy_num();// ���� �ִ��ſ� � ���� �־���
				
				int piggybacked = board[x][y].out_mal_num();//���� �� ��ȣ
				System.out.println("������ ���� �� : " + player.get(player_num).out_mal(mal_num).out_piggy_num());
				
				player.get(player_num).out_mal(mal_num)
						.piggy_mal(ori_piggy_num);// ���� �����ִ��� ���� �������� ���ϱ�
				
				player.get(board[x][y].out_plyer_num())
						.out_mal(board[x][y].out_mal_num()).ride_on_other();// ������ �������� �����
				
				int total = player.get(player_num).out_mal(mal_num).out_piggy_num();
				
				System.out.println(player_num + "�� �÷��̾�");
				System.out.println(mal_num + "�� ����");
				System.out.println(ori_piggy_num + "���� ������" +
						piggybacked + "���� ����" + " �� : "
						+ total + "����\n");
			

				board[x][y] = null;
				board[x][y] = player.get(player_num).out_mal(mal_num);
				
				result = "piggy#" + player_num +"#"+ mal_num +"#"+ piggybacked + "#" +
				ori_piggy_num +"#"+ total;
				
				return result;
				
			}
		}
		board[x][y] = player.get(player_num).out_mal(mal_num);
		board[x][y].set_mal_num(mal_num);
		board[x][y].set_player_num(player_num);
		return result;

	}

	public void mal_state_change(int player_num, int mal_num, int state) {
		player.get(player_num).out_mal(mal_num).change_mal_state(state);
	}

	public int out_currplayer() {
		return currplayer;
	}

	public int out_room_num() {
		return room_num;
	}

	public int out_state() {
		return state;
	}

	public int out_maxplayer() {
		return maxplayer;
	}

	public void put_room_num(int temp) {
		room_num = temp;
	}

	public void put_maxplayer(int temp) {
		maxplayer = temp;
	}

	public int add_player(BufferedWriter writer)// �߰��ϸ� 1 / �ƴϸ� 0
	{
		if (state == 0) {
			currplayer++;
			Player temp = new Player();
			temp.set_room_num(room_num);
			temp.set_turn(currplayer);
			player.add(temp);
			list_writer.add(writer);
			
		
			System.out.println("maxplayer : " + maxplayer +"player.size : " + player.size() + "curr : " + currplayer);
			if (maxplayer == player.size())
			{
				state = 1;
			}

			return 1;
		} else {
			System.out.println("player full");
			return 0;
		}
	}


	public Player out_player(int num)// �÷��̾� ��ȣ,��
	{
		return player.get(num);

	}
	
	public void room_reset()
	{
		room_num = -1;
		state = 3;
		maxplayer = 0;
		player.clear();
		currplayer = -1;
		list_writer.clear();
		Arrays.fill(board, null);
		Arrays.fill(grade, 0);
	}
	public int quit_player()
	{
		currplayer--;
		return currplayer;
	}
}