package org.mscda.group5.service;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;


import org.mscda.group5.dao.JDBCConnectionDAOImpl;
import org.mscda.group5.model.LogIn;
import org.mscda.group5.model.OrderDetails;
import org.mscda.group5.model.PaymentInformation;


@Path("/Order")
public class OrderService {

	@GET
	@Path("/orderhistory")
	@Produces({MediaType.APPLICATION_JSON})
	public Response getOrderHistory() {
	 String dummyDetails = null;
	 List<OrderDetails> orderList = null;

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 orderList = orderDaoImpl.getAllOrderDetails();
	 
	 if(orderList.size() ==0) {
     	return Response.status(Response.Status.NO_CONTENT).build();
     }
     return Response.status(Response.Status.OK).entity(orderList).build();
	}
	
	@POST
	@Path("/login")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response validateLogin(LogIn loginCreds) {
 
	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 boolean result = orderDaoImpl.postLogin(loginCreds);
	 if(result) {
		 return Response.status(Response.Status.NO_CONTENT).build();
	 } else {
		 return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
	 }
	 
	}

	@GET
	@Path("/orderdetails/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getOrderDetails(@PathParam("id") String orderId) {
	 OrderDetails orderList = null;

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 orderList = orderDaoImpl.getOrderDetails(orderId);
	 return Response.status(Response.Status.OK).entity(orderList).build();
	}
	
	@GET
	@Path("/paymenthistory")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getPaymentinfo() {
		List<PaymentInformation> piList = null;

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 piList = orderDaoImpl.getAllPaymentinfo();
	 return Response.status(Response.Status.OK).entity(piList).build();
	}
	
	@POST
	@Path("/postorderdetails")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response postOrderDetails(OrderDetails order) {

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 int oId = orderDaoImpl.postOrderDetails(order);
	 return Response.status(Response.Status.NO_CONTENT).entity(oId).build();

	}
	
	@POST
	@Path("/postpaymentinfo")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response postPaymentInformation(PaymentInformation paymentInfo) {

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 orderDaoImpl.postPaymentInformation(paymentInfo);
	 return Response.status(Response.Status.NO_CONTENT).build();

	}
	
	@PUT
	@Path("/putorderdetails")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response putOrderDetails(OrderDetails order) {

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 int oId = orderDaoImpl.postOrderDetails(order);
	 return Response.status(Response.Status.NO_CONTENT).build();

	}
	
	@PUT
	@Path("/putpaymentinfo")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response putPaymentInformation(PaymentInformation paymentInfo) {

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 orderDaoImpl.postPaymentInformation(paymentInfo);
	 return Response.status(Response.Status.NO_CONTENT).build();

	}
	
	@DELETE
	@Path("/deleteorder/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response deleteOrder(@PathParam("id") String orderId) {

	 JDBCConnectionDAOImpl orderDaoImpl = new JDBCConnectionDAOImpl();
	 boolean bStatus = orderDaoImpl.deleteOrder(Integer.parseInt(orderId));
	 return Response.status(Response.Status.NO_CONTENT).build();
	}
	
}
