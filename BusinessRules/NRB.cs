using System;
using Volans.Common;
using Volans.DAL;

namespace Volans.BusinessRules {
	
	public class NRB {

		#region category

		public CategoryInfo[] GetCategories() {
			CategoryInfo[] cats  = null;
			using (NRBDAL nDal = new NRBDAL()) {
				cats = nDal.GetCategories();
			}
			return cats;
		}


		public CategoryInfo GetCategoryInfo(int categoryID) {
			CategoryInfo cat  = null;
			using (NRBDAL nDal = new NRBDAL()) {
				cat = nDal.GetCategoryInfo(categoryID);
			}
			return cat;
		}


		#endregion

		#region NRB

		public bool RemoveNRB(int nrbID) {
			bool res = false;
			using (NRBDAL nDal = new NRBDAL()) {
				res = nDal.RemoveNRB(nrbID);
			}
			return res;
		}


		private bool FillNRBInfo(ref NRBInfo nrb) {
			/*AgentDAL aDal = new AgentDAL();
			RequestDAL rDal = new RequestDAL();
			*/
			Agent aRules = new Agent();
			Request rRules = new Request();

			if(nrb.Category.CategoryID != PersistentBusinessEntity.ID_Empty)
				nrb.Category = GetCategoryInfo(nrb.Category.CategoryID);
			if(nrb.Position.PositionID != PersistentBusinessEntity.ID_Empty)
				nrb.Position = rRules.GetPositionInfo(nrb.Position.PositionID);
			nrb.Agent = aRules.GetInfo(nrb.Agent.AgentID);
			return true;
		}


		public NRBInfo[] GetNRBList(FilterExpression filter, OrderExpression order) {
			NRBInfo[] nrbList  = null;
			using (NRBDAL nDal = new NRBDAL()) {
				nrbList = nDal.GetNRBList(filter, order);
			}
			if (nrbList != null)
				for (int i=0; i<nrbList.Length; i++)
					FillNRBInfo(ref nrbList[i]);
			return nrbList;
		}


		public NRBInfo[] GetNRBList(int agentID) {
			FilterExpression filter = new FilterExpression(typeof(NRBFields));
			filter.Add(NRBFields.nrbAgent, agentID);
			return GetNRBList(filter, null);
		}


		public NRBInfo[] GetNRBList() {
			return GetNRBList(null, null);
		}


		public NRBInfo GetNRBInfo(int nrbID) {
			NRBInfo nrb  = null;
			using (NRBDAL nDal = new NRBDAL()) {
				nrb = nDal.GetNRBInfo(nrbID);
			}
			if (nrb != null)
				FillNRBInfo(ref nrb);
			return nrb;
		}


		public bool AddNRBInfo(NRBInfo nrbInfo, out int nrbID) {
			bool res = false;
			using (NRBDAL nDal = new NRBDAL()) {
				res = nDal.AddNRBInfo(nrbInfo, out nrbID);
			}
			return res;
		}

		
		public bool UpdateNRBInfo(NRBInfo nrbInfo) {
			bool res = false;
			using (NRBDAL nDal = new NRBDAL()) {
				res = nDal.UpdateNRBInfo(nrbInfo);
			}
			return res;
		}

		
		#endregion
	}
}
