using System;

using Volans.Common;
using Volans.DAL;


namespace Volans.BusinessRules {

	public class Obligation {


		public bool RemoveObligation(int oblID) {
			bool res = false;
			using (ObligationDAL oDal = new ObligationDAL()) {
				res = oDal.RemoveObligation(oblID);
			}
			return res;
		}



		private bool FillObligationInfo(ref ObligationInfo obl) {
			/*AgentDAL aDal = new AgentDAL();
			RequestDAL rDal = new RequestDAL();
			*/
			Agent aRules = new Agent();
			Request rRules = new Request();

			if(obl.Position.PositionID != PersistentBusinessEntity.ID_Empty)
				obl.Position = rRules.GetPositionInfo(obl.Position.PositionID);
			obl.Agent = aRules.GetInfo(obl.Agent.AgentID);
			return true;
		}


		
		public ObligationInfo[] GetObligations(FilterExpression filter, OrderExpression order) {
			ObligationInfo[] oblList  = null;
			using (ObligationDAL oDal = new ObligationDAL()) {
				oblList = oDal.GetObligations(filter, order);
			}
			if (oblList != null)
				for (int i=0; i<oblList.Length; i++)
					FillObligationInfo(ref oblList[i]);
			return oblList;
		}



		public ObligationInfo[] GetObligations(){
			return GetObligations(null, null);
			
		}


		public ObligationInfo[] GetObligations(int agentID) {
			FilterExpression filter = new FilterExpression(typeof(ObligationFields));
			filter.Add(ObligationFields.oblAgent, agentID);
			return GetObligations(filter, null);
		}



		public ObligationInfo GetObligationInfo(int oblID) {
			ObligationInfo obl  = null;
			using (ObligationDAL oDal = new ObligationDAL()) {
				obl = oDal.GetObligationInfo(oblID);
			}
			if (obl != null)
				FillObligationInfo(ref obl);
			return obl;
		}


		public bool AddObligationInfo(ObligationInfo oblInfo, out int oblID) {
			bool res = false;
			using (ObligationDAL oDal = new ObligationDAL()) {
				res = oDal.AddObligationInfo(oblInfo, out oblID);
			}
			return res;
		}

		
		public bool UpdateObligationInfo(ObligationInfo oblInfo) {
			bool res = false;
			using (ObligationDAL oDal = new ObligationDAL()) {
				res = oDal.UpdateObligationInfo(oblInfo);
			}
			return res;
		}

		
	}
}
