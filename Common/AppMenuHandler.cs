using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;

namespace Volans.Common {
	
	public class MenuItem {
		public String Text;
		public int position;
		public String Id;
		public String Link;
		public ArrayList submenu;
	}

	
	/// <summary>
	/// AppMenu section handler.
	/// </summary>
	public class AppMenuHandler : IConfigurationSectionHandler	{

		public AppMenuHandler() {}

		private static ArrayList _items;

		/// <summary>
		/// <code>IConfigurationSectionHandler</code> interface <code>Create</code> method implementation.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		public object Create ( object parent, object configContext, XmlNode section ) {
			
			if (!section.HasChildNodes) {
				throw new ConfigurationException("Wrong application configuration. Section has no child nodes");
			}

			if (!section.FirstChild.Name.Equals("items")) {
				throw new ConfigurationException("Wrong application configuration.");
			}
			_items = processMenuItems(section.FirstChild);
			return _items;

		}

		private ArrayList processMenuItems(XmlNode ItemsSection) {
			
			ArrayList items = new ArrayList();

			#region cycle
			foreach ( XmlNode itemNode in ItemsSection.ChildNodes) {
				MenuItem item = new MenuItem();
				if (itemNode.Name.Equals("item")) {

					item.Text = itemNode.Attributes["name"].Value;
					if (itemNode.Equals("")) {
						throw new ConfigurationException("itemNode name can't be empty");
					}
					try {
						if (itemNode.Attributes["position"]!=null) {
							item.position = int.Parse(itemNode.Attributes["position"].Value);
						} else { item.position = 0; }
					} catch (Exception ex) {
						throw new ConfigurationException("Wrong value of 'position' attribute",ex);
					}
					
					if (itemNode.Attributes["id"]!=null){
						item.Id = itemNode.Attributes["id"].Value;
					} else { item.Id = null; }
					
					if (itemNode.Attributes["href"]!=null) {
						item.Link = itemNode.Attributes["href"].Value;
					} else { item.Link = null; }
					
					if (itemNode.FirstChild!=null) {
						if (!itemNode.FirstChild.Name.Equals("items")) {
							throw new ConfigurationException("invalid configuration");
						}
						if (!itemNode.FirstChild.HasChildNodes) {
							throw new ConfigurationException("invalid configuration");
						}

						item.submenu = processMenuItems(itemNode.FirstChild);
						if (item.submenu.Count == 0) { item.submenu = null; }
					} else { item.submenu = null; }
					items.Add(item);
				}
			
			}
			#endregion
			if (items.Count==0) { 
				return null; 
			} else { return items; }
		}

		public static void OnApplicationStart() {
			System.Configuration.ConfigurationSettings.GetConfig("AppMenu");
		}

		public static ArrayList Items {
			get {
				return _items;
			}
		}

	}
}
