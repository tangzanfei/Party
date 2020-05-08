using System;
namespace PartyConstruction.Model
{
	/// <summary>
	/// DBUserActionData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBUserActionData
	{
		public DBUserActionData()
		{}
		#region Model
		private int _id;
		private int? _actionid;
		private int? _userid;
		private bool _managerconfirmed= false;
		private int? _managerid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ActionID
		{
			set{ _actionid=value;}
			get{return _actionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ManagerConfirmed
		{
			set{ _managerconfirmed=value;}
			get{return _managerconfirmed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ManagerID
		{
			set{ _managerid=value;}
			get{return _managerid;}
		}
		#endregion Model

	}
}

