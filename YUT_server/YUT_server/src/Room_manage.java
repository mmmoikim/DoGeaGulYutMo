import java.io.BufferedWriter;



public class Room_manage {
	
	
	
	public void create_room(int maxplayer, int num, BufferedWriter temp)//num = 방번호
	{

		Room room = new Room();
		YK_Static.list_room.add(room);
		YK_Static.list_room.get(num).put_maxplayer(maxplayer);
		YK_Static.list_room.get(num).put_room_num(num);
		YK_Static.list_room.get(num).put_state(0);
		enter_room(num,temp);
	}
	
	public int enter_room(int num, BufferedWriter temp)//들어가면 1 / 방 다찼으면 0
	{
		if(num != -1)
		{
			if(1 == YK_Static.list_room.get(num).add_player(temp))
			{
			System.out.println("player enter the room");
			return 1;
			}
		}

		System.out.println("room full");
		return 0;
		
	}
	
	
	public int search_room()
	{
		for(int i=0; i<YK_Static.list_room.size(); i++)
		{
			if( YK_Static.list_room.get(i).out_state() == 0)
			{
				return YK_Static.list_room.get(i).out_room_num();//empty 상태 룸 넘버 리턴
			}
		}
		return -1;//-1 이면 빈방 없음
	}
}
