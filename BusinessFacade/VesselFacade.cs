using System;
using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {

	public class VesselFacade {

		public VesselInfo GetInfo(int vesselID) {
			Vessel vsl = new Vessel();
			return vsl.GetInfo(vesselID);
		}


		public VesselInfo[] GetVessels(FilterExpression filter, OrderExpression order) {
			Vessel vsl = new Vessel();
			return vsl.GetVessels(filter, order);
		}


		public VesselInfo[] GetAgentVessels(int agentID) {
			Vessel vsl = new Vessel();
			return vsl.GetAgentVessels(agentID);
		}


		public VesselInfo[] GetVessels() {
			Vessel vsl = new Vessel();
			return vsl.GetVessels(null, null);
		}


		public bool Add(VesselInfo vesselInfo, out int vesselID) {
			Vessel vsl = new Vessel();
			return vsl.Add(vesselInfo, out vesselID);
		}


		public bool Update(VesselInfo vesselInfo) {
			Vessel vsl = new Vessel();
			return vsl.Update(vesselInfo);
		}


		public bool Remove(int vesselID) {
			Vessel vsl = new Vessel();
			return vsl.Remove(vesselID);
		}
	

		public int GetVesselsCount() {
			Vessel vsl = new Vessel();
			return vsl.GetVesselsCount();
		}

		public int GetVesselsCount(int agentID) {
			Vessel vsl = new Vessel();
			return vsl.GetVesselsCount(agentID);
		}

		
		//Vessel types
		public VesselTypeInfo GetVesselTypeInfo(int vtpID) {
			Vessel vsl = new Vessel();
			return vsl.GetVesselTypeInfo(vtpID);
		}

		public VesselTypeInfo[] GetVesselTypes() {
			Vessel vsl = new Vessel();
			return vsl.GetVesselTypes();
		}


		//Engine types
		public EngineTypeInfo GetEngineTypeInfo(int etpID) {
			Vessel vsl = new Vessel();
			return vsl.GetEngineTypeInfo(etpID);
		}

		public EngineTypeInfo[] GetEngineTypes() {
			Vessel vsl = new Vessel();
			return vsl.GetEngineTypes();
		}


		//Flags
		public FlagInfo GetFlagInfo(int flgID) {
			Vessel vsl = new Vessel();
			return vsl.GetFlagInfo(flgID);
		}

		public FlagInfo[] GetFlags() {
			Vessel vsl = new Vessel();
			return vsl.GetFlags();
		}

	

	}
}
