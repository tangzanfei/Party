using System;
namespace DBCommon.Model
{
	/// <summary>
	/// DBPoint:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DBPoint
	{
		public DBPoint()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _qrcode;
		private string _wifimac;
		private string _wifiname;
		private double? _lon;
		private double? _lat;
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
		public string QrCode
		{
			set{ _qrcode=value;}
			get{return _qrcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WifiMac
		{
			set{ _wifimac=value;}
			get{return _wifimac;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WifiName
		{
			set{ _wifiname=value;}
			get{return _wifiname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? Lon
		{
			set{ _lon=value;}
			get{return _lon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? Lat
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		#endregion Model

	}
}

