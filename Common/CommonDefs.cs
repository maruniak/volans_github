using System;

namespace Volans.Common {
	public abstract class PersistentBusinessEntity {
		public const int ID_Empty = -1;
		public static DateTime Date_Empty {
			get {return DateTime.MaxValue;}
		}
	} 


	public enum ControlEditMode {
		Add,
		Update
	}

	public enum PageMode {
		Add,
		Update,
		View,
		Delete
	}

	/* Stas change */
	/// <summary>
	/// ////////////////////////
	/// </summary>
	public enum VesselFields {
		NONE = 0,
		vslName,
		vslOperator,
		vslAgent
	
	}

	public enum VesselOrderFields {
		NONE = 0,
		vslName,
		vslType,
		vslFlag,
		vslGRT,
		vslNRT,
		vslDWT,
		vtpName,
		flgName,
		etpName
	}

	public enum AgentOrderFields {
		NONE = 0,
		agnID,
		agnNameCo,
		agnemail,
		agnWWW,
		astName
	}


	////////////////////////
	///alex
	public enum PositionFields {
		NONE = 0,
		posID,
		depID,
		posName
	}


	public enum RequestFields {
		NONE = 0,
		rqsStatus,
		rqsAgent,
		rqsVesselID,
		rqsPortArr,
		rqsDateArr,
		rqsDescr,
		rqsDateDB,
		rqsID,
		rqsCrewQuantity,
		rstID,
		rstName,
		rstCode,
		vslName
	}
	
	public enum RequestPositionFields {
		NONE = 0,
		rqpID,
		rqpRequest,
		rqpPosition,
		rqpQuantity,
		rqpSalary,
		rqpCurrency,
		rqpLengthCo,
		rqpComments,
		posName,
		depName,
		posID
	}
	
	///---

	public enum NRBFields {
		NONE = 0,
		nrbID,
		nrbSurname,		
		nrbSurnameR,	
		nrbName,		
		nrbNameR,		
		nrbDOB,			
		nrbSMB,			
		nrbTPT,			
		nrbUPT,			
		nrbIdencode,	
		nrbAgent,		
		nrbPos,			
		nrbDescription,	
		nrbCat,
		nrbDateDB			
	}


	public enum ObligationFields {
		NONE = 0,
		oblID,
		oblSurname,		
		oblSurnameR,	
		oblName,		
		oblNameR,		
		oblDOB,			
		oblSMB,			
		oblTPT,			
		oblUPT,			
		oblIdencode,	
		oblAgent,		
		oblPos,			
		oblDescription,	
		oblDate			
	}

	
	public enum RequestListItemFields {
		NONE = 0,
		rqsStatus,
		rqsVesselID, 
		rqsAgent,
		agnNameCo,
		/*departmentID,  */
		depID,
		rqpID,
		posID,
		vslName,
		vslEtype,
		vslType,
		rstName,
		rstCode,
		/*depName,*/
		posName,
		vtpName,
		flgName,
		etpName
	}


	public enum ExchangeLinksFields {
		NONE = 0,
		lnkID,
		lnkName,
		lnkURL,
		lnkDescription,
		lnkImage,
		lnkType
	}

	
	public enum GuestBookFields {
		NONE = 0,
		gbkID,
		gbkUserName,
		gbkEMail,
		gbkText,
		gbkDateDB
	}


	public enum ExchangeLinkType {
		MarineOrganizations = 0,
		Kindred,
		ExchangeAgents
	}

}
