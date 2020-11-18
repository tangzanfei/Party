using System;
namespace DBCommon.Model
{
	/// <summary>
	/// DBBonus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBBonus
	{
		public DBBonus()
		{}
		#region Model
		private string _id;
		private string _userid;
		private string _content;
		private DateTime _summittime;
		private int? _score;
		private int? _confirmstate=0;
		private DateTime? _confirmtime;
		private string _confirmmanagerid;
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
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public DateTime SummitTime
		{
			set{ _summittime=value;}
			get{return _summittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ConfirmState
		{
			set{ _confirmstate=value;}
			get{return _confirmstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ConfirmTime
		{
			set{ _confirmtime=value;}
			get{return _confirmtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConfirmManagerID
		{
			set{ _confirmmanagerid=value;}
			get{return _confirmmanagerid;}
		}
		#endregion Model

	}
}

