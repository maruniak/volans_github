using System;

namespace Volans.Common {

	public class RequestListItem {

		#region private
		private RequestStatusInfo _requestStatus;
		private AgentInfo _agent;
		private VesselInfo _vessel;
		private RequestPositionInfo _requestPosition;
		private int _requestID;
		#endregion

		#region properties
		public RequestStatusInfo RequestStatus{
			get {return _requestStatus;}
			set {_requestStatus = value;}
		}

		public AgentInfo Agent{
			get {return _agent;}
			set {_agent = value;}
		}

		public VesselInfo Vessel{
			get {return _vessel;}
			set {_vessel = value;}
		}

		public RequestPositionInfo RequestPosition{
			get {return _requestPosition;}
			set {_requestPosition = value;}
		}

		public int RequestID {
			get { return _requestID;}
			set {_requestID = value;}
		}
		#endregion

		#region constructor
		public RequestListItem() {
			RequestStatus = new RequestStatusInfo();
			RequestPosition = new RequestPositionInfo();
			Agent = new AgentInfo();
			Vessel = new VesselInfo();
			RequestID = PersistentBusinessEntity.ID_Empty;
		}

		#endregion


	}
}
