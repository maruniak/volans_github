using System;

namespace Volans.Common {

	public class ExchangeLink {
		#region private
		private int _linkID;
		private string _name;
		private string _URL;
		private string _description;
		private string _imageURL;
		#endregion


		#region properties
		public int LinkID {
			get {return _linkID;}
			set {_linkID = value;}
		}

		public string Name {
			get {return _name;}
			set {_name = value;}
		}

		public string URL {
			get {return _URL;}
			set {_URL = value;}
		}

		public string Description {
			get {return _description;}
			set {_description = value;}
		}

		public string ImageURL {
			get {return _imageURL;}
			set {_imageURL = value;}
		}

		#endregion


		#region constructor
		public ExchangeLink() {
			LinkID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}


	public class GuestBookMessage {
		#region private
		private int _gbmID;
		private string _UserName;
		private DateTime _dateDB;
		private string _email;
		private string _text;
		#endregion


		#region properties
		public int MessageID {
			get {return _gbmID;}
			set {_gbmID = value;}
		}

		public string UserName {
			get {return _UserName;}
			set {_UserName = value;}
		}

		public DateTime DateDB {
			get {return _dateDB;}
			set {_dateDB = value;}
		}

		public string EMail {
			get {return _email;}
			set {_email = value;}
		}

		public string Text {
			get {return _text;}
			set {_text = value;}
		}


		#endregion


		#region constructor
		public GuestBookMessage() {
			MessageID = PersistentBusinessEntity.ID_Empty;
			DateDB = DateTime.Now;
		}
		#endregion
		
	}

}
