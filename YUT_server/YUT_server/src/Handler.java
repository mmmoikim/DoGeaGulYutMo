import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.StringTokenizer;

public class Handler extends Thread {

	protected Socket socket;

	public Handler(Socket clientsocket) {
		this.socket = clientsocket;
		
	}
	private Room_manage manager = new Room_manage();


	public void run() {

		String read_string = null;

		while (true) {
			try {
				BufferedReader reader = new BufferedReader(
						new InputStreamReader(socket.getInputStream()));
				BufferedWriter writer =new BufferedWriter(
						new OutputStreamWriter(socket.getOutputStream()));

				
				List<String> token = new ArrayList<String>();
				
				read_string = reader.readLine();//�б�
				if(read_string != null)
				{
					
					token = tokenizer(read_string);
					
					for(int i=0; i<token.size(); i++)
					{
						System.out.println("��� ����" + token.get(i));
					}
					
					System.out.println("\n");
					
					if(token.get(0).equals("room_create"))
					{

					   int last_room_num = YK_Static.list_room.size();
						manager.create_room(Integer.parseInt(token.get(1)),last_room_num,writer);
						YK_Static.list_room.get(last_room_num).send_Room_member("player_enter#" + 0 + "#" + last_room_num, -1);
						System.out.println("player_enter#" + 0 + "#" + last_room_num);
						
						YK_Static.list_room.get(last_room_num).out_player(0).set_cn(token.get(2));
						YK_Static.list_room.get(last_room_num).out_player(0).set_nick(token.get(3));
						
					}
					else if(token.get(0).equals("room_enter"))
					{
						System.out.println("size : " + YK_Static.list_room.size());
						int empty_room_num = manager.search_room();
						System.out.println("empty room" + empty_room_num);
						
						
						
						if(manager.enter_room(empty_room_num,writer) == 1)
						{
							int playernum = YK_Static.list_room.get(empty_room_num).out_currplayer();
							System.out.println("player_enter#" + playernum + "#" + empty_room_num);
							YK_Static.list_room.get(empty_room_num).send_Room_member("player_enter#" + playernum + "#" + empty_room_num, -1);
							YK_Static.list_room.get(empty_room_num).out_player(playernum).set_cn(token.get(1));
							YK_Static.list_room.get(empty_room_num).out_player(playernum).set_nick(token.get(2));
						}
						else
						{
							writer.write("room_full#");
							writer.flush();
						}
					}
					else if(token.get(0).equals("quit"))
					{
						
						int r_num = Integer.parseInt(token.get(1));
						int player_num = Integer.parseInt(token.get(2));
						
					if(r_num != -1)
					{
						
						
						if(0 == YK_Static.list_room.get(r_num).quit_player())
						{
							YK_Static.list_room.get(r_num).send_Room_member("quit_other#" + player_num, player_num);
							YK_Static.list_room.get(r_num).room_reset();
					
						}
						else
						{
							YK_Static.list_room.get(r_num).send_Room_member("quit_other#" + player_num, -1);
						}
						
						System.out.println(" quit room : " + r_num + "player : " + player_num);
						
					}
							
					}
					else if(token.get(0).equals("throw_yut"))
					{
						String yut = token.get(1);
						int room_num = Integer.parseInt(token.get(2));
						int my_turn = Integer.parseInt(token.get(3));
						System.out.println("room_num : " + room_num + "my_turn : " + my_turn);
						
						
						switch(yut)
						{
						case "Bdo" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#-1#" + my_turn,-1);
							
							break;
						case "nack" :
							my_turn++;
							if(my_turn >= YK_Static.list_room.get(room_num).out_maxplayer())
							{
								my_turn = 0;
							}
							if(YK_Static.list_room.get(room_num).out_grade(my_turn) != 0)
							{
							my_turn++;
							}
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#0#" + my_turn, -1);
							break;
						case "do" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#1#" + my_turn, -1);
							break;
						case "gea" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#2#" + my_turn, -1);
							break;
						case "gul" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#3#" + my_turn, -1);
							break;
						case "yut" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#4#" + my_turn, -1);
							break;
						case "mo" :
							YK_Static.list_room.get(room_num).send_Room_member("other_throw#5#" + my_turn, -1);
							break;
						}
					}
					else if(token.get(0).equals("goalin"))
					{
						int r_num = Integer.parseInt(token.get(1));
						int player_num = Integer.parseInt(token.get(2));
						int mal_num =Integer.parseInt(token.get(3));
						int hand = Integer.parseInt(token.get(4));
						int re_turn = 0;
						int turn = player_num;
						int dice = Integer.parseInt(token.get(5));
						
			
						if(hand == 1)
						{
								turn++;
								
							while(YK_Static.list_room.get(r_num).out_grade
									(turn %(YK_Static.list_room.get(r_num).out_maxplayer())) != 0)
							{
								turn++;
							}
							
							turn = turn%(YK_Static.list_room.get(r_num).out_maxplayer());
						}
						else if(hand == 2)
						{
							re_turn = 1;
						}
						
						
						YK_Static.list_room.get(r_num).remove_from_board(player_num,mal_num);
						String temp = YK_Static.list_room.get(r_num).golin_mal(player_num,mal_num);
						//info = 플레이어#말번호#업혀있던마리#총 골인한수#순위

						int quit_check = 0;
						String point = " # # # # # # # # # # # #";
						
						if(YK_Static.list_room.get(r_num).out_state() == 3)
						{
							point = "";
							for(int i=0; i<4; i++)
							{
								if(i < YK_Static.list_room.get(r_num).out_maxplayer())
								{
							String nick = YK_Static.list_room.get(r_num).out_player(i).out_nick();
							String cn = YK_Static.list_room.get(r_num).out_player(i).out_cn();
							
							YK_Static.db.get_user(cn,nick);//��񿡼� �˻��ϰ� ������ �߰�
							
							if(YK_Static.list_room.get(r_num).out_grade(i) == 1)//�ϵ��̸�
							{
								YK_Static.db.update_win_db(cn);//��� win ++
							}
							else
							{
								YK_Static.db.update_lose_db(cn);//������ ��� lose++
							}
								point += YK_Static.db.select_db(cn) + "#";
								}
								else//����� ������
								{
									point += " # # #";
								}
							}
							
							quit_check = 1;
							
						}
						
						if(YK_Static.list_room.get(r_num).out_grade(turn) != 0)
						{
							turn++;
							re_turn = 0;
							if(turn == YK_Static.list_room.get(r_num).out_maxplayer())
							{
								turn = 0;
							}
						}
						
						 System.out.println("goalin#"+ temp +
									"#"+turn+"#"+ re_turn+"#"+quit_check +"#"+point + dice);
								 
						YK_Static.list_room.get(r_num).send_Room_member("goalin#"+ temp +
								"#"+turn+"#"+ re_turn+"#"+quit_check +"#"+point + dice,-1);
						
					}
					else if(token.get(0).equals("mal_move"))
					{
						int r_num = Integer.parseInt(token.get(1));
						int player_num = Integer.parseInt(token.get(2));
						int mal_num =Integer.parseInt(token.get(3));
						int x = Integer.parseInt(token.get(4));
						int y = Integer.parseInt(token.get(5));
						int hand = Integer.parseInt(token.get(6));//�� �Ѿ�� 1 �ƴϸ� 0
						int dice = Integer.parseInt(token.get(7));
						int re_turn = 0;
						
						YK_Static.list_room.get(r_num).remove_from_board(player_num,mal_num);
						String info = YK_Static.list_room.get(r_num).set_board(x, y, player_num, mal_num);
						
						
						int turn = player_num;
						
						if(hand == 1)
						{
								turn++;
								
							while(YK_Static.list_room.get(r_num).out_grade
									(turn %(YK_Static.list_room.get(r_num).out_maxplayer())) != 0)
							{
								turn++;
							}
							
							turn = turn%(YK_Static.list_room.get(r_num).out_maxplayer());
						}
						else if(hand == 2)
						{
							re_turn = 1;
						}
						
						System.out.println(info.substring(0, 1));
						if(info.substring(0, 1).equals("c"))
						{
							turn = player_num;
						}
		
						System.out.println("mal_move#" + player_num +"#"+mal_num
								+"#"+x+"#"+y+"#"+turn+"#"+ re_turn + "#" +info + "#" + dice);
						
						YK_Static.list_room.get(r_num).send_Room_member("mal_move#" + player_num +"#"+mal_num
								+"#"+x+"#"+y+"#"+turn+"#"+ re_turn + "#" +info+ "#" + dice, -1);
							
					}
					else if(token.get(0).equals("game_start"))
					{
						int r_num = Integer.parseInt(token.get(1));
						
						YK_Static.list_room.get(r_num).send_Room_member("game_start#",-1);
					}
					else if(token.get(0).equals("login"))
					{
						String user_key = token.get(1);
						String user_id = token.get(2);
						
						System.out.println("user_key : " + user_key + "user_id" + user_id);
						
						
					}
				}
				else
				{
					reader.close();
					writer.close();
				}
				
			}
			catch (IOException e) {
				System.out.println("Connection closed by client" + e);
				break;
			}
			

		}
		
		try {
		    socket.close();
		    System.out.println("socket close");
		}

		catch (IOException e) {
			System.out.println("socket close failed" + e);
	}

}
	
	public BufferedWriter out_writer()
	{
		try
		{
		BufferedWriter writer =new BufferedWriter(
				new OutputStreamWriter(socket.getOutputStream()));
		return writer;
		}
		catch (IOException e) {
		    System.out.println(e);
		    return null;
		}
	}
	
	public List<String> tokenizer(String data)
	{
		List<String> token = new ArrayList<String>();
		StringTokenizer temp = new StringTokenizer(data,"#");
		while(temp.hasMoreTokens())
		{
			token.add(temp.nextToken());
		}
		return token;
	}

}
