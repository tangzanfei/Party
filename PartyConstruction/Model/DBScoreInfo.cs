using System;
namespace PartyConstruction.Model
{
	/// <summary>
	/// DBScoreInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBScoreInfo
	{
		public DBScoreInfo()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private DateTime? _datetime;
		private int? _scorediff;
		private string _note;
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
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ScoreDiff
		{
			set{ _scorediff=value;}
			get{return _scorediff;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

