using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;


using Volans.Common;

namespace Volans.DAL {

	public class ObligationDAL : System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;

		#region constants
		//Obligation
		private const string OblID = "@oblID";
		private const string OblAgent = "@oblAgent";
		private const string OblPos = "@oblPos";
		private const string OblSurname = "@oblSurname";
		private const string OblSurnameR = "@oblSurnameR";
		private const string OblName = "@oblName";
		private const string OblNameR = "@oblNameR";
		private const string OblDOB = "@oblDOB";
		private const string OblSMB = "@oblSMB";
		private const string OblTPT = "@oblTPT";
		private const string OblUPT = "@oblUPT";
		private const string OblIndencode = "@oblIdencode";
		private const string OblDescription = "@oblDescription";
		private const string OblDateDB = "@oblDate";
		//
		private const string Filter = "@filterClause";
		private const string Order = "@orderClause";
		#endregion


		#region SQLCommands
		private SqlCommand addObligationCmd;
		private SqlCommand loadObligationsCmd;
		private SqlCommand loadObligationInfoCmd;
		private SqlCommand removeObligationCmd;
		private SqlCommand updateObligationCmd;

		#endregion		

		
		#region constructors 


		public ObligationDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public ObligationDAL() {
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
				if(loadObligationsCmd != null)
					loadObligationsCmd.Dispose();
				if(loadObligationInfoCmd != null)
					loadObligationInfoCmd.Dispose();
				if(addObligationCmd != null)
					addObligationCmd.Dispose();
				if(updateObligationCmd != null)
					updateObligationCmd.Dispose();
			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion
		

		#region SQL Command Getters
	
		private SqlCommand GetLoadObligationsCommand() {
			if ( loadObligationsCmd == null ) {
				loadObligationsCmd = new SqlCommand("dbo.LoadObligations");
				loadObligationsCmd.CommandType = CommandType.StoredProcedure;
				loadObligationsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadObligationsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadObligationsCmd;
		}


		private SqlCommand GetLoadObligationInfoCommand() {
			if ( loadObligationInfoCmd == null ) {
				loadObligationInfoCmd = new SqlCommand("dbo.GetObligationInfo");
				loadObligationInfoCmd.CommandType = CommandType.StoredProcedure;
				loadObligationInfoCmd.Parameters.Add(new SqlParameter(OblID, SqlDbType.Int));
			}
			return loadObligationInfoCmd;
		}


		private SqlCommand GetAddObligationCommand() {
			if ( addObligationCmd == null ) {
				addObligationCmd = new SqlCommand("dbo.AddObligationInfo");
				addObligationCmd.CommandType = CommandType.StoredProcedure;
				addObligationCmd.Parameters.Add(new SqlParameter(OblID, SqlDbType.Int));
				addObligationCmd.Parameters.Add(new SqlParameter(OblSurname, SqlDbType.NVarChar, 32));
				addObligationCmd.Parameters.Add(new SqlParameter(OblSurnameR, SqlDbType.NVarChar, 32));
				addObligationCmd.Parameters.Add(new SqlParameter(OblName, SqlDbType.NVarChar, 32));
				addObligationCmd.Parameters.Add(new SqlParameter(OblNameR, SqlDbType.NVarChar, 32));
				addObligationCmd.Parameters.Add(new SqlParameter(OblDOB, SqlDbType.DateTime));
				addObligationCmd.Parameters.Add(new SqlParameter(OblSMB, SqlDbType.NChar, 8));
				addObligationCmd.Parameters.Add(new SqlParameter(OblTPT, SqlDbType.NChar, 8));
				addObligationCmd.Parameters.Add(new SqlParameter(OblUPT, SqlDbType.NChar, 8));
				addObligationCmd.Parameters.Add(new SqlParameter(OblIndencode, SqlDbType.Int));
				addObligationCmd.Parameters.Add(new SqlParameter(OblAgent, SqlDbType.Int));
				addObligationCmd.Parameters.Add(new SqlParameter(OblDescription, SqlDbType.NVarChar, 100));
				addObligationCmd.Parameters.Add(new SqlParameter(OblPos, SqlDbType.SmallInt));
				addObligationCmd.Parameters.Add(new SqlParameter(OblDateDB, SqlDbType.DateTime));
				addObligationCmd.Parameters[OblID].Direction = ParameterDirection.Output;
			}
			return addObligationCmd;
		}

		
		private SqlCommand GetUpdateObligationCommand() {
			if ( updateObligationCmd == null ) {
				updateObligationCmd = new SqlCommand("dbo.UpdateObligation");
				updateObligationCmd.CommandType = CommandType.StoredProcedure;
				updateObligationCmd.Parameters.Add(new SqlParameter(OblID, SqlDbType.Int));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblSurname, SqlDbType.NVarChar, 32));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblSurnameR, SqlDbType.NVarChar, 32));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblName, SqlDbType.NVarChar, 32));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblNameR, SqlDbType.NVarChar, 32));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblDOB, SqlDbType.DateTime));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblSMB, SqlDbType.NChar, 8));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblTPT, SqlDbType.NChar, 8));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblUPT, SqlDbType.NChar, 8));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblIndencode, SqlDbType.Int));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblAgent, SqlDbType.Int));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblDescription, SqlDbType.NVarChar, 100));
				updateObligationCmd.Parameters.Add(new SqlParameter(OblPos, SqlDbType.SmallInt));
				//updateObligationCmd.Parameters.Add(new SqlParameter(OblDateDB, SqlDbType.DateTime));
			}
			return updateObligationCmd;
		}

		
		private SqlCommand GetRemoveObligationCommand() {
			if ( removeObligationCmd == null ) {
				removeObligationCmd = new SqlCommand("dbo.RemoveObligation");
				removeObligationCmd.CommandType = CommandType.StoredProcedure;
				removeObligationCmd.Parameters.Add(new SqlParameter(OblID, SqlDbType.Int));
			}
			return removeObligationCmd;
		}

		#endregion


		#region Public commands

		public bool RemoveObligation(int oblID) {
			SqlCommand cmd = GetRemoveObligationCommand();
			cmd.Parameters[OblID].Value = oblID;
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


		public ObligationInfo[] GetObligations(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadObligationsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			ObligationInfo[] oblList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					ObligationInfo obl = new ObligationInfo();
					obl.ObligationID = (int)reader["oblID"];
					obl.DateOfBirthday = (DateTime)reader["oblDOB"];
					obl.Agent.AgentID = (int)reader["oblAgent"];
					if (reader["oblSurname"] != DBNull.Value)
						obl.Surname = (string)reader["oblSurname"];
					if (reader["oblSurnameR"] != DBNull.Value)
						obl.SurnameRussian = (string)reader["oblSurnameR"];
					if (reader["oblName"] != DBNull.Value)
						obl.Name = (string)reader["oblName"];
					if (reader["oblNameR"] != DBNull.Value)
						obl.NameRussian = (string)reader["oblNameR"];
					if (reader["oblSMB"] != DBNull.Value)
						obl.SMB = (string)reader["oblSMB"];
					if (reader["oblTPT"] != DBNull.Value)
						obl.TPT = (string)reader["oblTPT"];
					if (reader["oblUPT"] != DBNull.Value)
						obl.UPT = (string)reader["oblUPT"];
					if (reader["oblIdencode"] != DBNull.Value)
						obl.IdentityCode = (int)reader["oblIdencode"];
					else
						obl.IdentityCode = PersistentBusinessEntity.ID_Empty;
					if (reader["oblPos"] != DBNull.Value)
						obl.Position.PositionID = (Int16)reader["oblPos"];
					if (reader["oblDescription"] != DBNull.Value)
						obl.Description = (string)reader["oblDescription"];
					if (reader["oblDate"] != DBNull.Value)
						obl.DateDB = (DateTime)reader["oblDate"];

					array.Add(obl);
				}
				reader.Close();
			} catch (Exception ex){
				//return null;
				throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				oblList = new ObligationInfo[array.Count];
				array.CopyTo(oblList);
			}
			return oblList;
		}


		public ObligationInfo GetObligationInfo(int oblID) {
			SqlCommand cmd = GetLoadObligationInfoCommand();
			cmd.Parameters[OblID].Value = oblID;
			
			ObligationInfo obl = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					obl = new ObligationInfo();
					obl.ObligationID = (int)reader["oblID"];
					obl.DateOfBirthday = (DateTime)reader["oblDOB"];
					obl.Agent.AgentID = (int)reader["oblAgent"];
					if (reader["oblSurname"] != DBNull.Value)
						obl.Surname = (string)reader["oblSurname"];
					if (reader["oblSurnameR"] != DBNull.Value)
						obl.SurnameRussian = (string)reader["oblSurnameR"];
					if (reader["oblName"] != DBNull.Value)
						obl.Name = (string)reader["oblName"];
					if (reader["oblNameR"] != DBNull.Value)
						obl.NameRussian = (string)reader["oblNameR"];
					if (reader["oblSMB"] != DBNull.Value)
						obl.SMB = (string)reader["oblSMB"];
					if (reader["oblTPT"] != DBNull.Value)
						obl.TPT = (string)reader["oblTPT"];
					if (reader["oblUPT"] != DBNull.Value)
						obl.UPT = (string)reader["oblUPT"];
					if (reader["oblIdencode"] != DBNull.Value)
						obl.IdentityCode = (int)reader["oblIdencode"];
					else
						obl.IdentityCode = PersistentBusinessEntity.ID_Empty;
					if (reader["oblPos"] != DBNull.Value)
						obl.Position.PositionID = (Int16)reader["oblPos"];
					if (reader["oblDescription"] != DBNull.Value)
						obl.Description = (string)reader["oblDescription"];
					if (reader["oblDate"] != DBNull.Value)
						obl.DateDB = (DateTime)reader["oblDate"];
				}
				reader.Close();
			} catch (Exception ex){
				//return null;
				throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return obl;
		}


		public bool AddObligationInfo(ObligationInfo oblInfo, out int oblID) {
			SqlCommand cmd = GetAddObligationCommand();
			cmd.Parameters[OblID].Value        = oblInfo.ObligationID;
			cmd.Parameters[OblDOB].Value       = oblInfo.DateOfBirthday;
			cmd.Parameters[OblIndencode].Value = (oblInfo.IdentityCode == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)oblInfo.IdentityCode;
			cmd.Parameters[OblAgent].Value     = oblInfo.Agent.AgentID;
			cmd.Parameters[OblPos].Value       = oblInfo.Position.PositionID;
			cmd.Parameters[OblDateDB].Value    = oblInfo.DateDB;
			cmd.Parameters[OblSurname].Value     = (oblInfo.Surname == null) ? DBNull.Value : (Object)oblInfo.Surname;
			cmd.Parameters[OblSurnameR].Value    = (oblInfo.SurnameRussian == null) ? DBNull.Value : (Object)oblInfo.SurnameRussian;
			cmd.Parameters[OblName].Value        = (oblInfo.Name == null) ? DBNull.Value : (Object)oblInfo.Name;
			cmd.Parameters[OblNameR].Value       = (oblInfo.NameRussian == null) ? DBNull.Value : (Object)oblInfo.NameRussian;
			cmd.Parameters[OblSMB].Value         = (oblInfo.SMB == null) ? DBNull.Value : (Object)oblInfo.SMB;
			cmd.Parameters[OblTPT].Value         = (oblInfo.TPT == null) ? DBNull.Value : (Object)oblInfo.TPT;
			cmd.Parameters[OblUPT].Value         = (oblInfo.UPT == null) ? DBNull.Value : (Object)oblInfo.UPT;
			cmd.Parameters[OblDescription].Value = (oblInfo.Description == null) ? DBNull.Value : (Object)oblInfo.Description;

			oblID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				oblID = (int)cmd.Parameters[OblID].Value;
			} catch (Exception ex) {
				throw new Exception(ex.Message); 
				//return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}

		
		public bool UpdateObligationInfo(ObligationInfo oblInfo) {
			SqlCommand cmd = GetUpdateObligationCommand();
			cmd.Parameters[OblID].Value        = oblInfo.ObligationID;
			cmd.Parameters[OblDOB].Value       = oblInfo.DateOfBirthday;
			cmd.Parameters[OblIndencode].Value = (oblInfo.IdentityCode == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)oblInfo.IdentityCode;
			cmd.Parameters[OblAgent].Value     = oblInfo.Agent.AgentID;
			cmd.Parameters[OblPos].Value       = oblInfo.Position.PositionID;
			//cmd.Parameters[OblDateDB].Value    = oblInfo.DateDB;
			cmd.Parameters[OblSurname].Value     = (oblInfo.Surname == null) ? DBNull.Value : (Object)oblInfo.Surname;
			cmd.Parameters[OblSurnameR].Value    = (oblInfo.SurnameRussian == null) ? DBNull.Value : (Object)oblInfo.SurnameRussian;
			cmd.Parameters[OblName].Value        = (oblInfo.Name == null) ? DBNull.Value : (Object)oblInfo.Name;
			cmd.Parameters[OblNameR].Value       = (oblInfo.NameRussian == null) ? DBNull.Value : (Object)oblInfo.NameRussian;
			cmd.Parameters[OblSMB].Value         = (oblInfo.SMB == null) ? DBNull.Value : (Object)oblInfo.SMB;
			cmd.Parameters[OblTPT].Value         = (oblInfo.TPT == null) ? DBNull.Value : (Object)oblInfo.TPT;
			cmd.Parameters[OblUPT].Value         = (oblInfo.UPT == null) ? DBNull.Value : (Object)oblInfo.UPT;
			cmd.Parameters[OblDescription].Value = (oblInfo.Description == null) ? DBNull.Value : (Object)oblInfo.Description;

			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			} catch (Exception ex) {
				throw new Exception(ex.Message); 
				//return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}

		
		#endregion
		
		
		#region Component Designer generated code
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
