using System;
using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {

	public class ObligationFacade {
		public bool RemoveObligation(int oblID) {
			Obligation obl = new Obligation();
			return obl.RemoveObligation(oblID);
		}



		public ObligationInfo[] GetObligations(FilterExpression filter, OrderExpression order) {
			Obligation obl = new Obligation();
			return obl.GetObligations(filter, order);
		}



		public ObligationInfo[] GetObligations(){
			Obligation obl = new Obligation();
			return obl.GetObligations();
		}


		public ObligationInfo[] GetObligations(int agentID) {
			Obligation obl = new Obligation();
			return obl.GetObligations(agentID);
		}



		public ObligationInfo GetObligationInfo(int oblID) {
			Obligation obl = new Obligation();
			return obl.GetObligationInfo(oblID);
		}


		public bool AddObligationInfo(ObligationInfo oblInfo, out int oblID) {
			Obligation obl = new Obligation();
			return obl.AddObligationInfo(oblInfo, out oblID);
		}

		
		public bool UpdateObligationInfo(ObligationInfo oblInfo) {
			Obligation obl = new Obligation();
			return obl.UpdateObligationInfo(oblInfo);
		}

	
	}
}
