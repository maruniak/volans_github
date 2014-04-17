using System;

namespace Volans.Common {

	public class AgentStatus {
		#region private
		private Int16 _statusID;
		private string _name;
		private Int16 _code;
		private string _description;
		#endregion

		#region properties
		public Int16 StatusID {
			get { return _statusID; }
			set { _statusID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public Int16 Code {
			get { return _code; }
			set { _code = value; }
		}

		public string Description {
			get { return _description; }
			set { _description = value; }
		}
		#endregion

		#region constructors
		public AgentStatus() {
			StatusID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}



	public class AgentPhone {
		#region private
		private int _phoneID;
		private int _agentCode;
		private string _number;
		private string _numberType;
		private string _person;
		private string _position;
		#endregion


		#region properties
		public int PhoneID {
			get { return _phoneID; }
			set { _phoneID = value; }
		}

		public int AgentCode {
			get { return _agentCode; }
			set { _agentCode = value; }
		}
		public string PhoneNumber {
			get { return _number; }
			set { _number = value; }
		}
		
		public string NumberType {
			get { return _numberType; }
			set { _numberType = value; }
		}
		
		public string ContactPerson {
			get { return _person; }
			set { _person = value; }
		}
		
		public string PersonPosition {
			get { return _position; }
			set { _position = value; }
		}
		
		#endregion

	}
	
	

	public class AgentInfo {
		#region private
		private int _agentID;
		private AgentStatus _status;
		private string _companyName;
		private string _address;
		private string _email;
		private string _www;
		private string _directorName;
		private AgentPhone[] _phones;
		private string _profile;
		private string _login;
		private string _PSWD;
		#endregion

		#region properties
		public int AgentID {
			get { return _agentID; }
			set {  _agentID = value; }
		}

		public AgentStatus Status {
			get { return _status; }
			set { _status = value; }
		}

		public string CompanyName {
			get { return _companyName; }
			set {  _companyName = value; }
		}

		public string Address {
			get { return _address; }
			set {  _address = value; }
		}

		public string EMail {
			get { return _email; }
			set {  _email = value; }
		}
		
		public string WWW {
			get { return _www; }
			set {  _www = value; }
		}

		public string DirectorName {
			get { return _directorName; }
			set {  _directorName = value; }
		}

		public AgentPhone[] Phones {
			get { return _phones; }
			set {  _phones = value; }
		}

		public string Profile {
			get { return _profile; }
			set { _profile = value; }
		}

		public string Login {
			get { return _login; }
			set { _login = value; }
		}

		public string Password {
			set { _PSWD = value; }
		}

	
		#endregion

		#region constructors
		public AgentInfo() {
			AgentID = PersistentBusinessEntity.ID_Empty;
			Status = new AgentStatus();
			Phones = new AgentPhone[0];
		}
		#endregion
	}
}
