import java.util.ArrayList;
import java.util.List;



public class Main {
	
	
	public static void main(String args[]) {
	
		Server_TCP server = new Server_TCP();
		server.Init_server(5002);
		server.Listening();
		
	}
	
}