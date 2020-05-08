using System;
namespace PartyConstruction.Model
{
	/// <summary>
	/// DBBranchInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBBranchInfo
	{
		public DBBranchInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentbranchid;
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
		public int? ParentBranchID
		{
			set{ _parentbranchid=value;}
			get{return _parentbranchid;}
		}
		#endregion Model

	}
}

