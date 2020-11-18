using System;
namespace DBCommon.Model
{
	/// <summary>
	/// DBUsuryActionData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBUsuryActionData
	{
		public DBUsuryActionData()
		{}
		#region Model
		private string _id;
		private string _userid;
		private string _pointid;
		private DateTime _checktime;
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
		public string PointID
		{
			set{ _pointid=value;}
			get{return _pointid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		#endregion Model

	}
}

