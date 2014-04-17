using System;
using Volans.Common;
using Volans.BusinessRules;


namespace Volans.BusinessFacade {

	
	public class AgentFacade {
		
		#region agents

		public AgentInfo GetInfo(int agentID) {
			Agent agent = new Agent();
			return agent.GetInfo(agentID);
		}


		public AgentInfo[] GetAgents(FilterExpression filter, OrderExpression order) {
			Agent agent = new Agent();
			return agent.GetAgents(filter, order);
		}


		public AgentInfo[] GetAgents() {
			Agent agent = new Agent();
			return agent.GetAgents(null, null);
		}


		public bool Add(AgentInfo agentInfo) {
			Agent agent = new Agent();
			return agent.Add(agentInfo);
		}


		public bool Update(AgentInfo agentInfo) {
			Agent agent = new Agent();
			return agent.Update(agentInfo);
		}


		public bool Remove(int agentID) {
			Agent agent = new Agent();
			return agent.Remove(agentID);
		}
	

		public bool CheckLogin(string login, string passwd) {
			Agent agent = new Agent();
			return agent.CheckLogin(login, passwd);
		}

		public AgentInfo GetInfoByLogin(string login) {
			Agent agent = new Agent();
			return agent.GetInfoByLogin(login);
		}


		public bool ChangePassword(int agentID, string password) {
			Agent agent = new Agent();
			return agent.ChangePassword(agentID, password);
		}

		public int GetAgentsCount() {
			Agent agent = new Agent();
			return agent.GetAgentsCount();
		}

		#endregion


		#region phones

		public AgentPhone[] GetPhones(int agentID) {
			Agent agent = new Agent();
			return agent.GetPhones(agentID);
		}


		public AgentPhone GetPhoneInfo(int phoneID) {
			Agent agent = new Agent();
			return agent.GetPhoneInfo(phoneID);
		}


		public bool RemovePhone(int phoneID) {
			Agent agent = new Agent();
			return agent.RemovePhone(phoneID);
		}


		public bool UpdatePhone(AgentPhone phone) {
			Agent agent = new Agent();
			return agent.UpdatePhone(phone);
		}


		public bool AddPhone(AgentPhone phone, out int phoneID) {
			Agent agent = new Agent();
			return agent.AddPhone(phone, out phoneID);
		}

		#endregion

	
		#region statuses

		public AgentStatus[] GetStatuses() {
			Agent agent = new Agent();
			return agent.GetStatuses();
		}


		public AgentStatus GetStatusInfo(int statusID) {
			Agent agent = new Agent();
			return agent.GetStatusInfo(statusID);
		}


		#endregion
	
	}
}
