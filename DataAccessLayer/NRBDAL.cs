using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

using Volans.Common;


namespace Volans.DAL {

	public class NRBDAL : System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;


		#region constants
		//Category
		private const string CatID = "@IDcat";
		private const string CatName = "@catName";

		//NRB
		private const string NrbID = "@nrbID";
		private const string NrbSurname = "@nrbSurname";
		private const string NrbSurnameR = "@nrbSurnameR";
		private const string NrbName = "@nrbName";
		private const string NrbNameR = "@nrbNameR";
		private const string NrbDOB = "@nrbDOB";
		private const string NrbSMB = "@nrbSMB";
		private const string NrbTPT = "@nrbTPT";
		private const string NrbUPT = "@nrbUPT";
		private const string NrbIndencode = "@nrbIdencode";
		private const string NrbAgent = "@nrbAgent";
		private const string NrbPos = "@nrbPos";
		private const string NrbDescription = "@nrbDescription";
		private const string NrbCategory = "@nrbCat";
		private const string NrbDateDB = "@nrbDateDB";
		//
		private const string Filter = "@filterClause";
		private const string Order = "@orderClause";
		#endregion


		#region SQLCommands
		//category
		private SqlCommand loadCategoriesCmd;
		private SqlCommand loadCategoryInfoCmd;

		//NRB
		private SqlCommand addNRBCmd;
		private SqlCommand loadNRBsCmd;
		private SqlCommand loadNRBInfoCmd;
		private SqlCommand removeNRBCmd;
		private SqlCommand updateNRBCmd;

		#endregion		


		#region constructors
		public NRBDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public NRBDAL() {
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
				//categories
				if(loadCategoriesCmd != null)
					loadCategoriesCmd.Dispose();
				if(loadCategoryInfoCmd != null)
					loadCategoryInfoCmd.Dispose();

				//NRB
				if(loadNRBsCmd != null)
					loadNRBsCmd.Dispose();
				if(loadNRBInfoCmd != null)
					loadNRBInfoCmd.Dispose();
				if(addNRBCmd != null)
					addNRBCmd.Dispose();
				if(updateNRBCmd != null)
					updateNRBCmd.Dispose();
			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion
		

		#region SQL Command Getters
	
		#region category
		private SqlCommand GetLoadCategoriesCommand() {
			if ( loadCategoriesCmd == null ) {
				loadCategoriesCmd = new SqlCommand("dbo.LoadCategories");
				loadCategoriesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadCategoriesCmd;
		}


		private SqlCommand GetLoadCategoryInfoCommand() {
			if ( loadCategoryInfoCmd == null ) {
				loadCategoryInfoCmd = new SqlCommand("dbo.GetCategoryInfo");
				loadCategoryInfoCmd.CommandType = CommandType.StoredProcedure;
				loadCategoryInfoCmd.Parameters.Add(new SqlParameter(CatID, SqlDbType.Int));
			}
			return loadCategoryInfoCmd;
		}

		#endregion


		#region NRB

		private SqlCommand GetLoadNRBsCommand() {
			if ( loadNRBsCmd == null ) {
				loadNRBsCmd = new SqlCommand("dbo.LoadNRBs");
				loadNRBsCmd.CommandType = CommandType.StoredProcedure;
				loadNRBsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadNRBsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadNRBsCmd;
		}


		private SqlCommand GetLoadNRBInfoCommand() {
			if ( loadNRBInfoCmd == null ) {
				loadNRBInfoCmd = new SqlCommand("dbo.GetNRBInfo");
				loadNRBInfoCmd.CommandType = CommandType.StoredProcedure;
				loadNRBInfoCmd.Parameters.Add(new SqlParameter(NrbID, SqlDbType.Int));
			}
			return loadNRBInfoCmd;
		}


		private SqlCommand GetAddNRBCommand() {
			if ( addNRBCmd == null ) {
				addNRBCmd = new SqlCommand("dbo.AddNRBInfo");
				addNRBCmd.CommandType = CommandType.StoredProcedure;
				addNRBCmd.Parameters.Add(new SqlParameter(NrbID, SqlDbType.Int));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbSurname, SqlDbType.NVarChar, 32));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbSurnameR, SqlDbType.NVarChar, 32));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbName, SqlDbType.NVarChar, 32));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbNameR, SqlDbType.NVarChar, 32));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbDOB, SqlDbType.DateTime));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbSMB, SqlDbType.NChar, 8));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbTPT, SqlDbType.NChar, 8));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbUPT, SqlDbType.NChar, 8));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbIndencode, SqlDbType.Int));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbAgent, SqlDbType.Int));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbPos, SqlDbType.SmallInt));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbDescription, SqlDbType.NVarChar, 100));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbCategory, SqlDbType.SmallInt));
				addNRBCmd.Parameters.Add(new SqlParameter(NrbDateDB, SqlDbType.DateTime));
				addNRBCmd.Parameters[NrbID].Direction = ParameterDirection.Output;
			}
			return addNRBCmd;
		}

		
		private SqlCommand GetUpdateNRBCommand() {
			if ( updateNRBCmd == null ) {
				updateNRBCmd = new SqlCommand("dbo.UpdateNRB");
				updateNRBCmd.CommandType = CommandType.StoredProcedure;
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbID, SqlDbType.Int));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbSurname, SqlDbType.NVarChar, 32));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbSurnameR, SqlDbType.NVarChar, 32));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbName, SqlDbType.NVarChar, 32));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbNameR, SqlDbType.NVarChar, 32));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbDOB, SqlDbType.DateTime));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbSMB, SqlDbType.NChar, 8));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbTPT, SqlDbType.NChar, 8));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbUPT, SqlDbType.NChar, 8));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbIndencode, SqlDbType.Int));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbAgent, SqlDbType.Int));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbPos, SqlDbType.SmallInt));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbDescription, SqlDbType.NVarChar, 100));
				updateNRBCmd.Parameters.Add(new SqlParameter(NrbCategory, SqlDbType.SmallInt));
				//updateNRBCmd.Parameters.Add(new SqlParameter(NrbDateDB, SqlDbType.DateTime));
			}
			return updateNRBCmd;
		}

		
		private SqlCommand GetRemoveNRBCommand() {
			if ( removeNRBCmd == null ) {
				removeNRBCmd = new SqlCommand("dbo.RemoveNRB");
				removeNRBCmd.CommandType = CommandType.StoredProcedure;
				removeNRBCmd.Parameters.Add(new SqlParameter(NrbID, SqlDbType.Int));
			}
			return removeNRBCmd;
		}

		#endregion
		#endregion


		#region Public commands


		#region Categories
		public CategoryInfo[] GetCategories() {
			SqlCommand cmd = GetLoadCategoriesCommand();
			CategoryInfo[] catList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					CategoryInfo cat = new CategoryInfo();
					cat.CategoryID = (Int16)reader["IDcat"];
					if (reader["catName"] != DBNull.Value)
						cat.Name = (string)(reader["catName"]);

					array.Add(cat);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				catList = new CategoryInfo[array.Count];
				array.CopyTo(catList);
			}
			return catList;
		}


		public CategoryInfo GetCategoryInfo(int categoryID) {
			SqlCommand cmd = GetLoadCategoryInfoCommand();
			cmd.Parameters[CatID].Value = categoryID;

			CategoryInfo cat = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					cat = new CategoryInfo();
					cat.CategoryID = (Int16)reader["IDcat"];
					if (reader["catName"] != DBNull.Value)
						cat.Name = (string)(reader["catName"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return cat;
		}


		#endregion

		
		#region NRB

		public bool RemoveNRB(int nrbID) {
			SqlCommand cmd = GetRemoveNRBCommand();
			cmd.Parameters[NrbID].Value = nrbID;
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


		public NRBInfo[] GetNRBList(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadNRBsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			NRBInfo[] nrbList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					NRBInfo nrb = new NRBInfo();
					nrb.NBR_ID = (int)reader["nrbID"];
					nrb.DateOfBirthday = (DateTime)reader["nrbDOB"];
					nrb.Agent.AgentID = (int)reader["nrbAgent"];
					if (reader["nrbSurname"] != DBNull.Value)
						nrb.Surname = (string)reader["nrbSurname"];
					if (reader["nrbSurnameR"] != DBNull.Value)
						nrb.SurnameRussian = (string)reader["nrbSurnameR"];
					if (reader["nrbName"] != DBNull.Value)
						nrb.Name = (string)reader["nrbName"];
					if (reader["nrbNameR"] != DBNull.Value)
						nrb.NameRussian = (string)reader["nrbNameR"];
					if (reader["nrbSMB"] != DBNull.Value)
						nrb.SMB = (string)reader["nrbSMB"];
					if (reader["nrbTPT"] != DBNull.Value)
						nrb.TPT = (string)reader["nrbTPT"];
					if (reader["nrbUPT"] != DBNull.Value)
						nrb.UTP = (string)reader["nrbUPT"];
					if (reader["nrbIdencode"] != DBNull.Value)
						nrb.IdentityCode = (int)reader["nrbIdencode"];
					else
						nrb.IdentityCode = PersistentBusinessEntity.ID_Empty;
					if (reader["nrbPos"] != DBNull.Value)
						nrb.Position.PositionID = (Int16)reader["nrbPos"];
					if (reader["nrbDescription"] != DBNull.Value)
						nrb.Description = (string)reader["nrbDescription"];
					if (reader["nrbCat"] != DBNull.Value)
						nrb.Category.CategoryID = (Int16)reader["nrbCat"];
					if (reader["nrbDateDB"] != DBNull.Value)
						nrb.DateDB = (DateTime)reader["nrbDateDB"];

					array.Add(nrb);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				nrbList = new NRBInfo[array.Count];
				array.CopyTo(nrbList);
			}
			return nrbList;
		}


		public NRBInfo GetNRBInfo(int nrbID) {
			SqlCommand cmd = GetLoadNRBInfoCommand();
			cmd.Parameters[NrbID].Value = nrbID;
			
			NRBInfo nrb = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					nrb = new NRBInfo();
					nrb.NBR_ID = (int)reader["nrbID"];
					nrb.DateOfBirthday = (DateTime)reader["nrbDOB"];
					nrb.Agent.AgentID = (int)reader["nrbAgent"];
					if (reader["nrbSurname"] != DBNull.Value)
						nrb.Surname = (string)reader["nrbSurname"];
					if (reader["nrbSurnameR"] != DBNull.Value)
						nrb.SurnameRussian = (string)reader["nrbSurnameR"];
					if (reader["nrbName"] != DBNull.Value)
						nrb.Name = (string)reader["nrbName"];
					if (reader["nrbNameR"] != DBNull.Value)
						nrb.NameRussian = (string)reader["nrbNameR"];
					if (reader["nrbSMB"] != DBNull.Value)
						nrb.SMB = (string)reader["nrbSMB"];
					if (reader["nrbTPT"] != DBNull.Value)
						nrb.TPT = (string)reader["nrbTPT"];
					if (reader["nrbUPT"] != DBNull.Value)
						nrb.UTP = (string)reader["nrbUPT"];
					if (reader["nrbIdencode"] != DBNull.Value)
						nrb.IdentityCode = (int)reader["nrbIdencode"];
					else
						nrb.IdentityCode = PersistentBusinessEntity.ID_Empty;
					if (reader["nrbPos"] != DBNull.Value)
						nrb.Position.PositionID = (Int16)reader["nrbPos"];
					if (reader["nrbDescription"] != DBNull.Value)
						nrb.Description = (string)reader["nrbDescription"];
					if (reader["nrbCat"] != DBNull.Value)
						nrb.Category.CategoryID = (Int16)reader["nrbCat"];
					if (reader["nrbDateDB"] != DBNull.Value)
						nrb.DateDB = (DateTime)reader["nrbDateDB"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return nrb;
		}


		public bool AddNRBInfo(NRBInfo nrbInfo, out int nrbID) {
			SqlCommand cmd = GetAddNRBCommand();
			cmd.Parameters[NrbID].Value        = nrbInfo.NBR_ID;
			cmd.Parameters[NrbDOB].Value       = nrbInfo.DateOfBirthday;
			cmd.Parameters[NrbIndencode].Value = (nrbInfo.IdentityCode == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)nrbInfo.IdentityCode;
			cmd.Parameters[NrbAgent].Value     = nrbInfo.Agent.AgentID;
			cmd.Parameters[NrbPos].Value       = nrbInfo.Position.PositionID;
			cmd.Parameters[NrbCategory].Value  = nrbInfo.Category.CategoryID;
			cmd.Parameters[NrbDateDB].Value    = nrbInfo.DateDB;
			cmd.Parameters[NrbSurname].Value     = (nrbInfo.Surname == null) ? DBNull.Value : (Object)nrbInfo.Surname;
			cmd.Parameters[NrbSurnameR].Value    = (nrbInfo.SurnameRussian == null) ? DBNull.Value : (Object)nrbInfo.SurnameRussian;
			cmd.Parameters[NrbName].Value        = (nrbInfo.Name == null) ? DBNull.Value : (Object)nrbInfo.Name;
			cmd.Parameters[NrbNameR].Value       = (nrbInfo.NameRussian == null) ? DBNull.Value : (Object)nrbInfo.NameRussian;
			cmd.Parameters[NrbSMB].Value         = (nrbInfo.SMB == null) ? DBNull.Value : (Object)nrbInfo.SMB;
			cmd.Parameters[NrbTPT].Value         = (nrbInfo.TPT == null) ? DBNull.Value : (Object)nrbInfo.TPT;
			cmd.Parameters[NrbUPT].Value         = (nrbInfo.UTP == null) ? DBNull.Value : (Object)nrbInfo.UTP;
			cmd.Parameters[NrbDescription].Value = (nrbInfo.Description == null) ? DBNull.Value : (Object)nrbInfo.Description;

			nrbID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				nrbID = (int)cmd.Parameters[NrbID].Value;
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}

		
		public bool UpdateNRBInfo(NRBInfo nrbInfo) {
			SqlCommand cmd = GetUpdateNRBCommand();
			cmd.Parameters[NrbID].Value        = nrbInfo.NBR_ID;
			cmd.Parameters[NrbDOB].Value       = nrbInfo.DateOfBirthday;
			cmd.Parameters[NrbIndencode].Value = (nrbInfo.IdentityCode == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)nrbInfo.IdentityCode;
			cmd.Parameters[NrbAgent].Value     = nrbInfo.Agent.AgentID;
			cmd.Parameters[NrbPos].Value       = nrbInfo.Position.PositionID;
			cmd.Parameters[NrbCategory].Value  = nrbInfo.Category.CategoryID;
			cmd.Parameters[NrbSurname].Value     = (nrbInfo.Surname == null) ? DBNull.Value : (Object)nrbInfo.Surname;
			cmd.Parameters[NrbSurnameR].Value    = (nrbInfo.SurnameRussian == null) ? DBNull.Value : (Object)nrbInfo.SurnameRussian;
			cmd.Parameters[NrbName].Value        = (nrbInfo.Name == null) ? DBNull.Value : (Object)nrbInfo.Name;
			cmd.Parameters[NrbNameR].Value       = (nrbInfo.NameRussian == null) ? DBNull.Value : (Object)nrbInfo.NameRussian;
			cmd.Parameters[NrbSMB].Value         = (nrbInfo.SMB == null) ? DBNull.Value : (Object)nrbInfo.SMB;
			cmd.Parameters[NrbTPT].Value         = (nrbInfo.TPT == null) ? DBNull.Value : (Object)nrbInfo.TPT;
			cmd.Parameters[NrbUPT].Value         = (nrbInfo.UTP == null) ? DBNull.Value : (Object)nrbInfo.UTP;
			cmd.Parameters[NrbDescription].Value = (nrbInfo.Description == null) ? DBNull.Value : (Object)nrbInfo.Description;

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

		
		#endregion
		
		
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
