using System;

namespace Volans.Common {
	public class RequestStatusInfo {
		#region private
		private Int16 _rqsID;
		private string _name;
		private Int16 _code;
		#endregion

		#region properties
		public Int16 RequestStatusID {
			get { return _rqsID; }
			set { _rqsID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public Int16 Code {
			get { return _code; }
			set { _code = value; }
		}
		#endregion

		#region constructors
		public RequestStatusInfo() {
			RequestStatusID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}


	public class CurrencyInfo {
		#region private
		private Int16 _currencyID;
		private string _name;
		#endregion

		#region properties
		public Int16 CurrencyID {
			get { return _currencyID; }
			set { _currencyID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public CurrencyInfo() {
			CurrencyID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}


	public class DepartmentInfo {
		#region private
		private Int16 _depID;
		private string _name;
		#endregion

		#region properties
		public Int16 DepartmentID {
			get { return _depID; }
			set { _depID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public DepartmentInfo() {
			DepartmentID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}


	public class PositionInfo {
		#region private
		private Int16 _positionID;
		private DepartmentInfo _department;
		private string _name;
		#endregion

		#region properties
		public Int16 PositionID {
			get { return _positionID; }
			set { _positionID = value; }
		}

		public DepartmentInfo Department {
			get { return _department; }
			set { _department = value;}
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public PositionInfo() {
			PositionID = PersistentBusinessEntity.ID_Empty;
			Department = new DepartmentInfo();
		}
		#endregion
	}


	public class RequestPositionInfo {
		#region private
		private int _rqpID;
		//		private int _requestID; //TODO
		private PositionInfo _position;
		private Int16 _quantity;
		private Int16 _salary;
		private CurrencyInfo _currency;
		private byte _lengthCo;
		private string _comments;
		#endregion

		#region properties
		public int RequestPositionID {
			get { return _rqpID; }
			set { _rqpID = value; }
		}

		public PositionInfo Position {
			get { return _position; }
			set { _position = value; }
		}

		public Int16 Quantity {
			get { return _quantity; }
			set { _quantity = value; }
		}

		public Int16 Salary {
			get { return _salary; }
			set { _salary = value; }
		}

		public CurrencyInfo Currency {
			get { return _currency; }
			set { _currency = value; }
		}

		public byte ContractLength {
			get { return _lengthCo; }
			set { _lengthCo = value; }
		}

		public string Comments {
			get { return _comments; }
			set { _comments = value; }
		}

		#endregion

		#region constructors
		public RequestPositionInfo() {
			RequestPositionID = PersistentBusinessEntity.ID_Empty;
			Position = new PositionInfo();
			Currency = new CurrencyInfo();
			Salary = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}




	public class RequestInfo {
		#region private
		private int _requestID;
		private RequestStatusInfo _status;
		private AgentInfo _agent;
		private VesselInfo _vessel;
		private string _portArr;
		private DateTime _dateArr;
		private string _description;
		private DateTime _dateDB;
		private RequestPositionInfo[] _positions;
		private Int16 _crewQuantity;
		#endregion

		#region properties
		public int RequestID {
			get { return _requestID; }
			set { _requestID = value; }
		}

		public RequestStatusInfo Status {
			get { return _status; }
			set { _status = value; }
		}

		public AgentInfo Agent {
			get { return _agent; }
			set { _agent = value; }
		}
		public VesselInfo Vessel {
			get { return _vessel; }
			set { _vessel = value; }
		}

		public string PortArr {
			get { return _portArr; }
			set { _portArr = value; }
		}

		public DateTime DateArr {
			get { return _dateArr; }
			set { _dateArr = value; }
		}
		public string Description {
			get { return _description; }
			set { _description = value; }
		}
		public DateTime DateDB {
			get { return _dateDB; }
			set { _dateDB = value; }
		}
		public RequestPositionInfo[] RequestPositions {
			get { return _positions; }
			set { _positions = value;}
		}

		public Int16 CrewQuantity {
			get { return _crewQuantity; }
			set { _crewQuantity = value; }
		}

		#endregion

		#region constructors
		public RequestInfo() {
			RequestID = PersistentBusinessEntity.ID_Empty;
			Status = new RequestStatusInfo();
			Agent = new AgentInfo();
			Vessel = new VesselInfo();
			DateDB = DateTime.Now;
			DateArr = PersistentBusinessEntity.Date_Empty;  
			CrewQuantity = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}
}
