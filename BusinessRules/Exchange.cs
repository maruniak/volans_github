using System;

using Volans.Common;
using Volans.DAL;


namespace Volans.BusinessRules {

	public class Exchange {

		public GuestBookMessage[] GetGuestBook(FilterExpression filter, OrderExpression order) {
			GuestBookMessage[] msg  = null;
			using (ExchangeDAL xDal = new ExchangeDAL()) {
				msg = xDal.GetGuestBook(filter, order);
			}
			return msg;
		}


		public GuestBookMessage[] GetGuestBook() {
			return GetGuestBook(null, null);
		}


		public bool AddGuestBookMessage(GuestBookMessage message, out int msgID) {
			bool res = false;
			using (ExchangeDAL xDal = new ExchangeDAL()) {
				res = xDal.AddGuestBookMessage(message, out msgID);
			}
			return res;
		}

	
		public ExchangeLink[] GetLinks(FilterExpression filter, OrderExpression order) {
			ExchangeLink[] links  = null;
			using (ExchangeDAL xDal = new ExchangeDAL()) {
				links = xDal.GetLinks(filter, order);
			}
			return links;
		}

		public ExchangeLink[] GetMarineOrganizationsLinks(FilterExpression filter, OrderExpression order) {
			if (filter == null)
				filter = new FilterExpression(typeof(ExchangeLinksFields));
			filter.Add(ExchangeLinksFields.lnkType, (int)ExchangeLinkType.MarineOrganizations);
			return GetLinks(filter, order);
		}

		public ExchangeLink[] GetKindredSitesLinks(FilterExpression filter, OrderExpression order) {
			if (filter == null)
				filter = new FilterExpression(typeof(ExchangeLinksFields));
			filter.Add(ExchangeLinksFields.lnkType, (int)ExchangeLinkType.Kindred);
			return GetLinks(filter, order);
		}


		public ExchangeLink[] GetExchangeAgentsLinks(FilterExpression filter, OrderExpression order) {
			if (filter == null)
				filter = new FilterExpression(typeof(ExchangeLinksFields));
			filter.Add(ExchangeLinksFields.lnkType, (int)ExchangeLinkType.ExchangeAgents);
			return GetLinks(filter, order);
		}

	}
}
