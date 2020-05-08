using System;
namespace PartyConstruction.Model
{
	/// <summary>
	/// DBUserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBUserInfo
	{
		public DBUserInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private bool _isbranchmaster= false;
		private bool _ismanager= false;
		private int? _branchid;
		private string _account;
		private string _password;
		private int? _servicingbranchid;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsBranchMaster
		{
			set{ _isbranchmaster=value;}
			get{return _isbranchmaster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsManager
		{
			set{ _ismanager=value;}
			get{return _ismanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BranchID
		{
			set{ _branchid=value;}
			get{return _branchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ServicingBranchID
		{
			set{ _servicingbranchid=value;}
			get{return _servicingbranchid;}
		}
		#endregion Model

	}
}

