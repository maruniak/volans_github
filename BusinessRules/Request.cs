using System;
using Volans.Common;
using Volans.DAL;


namespace Volans.BusinessRules {

	public class Request {

		#region statuses

		public RequestStatusInfo[] GetStatuses() {
			RequestStatusInfo[] statuses  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				statuses = rDal.GetStatuses();
			}
			return statuses;
		}


		public RequestStatusInfo GetStatusInfo(int rStatusID) {
			RequestStatusInfo status  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				status = rDal.GetStatusInfo(rStatusID);
			}
			return status;
		}


		#endregion

	
		#region currency

		public CurrencyInfo[] GetCurrencies() {
			CurrencyInfo[] currencies  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				currencies = rDal.GetCurrencies();
			}
			return currencies;
		}


		public CurrencyInfo GetCurrencyInfo(int currencyID) {
			CurrencyInfo cur  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				cur = rDal.GetCurrencyInfo(currencyID);
			}
			return cur;
		}


		#endregion
	

		#region departments

		public DepartmentInfo[] GetDepartments() {
			DepartmentInfo[] departments  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				departments = rDal.GetDepartments();
			}
			return departments;
		}


		public DepartmentInfo GetDepartmentInfo(int departmentID) {
			DepartmentInfo dep  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				dep = rDal.GetDepartmentInfo(departmentID);
			}
			return dep;
		}


		#endregion
	

		#region positions

		private bool FillPositionInfo(ref PositionInfo pos) {
			RequestDAL rDal = new RequestDAL();
			if (pos.Department.DepartmentID != PersistentBusinessEntity.ID_Empty)
				pos.Department  = rDal.GetDepartmentInfo(pos.Department.DepartmentID);
			return true;
		}


		public PositionInfo GetPositionInfo(int positionID) {
			PositionInfo pos  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				pos = rDal.GetPositionInfo(positionID);
			}
			if (pos != null)
				FillPositionInfo(ref pos);
			return pos;
		}


		public PositionInfo[] GetPositions() {
			PositionInfo[] positions  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				positions = rDal.GetPositions(null, null);
			}
			if (positions != null)
				for (int i=0; i<positions.Length; i++)
					FillPositionInfo(ref positions[i]);
			return positions;
		}


		public PositionInfo[] GetPositions(int departmentID) {
			PositionInfo[] positions  = null;
			FilterExpression filter = null;
			if(departmentID != PersistentBusinessEntity.ID_Empty) {
				filter = new FilterExpression(typeof(PositionFields));
				filter.Add(PositionFields.depID, departmentID);
			}
			using (RequestDAL rDal = new RequestDAL()) {
				positions = rDal.GetPositions(filter, null);
			}
			if (positions != null)
				for (int i=0; i<positions.Length; i++)
					FillPositionInfo(ref positions[i]);
			return positions;
		}

		
		#endregion

	
		#region requests

		private bool FillRequestInfo(ref RequestInfo rqs) {
			/*AgentDAL aDal = new AgentDAL();
			VesselDAL vDal = new VesselDAL();
			RequestDAL rDal = new RequestDAL();
			*/
			Agent aRules = new Agent();
			Vessel vRules = new Vessel();
			

			if(rqs.Agent.AgentID != PersistentBusinessEntity.ID_Empty)
				rqs.Agent = aRules.GetInfo(rqs.Agent.AgentID);
			if(rqs.Vessel.VesselID != PersistentBusinessEntity.ID_Empty)
				rqs.Vessel = vRules.GetInfo(rqs.Vessel.VesselID);
			if(rqs.Status.RequestStatusID != PersistentBusinessEntity.ID_Empty)
				rqs.Status = GetStatusInfo(rqs.Status.RequestStatusID);
			return true;
		}


		public RequestInfo[] GetRequests(FilterExpression filter, OrderExpression order) {
			RequestInfo[] requests  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				requests = rDal.GetRequests(filter, order);
			}
			if (requests != null)
				for (int i=0; i<requests.Length; i++)
					FillRequestInfo(ref requests[i]);

			return requests;
		}


		public RequestInfo[] GetRequests() {
			return GetRequests(null, null);
		}


		public RequestInfo[] GetRequests(int agentID) {
			FilterExpression filter = new FilterExpression(typeof(RequestFields));
			filter.Add(RequestFields.rqsAgent, agentID);
			return GetRequests(filter, null);
		}


		public RequestInfo GetRequestInfo(int requestID) {
			RequestInfo request  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				request = rDal.GetRequestInfo(requestID);
			}
			if (request != null)
				FillRequestInfo(ref request);
			return request;
		}


		public bool RemoveRequest(int requestID) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.RemoveRequest(requestID);
			}
			return res;
		}


		public bool UpdateRequest(RequestInfo request) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.UpdateRequest(request);
			}
			return res;
		}


		public bool AddRequest(RequestInfo request, out int requestID) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.AddRequest(request,out requestID);
			}
			return res;
		}


		private int CalculateRequests(FilterExpression filter) {
			int itemCount = 0;
			using (RequestDAL rDal = new RequestDAL()) {
				itemCount = rDal.CalculateRequests(filter);
			}
			return itemCount;
		}


		public int GetRequestsCount() {
			return CalculateRequests(null);
		}


		public int GetRequestsCount(int requestStatusID) {
			FilterExpression filter = new FilterExpression(typeof(RequestFields));
			filter.Add(RequestFields.rqsStatus, requestStatusID);
			return CalculateRequests(filter);
		}


		public int GetRequestsCount(int agentID, int requestStatusID) {
			FilterExpression filter = new FilterExpression(typeof(RequestFields));
			filter.Add(RequestFields.rqsStatus, requestStatusID);
			filter.Add(RequestFields.rqsAgent, agentID);
			return CalculateRequests(filter);
		}

		
		public int GetRequestsCountOfAgent(int agentID) {
			FilterExpression filter = new FilterExpression(typeof(RequestFields));
			filter.Add(RequestFields.rqsAgent, agentID);
			return CalculateRequests(filter);
		}


			#endregion
	

		#region request positions

		private bool FillRequestPositionInfo(ref RequestPositionInfo rqp) {
			RequestDAL rDal = new RequestDAL();
			if(rqp.Currency.CurrencyID != PersistentBusinessEntity.ID_Empty)
				rqp.Currency = rDal.GetCurrencyInfo(rqp.Currency.CurrencyID);
			//if(rqp.Position.PositionID != PersistentBusinessEntity.ID_Empty)
			//	rqp.Position = rDal.GetPositionInfo(rqp.Position.PositionID);
			rqp.Position = GetPositionInfo(rqp.Position.PositionID);
			return true;
		}


		public RequestPositionInfo[] GetRequestPositions(FilterExpression filter, OrderExpression order) {
			RequestPositionInfo[] rqps  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				rqps = rDal.GetRequestPositions(filter, order);
			}
			if (rqps != null)
				for (int i=0; i<rqps.Length; i++)
					FillRequestPositionInfo(ref rqps[i]);

			return rqps;
		}


		public RequestPositionInfo[] GetRequestPositions() {
			return GetRequestPositions(null, null);
		}

		
		public RequestPositionInfo[] GetRequestPositions(int requestID) {
			FilterExpression filter = new FilterExpression(typeof(RequestPositionFields));
			filter.Add(RequestPositionFields.rqpRequest, requestID);
			return GetRequestPositions(filter, null);
		}


		public RequestPositionInfo GetRequestPositionInfo(int rqpID) {
			RequestPositionInfo rqp  = null;
			using (RequestDAL rDal = new RequestDAL()) {
				rqp = rDal.GetRequestPositionInfo(rqpID);
			}
			if (rqp != null)
				FillRequestPositionInfo(ref rqp);

			return rqp;
		}


		public bool RemoveRequestPosition(int rqpID) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.RemoveRequestPosition(rqpID);
			}
			return res;
		}


		public bool UpdateRequestPosition(RequestPositionInfo rqpInfo,int requestID) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.UpdateRequestPosition(rqpInfo, requestID);
			}
			return res;
		}


		public bool AddRequestPosition(RequestPositionInfo rqpInfo, int requestID, out int rqpID) {
			bool res = false;
			using (RequestDAL rDal = new RequestDAL()) {
				res = rDal.AddRequestPosition(rqpInfo, requestID,out rqpID);
			}
			return res;
		}


		private int CalculateRequestPositions(FilterExpression filter) {
			int itemCount = 0;
			using (RequestDAL rDal = new RequestDAL()) {
				itemCount = rDal.CalculateRequestPositions(filter);
			}
			return itemCount;
		}


		public int GetRequestPositionCount() {
			return CalculateRequestPositions(null);
		}


		public int GetRequestPositionCount(int requestID) {
			FilterExpression filter = new FilterExpression(typeof(RequestPositionFields));
			filter.Add(RequestPositionFields.rqpRequest, requestID);
			return CalculateRequestPositions(filter);
		}



		#endregion
	
	
	}
}
