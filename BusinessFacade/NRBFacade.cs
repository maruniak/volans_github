using System;
using Volans.Common;
using Volans.BusinessRules;

namespace Volans.BusinessFacade {

	public class NRBFacade {

		#region category

		public CategoryInfo[] GetCategories() {
			NRB nrb = new NRB();
			return nrb.GetCategories();
		}


		public CategoryInfo GetCategoryInfo(int categoryID) {
			NRB nrb = new NRB();
			return nrb.GetCategoryInfo(categoryID);
		}


		#endregion

		#region NRB

		public bool RemoveNRB(int nrbID) {
			NRB nrb = new NRB();
			return nrb.RemoveNRB(nrbID);
		}


		public NRBInfo[] GetNRBList(FilterExpression filter, OrderExpression order) {
			NRB nrb = new NRB();
			return nrb.GetNRBList(filter, order);
		}


		public NRBInfo[] GetNRBList(int agentID) {
			NRB nrb = new NRB();
			return nrb.GetNRBList(agentID);
		}


		public NRBInfo[] GetNRBList() {
			NRB nrb = new NRB();
			return nrb.GetNRBList();
		}


		public NRBInfo GetNRBInfo(int nrbID) {
			NRB nrb = new NRB();
			return nrb.GetNRBInfo(nrbID);
		}


		public bool AddNRBInfo(NRBInfo nrbInfo, out int nrbID) {
			NRB nrb = new NRB();
			return nrb.AddNRBInfo(nrbInfo, out nrbID);
		}

		
		public bool UpdateNRBInfo(NRBInfo nrbInfo) {
			NRB nrb = new NRB();
			return nrb.UpdateNRBInfo(nrbInfo);
		}

		
		#endregion
	}
}
