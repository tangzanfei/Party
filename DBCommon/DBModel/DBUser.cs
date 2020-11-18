using System;
namespace DBCommon.Model
{
	/// <summary>
	/// DBUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBUser
	{
		public DBUser()
		{}
		#region Model
		private string _openid;
		private string _nickname;
		private string _name;
		private bool _ismanager= false;
		private string _branchid;
		private string _servicingbranchid;
		private string _session;
		private DateTime? _lastlogintime;
		/// <summary>
		/// 
		/// </summary>
		public string OpenID
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
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
		public bool IsManager
		{
			set{ _ismanager=value;}
			get{return _ismanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BranchID
		{
			set{ _branchid=value;}
			get{return _branchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServicingBranchID
		{
			set{ _servicingbranchid=value;}
			get{return _servicingbranchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Session
		{
			set{ _session=value;}
			get{return _session;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		#endregion Model

	}
}

