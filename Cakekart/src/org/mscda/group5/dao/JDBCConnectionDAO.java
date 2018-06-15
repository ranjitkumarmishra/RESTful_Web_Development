package org.mscda.group5.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class JDBCConnectionDAO {

	public Connection getConnnection() {
		 Connection connection = null;

		try {
		 String connectionURL = "jdbc:mysql://localhost:3306/mcda551005";
		 Class.forName("com.mysql.jdbc.Driver").newInstance();
		 connection = DriverManager.getConnection(connectionURL, "root", "root");


		} catch (InstantiationException | IllegalAccessException | ClassNotFoundException | SQLException e) {
		 // TODO Auto-generated catch block
		 e.getLocalizedMessage();
		 }
		 return connection;
	}

}
