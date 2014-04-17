using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

using Volans.Common;


namespace Volans.DAL {

	public class FindListsDAL : System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;


		#region constants
		private const string FlSatusID = "@rqsStatus";
		private const string FlVesselID = "@rqsVesselID";
		private const string FlAgentID = "@rqsAgent";
		private const string FlDepID = "@depID";
		private const string FlRPositionID = "@rqpID";
		private const string FlPositionID = "@posID";
		//
		private const string Filter = "@filterClause";
		private const string Order = "@orderClause";
		#endregion

	
		#region SQLCommands
		private SqlCommand loadRequestListCmd;
		#endregion

		
		#region constructors
		public FindListsDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public FindListsDAL() {
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
				if(loadRequestListCmd != null)
					loadRequestListCmd.Dispose();
			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion


		#region SQL Command Getters
		private SqlCommand GetLoadRequestListCommand() {
			if ( loadRequestListCmd == null ) {
				loadRequestListCmd = new SqlCommand("dbo.LoadListOfRequests");
				loadRequestListCmd.CommandType = CommandType.StoredProcedure;
				loadRequestListCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadRequestListCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadRequestListCmd;
		}


		#endregion

		
		#region Public commands
		public RequestListItem[] GetRequestList(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadRequestListCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			RequestListItem[] list = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					RequestListItem item = new RequestListItem();
					item.Agent.AgentID = (int)reader["rqsAgent"];
					item.RequestPosition.RequestPositionID = (int)reader["rqpID"];
					item.RequestStatus.RequestStatusID = (Int16)reader["rqsStatus"];
					item.Vessel.VesselID = (int)reader["rqsVesselID"];
					item.RequestID = (int)reader["rqsID"];
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
				list = new RequestListItem[array.Count];
				array.CopyTo(list);
			}
			return list;
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
