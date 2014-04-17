using System;
using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {

	public class RequestFacade {

		#region statuses

		public RequestStatusInfo[] GetStatuses() {
			Request rst = new Request();
			return rst.GetStatuses();
		}


		public RequestStatusInfo GetStatusInfo(int rStatusID) {
			Request rst = new Request();
			return rst.GetStatusInfo(rStatusID);
		}


		#endregion
	
	
		#region currency

		public CurrencyInfo[] GetCurrencies() {
			Request rst = new Request();
			return rst.GetCurrencies();
		}


		public CurrencyInfo GetCurrencyInfo(int currencyID) {
			Request rst = new Request();
			return rst.GetCurrencyInfo(currencyID);
		}


		#endregion
	

		#region department
		public DepartmentInfo[] GetDepartments() {
			Request rst = new Request();
			return rst.GetDepartments();
		}


		public DepartmentInfo GetDepartmentInfo(int departmentID) {
			Request rst = new Request();
			return rst.GetDepartmentInfo(departmentID);
		}

		#endregion


		#region positions

		public PositionInfo GetPositionInfo(int positionID) {
			Request rst = new Request();
			return rst.GetPositionInfo(positionID);
		}


		public PositionInfo[] GetPositions() {
			Request rst = new Request();
			return rst.GetPositions();
		}


		public PositionInfo[] GetPositions(int departmentID) {
			Request rst = new Request();
			return rst.GetPositions(departmentID);
		}

		
		#endregion

	
		#region requests

		public RequestInfo[] GetRequests(FilterExpression filter, OrderExpression order) {
			Request rst = new Request();
			return rst.GetRequests(filter, order);
		}


		public RequestInfo[] GetRequests() {
			Request rst = new Request();
			return rst.GetRequests();
		}


		public RequestInfo[] GetRequests(int agentID) {
			Request rst = new Request();
			return rst.GetRequests(agentID);
		}


		public RequestInfo GetRequestInfo(int requestID) {
			Request rst = new Request();
			return rst.GetRequestInfo(requestID);
		}


		public bool RemoveRequest(int requestID) {
			Request rst = new Request();
			return rst.RemoveRequest(requestID);
		}


		public bool UpdateRequest(RequestInfo request) {
			Request rst = new Request();
			return rst.UpdateRequest(request);
		}


		public bool AddRequest(RequestInfo request, out int requestID) {
			Request rst = new Request();
			return rst.AddRequest(request, out requestID);
		}

		public int GetRequestsCount() {
			Request rst = new Request();
			return rst.GetRequestsCount();
		}

		public int GetRequestsCount(int requestStatusID) {
			Request rst = new Request();
			return rst.GetRequestsCount(requestStatusID);
		}


		public int GetRequestsCount(int agentID, int requestStatusID) {
			Request rst = new Request();
			return rst.GetRequestsCount(agentID,requestStatusID);
		}

		
		public int GetRequestsCountOfAgent(int agentID) {
			Request rst = new Request();
			return rst.GetRequestsCountOfAgent(agentID);
		}


	#endregion
	
		
		#region request positions

		public RequestPositionInfo[] GetRequestPositions(FilterExpression filter, OrderExpression order) {
			Request rst = new Request();
			return rst.GetRequestPositions(filter, order);
		}


		public RequestPositionInfo[] GetRequestPositions() {
			Request rst = new Request();
			return rst.GetRequestPositions(null, null);
		}

		
		public RequestPositionInfo[] GetRequestPositions(int requestID) {
			Request rst = new Request();
			return rst.GetRequestPositions(requestID);
		}


		public RequestPositionInfo GetRequestPositionInfo(int rqpID) {
			Request rst = new Request();
			return rst.GetRequestPositionInfo(rqpID);
		}


		public bool RemoveRequestPosition(int rqpID) {
			Request rst = new Request();
			return rst.RemoveRequestPosition(rqpID);
		}


		public bool UpdateRequestPosition(RequestPositionInfo rqpInfo,int requestID) {
			Request rst = new Request();
			return rst.UpdateRequestPosition(rqpInfo, requestID);
		}


		public bool AddRequestPosition(RequestPositionInfo rqpInfo, int requestID, out int rqpID) {
			Request rst = new Request();
			return rst.AddRequestPosition(rqpInfo, requestID, out rqpID);
		}

		public int GetRequestPositionCount() {
			Request rst = new Request();
			return rst.GetRequestPositionCount();
		}


		public int GetRequestPositionCount(int requestID) {
			Request rst = new Request();
			return rst.GetRequestPositionCount(requestID);
		}


		#endregion
	

	}
}
