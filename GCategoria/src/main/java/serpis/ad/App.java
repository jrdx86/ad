package serpis.ad;

import java.net.ConnectException;
import java.sql.Connection;

public class App {
	private static App instance = new App();
	
	private App() { }
	
	public static App getInstance() {
		return instance;
	}
	public Connection connection;
	
	public Connection getConnection() {
		return connection;
	}
	public void setConnection (Connection connection) {
		this.connection = connection;
	}
}
