using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace DBCommon.DAL
{
	/// <summary>
	/// 数据访问类:PointDAL
	/// </summary>
	public partial class PointDAL
	{
		public PointDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PointInfo");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBPoint model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PointInfo(");
			strSql.Append("ID,Name,QrCode,WifiMac,WifiName,Lon,Lat)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Name,@QrCode,@WifiMac,@WifiName,@Lon,@Lat)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647),
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@QrCode", DbType.String,2147483647),
					new SQLiteParameter("@WifiMac", DbType.String,2147483647),
					new SQLiteParameter("@WifiName", DbType.String,2147483647),
					new SQLiteParameter("@Lon", DbType.Double,8),
					new SQLiteParameter("@Lat", DbType.Double,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.QrCode;
			parameters[3].Value = model.WifiMac;
			parameters[4].Value = model.WifiName;
			parameters[5].Value = model.Lon;
			parameters[6].Value = model.Lat;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DBCommon.Model.DBPoint model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PointInfo set ");
			strSql.Append("Name=@Name,");
			strSql.Append("QrCode=@QrCode,");
			strSql.Append("WifiMac=@WifiMac,");
			strSql.Append("WifiName=@WifiName,");
			strSql.Append("Lon=@Lon,");
			strSql.Append("Lat=@Lat");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@QrCode", DbType.String,2147483647),
					new SQLiteParameter("@WifiMac", DbType.String,2147483647),
					new SQLiteParameter("@WifiName", DbType.String,2147483647),
					new SQLiteParameter("@Lon", DbType.Double,8),
					new SQLiteParameter("@Lat", DbType.Double,8),
					new SQLiteParameter("@ID", DbType.String,2147483647)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.QrCode;
			parameters[2].Value = model.WifiMac;
			parameters[3].Value = model.WifiName;
			parameters[4].Value = model.Lon;
			parameters[5].Value = model.Lat;
			parameters[6].Value = model.ID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PointInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PointInfo ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DBCommon.Model.DBPoint GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,QrCode,WifiMac,WifiName,Lon,Lat from PointInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			DBCommon.Model.DBPoint model=new DBCommon.Model.DBPoint();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DBCommon.Model.DBPoint DataRowToModel(DataRow row)
		{
			DBCommon.Model.DBPoint model=new DBCommon.Model.DBPoint();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["QrCode"]!=null)
				{
					model.QrCode=row["QrCode"].ToString();
				}
				if(row["WifiMac"]!=null)
				{
					model.WifiMac=row["WifiMac"].ToString();
				}
				if(row["WifiName"]!=null)
				{
					model.WifiName=row["WifiName"].ToString();
				}
					//model.Lon=row["Lon"].ToString();
					//model.Lat=row["Lat"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,QrCode,WifiMac,WifiName,Lon,Lat ");
			strSql.Append(" FROM PointInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PointInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from PointInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "PointInfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

