using System;

namespace Volans.Common {

	public class ObligationInfo {
		#region private
		private int _oblID;
		private AgentInfo _agent;
		private PositionInfo _position;
		private string _surname;
		private string _surnameR;
		private string _name;
		private string _nameR;
		private DateTime _DOB;
		private string _SMB;
		private string _TPT;
		private string _UPT;
		private int _idencode;
		private string _descrition;
		private DateTime _dateDB;
		#endregion


		#region properties
		public int ObligationID {
			get { return _oblID; }
			set { _oblID = value; }
		}


		public AgentInfo Agent {
			get { return _agent; }
			set { _agent = value; }
		}


		public PositionInfo Position {
			get { return _position; }
			set { _position = value; }
		}

		public string Surname {
			get { return _surname; }
			set { _surname = value; }
		}

		public string SurnameRussian {
			get { return _surnameR; }
			set { _surnameR = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public string NameRussian {
			get { return _nameR; }
			set { _nameR = value; }
		}


		public string SMB {
			get { return _SMB; }
			set { _SMB = value; }
		}

		public string UPT {
			get { return _UPT; }
			set { _UPT = value; }
		}

		public string TPT {
			get { return _TPT; }
			set { _TPT = value; }
		}

		public string Description {
			get { return _descrition; }
			set { _descrition = value; }
		}

		public DateTime DateOfBirthday {
			get { return _DOB; }
			set { _DOB = value; }
		}

		public DateTime DateDB {
			get { return _dateDB; }
			set { _dateDB = value; }
		}


		public int IdentityCode {
			get { return _idencode; }
			set { _idencode = value; }
		}


		#endregion


		#region constructors


		public ObligationInfo()	{
			Agent = new AgentInfo();
			Position = new PositionInfo();
			DateOfBirthday = DateTime.Now;
			DateDB = DateTime.Now;
			ObligationID = PersistentBusinessEntity.ID_Empty;
			IdentityCode = PersistentBusinessEntity.ID_Empty;
		}

		#endregion
	}
}
