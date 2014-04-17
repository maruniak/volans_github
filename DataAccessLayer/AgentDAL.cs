using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

using Volans.Common;


namespace Volans.DAL {

	public class AgentDAL : System.ComponentModel.Component {

		private System.ComponentModel.Container components = null;

		#region constants
		
		private const string AgnStatus = "@agnStatus";
		private const string AgnID = "@agnID";
		private const string AgnNameCo = "@agnNameCo";
		private const string AgnAddress = "@agnAddress";
		private const string AgnEmail = "@agnEmail";
		private const string AgnWWW = "@agnWWW";
		private const string AgnDirector = "@agnDirector";
		private const string AgnProfile = "@agnProfile";
		private const string AgnLogin = "@agnLogin";
		private const string AgnPassword = "@agnPSWD";

		//phones
		private const string PhnID = "@phnID";
		private const string PhnAgent = "@phnAgent";
		private const string PhnNumber = "@phnNumber";
		private const string PhnType = "@phnType";
		private const string PhnPerson = "@phnPerson";
		private const string PhnPosition = "@phnPosition";

		//statuses
		private const string AstID = "@astID";
		private const string AstName = "@astName";
		private const string AstCode = "@astCode";
		private const string AstDesciption = "@astDescription";

		//
		private const String Filter = "@filterClause";
		private const String Order = "@orderClause";

		#endregion


		#region SQLCommands

		//agents
		private SqlCommand loadAgentsCmd;
		private SqlCommand loadAgentInfoCmd;
		private SqlCommand removeAgentCmd;
		private SqlCommand updateAgentCmd;
		private SqlCommand checkLoginCmd;
		private SqlCommand loadAgentByLoginCmd;
		private SqlCommand changeLoginCmd;
		private SqlCommand calcAgentsCmd;

		//phones
		private SqlCommand loadPhonesCmd;
		private SqlCommand loadPhoneInfoCmd;
		private SqlCommand addPhoneCmd;
		private SqlCommand updatePhoneCmd;
		private SqlCommand removePhoneCmd;

		//statuses 
		private SqlCommand loadStatusesCmd;
		private SqlCommand loadStatusInfoCmd;

		#endregion


		#region constructors
		public AgentDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public AgentDAL() {
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
				//agents
				if(loadAgentsCmd != null)
					loadAgentsCmd.Dispose();
				if(loadAgentInfoCmd != null)
					loadAgentInfoCmd.Dispose();
				if(removeAgentCmd != null)
					removeAgentCmd.Dispose();
				if(updateAgentCmd != null)
					updateAgentCmd.Dispose();
				if(checkLoginCmd != null) 
					checkLoginCmd.Dispose();
				if(loadAgentByLoginCmd != null) 
					loadAgentByLoginCmd.Dispose();
				if(changeLoginCmd != null) 
					changeLoginCmd.Dispose();
				if(calcAgentsCmd != null) 
					calcAgentsCmd.Dispose();

				//phones
				if(loadPhonesCmd != null)
					loadPhonesCmd.Dispose();
				if(loadPhoneInfoCmd != null)
					loadPhoneInfoCmd.Dispose();
				if(addPhoneCmd != null)
					addPhoneCmd.Dispose();
				if(updatePhoneCmd != null)
					updatePhoneCmd.Dispose();
				if(removePhoneCmd != null)
					removePhoneCmd.Dispose();

				//statuses
				if(loadStatusesCmd != null)
					loadStatusesCmd.Dispose();
				if(loadStatusInfoCmd != null)
					loadStatusInfoCmd.Dispose();

			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion
	

		#region SQL Command Getters

		#region Agents
		private SqlCommand GetLoadAgentsCommand() {
			if ( loadAgentsCmd == null ) {
				loadAgentsCmd = new SqlCommand("dbo.LoadAgents");
				loadAgentsCmd.CommandType = CommandType.StoredProcedure;
				loadAgentsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadAgentsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadAgentsCmd;
		}


		private SqlCommand GetLoadAgentInfoCommand() {
			if ( loadAgentInfoCmd == null ) {
				loadAgentInfoCmd = new SqlCommand("dbo.GetAgentInfo");
				loadAgentInfoCmd.CommandType = CommandType.StoredProcedure;
				loadAgentInfoCmd.Parameters.Add(new SqlParameter(AgnID, SqlDbType.Int));
			}
			return loadAgentInfoCmd;
		}


		private SqlCommand GetRemoveAgentCommand() {
			if ( removeAgentCmd == null ) {
				removeAgentCmd = new SqlCommand("dbo.RemoveAgent");
				removeAgentCmd.CommandType = CommandType.StoredProcedure;
				removeAgentCmd.Parameters.Add(new SqlParameter(AgnID, SqlDbType.Int));
			}
			return removeAgentCmd;
		}


		private SqlCommand GetUpdateAgentCommand() {
			if ( updateAgentCmd == null ) {
				updateAgentCmd = new SqlCommand("dbo.UpdateAgentInfo");
				updateAgentCmd.CommandType = CommandType.StoredProcedure;
				//updateAgentCmd.Parameters.Add(new SqlParameter(AgnStatus, SqlDbType.SmallInt));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnID, SqlDbType.Int));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnNameCo, SqlDbType.NVarChar, 50));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnAddress, SqlDbType.NVarChar, 100));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnEmail, SqlDbType.NVarChar, 50));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnWWW, SqlDbType.NVarChar, 50));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnDirector, SqlDbType.NVarChar, 50));
				updateAgentCmd.Parameters.Add(new SqlParameter(AgnProfile, SqlDbType.NVarChar, 800));
				//updateAgentCmd.Parameters.Add(new SqlParameter(AgnLogin, SqlDbType.NVarChar, 50));
				//updateAgentCmd.Parameters.Add(new SqlParameter(AgnPassword, SqlDbType.NVarChar, 50));
			}
			return updateAgentCmd;
		}

		
		private SqlCommand GetCheckLoginCommand() {
			if ( checkLoginCmd == null ) {
				checkLoginCmd = new SqlCommand("dbo.CheckLogin");
				checkLoginCmd.CommandType = CommandType.StoredProcedure;
				checkLoginCmd.Parameters.Add(new SqlParameter(AgnLogin, SqlDbType.NVarChar, 24));
				checkLoginCmd.Parameters.Add(new SqlParameter(AgnPassword, SqlDbType.NVarChar, 24));
				checkLoginCmd.Parameters.Add(new SqlParameter("@logged", SqlDbType.Int));
				checkLoginCmd.Parameters["@logged"].Direction = ParameterDirection.Output;
			}
			return checkLoginCmd;
		}
	
		
		private SqlCommand GetLoadAgentByLoginCommand() {
			if ( loadAgentByLoginCmd == null ) {
				loadAgentByLoginCmd = new SqlCommand("dbo.GetAgentByLogin");
				loadAgentByLoginCmd.CommandType = CommandType.StoredProcedure;
				loadAgentByLoginCmd.Parameters.Add(new SqlParameter(AgnLogin, SqlDbType.NVarChar, 24));
			}
			return loadAgentByLoginCmd;
		}

		
		private SqlCommand GetChangePswdCommand() {
			if ( changeLoginCmd == null ) {
				changeLoginCmd = new SqlCommand("dbo.ChangePassword");
				changeLoginCmd.CommandType = CommandType.StoredProcedure;
				changeLoginCmd.Parameters.Add(new SqlParameter(AgnID, SqlDbType.Int));
				changeLoginCmd.Parameters.Add(new SqlParameter(AgnPassword, SqlDbType.NVarChar, 50));
			}
			return changeLoginCmd;
		}
	
		
		private SqlCommand GetCalcAgentsCommand() {
			if ( calcAgentsCmd == null ) {
				calcAgentsCmd = new SqlCommand("dbo.CalculateAgents");
				calcAgentsCmd.CommandType = CommandType.StoredProcedure;
				calcAgentsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
			}
			return calcAgentsCmd;
		}


		#endregion


		#region Phones

		private SqlCommand GetLoadPhonesCommand() {
			if ( loadPhonesCmd == null ) {
				loadPhonesCmd = new SqlCommand("dbo.LoadAgentPhones");
				loadPhonesCmd.CommandType = CommandType.StoredProcedure;
				loadPhonesCmd.Parameters.Add(new SqlParameter(PhnAgent, SqlDbType.Int));
			}
			return loadPhonesCmd;
		}


		private SqlCommand GetLoadPhoneInfoCommand() {
			if ( loadPhoneInfoCmd == null ) {
				loadPhoneInfoCmd = new SqlCommand("dbo.GetPhoneInfo");
				loadPhoneInfoCmd.CommandType = CommandType.StoredProcedure;
				loadPhoneInfoCmd.Parameters.Add(new SqlParameter(PhnID, SqlDbType.Int));
			}
			return loadPhoneInfoCmd;
		}


		private SqlCommand GetAddPhoneCommand() {
			if ( addPhoneCmd == null ) {
				addPhoneCmd = new SqlCommand("dbo.AddAgentPhone");
				addPhoneCmd.CommandType = CommandType.StoredProcedure;
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnAgent, SqlDbType.Int));
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnNumber, SqlDbType.Char, 24));
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnType, SqlDbType.NVarChar, 5));
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnPerson, SqlDbType.NVarChar, 50));
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnPosition, SqlDbType.NVarChar, 50));
				addPhoneCmd.Parameters.Add(new SqlParameter(PhnID, SqlDbType.Int));
				addPhoneCmd.Parameters[PhnID].Direction = ParameterDirection.Output;
			}
			return addPhoneCmd;
		}

		
		private SqlCommand GetUpdatePhoneCommand() {
			if ( updatePhoneCmd == null ) {
				updatePhoneCmd = new SqlCommand("dbo.UpdateAgentPhone");
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnID, SqlDbType.Int));
				updatePhoneCmd.CommandType = CommandType.StoredProcedure;
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnAgent, SqlDbType.Int));
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnNumber, SqlDbType.Char, 24));
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnType, SqlDbType.NVarChar, 5));
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnPerson, SqlDbType.NVarChar, 50));
				updatePhoneCmd.Parameters.Add(new SqlParameter(PhnPosition, SqlDbType.NVarChar, 50));
			}
			return updatePhoneCmd;
		}

		
		private SqlCommand GetRemovePhoneCommand() {
			if ( removePhoneCmd == null ) {
				removePhoneCmd = new SqlCommand("dbo.RemoveAgentPhone");
				removePhoneCmd.CommandType = CommandType.StoredProcedure;
				removePhoneCmd.Parameters.Add(new SqlParameter(PhnID, SqlDbType.Int));
			}
			return removePhoneCmd;
		}

		#endregion

		
		#region Statuses
	
		private SqlCommand GetLoadStatusesCommand() {
			if ( loadStatusesCmd == null ) {
				loadStatusesCmd = new SqlCommand("dbo.LoadAgentStatuses");
				loadStatusesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadStatusesCmd;
		}


		private SqlCommand GetLoadStatusInfoCommand() {
			if ( loadStatusInfoCmd == null ) {
				loadStatusInfoCmd = new SqlCommand("dbo.GetAgentStatusInfo");
				loadStatusInfoCmd.CommandType = CommandType.StoredProcedure;
				loadStatusInfoCmd.Parameters.Add(new SqlParameter(AstID, SqlDbType.Int));
			}
			return loadStatusInfoCmd;
		}



		#endregion
		
		#endregion
		

		#region Public commands

		#region Agents

		public AgentInfo[] GetAgents(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadAgentsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			AgentInfo[] agentsList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					AgentInfo agent = new AgentInfo();
					agent.AgentID = (int)reader["agnID"];
					agent.Status.StatusID = (Int16)reader["agnStatus"];
					if (reader["agnNameCo"] != DBNull.Value)
						agent.CompanyName = (string)(reader["agnNameCo"]);
					if (reader["agnAddress"] != DBNull.Value)
						agent.Address = (string)(reader["agnAddress"]);
					if (reader["agnemail"] != DBNull.Value)
						agent.EMail = (string)reader["agnemail"];
					if (reader["agnWWW"] != DBNull.Value)
						agent.WWW = (string)reader["agnWWW"];
					if (reader["agnDirector"] != DBNull.Value)
						agent.DirectorName = (String)reader["agnDirector"];
					if (reader["agnProfile"] != DBNull.Value)
						agent.Profile = (String)reader["agnProfile"];
					if (reader["agnLogin"] != DBNull.Value)
						agent.Login = (String)reader["agnLogin"];
					//if (reader["agnPSWD"] != DBNull.Value)
					//	agent.Password = (String)reader["agnPSWD"];

					array.Add(agent);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				agentsList = new AgentInfo[array.Count];
				array.CopyTo(agentsList);
			}
			return agentsList;
		}


		public AgentInfo GetInfo(int agentID) {
			SqlCommand cmd = GetLoadAgentInfoCommand();
			cmd.Parameters[AgnID].Value = agentID;
			
			AgentInfo agent = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					agent = new AgentInfo();
					agent.AgentID = (int)reader["agnID"];
					agent.Status.StatusID = (Int16)reader["agnStatus"];
					if (reader["agnNameCo"] != DBNull.Value)
						agent.CompanyName = (string)(reader["agnNameCo"]);
					if (reader["agnAddress"] != DBNull.Value)
						agent.Address = (string)(reader["agnAddress"]);
					if (reader["agnemail"] != DBNull.Value)
						agent.EMail = (string)reader["agnemail"];
					if (reader["agnWWW"] != DBNull.Value)
						agent.WWW = (string)reader["agnWWW"];
					if (reader["agnDirector"] != DBNull.Value)
						agent.DirectorName = (String)reader["agnDirector"];
					if (reader["agnProfile"] != DBNull.Value)
						agent.Profile = (String)reader["agnProfile"];
					if (reader["agnLogin"] != DBNull.Value)
						agent.Login = (String)reader["agnLogin"];
					//if (reader["agnPSWD"] != DBNull.Value)
					//	agent.Password = (String)reader["agnPSWD"];
					//FIXME

				}
				reader.Close();
			} catch /*(Exception ex)*/{
				//throw new Exception(ex.Message);
				return null;
			} finally {
				if (conn != null) conn.Close();
			}
			return agent;
		}


		public bool Remove(int agentID) {
			SqlCommand cmd = GetRemoveAgentCommand();
			cmd.Parameters[AgnID].Value = agentID;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch	{
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public bool Update(AgentInfo agentInfo) {
			SqlCommand cmd = GetUpdateAgentCommand();
			cmd.Parameters[AgnID].Value = agentInfo.AgentID;
			//cmd.Parameters[AgnStatus].Value   = agentInfo.Status.StatusID;
			cmd.Parameters[AgnNameCo].Value   = (agentInfo.CompanyName == null) ? DBNull.Value : (Object)agentInfo.CompanyName;
			cmd.Parameters[AgnAddress].Value  = (agentInfo.Address == null) ? DBNull.Value : (Object)agentInfo.Address;
			cmd.Parameters[AgnEmail].Value    = (agentInfo.EMail == null) ? DBNull.Value : (Object)agentInfo.EMail;
			cmd.Parameters[AgnWWW].Value      = (agentInfo.WWW == null) ? DBNull.Value : (Object)agentInfo.WWW;
			cmd.Parameters[AgnDirector].Value = (agentInfo.DirectorName == null) ? DBNull.Value : (Object)agentInfo.DirectorName;
			cmd.Parameters[AgnProfile].Value  = (agentInfo.Profile == null) ? DBNull.Value : (Object)agentInfo.Profile;
			//cmd.Parameters[AgnLogin].Value    = (agentInfo.Login == null) ? DBNull.Value : (Object)agentInfo.Login;
			//cmd.Parameters[AgnPassword].Value = (agentInfo.Password == null) ? DBNull.Value : (Object)agentInfo.Password;

			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public bool CheckLogin(string login, string passwd) {
			SqlCommand cmd = GetCheckLoginCommand();
			cmd.Parameters[AgnLogin].Value = login;
			cmd.Parameters[AgnPassword].Value = passwd;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				cmd.ExecuteNonQuery();
			} catch {
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			int logged = (int)cmd.Parameters["@logged"].Value;
			if ((logged == -2) || (logged == -1)) 
				return false;
			return (logged == 1);
		}

		
		public AgentInfo GetInfoByLogin(string login) {
			SqlCommand cmd = GetLoadAgentByLoginCommand();
			cmd.Parameters[AgnLogin].Value = login;
			
			AgentInfo agent = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					agent = new AgentInfo();
					agent.AgentID = (int)reader["agnID"];
					agent.Status.StatusID = (Int16)reader["agnStatus"];
					if (reader["agnNameCo"] != DBNull.Value)
						agent.CompanyName = (string)(reader["agnNameCo"]);
					if (reader["agnAddress"] != DBNull.Value)
						agent.Address = (string)(reader["agnAddress"]);
					if (reader["agnemail"] != DBNull.Value)
						agent.EMail = (string)reader["agnemail"];
					if (reader["agnWWW"] != DBNull.Value)
						agent.WWW = (string)reader["agnWWW"];
					if (reader["agnDirector"] != DBNull.Value)
						agent.DirectorName = (String)reader["agnDirector"];
					if (reader["agnProfile"] != DBNull.Value)
						agent.Profile = (String)reader["agnProfile"];
					if (reader["agnLogin"] != DBNull.Value)
						agent.Login = (String)reader["agnLogin"];
					if (reader["agnPSWD"] != DBNull.Value)
						agent.Password = (String)reader["agnPSWD"];
					//FIXME
					//agent.Status = 

				}
				reader.Close();
			} catch /*(Exception ex)*/{
				//throw new Exception(ex.Message);
				return null;
			} finally {
				if (conn != null) conn.Close();
			}
			return agent;
		}


		public bool ChangePassword(int agentID, string password) {
			SqlCommand cmd = GetChangePswdCommand();
			cmd.Parameters[AgnID].Value = agentID;
			cmd.Parameters[AgnPassword].Value = (password == null) ? DBNull.Value : (Object)password;

			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		
		public int CalculatAgents(FilterExpression filter) {
			SqlCommand cmd = GetCalcAgentsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			
			int itemCount = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					itemCount = (int)reader["itemCount"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				//throw new Exception(ex.Message);
				return 0;
			} finally {
				if (conn != null) conn.Close();
			}
			return itemCount;
		}

	
		#endregion


		#region phones
		
		public AgentPhone[] GetPhones(int agentID) {
			SqlCommand cmd = GetLoadPhonesCommand();
			cmd.Parameters[PhnAgent].Value = agentID;
			AgentPhone[] phonesList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					AgentPhone phn = new AgentPhone();
					phn.PhoneID = (int)reader["phnID"];
					phn.AgentCode = (int)reader["phnAgent"];
					if (reader["phnNumber"] != DBNull.Value)
						phn.PhoneNumber = (string)(reader["phnNumber"]);
					if (reader["phnType"] != DBNull.Value)
						phn.NumberType = (string)(reader["phnType"]);
					if (reader["phnPerson"] != DBNull.Value)
						phn.ContactPerson = (string)reader["phnPerson"];
					if (reader["phnPosition"] != DBNull.Value)
						phn.PersonPosition = (string)reader["phnPosition"];

					array.Add(phn);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				//throw new Exception(ex.Message);
				return null;
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				phonesList = new AgentPhone[array.Count];
				array.CopyTo(phonesList);
			}
			return phonesList;
		}


		public AgentPhone GetPhoneInfo(int phoneID) {
			SqlCommand cmd = GetLoadPhoneInfoCommand();
			cmd.Parameters[PhnID].Value = phoneID;

			AgentPhone phn = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					phn = new AgentPhone();
					phn.PhoneID = (int)reader["phnID"];
					phn.AgentCode = (int)reader["phnAgent"];
					if (reader["phnNumber"] != DBNull.Value)
						phn.PhoneNumber = (string)(reader["phnNumber"]);
					if (reader["phnType"] != DBNull.Value)
						phn.NumberType = (string)(reader["phnType"]);
					if (reader["phnPerson"] != DBNull.Value)
						phn.ContactPerson = (string)reader["phnPerson"];
					if (reader["phnPosition"] != DBNull.Value)
						phn.PersonPosition = (string)reader["phnPosition"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return phn;
		}


		public bool RemovePhone(int phoneID) {
			SqlCommand cmd = GetRemovePhoneCommand();
			cmd.Parameters[PhnID].Value = phoneID;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch	{
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public bool UpdatePhone(AgentPhone phone) {
			SqlCommand cmd = GetUpdatePhoneCommand();
			cmd.Parameters[PhnID].Value       = phone.PhoneID;
			cmd.Parameters[PhnAgent].Value    = phone.AgentCode;
			cmd.Parameters[PhnNumber].Value   = (phone.PhoneNumber == null) ? DBNull.Value : (Object)phone.PhoneNumber;
			cmd.Parameters[PhnType].Value     = (phone.NumberType == null) ? DBNull.Value : (Object)phone.NumberType;
			cmd.Parameters[PhnPerson].Value   = (phone.ContactPerson == null) ? DBNull.Value : (Object)phone.ContactPerson;
			cmd.Parameters[PhnPosition].Value = (phone.PersonPosition == null) ? DBNull.Value : (Object)phone.PersonPosition;

			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public bool AddPhone(AgentPhone phone, out int phoneID) {
			SqlCommand cmd = GetAddPhoneCommand();
			cmd.Parameters[PhnID].Value       = phone.PhoneID;
			cmd.Parameters[PhnAgent].Value    = phone.AgentCode;
			cmd.Parameters[PhnNumber].Value   = (phone.PhoneNumber == null) ? DBNull.Value : (Object)phone.PhoneNumber;
			cmd.Parameters[PhnType].Value     = (phone.NumberType == null) ? DBNull.Value : (Object)phone.NumberType;
			cmd.Parameters[PhnPerson].Value   = (phone.ContactPerson == null) ? DBNull.Value : (Object)phone.ContactPerson;
			cmd.Parameters[PhnPosition].Value = (phone.PersonPosition == null) ? DBNull.Value : (Object)phone.PersonPosition;

			phoneID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				phoneID = (int)cmd.Parameters[PhnID].Value;
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		#endregion
		
		
		#region Statuses
		public AgentStatus[] GetStatuses() {
			SqlCommand cmd = GetLoadStatusesCommand();
			AgentStatus[] statusList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					AgentStatus ast = new AgentStatus();
					ast.StatusID = (Int16)reader["astID"];
					ast.Code = (Int16)reader["astCode"];
					if (reader["astName"] != DBNull.Value)
						ast.Name = (string)(reader["astName"]);
					if (reader["astDescription"] != DBNull.Value)
						ast.Description = (string)(reader["astDescription"]);

					array.Add(ast);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				statusList = new AgentStatus[array.Count];
				array.CopyTo(statusList);
			}
			return statusList;
		}


		public AgentStatus GetStatusInfo(int statusID) {
			SqlCommand cmd = GetLoadStatusInfoCommand();
			cmd.Parameters[AstID].Value = statusID;

			AgentStatus ast = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					ast = new AgentStatus();
					ast.StatusID = (Int16)reader["astID"];
					ast.Code = (Int16)reader["astCode"];
					if (reader["astName"] != DBNull.Value)
						ast.Name = (string)(reader["astName"]);
					if (reader["astDescription"] != DBNull.Value)
						ast.Description = (string)(reader["astDescription"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return ast;
		}


		#endregion


		#endregion


		#region Component Designer generated code
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
