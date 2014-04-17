using System;
using Volans.Common;
using Volans.DAL;


namespace Volans.BusinessRules {

	public class Vessel {

		private bool FillVesselInfo(ref VesselInfo vsl) {
			/*VesselDAL vDal = new VesselDAL();
			AgentDAL  aDal = new AgentDAL();
			*/
			Agent aRules = new Agent();

			vsl.Agent = aRules.GetInfo(vsl.Agent.AgentID);
			if (vsl.Flag.FlagID != PersistentBusinessEntity.ID_Empty)
				vsl.Flag  = GetFlagInfo(vsl.Flag.FlagID);
			if (vsl.VesselType.VesselTypeID != PersistentBusinessEntity.ID_Empty)
				vsl.VesselType = GetVesselTypeInfo(vsl.VesselType.VesselTypeID);
			if (vsl.EngineType.EngineTypeID != PersistentBusinessEntity.ID_Empty)
				vsl.EngineType = GetEngineTypeInfo(vsl.EngineType.EngineTypeID);
			if (vsl.OperatorCountry.FlagID != PersistentBusinessEntity.ID_Empty)
				vsl.OperatorCountry  = GetFlagInfo(vsl.OperatorCountry.FlagID);
			if (vsl.OwnerCountry.FlagID != PersistentBusinessEntity.ID_Empty)
				vsl.OwnerCountry  = GetFlagInfo(vsl.OwnerCountry.FlagID);


			return true;
		}

	
		public VesselInfo GetInfo(int vesselID) {
			VesselInfo vessel  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				vessel = vDal.GetInfo(vesselID);
				FillVesselInfo(ref vessel);
			}
			return vessel;
		}


		public VesselInfo[] GetVessels(FilterExpression filter, OrderExpression order) {
			VesselInfo[] vessels  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				vessels = vDal.GetVessels(filter, order);
			}
			for (int i=0; i<vessels.Length; i++)
				FillVesselInfo(ref vessels[i]);
			return vessels;
		}


		public VesselInfo[] GetAgentVessels(int agentID) {
			VesselInfo[] vessels = null;
			FilterExpression filter = new FilterExpression(typeof(VesselFields));
			filter.Add(VesselFields.vslAgent,agentID);
			using (VesselDAL vDal = new VesselDAL()) {
				vessels = vDal.GetVessels(filter, null);	
			}
			for (int i=0; i<vessels.Length; i++)
				FillVesselInfo(ref vessels[i]);
			return vessels;
		}


		public bool Add(VesselInfo vesselInfo, out int vesselID) {
			bool res = false;
			using (VesselDAL vDal = new VesselDAL()) {
				res = vDal.Add(vesselInfo, out vesselID);
			}
			return res;
		}


		public bool Update(VesselInfo vesselInfo) {
			bool res = false;
			using (VesselDAL vDal = new VesselDAL()) {
				res = vDal.Update(vesselInfo);
			}
			return res;
		}


		public bool Remove(int vesselID) {
			bool res = false;
			using (VesselDAL vDal = new VesselDAL()) {
				res = vDal.Remove(vesselID);
			}
			return res;
		}
	
		private int CalculateVessels(FilterExpression filter) {
			int itemCount = 0;
			using (VesselDAL vDal = new VesselDAL()) {
				itemCount = vDal.CalculateVessels(filter);
			}
			return itemCount;
		}


		public int GetVesselsCount() {
			return CalculateVessels(null);
		}


		public int GetVesselsCount(int agentID) {
			FilterExpression filter = new FilterExpression(typeof(VesselFields));
			filter.Add(VesselFields.vslAgent,agentID);
			return CalculateVessels(filter);
		}

		
		//Vessel types
		public VesselTypeInfo GetVesselTypeInfo(int vtpID) {
			VesselTypeInfo vtp  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				vtp = vDal.GetVesselTypeInfo(vtpID);
			}
			return vtp;
		}

		public VesselTypeInfo[] GetVesselTypes() {
			VesselTypeInfo[] vtps  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				vtps = vDal.GetVesselTypes();
			}
			return vtps;
		}


		//Engine types
		public EngineTypeInfo GetEngineTypeInfo(int etpID) {
			EngineTypeInfo etp  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				etp = vDal.GetEngineTypeInfo(etpID);
			}
			return etp;
		}

		public EngineTypeInfo[] GetEngineTypes() {
			EngineTypeInfo[] etps  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				etps = vDal.GetEngineTypes();
			}
			return etps;
		}


		//Flags
		public FlagInfo GetFlagInfo(int flgID) {
			FlagInfo flg  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				flg = vDal.GetFlagInfo(flgID);
			}
			return flg;
		}

		public FlagInfo[] GetFlags() {
			FlagInfo[] flgs  = null;
			using (VesselDAL vDal = new VesselDAL()) {
				flgs = vDal.GetFlags();
			}
			return flgs;
		}

	
	
	}
}
