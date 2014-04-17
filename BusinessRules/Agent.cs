using System;
using Volans.Common;
using Volans.DAL;

namespace Volans.BusinessRules {

	public class Agent {

		#region agents

		private bool FillAgentInfo(ref AgentInfo agn) {
			/*AgentDAL  aDal = new AgentDAL();*/
			agn.Phones = GetPhones(agn.AgentID);
			agn.Status = GetStatusInfo(agn.Status.StatusID);
			return true;
		}

	
		public AgentInfo GetInfo(int agentID) {
			AgentInfo agent  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				agent = aDal.GetInfo(agentID);
			}
			FillAgentInfo(ref agent);
			return agent;
		}


		public AgentInfo[] GetAgents(FilterExpression filter, OrderExpression order) {
			AgentInfo[] agents  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				agents = aDal.GetAgents(filter, order);
			}
			for (int i=0; i<agents.Length; i++)
				FillAgentInfo(ref agents[i]);
			return agents;
		}


		public bool Add(AgentInfo agentInfo) {
			throw new NotImplementedException("Метод не реализован");
		}


		public bool Update(AgentInfo agentInfo) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.Update(agentInfo);
			}
			return res;
		}


		public bool Remove(int agentID) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.Remove(agentID);
			}
			return res;
		}
	
	
		public bool CheckLogin(string login, string passwd) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.CheckLogin(login, passwd);
			}
			return res;
		}

		public AgentInfo GetInfoByLogin(string login) {
			AgentInfo agent  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				agent = aDal.GetInfoByLogin(login);
				if(agent != null)
					agent.Status = aDal.GetStatusInfo(agent.Status.StatusID);
			}
			//FillAgentInfo(ref agent);
			return agent;
		}


		public bool ChangePassword(int agentID, string password) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.ChangePassword(agentID, password);
			}
			return res;
		}


		private int CalculateAgents(FilterExpression filter) {
			int itemCount = 0;
			using (AgentDAL aDal = new AgentDAL()) {
				itemCount = aDal.CalculatAgents(filter);
			}
			return itemCount;
		}


		public int GetAgentsCount() {
			return CalculateAgents(null);
		}

		#endregion


		#region phones

		public AgentPhone[] GetPhones(int agentID) {
			AgentPhone[] phones  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				phones = aDal.GetPhones(agentID);
			}
			return phones;
		}


		public AgentPhone GetPhoneInfo(int phoneID) {
			AgentPhone phone  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				phone = aDal.GetPhoneInfo(phoneID);
			}
			return phone;
		}


		public bool RemovePhone(int phoneID) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.RemovePhone(phoneID);
			}
			return res;
		}


		public bool UpdatePhone(AgentPhone phone) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.UpdatePhone(phone);
			}
			return res;
		}


		public bool AddPhone(AgentPhone phone, out int phoneID) {
			bool res = false;
			using (AgentDAL aDal = new AgentDAL()) {
				res = aDal.AddPhone(phone, out phoneID);
			}
			return res;
		}


		#endregion
	
	
		#region statuses

		public AgentStatus[] GetStatuses() {
			AgentStatus[] statuses  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				statuses = aDal.GetStatuses();
			}
			return statuses;
		}


		public AgentStatus GetStatusInfo(int statusID) {
			AgentStatus status  = null;
			using (AgentDAL aDal = new AgentDAL()) {
				status = aDal.GetStatusInfo(statusID);
			}
			return status;
		}


		#endregion
	}
}
