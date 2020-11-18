using System;
namespace DBCommon.Model
{
	/// <summary>
	/// DBBranch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBBranch
	{
		public DBBranch()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _parentbranchid;
		private string _masterid;
		/// <summary>
		/// 
		/// </summary>
		public string ID
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
		public string ParentBranchID
		{
			set{ _parentbranchid=value;}
			get{return _parentbranchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MasterID
		{
			set{ _masterid=value;}
			get{return _masterid;}
		}
		#endregion Model

	}
}

