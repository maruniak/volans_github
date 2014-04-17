using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

using Volans.Common;

namespace Volans.DAL {
	public class RequestDAL : System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;


		#region constants
		//statuses
		private const string RstID = "@rstID";
		private const string RstName = "@rstName";
		private const string RstCode = "@rstCode";

		//currency
		private const string CurID = "@curID";
		private const string CurName = "@curName";

		//departments
		private const string DepID = "@depID";
		private const string DepName = "@depName";
		
		//positions
		private const string PosID = "@posID";
		private const string PosName = "@posName";

		//request positions
		private const string RqpID = "@rqpID";
		private const string RqpRequestID = "@rqpRequest";
		private const string RqpPositionID = "@rqpPosition";
		private const string RqpQuantity = "@rqpQuantity";
		private const string RqpSalary = "@rqpSalary";
		private const string RqpCurrencyID = "@rqpCurrency";
		private const string RqpLengthCo = "@rqpLengthCo";
		private const string RqpComments = "@rqpComments";

		//requests
		private const string RqsStatusID = "@rqsStatus";
		private const string RqsAgentID = "@rqsAgent";
		private const string RqsVesselID = "@rqsVesselID";
		private const string RqsPortArr = "@rqsPortArr";
		private const string RqsDateArr = "@rqsDateArr";
		private const string RqsDescription = "@rqsDescr";
		private const string RqsDateDB = "@rqsDateDB";
		private const string RqsID = "@rqsID";
		private const string RqsCrewQuantity = "@rqsCrewQuantity";

		//
		private const String Filter = "@filterClause";
		private const String Order = "@orderClause";
		#endregion


		#region SQLCommands

		//statuses 
		private SqlCommand loadStatusesCmd;
		private SqlCommand loadStatusInfoCmd;

		//currency 
		private SqlCommand loadCurrenciesCmd;
		private SqlCommand loadCurrencyInfoCmd;
		
		//departments 
		private SqlCommand loadDepartmentsCmd;
		private SqlCommand loadDepartmentInfoCmd;
		
		//positions 
		private SqlCommand loadPositionsCmd;
		private SqlCommand loadPositionInfoCmd;

		//requests
		private SqlCommand loadRequestsCmd;
		private SqlCommand loadRequestInfoCmd;
		private SqlCommand addRequestCmd;
		private SqlCommand updateRequestCmd;
		private SqlCommand removeRequestCmd;
		private SqlCommand calcRequestCmd;

		//request positions
		private SqlCommand loadRequestPositionsCmd;
		private SqlCommand loadRequestPositionInfoCmd;
		private SqlCommand addRequestPositionCmd;
		private SqlCommand updateRequestPositionCmd;
		private SqlCommand removeRequestPositionCmd;
		private SqlCommand calcRequestPositionCmd;


        #endregion


		#region constructors
		public RequestDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public RequestDAL() {
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
				//statuses
				if(loadStatusesCmd != null)
					loadStatusesCmd.Dispose();
				if(loadStatusInfoCmd != null)
					loadStatusInfoCmd.Dispose();

				//currency
				if(loadCurrenciesCmd != null)
					loadCurrenciesCmd.Dispose();
				if(loadCurrencyInfoCmd != null)
					loadCurrencyInfoCmd.Dispose();

				//currency
				if(loadDepartmentsCmd != null)
					loadDepartmentsCmd.Dispose();
				if(loadDepartmentInfoCmd != null)
					loadDepartmentInfoCmd.Dispose();

				//positions
				if(loadPositionsCmd != null)
					loadPositionsCmd.Dispose();
				if(loadPositionInfoCmd != null)
					loadPositionInfoCmd.Dispose();

				//requests
				if(loadRequestsCmd != null)
					loadRequestsCmd.Dispose();
				if(loadRequestInfoCmd != null)
					loadRequestInfoCmd.Dispose();
				if(addRequestCmd != null)
					addRequestCmd.Dispose();
				if(updateRequestCmd != null)
					updateRequestCmd.Dispose();
				if(removeRequestCmd != null)
					removeRequestCmd.Dispose();
				if(calcRequestCmd != null)
					calcRequestCmd.Dispose();

				//request positions
				if(loadRequestPositionsCmd != null)
					loadRequestPositionsCmd.Dispose();
				if(loadRequestPositionInfoCmd != null)
					loadRequestPositionInfoCmd.Dispose();
				if(addRequestPositionCmd != null)
					addRequestPositionCmd.Dispose();
				if(updateRequestPositionCmd != null)
					updateRequestPositionCmd.Dispose();
				if(removeRequestPositionCmd != null)
					removeRequestPositionCmd.Dispose();
				if(calcRequestPositionCmd != null)
					calcRequestPositionCmd.Dispose();


			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion

		
		#region SQL Command Getters
		
		#region Statuses
	
		private SqlCommand GetLoadStatusesCommand() {
			if ( loadStatusesCmd == null ) {
				loadStatusesCmd = new SqlCommand("dbo.LoadRequestStatuses");
				loadStatusesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadStatusesCmd;
		}


		private SqlCommand GetLoadStatusInfoCommand() {
			if ( loadStatusInfoCmd == null ) {
				loadStatusInfoCmd = new SqlCommand("dbo.GetRequestStatusInfo");
				loadStatusInfoCmd.CommandType = CommandType.StoredProcedure;
				loadStatusInfoCmd.Parameters.Add(new SqlParameter(RstID, SqlDbType.Int));
			}
			return loadStatusInfoCmd;
		}



		#endregion

		#region Currencies
	
		private SqlCommand GetLoadCurrenciesCommand() {
			if ( loadCurrenciesCmd == null ) {
				loadCurrenciesCmd = new SqlCommand("dbo.LoadCurrencies");
				loadCurrenciesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadCurrenciesCmd;
		}


		private SqlCommand GetLoadCurrencyInfoCommand() {
			if ( loadCurrencyInfoCmd == null ) {
				loadCurrencyInfoCmd = new SqlCommand("dbo.GetCurrencyInfo");
				loadCurrencyInfoCmd.CommandType = CommandType.StoredProcedure;
				loadCurrencyInfoCmd.Parameters.Add(new SqlParameter(CurID, SqlDbType.Int));
			}
			return loadCurrencyInfoCmd;
		}



		#endregion

		#region Departments
	
		private SqlCommand GetLoadDepartmentsCommand() {
			if ( loadDepartmentsCmd == null ) {
				loadDepartmentsCmd = new SqlCommand("dbo.LoadDepartments");
				loadDepartmentsCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadDepartmentsCmd;
		}


		private SqlCommand GetLoadDepartmentInfoCommand() {
			if ( loadDepartmentInfoCmd == null ) {
				loadDepartmentInfoCmd = new SqlCommand("dbo.GetDepartmentInfo");
				loadDepartmentInfoCmd.CommandType = CommandType.StoredProcedure;
				loadDepartmentInfoCmd.Parameters.Add(new SqlParameter(DepID, SqlDbType.Int));
			}
			return loadDepartmentInfoCmd;
		}



		#endregion

		#region Positions
	
		private SqlCommand GetLoadPositionsCommand() {
			if ( loadPositionsCmd == null ) {
				loadPositionsCmd = new SqlCommand("dbo.LoadPositions");
				loadPositionsCmd.CommandType = CommandType.StoredProcedure;
				loadPositionsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadPositionsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadPositionsCmd;
		}


		private SqlCommand GetLoadPositionInfoCommand() {
			if ( loadPositionInfoCmd == null ) {
				loadPositionInfoCmd = new SqlCommand("dbo.GetPositionInfo");
				loadPositionInfoCmd.CommandType = CommandType.StoredProcedure;
				loadPositionInfoCmd.Parameters.Add(new SqlParameter(PosID, SqlDbType.Int));
			}
			return loadPositionInfoCmd;
		}



		#endregion

		#region Requests

		private SqlCommand GetLoadRequestsCommand() {
			if ( loadRequestsCmd == null ) {
				loadRequestsCmd = new SqlCommand("dbo.LoadRequests");
				loadRequestsCmd.CommandType = CommandType.StoredProcedure;
				loadRequestsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadRequestsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadRequestsCmd;
		}


		private SqlCommand GetLoadRequestInfoCommand() {
			if ( loadRequestInfoCmd == null ) {
				loadRequestInfoCmd = new SqlCommand("dbo.GetRequestInfo");
				loadRequestInfoCmd.CommandType = CommandType.StoredProcedure;
				loadRequestInfoCmd.Parameters.Add(new SqlParameter(RqsID, SqlDbType.Int));
			}
			return loadRequestInfoCmd;
		}


		private SqlCommand GetAddRequestCommand() {
			if ( addRequestCmd == null ) {
				addRequestCmd = new SqlCommand("dbo.AddRequest");
				addRequestCmd.CommandType = CommandType.StoredProcedure;
				addRequestCmd.Parameters.Add(new SqlParameter(RqsStatusID, SqlDbType.SmallInt));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsAgentID, SqlDbType.Int));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsVesselID, SqlDbType.Int));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsPortArr, SqlDbType.NVarChar, 24));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsDateArr, SqlDbType.DateTime));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsDescription, SqlDbType.NVarChar, 100));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsDateDB, SqlDbType.DateTime));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsCrewQuantity, SqlDbType.SmallInt));
				addRequestCmd.Parameters.Add(new SqlParameter(RqsID, SqlDbType.Int));
				addRequestCmd.Parameters[RqsID].Direction = ParameterDirection.Output;
			}
			return addRequestCmd;
		}

		
		private SqlCommand GetUpdateRequestCommand() {
			if ( updateRequestCmd == null ) {
				updateRequestCmd = new SqlCommand("dbo.UpdateRequestInfo");
				updateRequestCmd.CommandType = CommandType.StoredProcedure;
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsStatusID, SqlDbType.SmallInt));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsAgentID, SqlDbType.Int));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsVesselID, SqlDbType.Int));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsPortArr, SqlDbType.NVarChar, 24));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsDateArr, SqlDbType.DateTime));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsDescription, SqlDbType.NVarChar, 100));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsDateDB, SqlDbType.DateTime));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsCrewQuantity, SqlDbType.SmallInt));
				updateRequestCmd.Parameters.Add(new SqlParameter(RqsID, SqlDbType.Int));
			}
			return updateRequestCmd;
		}

		
		private SqlCommand GetRemoveRequestCommand() {
			if ( removeRequestCmd == null ) {
				removeRequestCmd = new SqlCommand("dbo.RemoveRequest");
				removeRequestCmd.CommandType = CommandType.StoredProcedure;
				removeRequestCmd.Parameters.Add(new SqlParameter(RqsID, SqlDbType.Int));
			}
			return removeRequestCmd;
		}


		private SqlCommand GetCalcRequetsCommand() {
			if ( calcRequestCmd == null ) {
				calcRequestCmd = new SqlCommand("dbo.CalculateRequests");
				calcRequestCmd.CommandType = CommandType.StoredProcedure;
				calcRequestCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
			}
			return calcRequestCmd;
		}


		#endregion

		#region Request Positions

		private SqlCommand GetLoadRequestPositionsCommand() {
			if ( loadRequestPositionsCmd == null ) {
				loadRequestPositionsCmd = new SqlCommand("dbo.LoadRequestPositions");
				loadRequestPositionsCmd.CommandType = CommandType.StoredProcedure;
				loadRequestPositionsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadRequestPositionsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadRequestPositionsCmd;
		}


		private SqlCommand GetLoadRequestPositionInfoCommand() {
			if ( loadRequestPositionInfoCmd == null ) {
				loadRequestPositionInfoCmd = new SqlCommand("dbo.GetRequestPositionInfo");
				loadRequestPositionInfoCmd.CommandType = CommandType.StoredProcedure;
				loadRequestPositionInfoCmd.Parameters.Add(new SqlParameter(RqpID, SqlDbType.Int));
			}
			return loadRequestPositionInfoCmd;
		}


		private SqlCommand GetAddRequestPositionCommand() {
			if ( addRequestPositionCmd == null ) {
				addRequestPositionCmd = new SqlCommand("dbo.AddRequestPosition");
				addRequestPositionCmd.CommandType = CommandType.StoredProcedure;
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpID, SqlDbType.Int));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpRequestID, SqlDbType.Int));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpPositionID, SqlDbType.SmallInt));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpQuantity, SqlDbType.SmallInt));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpSalary, SqlDbType.SmallInt));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpCurrencyID, SqlDbType.SmallInt));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpLengthCo, SqlDbType.TinyInt));
				addRequestPositionCmd.Parameters.Add(new SqlParameter(RqpComments, SqlDbType.NVarChar, 64));
				addRequestPositionCmd.Parameters[RqpID].Direction = ParameterDirection.Output;
			}
			return addRequestPositionCmd;
		}

		
		private SqlCommand GetUpdateRequestPositionCommand() {
			if ( updateRequestPositionCmd == null ) {
				updateRequestPositionCmd = new SqlCommand("dbo.UpdateRequestPositionInfo");
				updateRequestPositionCmd.CommandType = CommandType.StoredProcedure;
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpID, SqlDbType.Int));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpRequestID, SqlDbType.Int));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpPositionID, SqlDbType.SmallInt));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpQuantity, SqlDbType.SmallInt));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpSalary, SqlDbType.SmallInt));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpCurrencyID, SqlDbType.SmallInt));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpLengthCo, SqlDbType.TinyInt));
				updateRequestPositionCmd.Parameters.Add(new SqlParameter(RqpComments, SqlDbType.NVarChar, 64));
			}
			return updateRequestPositionCmd;
		}

		
		private SqlCommand GetRemoveRequestPositionCommand() {
			if ( removeRequestPositionCmd == null ) {
				removeRequestPositionCmd = new SqlCommand("dbo.RemoveRequestPosition");
				removeRequestPositionCmd.CommandType = CommandType.StoredProcedure;
				removeRequestPositionCmd.Parameters.Add(new SqlParameter(RqpID, SqlDbType.Int));
			}
			return removeRequestPositionCmd;
		}


		
		private SqlCommand GetCalcRequetsPositionCommand() {
			if ( calcRequestPositionCmd == null ) {
				calcRequestPositionCmd = new SqlCommand("dbo.CalculateRequestPositions");
				calcRequestPositionCmd.CommandType = CommandType.StoredProcedure;
				calcRequestPositionCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
			}
			return calcRequestPositionCmd;
		}

		#endregion

		#endregion

		
		#region SQL Public commands

		#region Statuses
		public RequestStatusInfo[] GetStatuses() {
			SqlCommand cmd = GetLoadStatusesCommand();
			RequestStatusInfo[] statusList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					RequestStatusInfo rst = new RequestStatusInfo();
					rst.RequestStatusID = (Int16)reader["rstID"];
					rst.Code = (Int16)reader["rstCode"];
					if (reader["rstName"] != DBNull.Value)
						rst.Name = (string)(reader["rstName"]);

					array.Add(rst);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				statusList = new RequestStatusInfo[array.Count];
				array.CopyTo(statusList);
			}
			return statusList;
		}


		public RequestStatusInfo GetStatusInfo(int rStatusID) {
			SqlCommand cmd = GetLoadStatusInfoCommand();
			cmd.Parameters[RstID].Value = rStatusID;

			RequestStatusInfo rst = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					rst = new RequestStatusInfo();
					rst.RequestStatusID = (Int16)reader["rstID"];
					rst.Code = (Int16)reader["rstCode"];
					if (reader["rstName"] != DBNull.Value)
						rst.Name = (string)(reader["rstName"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return rst;
		}


		#endregion


		#region Currency
		public CurrencyInfo[] GetCurrencies() {
			SqlCommand cmd = GetLoadCurrenciesCommand();
			CurrencyInfo[] curList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					CurrencyInfo cur = new CurrencyInfo();
					cur.CurrencyID = (Int16)reader["curID"];
					if (reader["curName"] != DBNull.Value)
						cur.Name = (string)(reader["curName"]);

					array.Add(cur);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				curList = new CurrencyInfo[array.Count];
				array.CopyTo(curList);
			}
			return curList;
		}


		public CurrencyInfo GetCurrencyInfo(int currencyID) {
			SqlCommand cmd = GetLoadCurrencyInfoCommand();
			cmd.Parameters[CurID].Value = currencyID;

			CurrencyInfo cur = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					cur = new CurrencyInfo();
					cur.CurrencyID = (Int16)reader["curID"];
					if (reader["curName"] != DBNull.Value)
						cur.Name = (string)(reader["curName"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return cur;
		}


		#endregion


		#region Departments
		public DepartmentInfo[] GetDepartments() {
			SqlCommand cmd = GetLoadDepartmentsCommand();
			DepartmentInfo[] depList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					DepartmentInfo dep = new DepartmentInfo();
					dep.DepartmentID = (Int16)reader["depID"];
					if (reader["depName"] != DBNull.Value)
						dep.Name = (string)(reader["depName"]);

					array.Add(dep);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				depList = new DepartmentInfo[array.Count];
				array.CopyTo(depList);
			}
			return depList;
		}


		public DepartmentInfo GetDepartmentInfo(int departmentID) {
			SqlCommand cmd = GetLoadDepartmentInfoCommand();
			cmd.Parameters[DepID].Value = departmentID;

			DepartmentInfo dep = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					dep = new DepartmentInfo();
					dep.DepartmentID = (Int16)reader["depID"];
					if (reader["depName"] != DBNull.Value)
						dep.Name = (string)(reader["depName"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return dep;
		}


		#endregion

		
		#region Positions
		public PositionInfo[] GetPositions(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadPositionsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();

			PositionInfo[] posList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					PositionInfo pos = new PositionInfo();
					pos.PositionID = (Int16)reader["posID"];
					pos.Department.DepartmentID = (Int16)reader["depID"];
					if (reader["posName"] != DBNull.Value)
						pos.Name = (string)(reader["posName"]);

					array.Add(pos);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				posList = new PositionInfo[array.Count];
				array.CopyTo(posList);
			}
			return posList;
		}


		public PositionInfo GetPositionInfo(int positionID) {
			SqlCommand cmd = GetLoadPositionInfoCommand();
			cmd.Parameters[PosID].Value = positionID;

			PositionInfo pos = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					pos = new PositionInfo();
					pos.PositionID = (Int16)reader["posID"];
					pos.Department.DepartmentID = (Int16)reader["depID"];
					if (reader["posName"] != DBNull.Value)
						pos.Name = (string)(reader["posName"]);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return pos;
		}


		#endregion

		
		#region Requests
		
		public RequestInfo[] GetRequests(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadRequestsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			RequestInfo[] rqsList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					RequestInfo rqs = new RequestInfo();
					rqs.Status.RequestStatusID = (Int16)reader["rqsStatus"];
					rqs.Agent.AgentID = (int)reader["rqsAgent"];
					rqs.Vessel.VesselID = (int)reader["rqsVesselID"];
					rqs.RequestID = (int)reader["rqsID"];
					if (reader["rqsPortArr"] != DBNull.Value)
						rqs.PortArr = (string)(reader["rqsPortArr"]);
					if (reader["rqsDateArr"] != DBNull.Value)
						rqs.DateArr = (DateTime)(reader["rqsDateArr"]);
					if (reader["rqsDescr"] != DBNull.Value)
						rqs.Description = (string)reader["rqsDescr"];
					if (reader["rqsDateDB"] != DBNull.Value)
						rqs.DateDB = (DateTime)reader["rqsDateDB"];
					if (reader["rqsCrewQuantity"] != DBNull.Value)
						rqs.CrewQuantity = (Int16)reader["rqsCrewQuantity"];

					array.Add(rqs);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				rqsList = new RequestInfo[array.Count];
				array.CopyTo(rqsList);
			}
			return rqsList;
		}


		public RequestInfo GetRequestInfo(int requestID) {
			SqlCommand cmd = GetLoadRequestInfoCommand();
			cmd.Parameters[RqsID].Value = requestID;

			RequestInfo rqs = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					rqs = new RequestInfo();
					rqs.Status.RequestStatusID = (Int16)reader["rqsStatus"];
					rqs.Agent.AgentID = (int)reader["rqsAgent"];
					rqs.Vessel.VesselID = (int)reader["rqsVesselID"];
					rqs.RequestID = (int)reader["rqsID"];
					if (reader["rqsPortArr"] != DBNull.Value)
						rqs.PortArr = (string)(reader["rqsPortArr"]);
					if (reader["rqsDateArr"] != DBNull.Value)
						rqs.DateArr = (DateTime)(reader["rqsDateArr"]);
					if (reader["rqsDescr"] != DBNull.Value)
						rqs.Description = (string)reader["rqsDescr"];
					if (reader["rqsDateDB"] != DBNull.Value)
						rqs.DateDB = (DateTime)reader["rqsDateDB"];
					if (reader["rqsCrewQuantity"] != DBNull.Value)
						rqs.CrewQuantity = (Int16)reader["rqsCrewQuantity"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return rqs;
		}


		public bool RemoveRequest(int requestID) {
			SqlCommand cmd = GetRemoveRequestCommand();
			cmd.Parameters[RqsID].Value = requestID;
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


		public bool UpdateRequest(RequestInfo request) {
			SqlCommand cmd = GetUpdateRequestCommand();
			cmd.Parameters[RqsStatusID].Value   = request.Status.RequestStatusID;
			cmd.Parameters[RqsAgentID].Value    = request.Agent.AgentID;
			cmd.Parameters[RqsVesselID].Value   = request.Vessel.VesselID;
			cmd.Parameters[RqsID].Value			= request.RequestID;
			cmd.Parameters[RqsPortArr].Value    = (request.PortArr == null) ? DBNull.Value : (Object)request.PortArr;
			cmd.Parameters[RqsDateArr].Value    = (request.DateArr == PersistentBusinessEntity.Date_Empty) ? DBNull.Value : (Object)request.DateArr;
			cmd.Parameters[RqsDescription].Value= (request.Description == null) ? DBNull.Value : (Object)request.Description;
			cmd.Parameters[RqsDateDB].Value     = request.DateDB;
			cmd.Parameters[RqsCrewQuantity].Value = (request.CrewQuantity == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)request.CrewQuantity;

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


		public bool AddRequest(RequestInfo request, out int requestID) {
			SqlCommand cmd = GetAddRequestCommand();
			cmd.Parameters[RqsStatusID].Value   = request.Status.RequestStatusID;
			cmd.Parameters[RqsAgentID].Value    = request.Agent.AgentID;
			cmd.Parameters[RqsVesselID].Value   = request.Vessel.VesselID;
			cmd.Parameters[RqsID].Value			= request.RequestID;
			cmd.Parameters[RqsPortArr].Value    = (request.PortArr == null) ? DBNull.Value : (Object)request.PortArr;
			cmd.Parameters[RqsDateArr].Value    = (request.DateArr == PersistentBusinessEntity.Date_Empty) ? DBNull.Value : (Object)request.DateArr;
			cmd.Parameters[RqsDescription].Value= (request.Description == null) ? DBNull.Value : (Object)request.Description;
			cmd.Parameters[RqsDateDB].Value     = request.DateDB;
			cmd.Parameters[RqsCrewQuantity].Value = (request.CrewQuantity == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)request.CrewQuantity;

			requestID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				requestID = (int)cmd.Parameters[RqsID].Value;
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public int CalculateRequests(FilterExpression filter) {
			SqlCommand cmd = GetCalcRequetsCommand();
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
		

		#region Request positions
		
		public RequestPositionInfo[] GetRequestPositions(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadRequestPositionsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			RequestPositionInfo[] rqpList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					RequestPositionInfo rqp = new RequestPositionInfo();
					rqp.RequestPositionID = (int)reader["rqpID"];
					int rqsID = (int)reader["rqpRequest"];
					rqp.Position.PositionID = (Int16)reader["rqpPosition"];
					rqp.Quantity = (Int16)reader["rqpQuantity"];
					if(reader["rqpSalary"] != DBNull.Value)
						rqp.Salary = (Int16)reader["rqpSalary"];
					else
						rqp.Salary = PersistentBusinessEntity.ID_Empty;
					rqp.Currency.CurrencyID = (Int16)reader["rqpCurrency"];
					rqp.ContractLength = (byte)reader["rqpLengthCo"];
					if (reader["rqpComments"] != DBNull.Value)
						rqp.Comments = (string)reader["rqpComments"];

					array.Add(rqp);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				rqpList = new RequestPositionInfo[array.Count];
				array.CopyTo(rqpList);
			}
			return rqpList;
		}


		public RequestPositionInfo GetRequestPositionInfo(int rqpID) {
			SqlCommand cmd = GetLoadRequestPositionInfoCommand();
			cmd.Parameters[RqpID].Value = rqpID;

			RequestPositionInfo rqp = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					rqp = new RequestPositionInfo();
					rqp.RequestPositionID = (int)reader["rqpID"];
					int rqsID = (int)reader["rqpRequest"];
					rqp.Position.PositionID = (Int16)reader["rqpPosition"];
					rqp.Quantity = (Int16)reader["rqpQuantity"];
					if(reader["rqpSalary"] != DBNull.Value)
						rqp.Salary = (Int16)reader["rqpSalary"];
					else
						rqp.Salary = PersistentBusinessEntity.ID_Empty;
					rqp.Currency.CurrencyID = (Int16)reader["rqpCurrency"];
					rqp.ContractLength = (byte)reader["rqpLengthCo"];
					if (reader["rqpComments"] != DBNull.Value)
						rqp.Comments = (string)reader["rqpComments"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return rqp;
		}


		public bool RemoveRequestPosition(int rqpID) {
			SqlCommand cmd = GetRemoveRequestPositionCommand();
			cmd.Parameters[RqpID].Value = rqpID;
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


		public bool UpdateRequestPosition(RequestPositionInfo rqpInfo, int requestID) {
			SqlCommand cmd = GetUpdateRequestPositionCommand();
			cmd.Parameters[RqpID].Value = rqpInfo.RequestPositionID;
			cmd.Parameters[RqpRequestID].Value = requestID;
			cmd.Parameters[RqpPositionID].Value = rqpInfo.Position.PositionID;
			cmd.Parameters[RqpQuantity].Value = rqpInfo.Quantity;
			cmd.Parameters[RqpSalary].Value = (rqpInfo.Salary == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)rqpInfo.Salary;
			cmd.Parameters[RqpCurrencyID].Value = rqpInfo.Currency.CurrencyID;
			cmd.Parameters[RqpLengthCo].Value = rqpInfo.ContractLength;
			cmd.Parameters[RqpComments].Value = (rqpInfo.Comments == null) ? DBNull.Value : (Object)rqpInfo.Comments;

			requestID = PersistentBusinessEntity.ID_Empty;
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


		public bool AddRequestPosition(RequestPositionInfo rqpInfo, int requestID, out int rqpID) {
			SqlCommand cmd = GetAddRequestPositionCommand();
			cmd.Parameters[RqpID].Value = rqpInfo.RequestPositionID;
			cmd.Parameters[RqpRequestID].Value = requestID;
			cmd.Parameters[RqpPositionID].Value = rqpInfo.Position.PositionID;
			cmd.Parameters[RqpQuantity].Value = rqpInfo.Quantity;
			cmd.Parameters[RqpSalary].Value = (rqpInfo.Salary == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)rqpInfo.Salary;
			cmd.Parameters[RqpCurrencyID].Value = rqpInfo.Currency.CurrencyID;
			cmd.Parameters[RqpLengthCo].Value = rqpInfo.ContractLength;
			cmd.Parameters[RqpComments].Value = (rqpInfo.Comments == null) ? DBNull.Value : (Object)rqpInfo.Comments;

			rqpID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				rqpID = (int)cmd.Parameters[RqpID].Value;
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}



		public int CalculateRequestPositions(FilterExpression filter) {
			SqlCommand cmd = GetCalcRequetsPositionCommand();
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
		
		
		#endregion


		#region Component Designer generated code
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
