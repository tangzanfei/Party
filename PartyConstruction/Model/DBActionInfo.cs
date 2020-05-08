using System;
namespace PartyConstruction.Model
{
	/// <summary>
	/// DBActionInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBActionInfo
	{
		public DBActionInfo()
		{}
		#region Model
		private int _id;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private string _title;
		private string _content;
		private int? _branchid;
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
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BranchID
		{
			set{ _branchid=value;}
			get{return _branchid;}
		}
		#endregion Model

	}
}

