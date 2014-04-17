using System;

using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {
	public class FindListFacade	{

		public RequestListItem[] GetRequestList(FilterExpression filter, OrderExpression order) {
			FindList rules = new FindList();
			return rules.GetRequestList(filter, order);
		}

	
	
	}
}
