package org.mscda.group5.dao;

import java.sql.Connection;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.mscda.group5.model.LogIn;
import org.mscda.group5.model.OrderDetails;
import org.mscda.group5.model.PaymentInformation;

import com.mysql.jdbc.Statement;

public class JDBCConnectionDAOImpl {
	
	public List<OrderDetails> getAllOrderDetails() {

		List<OrderDetails> orderList = new ArrayList<OrderDetails>();

		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();

		try {
			 PreparedStatement ps = connection.prepareStatement(
			 "select * from mcda551005.cakeorderdetails");
			 ResultSet rs = ps.executeQuery();
	
			while (rs.next()) {
			 OrderDetails order = new OrderDetails();
			 order.setOrderID(rs.getInt("OrderID"));
			 order.setCakeName(rs.getString("CakeName"));
			 order.setCakeType(rs.getString("CakeType"));
			 order.setWeight(rs.getString("Weight"));
			 order.setDeliveryDate(rs.getString("DeliveryDate"));
			 order.setDeliveryTime(rs.getString("DeliveryTime"));
			 order.setFirstName(rs.getString("FirstName"));
			 order.setLastName(rs.getString("LastName"));
			 order.setStreetNumber(rs.getString("StreetNumber"));
			 order.setAddress(rs.getString("Address"));
			 order.setCity(rs.getString("City"));
			 order.setProvince(rs.getString("Province"));
			 order.setCountry(rs.getString("Country"));
			 order.setPostalCode(rs.getString("PostalCode"));
			 orderList.add(order);
		   }
		   rs.close();
		   ps.close();

		} catch (SQLException e) {
		 // TODO Auto-generated catch block
		 e.printStackTrace();
		 }

	return orderList;
	}
	
	public OrderDetails getOrderDetails(String oId) {
		
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();
		OrderDetails order = new OrderDetails();

		try {
			 PreparedStatement ps = connection.prepareStatement(
			 "select * from mcda551005.cakeorderdetails where OrderId="+oId);
			 ResultSet rs = ps.executeQuery();
	
			 while (rs.next()) {
				 order.setOrderID(rs.getInt("OrderID"));
				 order.setCakeName(rs.getString("CakeName"));
				 order.setCakeType(rs.getString("CakeType"));
				 order.setWeight(rs.getString("Weight"));
				 order.setDeliveryDate(rs.getString("DeliveryDate"));
				 order.setDeliveryTime(rs.getString("DeliveryTime"));
				 order.setFirstName(rs.getString("FirstName"));
				 order.setLastName(rs.getString("LastName"));
				 order.setStreetNumber(rs.getString("StreetNumber"));
				 order.setAddress(rs.getString("Address"));
				 order.setCity(rs.getString("City"));
				 order.setProvince(rs.getString("Province"));
				 order.setCountry(rs.getString("Country"));
				 order.setPostalCode(rs.getString("PostalCode"));
		    }
			rs.close();
		    ps.close();
	
		} catch (SQLException e) {
		 // TODO Auto-generated catch block
		 e.printStackTrace();
		 }
	return order;
		
		
	}
	
	public int postOrderDetails(OrderDetails order) {
		int orderID = -1;
		
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();

		try {
		 PreparedStatement ps = connection.prepareStatement(
		 "insert into mcda551005.cakeorderdetails (cakeName,cakeType,weight,deliveryDate,deliveryTime,firstName,lastName,streetNumber,address,city,province,country,postalCode) "
		 + "values (?,?,?,?,?,?,?,?,?,?,?,?,?)",Statement.RETURN_GENERATED_KEYS);
		 ps.setString(1, order.getCakeName());
		 ps.setString(2, order.getCakeType());
		 ps.setString(3, order.getWeight());
		 SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
		 java.util.Date date = new java.util.Date();
		try {
			date = formatter.parse(order.getDeliveryDate());
		} catch (ParseException e) {
			e.printStackTrace();
		}
		 java.sql.Date sqlStartDate = new java.sql.Date(date.getTime());  
		 ps.setDate(4, sqlStartDate);
		 ps.setString(5, order.getDeliveryTime());
		 ps.setString(6, order.getFirstName());
		 ps.setString(7, order.getLastName());
		 ps.setString(8, order.getStreetNumber());
		 ps.setString(9, order.getAddress());
		 ps.setString(10, order.getCity());
		 ps.setString(11, order.getProvince());
		 ps.setString(12, order.getCountry());
		 ps.setString(13, order.getPostalCode());
		 int result = ps.executeUpdate();
		 if (result > 0) {
			 ResultSet rs = ps.getGeneratedKeys();
		     if (rs.next()){
		         orderID =rs.getInt(1);			    
		     }
		     rs.close();
		  }
		  ps.close();		 
		} catch (SQLException e) {
			 // TODO Auto-generated catch block
			 e.printStackTrace();
        }

		return orderID;
		
	}
	
	public void postPaymentInformation(PaymentInformation paymentInfo) {
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();
		try {
			 PreparedStatement stmt = connection.prepareStatement(
		    		 "insert into mcda551005.paymentinformation (emailAddress,phoneNumber,creditCardType,name,creditCardNumber,expirationDate,codID) values(?,?,?,?,?,?,?)");
			 stmt.setString(1, paymentInfo.getEmailAddress());
			 stmt.setString(2, paymentInfo.getPhoneNumber());
			 stmt.setString(3, paymentInfo.getCreditCardType());
			 stmt.setString(4, paymentInfo.getName());
			 stmt.setString(5, paymentInfo.getCreditCardNumber());
			 SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
			 java.util.Date date = new java.util.Date();
			 try {
				date = formatter.parse(paymentInfo.getExpirationDate());
			 } catch (ParseException e) {
				e.printStackTrace();
			 }
			 java.sql.Date sqlStartDate = new java.sql.Date(date.getTime());  
			 stmt.setDate(6, sqlStartDate);
			 stmt.setInt(7, paymentInfo.getCodID());
			 int result = stmt.executeUpdate();
			 stmt.close();
		} catch (SQLException e) {
			 // TODO Auto-generated catch block
			 e.printStackTrace();
       }
	}

	
	public boolean deleteOrder(int oID) {
		boolean bStatus = false;
		int pid = 0;
		
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();

		try {
		 PreparedStatement ps = connection.prepareStatement(
				 				"select * from mcda551005.paymentinformation where CodId="+oID);
		 ResultSet rs = ps.executeQuery();
		 if (rs.next()) {
			 pid = rs.getInt("PID");
			 PreparedStatement stmt = connection.prepareStatement(
		    		 "delete from mcda551005.paymentinformation where PID="+pid);
			 int result = stmt.executeUpdate();
			 if (result > 0) {
				 PreparedStatement ps_deleteOrder = connection.prepareStatement(
			    		 "delete from mcda551005.paymentinformation where OrderID="+oID);
				 result = ps_deleteOrder.executeUpdate();
				 ps_deleteOrder.close();
				 if(result > 0) {
					 bStatus = true;
				 }
			 }
			 stmt.close();
			 
		 }
		 rs.close();
		 ps.close();		 
		
		} catch (SQLException e) {
			 // TODO Auto-generated catch block
			 e.printStackTrace();
       }

		return bStatus;
	}
	
	public List<PaymentInformation> getAllPaymentinfo() {

		List<PaymentInformation> piList = new ArrayList<PaymentInformation>();
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();

		try {
			 PreparedStatement ps = connection.prepareStatement(
			 "select * from mcda551005.PaymentInformation");
			 ResultSet rs = ps.executeQuery();
	
			while (rs.next()) {
				PaymentInformation pi = new PaymentInformation();
				pi.setEmailAddress(rs.getString("EmailAddress"));
				pi.setPhoneNumber(rs.getString("PhoneNumber"));
				pi.setCreditCardType(rs.getString("CreditCardType"));
				pi.setName(rs.getString("Name"));
				pi.setCreditCardNumber(rs.getString("CreditCardNumber"));
				pi.setExpirationDate(rs.getString("ExpirationDate"));
				pi.setCodID(rs.getInt("CodId"));
				pi.setPid(rs.getInt("PID"));
			    piList.add(pi);
		   }
		   rs.close();
		   ps.close();

		 } catch (SQLException e) {
			 // TODO Auto-generated catch block
			 e.printStackTrace();
		 }

		return piList;
	}
	
	public boolean postLogin(LogIn login) {
		boolean bStatus = false;
		int pid = 0;
		
		JDBCConnectionDAO jdbcConnection = new JDBCConnectionDAO();
		Connection connection = jdbcConnection.getConnnection();

		try {
			PreparedStatement ps = connection.prepareStatement("select * from mcda551005.login where userID=? and password=?");
			ps.setString(1, login.getUser());
			ps.setString(2, login.getPassword());
			ResultSet rs = ps.executeQuery();
			if (rs.next()) {
				bStatus = true;
			}
			rs.close();
			ps.close();			
		} catch (SQLException e) {
			 // TODO Auto-generated catch block
			 e.printStackTrace();
		}
		return bStatus;
	}
}
