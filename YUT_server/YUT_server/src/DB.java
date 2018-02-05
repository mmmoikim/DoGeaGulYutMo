import java.sql.*;

public class DB {
	private Connection conn;
	private Statement stmt;
	private ResultSet rs;

	DB() {
		try {
			Class.forName("com.mysql.jdbc.Driver");// 드라이버 로딩: DriverManager에 등록
		} catch (ClassNotFoundException e) {
			System.err.print("ClassNotFoundException: ");
		}

		try {
			String jdbcUrl = "jdbc:mysql://localhost/yutdb";// 사용하는 데이터베이스명을 포함한
															// url
			String userId = "root";// 사용자계정
			String userPass = "yutsql";// 사용자 패스워드

			conn = DriverManager.getConnection(jdbcUrl, userId, userPass);// Connection
																			// 객체를
																			// 얻어냄

			stmt = conn.createStatement();// Statement 객체를 얻어냄

			System.out.println("제대로 연결되었습니다");// 성공시 화면에 표시됨

		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}

	}
	
	void get_user(String cn,String nickname)
	{
		String user_cn = select_db(cn);
		if(user_cn == "")
		{
			insert_db(cn,nickname);
		}
	}

	String select_db(String cn)
	{
		String result = "";
		try {
			
			rs = stmt.executeQuery("SELECT * FROM yuttable where CN = '"+cn +"'");
			 
			 if(rs.next())
			 {
			  result = rs.getString("nick") + "#" +  rs.getInt("winnum") + "#" + rs.getInt("losenum");
			 }
	
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
		return result;
	}
	
	void insert_db(String cn, String nickname) {
		String query = " insert into yuttable (CN, nick, winnum, losenum)"
				+ " values (?, ?, ? ,?)";
		try {
			PreparedStatement preparedStmt = conn.prepareStatement(query);
			preparedStmt.setString(1, cn);
			preparedStmt.setString(2, nickname);
			preparedStmt.setInt(3, 0);
			preparedStmt.setInt(4, 0);

			preparedStmt.execute();
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
	}
	
	void update_win_db(String cn) {
		
		int ori_winnum = 0;
		
		try {
			
			rs = stmt.executeQuery("SELECT * FROM yuttable where CN = '"+cn +"'");
			 
			 if(rs.next())
			 {
				 ori_winnum = rs.getInt("winnum");//원래꺼 가져오기
			 }
			
			 
			String query = "UPDATE yuttable SET winnum = ? where CN = ?";
			PreparedStatement preparedStmt = conn.prepareStatement(query);
			preparedStmt.setInt(1, ori_winnum + 1);
			preparedStmt.setString(2, cn);
			preparedStmt.executeUpdate();
			
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
	}
	
void update_lose_db(String cn) {
		int ori_losenum = 0;
		
		try {
			rs = stmt.executeQuery("SELECT * FROM yuttable where CN = '"+cn +"'");
			 
			 if(rs.next())
			 {
				 ori_losenum = rs.getInt("losenum");//원래꺼 가져오기
			 }
			 
			
			String query = "UPDATE yuttable SET losenum = ? where CN = ?";
			
			PreparedStatement preparedStmt = conn.prepareStatement(query);
			preparedStmt.setInt(1, ori_losenum + 1);
			preparedStmt.setString(2, cn);
			preparedStmt.executeUpdate();
			
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
	}
	
void delete_db(String cn) {
		
		String query = "DELETE FROM yuttable where CN = ?";
		
		try {
			
			PreparedStatement preparedStmt = conn.prepareStatement(query);
			preparedStmt.setString(1, cn);
			preparedStmt.executeUpdate();
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
	}

	void conn_close() {
		try {
			stmt.close();
			conn.close();
		} catch (SQLException e) {
			System.out.println("SQLException: " + e.getMessage());
		}
	}

}
