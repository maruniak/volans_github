using System;

namespace Volans.Common {

	public class VesselTypeInfo {
		#region private
		private Int16 _typeID;
		private string _name;
		#endregion

		#region properties
		public Int16 VesselTypeID {
			get { return _typeID; }
			set { _typeID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public VesselTypeInfo() {
			VesselTypeID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}



	public class FlagInfo {
		#region private
		private Int16 _flagID;
		private string _name;
		#endregion

		#region properties
		public Int16 FlagID {
			get { return _flagID; }
			set { _flagID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public FlagInfo() {
			FlagID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}



	public class EngineTypeInfo {
		#region private
		private Int16 _typeID;
		private string _name;
		#endregion

		#region properties
		public Int16 EngineTypeID {
			get { return _typeID; }
			set { _typeID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region constructors
		public EngineTypeInfo() {
			EngineTypeID = PersistentBusinessEntity.ID_Empty;
		}
		#endregion
	}




	public class VesselInfo {
		#region private
		private AgentInfo _agent;
		private int _vesselID;
		private string _name;
		private VesselTypeInfo _type;
		private string _operator;
		private string _owner;
		private int _GRT;
		private int _NRT;
		private int _DWT;
		private string _portReg;
		private string _regNo;
		private FlagInfo _flag;
		private EngineTypeInfo _engineType;
		private string _engineNo;
		private int _enginePower;
		private string _EpUnit;
		private string _EAUX;
		private Int16 _PAX;
		private Int16 _cabines;
		private string _year;
		private string _IMOno;
		private string _callSign;
		private string _exName;
		private string _builderName;
		private Int16 _numberCrew;
		private string _length;
		private string _beam;
		private string _draft;
		private string _PhotoUrl;
		private FlagInfo _operatorC;
		private FlagInfo _ownerC;
		#endregion


		#region properties
		public AgentInfo Agent {
			get { return _agent; }
			set { _agent = value; }
		}

		public int VesselID {
			get { return _vesselID; }
			set { _vesselID = value; }
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public VesselTypeInfo VesselType {
			get { return _type; }
			set { _type = value; }
		}

		public string Operator {
			get { return _operator; }
			set { _operator = value; }
		}

		public string Owner {
			get { return _owner; }
			set { _owner = value; }
		}

		public int GRT {
			get { return _GRT; }
			set { _GRT = value; }
		}

		public int NRT {
			get { return _NRT; }
			set { _NRT = value; }
		}

		public int DWT {
			get { return _DWT; }
			set { _DWT = value; }
		}

		public string PortReg {
			get { return _portReg; }
			set { _portReg = value; }
		}

		public string RegNo {
			get { return _regNo; }
			set { _regNo = value; }
		}

		public FlagInfo Flag {
			get { return _flag; }
			set { _flag = value; }
		}

		public EngineTypeInfo EngineType {
			get { return _engineType; }
			set { _engineType = value; }
		}

		public string EngineNo {
			get { return _engineNo; }
			set { _engineNo = value; }
		}

		public int EnginePower {
			get { return _enginePower; }
			set { _enginePower = value; }
		}

		public string EpUnit {
			get { return _EpUnit; }
			set { _EpUnit = value; }
		}

		public string EAUX {
			get { return _EAUX; }
			set { _EAUX = value; }
		}

		public Int16 PAX {
			get { return _PAX; }
			set { _PAX = value; }
		}

		public Int16 Cabines {
			get { return _cabines; }
			set { _cabines = value; }
		}

		public string Year {
			get { return _year; }
			set { _year = value; }
		}

		public string IMOno {
			get { return _IMOno; }
			set { _IMOno = value; }
		}

		public string CallSign {
			get { return _callSign; }
			set { _callSign = value; }
		}

		public string ExName {
			get { return _exName; }
			set { _exName = value; }
		}

		public string BuilderName {
			get { return _builderName; }
			set { _builderName = value; }
		}

		public Int16 NumberCrew {
			get { return _numberCrew; }
			set { _numberCrew = value; }
		}

		public string Length {
			get { return _length; }
			set { _length = value; }
		}

		public string Beam {
			get { return _beam; }
			set { _beam = value; }
		}

		public string Draft {
			get { return _draft; }
			set { _draft = value; }
		}

		public string PhotoUrl {
			get { return _PhotoUrl; }
			set { _PhotoUrl = value; }
		}

		public FlagInfo OperatorCountry {
			get { return _operatorC; }
			set { _operatorC = value; }
		}

		public FlagInfo OwnerCountry {
			get { return _ownerC; }
			set { _ownerC = value; }
		}

		#endregion


		#region constructors
		public VesselInfo() {
			VesselID = PersistentBusinessEntity.ID_Empty;
			Agent = new AgentInfo();
			VesselType = new VesselTypeInfo();
			Flag = new FlagInfo();
			//
			EngineType = new EngineTypeInfo();
			//NULL
			GRT = PersistentBusinessEntity.ID_Empty;
			NRT = PersistentBusinessEntity.ID_Empty;
			DWT = PersistentBusinessEntity.ID_Empty;
			EnginePower = PersistentBusinessEntity.ID_Empty;
			PAX = PersistentBusinessEntity.ID_Empty;
			Cabines = PersistentBusinessEntity.ID_Empty;
			OperatorCountry = new FlagInfo();
			OwnerCountry = new FlagInfo();
		}
		#endregion
	}
}
