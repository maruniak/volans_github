using System;

using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {

	public class ExchangeFacade {

		public GuestBookMessage[] GetGuestBook(FilterExpression filter, OrderExpression order) {
			Exchange rules = new Exchange();
			return rules.GetGuestBook(filter, order);
		}


		public GuestBookMessage[] GetGuestBook() {
			Exchange rules = new Exchange();
			return rules.GetGuestBook();
		}


		public bool AddGuestBookMessage(GuestBookMessage message, out int msgID) {
			Exchange rules = new Exchange();
			return rules.AddGuestBookMessage(message, out msgID);
		}



		public ExchangeLink[] GetMarineOrganizationsLinks(FilterExpression filter, OrderExpression order) {
			Exchange rules = new Exchange();
			return rules.GetMarineOrganizationsLinks(filter, order);
		}

		public ExchangeLink[] GetKindredSitesLinks(FilterExpression filter, OrderExpression order) {
			Exchange rules = new Exchange();
			return rules.GetKindredSitesLinks(filter, order);
		}


		public ExchangeLink[] GetExchangeAgentsLinks(FilterExpression filter, OrderExpression order) {
			Exchange rules = new Exchange();
			return rules.GetExchangeAgentsLinks(filter, order);
		}
	
	}
}
