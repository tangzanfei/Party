/**  版本信息模板在安装目录下，可自行修改。
* DBUser.cs
*
* 功 能： N/A
* 类 名： DBUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/5/8 星期五 下午 5:08:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace PartyConstruction.Model
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
		private string _id;
		private string _name;
		private bool _isbranchmaster= false;
		private bool _ismanager= false;
		private string _branchid;
		private string _account;
		private string _password;
		private string _servicingbranchid;
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
		public string BranchID
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
		public string ServicingBranchID
		{
			set{ _servicingbranchid=value;}
			get{return _servicingbranchid;}
		}
		#endregion Model

	}
}

