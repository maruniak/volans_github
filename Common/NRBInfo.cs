using System;

namespace Volans.Common {

	
	public class CategoryInfo {
		#region private
		private Int16 _categoryID;
		private string _name;
		#endregion

		#region properties
		public Int16 CategoryID {
			get { return _categoryID; }
			set { _categoryID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		#endregion

		#region constructors
		public CategoryInfo() {
			CategoryID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}



	public class NRBInfo {
		#region private
		private int _NRB_ID;
		private string _surname;
		private string _surnameRussian;
		private string _name;
		private string _nameRussian;
		private DateTime _dateOfBirthday;
		private string _SMB;
		private string _TPT;
		private string _UTP;
		private int _identityCode;
		private string _description;
		private DateTime _dateDB;
		private AgentInfo _agent;
		private CategoryInfo _category;
		private PositionInfo _position;
		#endregion

		
		#region properties
		public int NBR_ID {
			get { return _NRB_ID; }
			set { _NRB_ID = value; }
		}

		public string Surname {
			get { return _surname; }
			set { _surname = value; }
		}

		public string SurnameRussian {
			get { return _surnameRussian; }
			set { _surnameRussian = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public string NameRussian {
			get { return _nameRussian; }
			set { _nameRussian = value; }
		}
		public DateTime DateOfBirthday {
			get { return _dateOfBirthday; }
			set { _dateOfBirthday = value; }
		}

		public string SMB {
			get { return _SMB; }
			set { _SMB = value; }
		}

		public string TPT {
			get { return _TPT; }
			set { _TPT = value; }
		}

		public string UTP {
			get { return _UTP; }
			set { _UTP = value; }
		}

		public int IdentityCode {
			get { return _identityCode; }
			set { _identityCode = value; }
		}

		public AgentInfo Agent {
			get { return _agent; }
			set { _agent = value; }
		}

		public PositionInfo Position{
			get { return _position; }
			set { _position = value; }
		}

		public string Description {
			get { return _description; }
			set { _description = value; }
		}

		public CategoryInfo Category {
			get { return _category; }
			set { _category = value; }
		}

		public DateTime DateDB {
			get { return _dateDB; }
			set { _dateDB = value; }
		}

		#endregion

		
		#region constructor
		public NRBInfo() {
			Agent = new AgentInfo();
			Position = new PositionInfo();
			Category = new CategoryInfo();
			DateDB = DateTime.Now;
			DateOfBirthday = DateTime.Now;
			NBR_ID = PersistentBusinessEntity.ID_Empty;
			IdentityCode = PersistentBusinessEntity.ID_Empty;
		}

		#endregion
		
		
	}
}
