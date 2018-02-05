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
		port = PortNum;//��Ʈ �޾ƿ���
		System.out.println("port = " + port);
		
		try{
			server_socket = new ServerSocket(port);//���� ���� ����
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
			Socket Client_Socket = server_socket.accept();//Ŭ���̾�Ʈ ���� �ޱ�
	
			InetAddress Client_IP = Client_Socket.getInetAddress();//Ŭ���̾�Ʈ �ּ� �ޱ�
			int Client_Port = Client_Socket.getLocalPort();
			
			System.out.println("New connection accepted " + Client_IP + ":"
					+ Client_Port);
			
			Handler thread = new Handler(Client_Socket);//������
			thread.start();

		}
		}
		catch (IOException e) {
		    System.out.println(e);
		}
		
		

}
}
