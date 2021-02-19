using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace DBCommon.DAL
{
	/// <summary>
	/// 数据访问类:BranchActionDAL
	/// </summary>
	public partial class BranchActionDAL
	{
		public BranchActionDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BranchActionInfo");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBBranchAction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BranchActionInfo(");
			strSql.Append("ID,BeginTime,EndTime,Title,BranchID,PointID,QrCode)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BeginTime,@EndTime,@Title,@BranchID,@PointID,@QrCode)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String),
					new SQLiteParameter("@BeginTime", DbType.DateTime),
					new SQLiteParameter("@EndTime", DbType.DateTime),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@BranchID", DbType.String),
					new SQLiteParameter("@PointID", DbType.String),
					new SQLiteParameter("@QrCode", DbType.String)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BeginTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.BranchID;
			parameters[5].Value = model.PointID;
			parameters[6].Value = model.QrCode;

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
		public bool Update(DBCommon.Model.DBBranchAction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BranchActionInfo set ");
			strSql.Append("BeginTime=@BeginTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Title=@Title,");
			strSql.Append("BranchID=@BranchID,");
			strSql.Append("PointID=@PointID,");
			strSql.Append("QrCode=@QrCode");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@BeginTime", DbType.DateTime),
					new SQLiteParameter("@EndTime", DbType.DateTime),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@BranchID", DbType.String),
					new SQLiteParameter("@PointID", DbType.String),
					new SQLiteParameter("@QrCode", DbType.String),
					new SQLiteParameter("@ID", DbType.String)};
			parameters[0].Value = model.BeginTime;
			parameters[1].Value = model.EndTime;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.BranchID;
			parameters[4].Value = model.PointID;
			parameters[5].Value = model.QrCode;
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
			strSql.Append("delete from BranchActionInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)			};
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
			strSql.Append("delete from BranchActionInfo ");
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
		public DBCommon.Model.DBBranchAction GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BeginTime,EndTime,Title,BranchID,PointID,QrCode from BranchActionInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String)			};
			parameters[0].Value = ID;

			DBCommon.Model.DBBranchAction model=new DBCommon.Model.DBBranchAction();
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
		public DBCommon.Model.DBBranchAction DataRowToModel(DataRow row)
		{
			DBCommon.Model.DBBranchAction model=new DBCommon.Model.DBBranchAction();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["BranchID"]!=null)
				{
					model.BranchID=row["BranchID"].ToString();
				}
				if(row["PointID"]!=null)
				{
					model.PointID=row["PointID"].ToString();
				}
				if(row["QrCode"]!=null)
				{
					model.QrCode=row["QrCode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BeginTime,EndTime,Title,BranchID,PointID,QrCode ");
			strSql.Append(" FROM BranchActionInfo ");
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
			strSql.Append("select count(1) FROM BranchActionInfo ");
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
			strSql.Append(")AS Row, T.*  from BranchActionInfo T ");
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
			parameters[0].Value = "BranchActionInfo";
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

