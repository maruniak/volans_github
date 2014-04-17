using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;


using Volans.Common;


namespace Volans.DAL {

	public class VesselDAL : System.ComponentModel.Component {

		private System.ComponentModel.Container components = null;

		#region constants
		
		//vessels
		private const string VslAgent		= "@vslAgent";
		private const string VslID			= "@vslID";
		private const string VslName		= "@vslName";
		private const string VslType		= "@vslType";
		private const string VslOperator	= "@vslOperator";
		private const string VslOperator_C	= "@vslOperator_C";
		private const string VslOwner		= "@vslOwner";
		private const string VslOwner_C		= "@vslOwner_C";
		private const string VslGRT			= "@vslGRT";
		private const string VslNRT			= "@vslNRT";
		private const string VslDWT			= "@vslDWT";
		private const string VslPortReg		= "@vslPortReg";
		private const string VslRegNo		= "@vslRegNo";
		private const string VslFlag		= "@vslFlag";
		private const string VslEtype		= "@vslEtype";
		private const string VslEno			= "@vslEno";
		private const string VslEPower		= "@vslEPower";
		private const string VslEpUnit		= "@vslEpUnit";
		private const string VslEAUX		= "@vslEAUX";
		private const string VslPAX			= "@vslPAX";
		private const string VslCabines		= "@vslCabins";
		private const string VslYear		= "@vslYear";
		private const string VslIMNo		= "@vslIMONo";
		private const string VslCallSign	= "@vslCallSign";
		private const string VslExNames		= "@vslExNames";
		private const string VslBuilder		= "@vslBuilder";
		private const string VslNCrew		= "@vslNCrew";
		private const string VslLength		= "@vslLength";
		private const string VslBeam		= "@vslBeam";
		private const string VslDraft		= "@vslDraft";
		private const string VslPhotoUrl    = "@vslPhoto";

		//Vtypes
		private const string VtpID   = "@vtpID";
		private const string VtpName = "@vtpName";

		//Flags
		private const string FlgID   = "@flgID";
		private const string FlgName = "@flgName";

		//Etypes
		private const string EtpID   = "@etpID";
		private const string EtpName = "@etpName";


		private const String Filter = "@filterClause";
		private const String Order = "@orderClause";

		#endregion


		#region SQLCommands

		private SqlCommand addVesselCmd;
		private SqlCommand loadVesselsCmd;
		private SqlCommand loadVesselInfoCmd;
		private SqlCommand removeVesselCmd;
		private SqlCommand updateVesselCmd;
		private SqlCommand calcVesselsCmd;

		//
		private SqlCommand loadVesselTypesCmd; 
		private SqlCommand loadVesselTypeInfoCmd;
		private SqlCommand loadEngineTypesCmd; 
		private SqlCommand loadEngineTypeInfoCmd;
		private SqlCommand loadFlagsCmd; 
		private SqlCommand loadFlagInfoCmd;

		#endregion

		
		#region constructors 

		public VesselDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}


		public VesselDAL() {
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
				if (addVesselCmd != null) 
					addVesselCmd.Dispose();
				if(loadVesselsCmd != null)
					loadVesselsCmd.Dispose();
				if(loadVesselInfoCmd != null)
					loadVesselInfoCmd.Dispose();
				if(removeVesselCmd != null)
					removeVesselCmd.Dispose();
				if(updateVesselCmd != null)
					updateVesselCmd.Dispose();
				if(calcVesselsCmd != null)
					calcVesselsCmd.Dispose();

				//
				if (loadVesselTypesCmd != null)
					loadVesselTypesCmd.Dispose();
				if (loadVesselTypeInfoCmd != null)
					loadVesselTypeInfoCmd.Dispose();
				if (loadEngineTypesCmd != null)
					loadEngineTypesCmd.Dispose();
				if (loadEngineTypeInfoCmd != null)
					loadEngineTypeInfoCmd.Dispose();
				if (loadFlagsCmd != null)
					loadFlagsCmd.Dispose();
				if (loadFlagInfoCmd != null)
					loadFlagInfoCmd.Dispose();
			} 
			finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion


		#region SQL Command Getters
		
		// Vessels
		private SqlCommand GetAddVesselCommand() {
			if ( addVesselCmd == null ) {
				addVesselCmd = new SqlCommand("dbo.AddVessel");
				addVesselCmd.CommandType = CommandType.StoredProcedure;
				addVesselCmd.Parameters.Add(new SqlParameter(VslAgent, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslName, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslType, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslOperator, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslOwner, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslOperator_C, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslOwner_C, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslGRT, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslNRT, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslDWT, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslPortReg, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslRegNo, SqlDbType.NVarChar, 16));
				addVesselCmd.Parameters.Add(new SqlParameter(VslFlag, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslEtype, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslEno, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslEPower, SqlDbType.Int));
				addVesselCmd.Parameters.Add(new SqlParameter(VslEpUnit, SqlDbType.Char, 3));
				addVesselCmd.Parameters.Add(new SqlParameter(VslEAUX, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslPAX, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslCabines, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslYear, SqlDbType.Char, 4));
				addVesselCmd.Parameters.Add(new SqlParameter(VslIMNo, SqlDbType.NVarChar, 16));
				addVesselCmd.Parameters.Add(new SqlParameter(VslCallSign, SqlDbType.NVarChar, 16));
				addVesselCmd.Parameters.Add(new SqlParameter(VslExNames, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslBuilder, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslNCrew, SqlDbType.SmallInt));
				addVesselCmd.Parameters.Add(new SqlParameter(VslLength, SqlDbType.NVarChar, 8));
				addVesselCmd.Parameters.Add(new SqlParameter(VslBeam, SqlDbType.NVarChar, 8));
				addVesselCmd.Parameters.Add(new SqlParameter(VslDraft, SqlDbType.NVarChar, 8));
				addVesselCmd.Parameters.Add(new SqlParameter(VslPhotoUrl, SqlDbType.NVarChar, 50));
				addVesselCmd.Parameters.Add(new SqlParameter(VslID, SqlDbType.Int));
				addVesselCmd.Parameters[VslID].Direction = ParameterDirection.Output;
			}
			return addVesselCmd;
		}


		private SqlCommand GetLoadVesselsCommand() {
			if ( loadVesselsCmd == null ) {
				loadVesselsCmd = new SqlCommand("dbo.LoadVessels");
				loadVesselsCmd.CommandType = CommandType.StoredProcedure;
				loadVesselsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
				loadVesselsCmd.Parameters.Add(new SqlParameter(Order, SqlDbType.NVarChar,1000));
			}
			return loadVesselsCmd;
		}


		private SqlCommand GetLoadVesselInfoCommand() {
			if ( loadVesselInfoCmd == null ) {
				loadVesselInfoCmd = new SqlCommand("dbo.GetVesselInfo");
				loadVesselInfoCmd.CommandType = CommandType.StoredProcedure;
				loadVesselInfoCmd.Parameters.Add(new SqlParameter(VslID, SqlDbType.Int));
			}
			return loadVesselInfoCmd;
		}


		private SqlCommand GetRemoveVesselCommand() {
			if ( removeVesselCmd == null ) {
				removeVesselCmd = new SqlCommand("dbo.RemoveVessel");
				removeVesselCmd.CommandType = CommandType.StoredProcedure;
				removeVesselCmd.Parameters.Add(new SqlParameter(VslID, SqlDbType.Int));
			}
			return removeVesselCmd;
		}


		private SqlCommand GetUpdateVesselCommand() {
			if ( updateVesselCmd == null ) {
				updateVesselCmd = new SqlCommand("dbo.UpdateVesselInfo");
				updateVesselCmd.CommandType = CommandType.StoredProcedure;
				updateVesselCmd.Parameters.Add(new SqlParameter(VslAgent, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslID, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslName, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslType, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslOperator, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslOwner, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslOperator_C, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslOwner_C, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslGRT, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslNRT, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslDWT, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslPortReg, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslRegNo, SqlDbType.NVarChar, 16));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslFlag, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslEtype, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslEno, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslEPower, SqlDbType.Int));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslEpUnit, SqlDbType.Char, 3));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslEAUX, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslPAX, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslCabines, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslYear, SqlDbType.Char, 4));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslIMNo, SqlDbType.NVarChar, 16));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslCallSign, SqlDbType.NVarChar, 16));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslExNames, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslBuilder, SqlDbType.NVarChar, 50));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslNCrew, SqlDbType.SmallInt));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslLength, SqlDbType.NVarChar, 8));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslBeam, SqlDbType.NVarChar, 8));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslDraft, SqlDbType.NVarChar, 8));
				updateVesselCmd.Parameters.Add(new SqlParameter(VslPhotoUrl, SqlDbType.NVarChar, 50));
			}
			return updateVesselCmd;
		}


		//Vessel types
		private SqlCommand GetLoadVesselTypesCommand() {
			if ( loadVesselTypesCmd == null ) {
				loadVesselTypesCmd = new SqlCommand("dbo.LoadVesselTypes");
				loadVesselTypesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadVesselTypesCmd;
		}


		private SqlCommand GetLoadVesselTypeInfoCommand() {
			if ( loadVesselTypeInfoCmd == null ) {
				loadVesselTypeInfoCmd = new SqlCommand("dbo.GetVeselTypeInfo");
				loadVesselTypeInfoCmd.CommandType = CommandType.StoredProcedure;
				loadVesselTypeInfoCmd.Parameters.Add(new SqlParameter(VtpID, SqlDbType.Int));
			}
			return loadVesselTypeInfoCmd;
		}


		
		private SqlCommand GetCalcVesselsCommand() {
			if ( calcVesselsCmd == null ) {
				calcVesselsCmd = new SqlCommand("dbo.CalculateVessels");
				calcVesselsCmd.CommandType = CommandType.StoredProcedure;
				calcVesselsCmd.Parameters.Add(new SqlParameter(Filter, SqlDbType.NVarChar,1000));
			}
			return calcVesselsCmd;
		}


		//Engine types
		private SqlCommand GetLoadEngineTypesCommand() {
			if ( loadEngineTypesCmd == null ) {
				loadEngineTypesCmd = new SqlCommand("dbo.LoadEngineTypes");
				loadEngineTypesCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadEngineTypesCmd;
		}


		private SqlCommand GetLoadEngineTypeInfoCommand() {
			if ( loadEngineTypeInfoCmd == null ) {
				loadEngineTypeInfoCmd = new SqlCommand("dbo.GetEngineTypeInfo");
				loadEngineTypeInfoCmd.CommandType = CommandType.StoredProcedure;
				loadEngineTypeInfoCmd.Parameters.Add(new SqlParameter(EtpID, SqlDbType.Int));
			}
			return loadEngineTypeInfoCmd;
		}


		
		//Flags
		private SqlCommand GetLoadFlagsCommand() {
			if ( loadFlagsCmd == null ) {
				loadFlagsCmd = new SqlCommand("dbo.LoadFlags");
				loadFlagsCmd.CommandType = CommandType.StoredProcedure;
			}
			return loadFlagsCmd;
		}


		private SqlCommand GetLoadFlagInfoCommand() {
			if ( loadFlagInfoCmd == null ) {
				loadFlagInfoCmd = new SqlCommand("dbo.GetFlagInfo");
				loadFlagInfoCmd.CommandType = CommandType.StoredProcedure;
				loadFlagInfoCmd.Parameters.Add(new SqlParameter(FlgID, SqlDbType.Int));
			}
			return loadFlagInfoCmd;
		}


		
		#endregion


		#region Public commands

		//vessels
		public VesselInfo[] GetVessels(FilterExpression filter, OrderExpression order) {
			SqlCommand cmd = GetLoadVesselsCommand();
			cmd.Parameters[Filter].Value = filter == null ? "" : filter.ToString();
			cmd.Parameters[Order].Value = order == null ? "" : order.ToString();
			VesselInfo[] vesselsList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					VesselInfo vsl = new VesselInfo();
					vsl.VesselID = (int)reader["vslID"];
					// ôû  ÷ðÿ¨þ¸þò
					int vAgent = (int)reader["vslAgent"];
					Int16 vType  = (Int16)reader["vslType"];
					Int16 vFlag  = PersistentBusinessEntity.ID_Empty;
					Int16 vEtype = PersistentBusinessEntity.ID_Empty;
					Int16 vOperatorC = PersistentBusinessEntity.ID_Empty;
					Int16 vOwnerC = PersistentBusinessEntity.ID_Empty;
					if (reader["vslFlag"] != DBNull.Value)
						vFlag  = (Int16)reader["vslFlag"];
					if (reader["vslEtype"] != DBNull.Value)
						vEtype = (Int16)reader["vslEtype"];
					if (reader["vslOperator_C"] != DBNull.Value)
						vOperatorC = (Int16)reader["vslOperator_C"];
					if (reader["vslOwner_C"] != DBNull.Value)
						vOwnerC = (Int16)reader["vslOwner_C"];
					//
					//FIXME
					vsl.Agent.AgentID = vAgent;
					vsl.VesselType.VesselTypeID = vType;					
					vsl.EngineType.EngineTypeID = vEtype;
					vsl.Flag.FlagID = vFlag;
					vsl.OperatorCountry.FlagID = vOperatorC;
					vsl.OwnerCountry.FlagID = vOwnerC;
					//--<
					if (reader["vslName"] != DBNull.Value)
						vsl.Name = (string)(reader["vslName"]);
					if (reader["vslOperator"] != DBNull.Value)
						vsl.Operator = (string)(reader["vslOperator"]);
					if (reader["vslOwner"] != DBNull.Value)
						vsl.Owner = (string)reader["vslOwner"];
					if (reader["vslGRT"] != DBNull.Value)
						vsl.GRT = (int)reader["vslGRT"];
					else
						vsl.GRT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslNRT"] != DBNull.Value)
						vsl.NRT = (int)reader["vslNRT"];
					else
						vsl.NRT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslDWT"] != DBNull.Value)
						vsl.DWT = (int)reader["vslDWT"];
					else
						vsl.DWT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslPortReg"] != DBNull.Value)
						vsl.PortReg = (string)reader["vslPortReg"];
					if (reader["vslRegNo"] != DBNull.Value)
						vsl.RegNo = (string)reader["vslRegNo"];
					if (reader["vslEno"] != DBNull.Value)
						vsl.EngineNo = (string)reader["vslEno"];
					if (reader["vslEPower"] != DBNull.Value)
						vsl.EnginePower = (int)reader["vslEPower"];
					else
						vsl.EnginePower = PersistentBusinessEntity.ID_Empty;
					if (reader["vslEpUnit"] != DBNull.Value)
						vsl.EpUnit = (string)reader["vslEpUnit"];
					if (reader["vslEAUX"] != DBNull.Value)
						vsl.EAUX = (string)reader["vslEAUX"];
					if (reader["vslPAX"] != DBNull.Value)
						vsl.PAX = (Int16)reader["vslPAX"];
					else
						vsl.PAX = PersistentBusinessEntity.ID_Empty;
					if (reader["vslCabins"] != DBNull.Value)
						vsl.Cabines = (Int16)reader["vslCabins"];
					else
						vsl.Cabines = PersistentBusinessEntity.ID_Empty;
					if (reader["vslYear"] != DBNull.Value)
						vsl.Year = (string)reader["vslYear"];
					if (reader["vslIMONo"] != DBNull.Value)
						vsl.IMOno = (string)reader["vslIMONo"];
					if (reader["vslCallSign"] != DBNull.Value)
						vsl.CallSign = (string)reader["vslCallSign"];
					if (reader["vslExNames"] != DBNull.Value)
						vsl.ExName = (string)reader["vslExNames"];
					if (reader["vslBuilder"] != DBNull.Value)
						vsl.BuilderName = (string)reader["vslBuilder"];
					if(reader["vslNCrew"] != DBNull.Value)
						vsl.NumberCrew = (Int16)reader["vslNCrew"];
					else
						vsl.NumberCrew = PersistentBusinessEntity.ID_Empty;
					if (reader["vslLength"] != DBNull.Value)
						vsl.Length = (string)reader["vslLength"];
					if (reader["vslBeam"] != DBNull.Value)
						vsl.Beam = (string)reader["vslBeam"];
					if (reader["vslDraft"] != DBNull.Value)
						vsl.Draft = (string)reader["vslDraft"];
					if (reader["vslPhoto"] != DBNull.Value)
						vsl.PhotoUrl = (string)reader["vslPhoto"];

					array.Add(vsl);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				vesselsList = new VesselInfo[array.Count];
				array.CopyTo(vesselsList);
			}
			return vesselsList;
		}


		public VesselInfo GetInfo(int vesselID) {
			SqlCommand cmd = GetLoadVesselInfoCommand();
			cmd.Parameters[VslID].Value = vesselID;
			
			VesselInfo vsl = null;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					vsl = new VesselInfo();
					vsl.VesselID = (int)reader["vslID"];
					vsl.VesselID = (int)reader["vslID"];
					// ôû  ÷ðÿ¨þ¸þò
					int vAgent = (int)reader["vslAgent"];
					Int16 vType  = (Int16)reader["vslType"];
					Int16 vFlag  = PersistentBusinessEntity.ID_Empty;
					Int16 vEtype = PersistentBusinessEntity.ID_Empty;
					Int16 vOperatorC = PersistentBusinessEntity.ID_Empty;
					Int16 vOwnerC = PersistentBusinessEntity.ID_Empty;
					if (reader["vslFlag"] != DBNull.Value)
						vFlag  = (Int16)reader["vslFlag"];
					if (reader["vslEtype"] != DBNull.Value)
						vEtype = (Int16)reader["vslEtype"];
					if (reader["vslOperator_C"] != DBNull.Value)
						vOperatorC = (Int16)reader["vslOperator_C"];
					if (reader["vslOwner_C"] != DBNull.Value)
						vOwnerC = (Int16)reader["vslOwner_C"];
					//
					//FIXME
					vsl.Agent.AgentID = vAgent;
					vsl.VesselType.VesselTypeID = vType;					
					vsl.EngineType.EngineTypeID = vEtype;
					vsl.Flag.FlagID = vFlag;
					vsl.OperatorCountry.FlagID = vOperatorC;
					vsl.OwnerCountry.FlagID = vOwnerC;
					//--<
					if (reader["vslName"] != DBNull.Value)
						vsl.Name = (string)(reader["vslName"]);
					if (reader["vslOperator"] != DBNull.Value)
						vsl.Operator = (string)(reader["vslOperator"]);
					if (reader["vslOwner"] != DBNull.Value)
						vsl.Owner = (string)reader["vslOwner"];
					if (reader["vslGRT"] != DBNull.Value)
						vsl.GRT = (int)reader["vslGRT"];
					else
						vsl.GRT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslNRT"] != DBNull.Value)
						vsl.NRT = (int)reader["vslNRT"];
					else
						vsl.NRT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslDWT"] != DBNull.Value)
						vsl.DWT = (int)reader["vslDWT"];
					else
						vsl.DWT = PersistentBusinessEntity.ID_Empty;
					if (reader["vslPortReg"] != DBNull.Value)
						vsl.PortReg = (string)reader["vslPortReg"];
					if (reader["vslRegNo"] != DBNull.Value)
						vsl.RegNo = (string)reader["vslRegNo"];
					if (reader["vslEno"] != DBNull.Value)
						vsl.EngineNo = (string)reader["vslEno"];
					if (reader["vslEPower"] != DBNull.Value)
						vsl.EnginePower = (int)reader["vslEPower"];
					else
						vsl.EnginePower = PersistentBusinessEntity.ID_Empty;
					if (reader["vslEpUnit"] != DBNull.Value)
						vsl.EpUnit = (string)reader["vslEpUnit"];
					if (reader["vslEAUX"] != DBNull.Value)
						vsl.EAUX = (string)reader["vslEAUX"];
					if (reader["vslPAX"] != DBNull.Value)
						vsl.PAX = (Int16)reader["vslPAX"];
					else
						vsl.PAX = PersistentBusinessEntity.ID_Empty;
					if (reader["vslCabins"] != DBNull.Value)
						vsl.Cabines = (Int16)reader["vslCabins"];
					else
						vsl.Cabines = PersistentBusinessEntity.ID_Empty;
					if (reader["vslYear"] != DBNull.Value)
						vsl.Year = (string)reader["vslYear"];
					if (reader["vslIMONo"] != DBNull.Value)
						vsl.IMOno = (string)reader["vslIMONo"];
					if (reader["vslCallSign"] != DBNull.Value)
						vsl.CallSign = (string)reader["vslCallSign"];
					if (reader["vslExNames"] != DBNull.Value)
						vsl.ExName = (string)reader["vslExNames"];
					if (reader["vslBuilder"] != DBNull.Value)
						vsl.BuilderName = (string)reader["vslBuilder"];
					if(reader["vslNCrew"] != DBNull.Value)
						vsl.NumberCrew = (Int16)reader["vslNCrew"];
					else
						vsl.NumberCrew = PersistentBusinessEntity.ID_Empty;
					if (reader["vslLength"] != DBNull.Value)
						vsl.Length = (string)reader["vslLength"];
					if (reader["vslBeam"] != DBNull.Value)
						vsl.Beam = (string)reader["vslBeam"];
					if (reader["vslDraft"] != DBNull.Value)
						vsl.Draft = (string)reader["vslDraft"];
					if (reader["vslPhoto"] != DBNull.Value)
						vsl.PhotoUrl = (string)reader["vslPhoto"];

				}
				reader.Close();
			} catch /*(Exception ex)*/{
				//throw new Exception(ex.Message);
				return null;
			} finally {
				if (conn != null) conn.Close();
			}
			return vsl;
		}


		public bool Remove(int vesselID) {
			SqlCommand cmd = GetRemoveVesselCommand();
			cmd.Parameters[VslID].Value = vesselID;
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


		public bool Add(VesselInfo vesselInfo, out int vesselID) {
			SqlCommand cmd = GetAddVesselCommand();
			cmd.Parameters[VslID].Value       = vesselInfo.VesselID;
			cmd.Parameters[VslAgent].Value    = vesselInfo.Agent.AgentID;
			cmd.Parameters[VslName].Value     = (vesselInfo.Name == null) ? DBNull.Value : (Object)vesselInfo.Name;
			cmd.Parameters[VslType].Value     = vesselInfo.VesselType.VesselTypeID;
			cmd.Parameters[VslOperator].Value = (vesselInfo.Operator == null) ? DBNull.Value : (Object)vesselInfo.Operator;
			cmd.Parameters[VslOwner].Value    = (vesselInfo.Owner == null) ? DBNull.Value : (Object)vesselInfo.Owner;
			cmd.Parameters[VslOperator_C].Value = (vesselInfo.OperatorCountry.FlagID == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.OperatorCountry.FlagID;
			cmd.Parameters[VslOwner_C].Value    = (vesselInfo.OwnerCountry.FlagID == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.OwnerCountry.FlagID;
			cmd.Parameters[VslGRT].Value      = (vesselInfo.GRT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.GRT;
			cmd.Parameters[VslNRT].Value      = (vesselInfo.NRT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.NRT;
			cmd.Parameters[VslDWT].Value      = (vesselInfo.DWT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.DWT;
			cmd.Parameters[VslPortReg].Value  = (vesselInfo.PortReg == null) ? DBNull.Value : (Object)vesselInfo.PortReg;
			cmd.Parameters[VslRegNo].Value    = (vesselInfo.RegNo == null) ? DBNull.Value : (Object)vesselInfo.RegNo;
			cmd.Parameters[VslFlag].Value     = vesselInfo.Flag.FlagID; 
			cmd.Parameters[VslEtype].Value    = vesselInfo.EngineType.EngineTypeID; 
			cmd.Parameters[VslEno].Value      = (vesselInfo.EngineNo == null) ? DBNull.Value : (Object)vesselInfo.EngineNo; 
			cmd.Parameters[VslEPower].Value   = (vesselInfo.EnginePower == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.EnginePower;
			cmd.Parameters[VslEpUnit].Value   = (vesselInfo.EpUnit == null) ? DBNull.Value : (Object)vesselInfo.EpUnit; 
			cmd.Parameters[VslEAUX].Value     = (vesselInfo.EAUX == null) ? DBNull.Value : (Object)vesselInfo.EAUX; 
			cmd.Parameters[VslPAX].Value      = (vesselInfo.PAX == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.PAX;
			cmd.Parameters[VslCabines].Value  = (vesselInfo.Cabines == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.Cabines; 
			cmd.Parameters[VslYear].Value     = (vesselInfo.Year == null) ? DBNull.Value : (Object)vesselInfo.Year; 
			cmd.Parameters[VslIMNo].Value     = (vesselInfo.IMOno == null) ? DBNull.Value : (Object)vesselInfo.IMOno; 
			cmd.Parameters[VslCallSign].Value = (vesselInfo.CallSign == null) ? DBNull.Value : (Object)vesselInfo.CallSign; 
			cmd.Parameters[VslExNames].Value  = (vesselInfo.ExName == null) ? DBNull.Value : (Object)vesselInfo.ExName; 
			cmd.Parameters[VslBuilder].Value  = (vesselInfo.BuilderName == null) ? DBNull.Value : (Object)vesselInfo.BuilderName; 
			cmd.Parameters[VslNCrew].Value    = (vesselInfo.NumberCrew == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.NumberCrew;  
			cmd.Parameters[VslLength].Value   = (vesselInfo.Length == null) ? DBNull.Value : (Object)vesselInfo.Length; 
			cmd.Parameters[VslBeam].Value     = (vesselInfo.Beam == null) ? DBNull.Value : (Object)vesselInfo.Beam; 
			cmd.Parameters[VslDraft].Value    = (vesselInfo.Draft == null) ? DBNull.Value : (Object)vesselInfo.Draft; 
			cmd.Parameters[VslPhotoUrl].Value = (vesselInfo.PhotoUrl == null) ? DBNull.Value : (Object)vesselInfo.PhotoUrl; 

			vesselID = PersistentBusinessEntity.ID_Empty;
			int rowsAffected = 0;
			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
				vesselID = (int)cmd.Parameters[VslID].Value;
			} catch /*(Exception ex)*/ {
				//throw new Exception(ex.Message); 
				return false;
			} finally {
				if (conn != null) conn.Close();
			}
			return (rowsAffected > 0);
		}


		public bool Update(VesselInfo vesselInfo) {
			SqlCommand cmd = GetUpdateVesselCommand();
			cmd.Parameters[VslID].Value       = vesselInfo.VesselID;
			cmd.Parameters[VslAgent].Value    = vesselInfo.Agent.AgentID;
			cmd.Parameters[VslName].Value     = (vesselInfo.Name == null) ? DBNull.Value : (Object)vesselInfo.Name;
			cmd.Parameters[VslType].Value     = vesselInfo.VesselType.VesselTypeID;
			cmd.Parameters[VslOperator].Value = (vesselInfo.Operator == null) ? DBNull.Value : (Object)vesselInfo.Operator;
			cmd.Parameters[VslOwner].Value    = (vesselInfo.Owner == null) ? DBNull.Value : (Object)vesselInfo.Owner;
			cmd.Parameters[VslOperator_C].Value = (vesselInfo.OperatorCountry.FlagID == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.OperatorCountry.FlagID;
			cmd.Parameters[VslOwner_C].Value    = (vesselInfo.OwnerCountry.FlagID == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.OwnerCountry.FlagID;
			cmd.Parameters[VslGRT].Value      = (vesselInfo.GRT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.GRT;
			cmd.Parameters[VslNRT].Value      = (vesselInfo.NRT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.NRT;
			cmd.Parameters[VslDWT].Value      = (vesselInfo.DWT == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.DWT;
			cmd.Parameters[VslPortReg].Value  = (vesselInfo.PortReg == null) ? DBNull.Value : (Object)vesselInfo.PortReg;
			cmd.Parameters[VslRegNo].Value    = (vesselInfo.RegNo == null) ? DBNull.Value : (Object)vesselInfo.RegNo;
			cmd.Parameters[VslFlag].Value     = vesselInfo.Flag.FlagID; 
			cmd.Parameters[VslEtype].Value    = vesselInfo.EngineType.EngineTypeID; 
			cmd.Parameters[VslEno].Value      = (vesselInfo.EngineNo == null) ? DBNull.Value : (Object)vesselInfo.EngineNo; 
			cmd.Parameters[VslEPower].Value   = (vesselInfo.EnginePower == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.EnginePower;
			cmd.Parameters[VslEpUnit].Value   = (vesselInfo.EpUnit == null) ? DBNull.Value : (Object)vesselInfo.EpUnit; 
			cmd.Parameters[VslEAUX].Value     = (vesselInfo.EAUX == null) ? DBNull.Value : (Object)vesselInfo.EAUX; 
			cmd.Parameters[VslPAX].Value      = (vesselInfo.PAX == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.PAX;
			cmd.Parameters[VslCabines].Value  = (vesselInfo.Cabines == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.Cabines; 
			cmd.Parameters[VslYear].Value     = (vesselInfo.Year == null) ? DBNull.Value : (Object)vesselInfo.Year; 
			cmd.Parameters[VslIMNo].Value     = (vesselInfo.IMOno == null) ? DBNull.Value : (Object)vesselInfo.IMOno; 
			cmd.Parameters[VslCallSign].Value = (vesselInfo.CallSign == null) ? DBNull.Value : (Object)vesselInfo.CallSign; 
			cmd.Parameters[VslExNames].Value  = (vesselInfo.ExName == null) ? DBNull.Value : (Object)vesselInfo.ExName; 
			cmd.Parameters[VslBuilder].Value  = (vesselInfo.BuilderName == null) ? DBNull.Value : (Object)vesselInfo.BuilderName; 
			cmd.Parameters[VslNCrew].Value    = (vesselInfo.NumberCrew == PersistentBusinessEntity.ID_Empty) ? DBNull.Value : (Object)vesselInfo.NumberCrew;  
			cmd.Parameters[VslLength].Value   = (vesselInfo.Length == null) ? DBNull.Value : (Object)vesselInfo.Length; 
			cmd.Parameters[VslBeam].Value     = (vesselInfo.Beam == null) ? DBNull.Value : (Object)vesselInfo.Beam; 
			cmd.Parameters[VslDraft].Value    = (vesselInfo.Draft == null) ? DBNull.Value : (Object)vesselInfo.Draft; 
			cmd.Parameters[VslPhotoUrl].Value = (vesselInfo.PhotoUrl == null) ? DBNull.Value : (Object)vesselInfo.PhotoUrl; 

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


		public int CalculateVessels(FilterExpression filter) {
			SqlCommand cmd = GetCalcVesselsCommand();
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

		// vessel type
		public VesselTypeInfo[] GetVesselTypes() {
			SqlCommand cmd = GetLoadVesselTypesCommand();
			VesselTypeInfo[] vesselTypesList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					VesselTypeInfo vtp = new VesselTypeInfo();
					vtp.VesselTypeID = (Int16)reader["vtpID"];
					if (reader["vtpName"] != DBNull.Value)
						vtp.Name  = (string)reader["vtpName"];
					array.Add(vtp);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				vesselTypesList = new VesselTypeInfo[array.Count];
				array.CopyTo(vesselTypesList);
			}
			return vesselTypesList;
		}
		

		public VesselTypeInfo GetVesselTypeInfo(int vtpID) {
			SqlCommand cmd = GetLoadVesselTypeInfoCommand();
			cmd.Parameters[VtpID].Value = vtpID;
			VesselTypeInfo vtp = null;

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					vtp = new VesselTypeInfo();
					vtp.VesselTypeID = (Int16)reader["vtpID"];
					if (reader["vtpName"] != DBNull.Value)
						vtp.Name  = (string)reader["vtpName"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return vtp;
		}
		

		//engine type
		public EngineTypeInfo[] GetEngineTypes() {
			SqlCommand cmd = GetLoadEngineTypesCommand();
			EngineTypeInfo[] engineTypesList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					EngineTypeInfo etp = new EngineTypeInfo();
					etp.EngineTypeID = (Int16)reader["etpID"];
					if (reader["etpName"] != DBNull.Value)
						etp.Name  = (string)reader["etpName"];
					array.Add(etp);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				engineTypesList = new EngineTypeInfo[array.Count];
				array.CopyTo(engineTypesList);
			}
			return engineTypesList;
		}
		

		public EngineTypeInfo GetEngineTypeInfo(int etpID) {
			SqlCommand cmd = GetLoadEngineTypeInfoCommand();
			cmd.Parameters[EtpID].Value = etpID;
			EngineTypeInfo etp = null;

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					etp = new EngineTypeInfo();
					etp.EngineTypeID = (Int16)reader["etpID"];
					if (reader["etpName"] != DBNull.Value)
						etp.Name  = (string)reader["etpName"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return etp;
		}
		

		//flags
		public FlagInfo[] GetFlags() {
			SqlCommand cmd = GetLoadFlagsCommand();
			FlagInfo[] flagList = null;
			ArrayList array = new ArrayList();

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()) {
					FlagInfo flg = new FlagInfo();
					flg.FlagID = (Int16)reader["flgID"];
					if (reader["flgName"] != DBNull.Value)
						flg.Name  = (string)reader["flgName"];
					array.Add(flg);
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			if (array.Count > 0) {
				flagList = new FlagInfo[array.Count];
				array.CopyTo(flagList);
			}
			return flagList;
		}
		

		public FlagInfo GetFlagInfo(int flgID) {
			SqlCommand cmd = GetLoadFlagInfoCommand();
			cmd.Parameters[FlgID].Value = flgID;
			FlagInfo flg = null;

			SqlConnection conn = null;
			try {
				conn = new SqlConnection(AppConfig.dbConnString);
				cmd.Connection = conn;
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if(reader.Read()) {
					flg = new FlagInfo();
					flg.FlagID = (Int16)reader["flgID"];
					if (reader["flgName"] != DBNull.Value)
						flg.Name  = (string)reader["flgName"];
				}
				reader.Close();
			} catch /*(Exception ex)*/{
				return null;
				//throw new Exception(ex.Message);
			} finally {
				if (conn != null) conn.Close();
			}
			return flg;
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
