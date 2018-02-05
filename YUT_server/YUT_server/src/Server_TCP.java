import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;



public class Server_TCP {
		
	private int port;
	private ServerSocket server_socket = null;
	
	public void Init_server(int PortNum)
	{
		port = PortNum;//포트 받아오기
		System.out.println("port = " + port);
		
		try{
			server_socket = new ServerSocket(port);//서버 소켓 생성
			System.out.println("Server waiting for client on port "+ port);
			Listening();
			}
		catch (IOException e) {
			System.out.println(e);
		}
	}
	
	public void Listening()
	{
		try
		{
		while (true) 
		{
			Socket Client_Socket = server_socket.accept();//클라이언트 소켓 받기
	
			InetAddress Client_IP = Client_Socket.getInetAddress();//클라이언트 주소 받기
			int Client_Port = Client_Socket.getLocalPort();
			
			System.out.println("New connection accepted " + Client_IP + ":"
					+ Client_Port);
			
			Handler thread = new Handler(Client_Socket);//스레드
			thread.start();

		}
		}
		catch (IOException e) {
		    System.out.println(e);
		}
		
		

}
}
