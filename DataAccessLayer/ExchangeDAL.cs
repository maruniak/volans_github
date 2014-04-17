using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

using Volans.Common;


namespace Volans.DAL {

	public class ExchangeDAL : System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;

		#region constants
		//guest book
		private const string GbkID = "@gbkID";
		private const string GbkUserName = "@gbkUserName";
		private const string GbkEMail = "@gbkEMail";
		private const string GbkText = "@gbkText";
		private const string GbkDateDB = "@gbkDateDB";
		//sites
		private const string LnkID = "@lnkID";
		private const string LnkName = "@lnkName";
		private const string LnkURL = "@lnkURL";
		private const string LnkDescription = "@lnkDescription";
		private const string LnkImageURL = "@lnkImageURL";
		private const string LnkType = "@lnkType";
		//
		private const string Filter = "@filterClause";
		private const string Order = "@orderClause";
		#endregion


		#region SQLCommands
		private SqlCommand loadGuestBookCmd;
		private SqlCommand addGuestBookMsgCmd; 
		//
		private SqlCommand loadLinksCmd;
		#endregion


		#region constructors

		public ExchangeDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public ExchangeDAL() {
			InitializeComponent();
		}

		#endregion


		#region destructors
		public new void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(true); 
		}


		protected new virtual void Dispose(bool disposing) {
			if (! disposing)
				return; 
			try {
				if(loadGuestBookCmd != null)
					loadGuestBookCmd.Dispose();
				if(addGuestBookMsgCmd != null)
					addGuestBookMsgCmd.Dispose();
				if(loadLinksCmd != null)
					loadLinksCmd.Dispose();
			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion


		#region SQL Command Getters
		private SqlCommand GetLoadGuestBookCommand() {
			if ( loadGuestBookCmd == null ) {
				loadGuestBookCmd = new SqlCommand("dbo.LoadGuestBook");
				loadGuestBookCmd.CommandType = CommandType.StoredProcedure;
				loadGuestBookCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadGuestBookCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadGuestBookCmd;
		}


		private SqlCommand GetAddGuestBookMsgCommand() {
			if ( addGuestBookMsgCmd == null ) {
				addGuestBookMsgCmd = new SqlCommand("dbo.AddGuestBookMessage");
				addGuestBookMsgCmd.CommandType = CommandType.StoredProcedure;
				addGuestBookMsgCmd.Parameters.Add(new SqlParameter(GbkUserName, SqlDbType.NVarChar,50));
				addGuestBookMsgCmd.Parameters.Add(new SqlParameter(GbkEMail, SqlDbType.NVarChar,50));
				addGuestBookMsgCmd.Parameters.Add(new SqlParameter(GbkText, SqlDbType.NVarChar,800));
				addGuestBookMsgCmd.Parameters.Add(new SqlParameter(GbkDateDB, SqlDbType.DateTime));
				addGuestBookMsgCmd.Parameters.Add(new SqlParameter(GbkID, SqlDbType.Int));
			}
			return addGuestBookMsgCmd;
		}

		
		private SqlCommand GetLoadLinksCommand() {
			if ( loadLinksCmd == null ) {
				loadLinksCmd = new SqlCommand("dbo.LoadExchangeLinks");
				loadLinksCmd.CommandType = CommandType.StoredProcedure;
				loadLinksCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadLinksCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadLinksCmd;
		}

		
		#endregion


		#region Public commands
		public GuestBookMessage[] GetGuestBook(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadGuestBookCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			GuestBookMessage[] book = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					GuestBookMessage item = new GuestBookMessage();
					item.MessageID = (int)reader["gbkID"];
					item.DateDB = (DateTime)reader["gbkDateDB"];
					if (reader["gbkUserName"] != DBNull.Value)
						item.UserName = (string)(reader["gbkUserName"]);
					if (reader["gbkEMail"] != DBNull.Value)
						item.EMail = (string)(reader["gbkEMail"]);
					if (reader["gbkText"] != DBNull.Value)
						item.Text = (string)(reader["gbkText"]);

					array.Add(item);
				}
				reader.Close();
			} catch (Exception ex){
				//return null;
				throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				book = new GuestBookMessage[array.Count];
				array.CopyTo(book);
			}
			return book;
		}


		public bool AddGuestBookMessage(GuestBookMessage message, out int msgID) {
			SqlCommand cmd = GetAddGuestBookMsgCommand();
			cmd.Parameters[GbkID].Value       = message.MessageID;
			cmd.Parameters[GbkDateDB].Value   = message.DateDB;
			cmd.Parameters[GbkEMail].Value    = (message.EMail == null) ? DBNull.Value : (Object)message.EMail;
			cmd.Parameters[GbkText].Value     = (message.Text == null) ? DBNull.Value : (Object)message.Text;
			cmd.Parameters[GbkUserName].Value = (message.UserName == null) ? DBNull.Value : (Object)message.UserName;

			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				msgID = (int)cmd.Parameters[GbkID].Value;
			} catch (Exception ex) {
				throw new Exception(ex.Message); 
				//return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public ExchangeLink[] GetLinks(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadLinksCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			ExchangeLink[] links = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					ExchangeLink item = new ExchangeLink();
					item.LinkID = (int)reader["lnkID"];
					if (reader["lnkName"] != DBNull.Value)
						item.Name = (string)(reader["lnkName"]);
					if (reader["lnkURL"] != DBNull.Value)
						item.URL = (string)(reader["lnkURL"]);
					if (reader["lnkDescription"] != DBNull.Value)
						item.Description = (string)(reader["lnkDescription"]);
					if (reader["lnkImage"] != DBNull.Value)
						item.ImageURL = (string)(reader["lnkImage"]);

					array.Add(item);
				}
				reader.Close();
			} catch (Exception ex){
				//return null;
				throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				links = new ExchangeLink[array.Count];
				array.CopyTo(links);
			}
			return links;
		}


		#endregion


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
