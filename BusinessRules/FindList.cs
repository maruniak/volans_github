using System;

using Volans.Common;
using Volans.DAL;


namespace Volans.BusinessRules {
	public class FindList {

		private bool FillRequestListItem(ref RequestListItem item) {
			Agent aRules = new Agent();
			Vessel vRules = new Vessel();
			Request rRules = new Request();
			

			if(item.Agent.AgentID != PersistentBusinessEntity.ID_Empty)
				item.Agent = aRules.GetInfo(item.Agent.AgentID);
			if(item.RequestPosition.RequestPositionID != PersistentBusinessEntity.ID_Empty)
				item.RequestPosition = rRules.GetRequestPositionInfo(item.RequestPosition.RequestPositionID);
			if(item.RequestStatus.RequestStatusID != PersistentBusinessEntity.ID_Empty)
				item.RequestStatus = rRules.GetStatusInfo(item.RequestStatus.RequestStatusID);
			if(item.Vessel.VesselID != PersistentBusinessEntity.ID_Empty)
				item.Vessel = vRules.GetInfo(item.Vessel.VesselID);
			
			return true;
		}

	
		public RequestListItem[] GetRequestList(FilterExpression filter, OrderExpression order) {
			RequestListItem[] list  = null;
			using (FindListsDAL fDal = new FindListsDAL()) {
				list = fDal.GetRequestList(filter, order);
			}
			if (list != null)
				for (int i=0; i<list.Length; i++)
					FillRequestListItem(ref list[i]);
			
			return list;
		}


	
	
	
	}
}
