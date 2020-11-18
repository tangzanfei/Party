using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DBCommon.Model;
namespace DBCommon.BLL
{
	/// <summary>
	/// UserBLL
	/// </summary>
	public partial class UserBLL
	{
		private readonly DBCommon.DAL.UserDAL dal=new DBCommon.DAL.UserDAL();
		public UserBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OpenID)
		{
			return dal.Exists(OpenID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DBCommon.Model.DBUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string OpenID)
		{
			
			return dal.Delete(OpenID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OpenIDlist )
		{
			return dal.DeleteList(OpenIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DBCommon.Model.DBUser GetModel(string OpenID)
		{
			
			return dal.GetModel(OpenID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DBCommon.Model.DBUser GetModelByCache(string OpenID)
		{
			
			string CacheKey = "DBUserModel-" + OpenID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OpenID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DBCommon.Model.DBUser)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBCommon.Model.DBUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBCommon.Model.DBUser> DataTableToList(DataTable dt)
		{
			List<DBCommon.Model.DBUser> modelList = new List<DBCommon.Model.DBUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DBCommon.Model.DBUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

