using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Net;

public class Network  : MonoBehaviour
{

		private Socket socket;
		private	String Host = "119.206.203.137";
		private Int32 Port = 5002;
		private NetworkStream networkStream;
		private StreamWriter writer;
		private StreamReader reader;
		private byte[] recvBuffer = new byte[1024];
		private string[] data_array;
		private int enternum = 1;
	
		void Start ()
		{
				DontDestroyOnLoad (this);
				Application.runInBackground = true;

				IPEndPoint ipep = new IPEndPoint (IPAddress.Parse (Host), Port);

				socket = new Socket (AddressFamily.InterNetwork,
		                           SocketType.Stream, ProtocolType.Tcp);

				socket.Connect (ipep);

				networkStream = new NetworkStream (socket);
				writer = new StreamWriter (networkStream);
				reader = new StreamReader (networkStream);

				if (socket.Connected) {
						Debug.Log ("connected");

						socket.BeginReceive (recvBuffer, 0, recvBuffer.Length,
						            SocketFlags.None, new AsyncCallback (ReceiveComplete), null);

				} else {
						Debug.Log ("connect failed");
				}
		}

		private void Shutdown ()
		{
				try {
						if (socket != null) {
								socket.Shutdown (SocketShutdown.Both);
								socket.Close ();
								socket = null;
						}
				} catch (Exception e) {
						Debug.Log ("shutdown error : " + e);
				}
		}
	
		private void ReceiveComplete (IAsyncResult ar)
		{
				try {
						if (null == socket)
								return;
			
						int len = socket.EndReceive (ar);
			
						if (len == 0) {
								Shutdown ();
						} else {
								String temp = System.Text.Encoding.UTF8.GetString (recvBuffer);
								Array.Clear (recvBuffer, 0, recvBuffer.Length);
								Debug.Log (temp);
								data_array = temp.Split ('#');
							
	
								
								foreach (string each in data_array) {
										Debug.Log ("리스트에 추가 : " + each);
										manage_static.read_data.Add (each);
								}

								socket.BeginReceive (recvBuffer, 0, recvBuffer.Length,
					SocketFlags.None, new AsyncCallback (ReceiveComplete), null);

						}                     
				} catch (Exception e) {
						Debug.Log (e);
						Shutdown ();
				}
		}
	
		void write_message (String temp)
		{
				try {
						writer.WriteLine (temp);
						writer.Flush ();
			
				} catch (SocketException err) {
						Debug.Log ("Socket send  error! : " + err.ToString ());
				}
		}
	
		void OnApplicationQuit ()
		{
				try {
						write_message ("quit#" + manage_static.room_num + "#" + manage_static.turn);
						networkStream.Close ();
						writer.Close ();
						socket.Close ();
						socket = null;

						Debug.Log ("Quit!");


				} catch (Exception e) {
						Debug.Log ("Socket close error! : " + e.ToString ());
				}
		}

		void Update ()
		{

				
				if (manage_static.read_data.Count != 0) {

						if (manage_static.read_data [0] == "room_full") {
								Debug.Log ("dddddd : room_full");
								GameObject.Find ("button").SendMessage ("set_message_confirm");
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);

						} else if (manage_static.read_data [0] == "other_throw" && manage_static.read_data.Count == 3) {
								Debug.Log ("dddddd : other_throw");
								int temp = Convert.ToInt32 (manage_static.read_data [1]);
								switch (temp) {
								case -1:
										GameObject.Find ("Info").SendMessage ("Bdo_on");
										GameObject.Find ("Quad").SendMessage ("Bdo_ani_on");
										break;
								case 0:
										GameObject.Find ("Info").SendMessage ("nack_on");
										GameObject.Find ("Quad").SendMessage ("nack_ani_on");
										manage_static.curr_turn = Convert.ToInt32 (manage_static.read_data [2]);
										GameObject.Find ("character0").SendMessage ("turn_set_position", manage_static.curr_turn);
			
										break;
								case 1:
										GameObject.Find ("Info").SendMessage ("do_on");
										GameObject.Find ("Quad").SendMessage ("do_ani_on");
										break;
								case 2:
										GameObject.Find ("Info").SendMessage ("gea_on");
										GameObject.Find ("Quad").SendMessage ("gea_ani_on");
										break;
								case 3:
										GameObject.Find ("Info").SendMessage ("gul_on");
										GameObject.Find ("Quad").SendMessage ("gul_ani_on");
										break;
								case 4:
										GameObject.Find ("Info").SendMessage ("yut_on");
										GameObject.Find ("Quad").SendMessage ("yut_ani_on");
										break;
								case 5:
										GameObject.Find ("Info").SendMessage ("mo_on");
										GameObject.Find ("Quad").SendMessage ("mo_ani_on");
										break;
								}
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);

						} else if (manage_static.read_data [0] == "current_turn") {
								Debug.Log ("dddddd : current_turn");
								manage_static.curr_turn = Convert.ToInt32 (manage_static.read_data [1]);

								GameObject.Find ("character0").SendMessage ("turn_set_position", manage_static.curr_turn);

								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);
							} else if (manage_static.read_data [0] == "goalin" && manage_static.read_data.Count == 21) {/////////////////골인
				int player = Convert.ToInt32 (manage_static.read_data [1]);
				int mal = Convert.ToInt32 (manage_static.read_data [2]);
				int mal_num = Convert.ToInt32 (manage_static.read_data [3]);
				int mal_total = Convert.ToInt32 (manage_static.read_data [4]);
				int grade = Convert.ToInt32 (manage_static.read_data [5]);
				int data_turn = Convert.ToInt32 (manage_static.read_data [6]);
				int re_turn = Convert.ToInt32 (manage_static.read_data [7]);
				int dice = Convert.ToInt32 (manage_static.read_data [21]);

				manage_static.curr_turn = data_turn;
				
				GameObject.Find("character0").SendMessage("turn_set_position", data_turn);
				

				GameObject.Find ("CharBoxPiece_0_0").SendMessage ("piece_on_" + player, mal_total);

								
								int [] move_data = new int[5];
								move_data [0] = player;
								move_data [1] = mal;
								move_data [2] = mal_num;
								move_data [3] = mal_total;
								move_data [4] = dice;
				
								GameObject.Find ("move_mal").SendMessage ("move", move_data);



				if (mal_total == 4) {//4개 골인이면
					GameObject.Find ("result").SendMessage ("player_grade_" + player, grade);

					if (manage_static.turn == player) {//내가 끝난거면
						manage_static.grade = grade;
										}
					
										if (Convert.ToInt32 (manage_static.read_data [8]) == 1) {
												if (manage_static.grade == 1) {
														GameObject.Find ("result").SendMessage ("win_on");
												} else {
														GameObject.Find ("result").SendMessage ("lose_on");
												}
										}
										String [] result = new string[30];

										for (int i=9; i<21; i++) {
												result [i - 9] = manage_static.read_data [i];
												Debug.Log (result [i - 9]);
										}
										GameObject.Find ("result").SendMessage ("put_text", result);
					
								}

				if (manage_static.turn == player) {
					manage_static.mal_state [mal] = 4;//골인한 말 상태 변경

					int count = 0;
					for(int i=0; i<4; i++)
					{
						if(mal_num != count -1 && manage_static.mal_state[i] == 3)
						{
							manage_static.mal_state[i] = 4;
							count++;
						}
					}



					if (re_turn == 1 && manage_static.turn == data_turn) {
												GameObject.Find ("S_marker0").SendMessage ("marker_set_position");
										}

								}



								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);
				
						} else if (manage_static.read_data [0] == "mal_move" && manage_static.read_data.Count == 14) {////////////////////말 이동

								String player_num = manage_static.read_data [1];
								int [] temp = new int[3];
								temp [0] = Convert.ToInt32 (manage_static.read_data [2]);//mal num
								temp [1] = Convert.ToInt32 (manage_static.read_data [3]);//x
								temp [2] = Convert.ToInt32 (manage_static.read_data [4]);//y

								int dice = Convert.ToInt32 (manage_static.read_data [13]);
								manage_static.curr_turn = Convert.ToInt32 (manage_static.read_data [5]);

								GameObject.Find ("character0").SendMessage ("turn_set_position", manage_static.curr_turn);
				
								int [] move_data = new int[5];
								move_data [0] = Convert.ToInt32 (manage_static.read_data [1]);
								move_data [1] = Convert.ToInt32 (manage_static.read_data [2]);
								move_data [2] = Convert.ToInt32 (manage_static.read_data [3]);
								move_data [3] = Convert.ToInt32 (manage_static.read_data [4]);
								move_data [4] = dice;
						
								GameObject.Find ("move_mal").SendMessage ("move", move_data);




								

								if (Convert.ToInt32 (manage_static.read_data [6]) == 1
										&& manage_static.turn == manage_static.curr_turn)
									{

										manage_static.move_state [2] = 1;

								}

				if (manage_static.read_data [7] == "catch") {

					manage_static.move_state [0] = 1;
					int [] data_c = new int[5]{ Convert.ToInt32(manage_static.read_data [8]),
						Convert.ToInt32(manage_static.read_data [10]),
						                Convert.ToInt32(manage_static.read_data [9]),
						                Convert.ToInt32(manage_static.read_data [11]),
						                Convert.ToInt32(manage_static.read_data [12])};

					GameObject.Find("move_mal").SendMessage("get_data",data_c);

				}
				else if (manage_static.read_data [7] == "piggy") {
					manage_static.move_state [1] = 1;
					int [] data_p = new int[5]{ Convert.ToInt32(manage_static.read_data [8]),
						Convert.ToInt32(manage_static.read_data [9]),
						                Convert.ToInt32(manage_static.read_data [10]),
						                Convert.ToInt32(manage_static.read_data [11]),
						                Convert.ToInt32(manage_static.read_data [12])};
					
					GameObject.Find("move_mal").SendMessage("get_data",data_p);
				}
			
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);

						} else if (manage_static.read_data [0] == "player_enter" && manage_static.read_data.Count == 3) {
								Debug.Log ("dddddd : player_enter");

								if (manage_static.turn == -1) {//내가 들어온거
										Application.LoadLevel ("game");
										manage_static.room_num = Convert.ToInt32 (manage_static.read_data [2]);
										Debug.Log ("my room :" + manage_static.room_num);
										manage_static.turn = Convert.ToInt32 (manage_static.read_data [1]);
										Debug.Log ("my turn :" + manage_static.turn);

								} else {//딴사람 들어온거
										enternum++;
										if (manage_static.turn == 0 && enternum == manage_static.maxplayer) {
												GameObject.Find ("character0").SendMessage ("start_on");
										}
										GameObject.Find ("character0").SendMessage ("character_on", Convert.ToInt32 (manage_static.read_data [1]));
										GameObject.Find ("door_0").SendMessage ("door_open_" + Convert.ToInt32 (manage_static.read_data [1]));
					                                            
								}
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);

						} else if (manage_static.read_data [0] == "quit_other" && manage_static.read_data.Count == 2) {
								Debug.Log ("dddddd : quit_other");
								GameObject.Find ("character0").SendMessage ("character_off", Convert.ToInt32 (manage_static.read_data [1]));
								GameObject.Find ("door_0").SendMessage ("door_close_" + Convert.ToInt32 (manage_static.read_data [1]));
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);

						} else if (manage_static.read_data [0] == "game_start") {
								Debug.Log ("dddddd : game_start");
								GameObject.Find ("character0").SendMessage ("turn_set_position", manage_static.curr_turn);
								manage_static.read_data.Clear ();
								Debug.Log ("clear read data : " + manage_static.read_data.Count);
						} else {
								Debug.Log ("dddddd : else" + manage_static.read_data [0] + "coutn : " + manage_static.read_data.Count);

						}

				}
		
		}
}