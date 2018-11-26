package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDateTime;

public class Prueba {
	private static Connection connection;
	public static void main(String[] args) throws SQLException {
		//Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
		connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		Statement statement = connection.createStatement();
		
		insert();
		
		
		
		ResultSet resultSet = statement.executeQuery("select * from categoria");
		while(resultSet.next())
			System.out.printf("%s %-40s\n", resultSet.getObject(1), resultSet.getObject(2));//-40 ancho
		statement.close();// implicit resultSet.Close()
		connection.close();
	}
	
	private static void insert() throws SQLException{
		String insertSQL = "Insert into categoria (nombre) values (?)";
		PreparedStatement preparedStatement = connection.prepareStatement(insertSQL);
		preparedStatement.setObject(1, "categoria " + LocalDateTime.now());
		preparedStatement.executeUpdate();
		preparedStatement.close();
	}
	private static void delete() throws SQLException{
		
	}

}
