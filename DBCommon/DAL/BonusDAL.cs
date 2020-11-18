using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace DBCommon.DAL
{
	/// <summary>
	/// 数据访问类:BonusDAL
	/// </summary>
	public partial class BonusDAL
	{
		public BonusDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BonusInfo");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBBonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BonusInfo(");
			strSql.Append("ID,UserID,Content,SummitTime,Score,ConfirmState,ConfirmTime,ConfirmManagerID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@UserID,@Content,@SummitTime,@Score,@ConfirmState,@ConfirmTime,@ConfirmManagerID)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647),
					new SQLiteParameter("@UserID", DbType.String,2147483647),
					new SQLiteParameter("@Content", DbType.String,2147483647),
					new SQLiteParameter("@SummitTime", DbType.DateTime),
					new SQLiteParameter("@Score", DbType.Int32,4),
					new SQLiteParameter("@ConfirmState", DbType.Int32,4),
					new SQLiteParameter("@ConfirmTime", DbType.DateTime),
					new SQLiteParameter("@ConfirmManagerID", DbType.String,2147483647)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.SummitTime;
			parameters[4].Value = model.Score;
			parameters[5].Value = model.ConfirmState;
			parameters[6].Value = model.ConfirmTime;
			parameters[7].Value = model.ConfirmManagerID;

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
		public bool Update(DBCommon.Model.DBBonus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BonusInfo set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Content=@Content,");
			strSql.Append("SummitTime=@SummitTime,");
			strSql.Append("Score=@Score,");
			strSql.Append("ConfirmState=@ConfirmState,");
			strSql.Append("ConfirmTime=@ConfirmTime,");
			strSql.Append("ConfirmManagerID=@ConfirmManagerID");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@UserID", DbType.String,2147483647),
					new SQLiteParameter("@Content", DbType.String,2147483647),
					new SQLiteParameter("@SummitTime", DbType.DateTime),
					new SQLiteParameter("@Score", DbType.Int32,4),
					new SQLiteParameter("@ConfirmState", DbType.Int32,4),
					new SQLiteParameter("@ConfirmTime", DbType.DateTime),
					new SQLiteParameter("@ConfirmManagerID", DbType.String,2147483647),
					new SQLiteParameter("@ID", DbType.String,2147483647)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.SummitTime;
			parameters[3].Value = model.Score;
			parameters[4].Value = model.ConfirmState;
			parameters[5].Value = model.ConfirmTime;
			parameters[6].Value = model.ConfirmManagerID;
			parameters[7].Value = model.ID;

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
			strSql.Append("delete from BonusInfo ");
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
			strSql.Append("delete from BonusInfo ");
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
		public DBCommon.Model.DBBonus GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,Content,SummitTime,Score,ConfirmState,ConfirmTime,ConfirmManagerID from BonusInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			DBCommon.Model.DBBonus model=new DBCommon.Model.DBBonus();
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
		public DBCommon.Model.DBBonus DataRowToModel(DataRow row)
		{
			DBCommon.Model.DBBonus model=new DBCommon.Model.DBBonus();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["SummitTime"]!=null && row["SummitTime"].ToString()!="")
				{
					model.SummitTime=DateTime.Parse(row["SummitTime"].ToString());
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["ConfirmState"]!=null && row["ConfirmState"].ToString()!="")
				{
					model.ConfirmState=int.Parse(row["ConfirmState"].ToString());
				}
				if(row["ConfirmTime"]!=null && row["ConfirmTime"].ToString()!="")
				{
					model.ConfirmTime=DateTime.Parse(row["ConfirmTime"].ToString());
				}
				if(row["ConfirmManagerID"]!=null)
				{
					model.ConfirmManagerID=row["ConfirmManagerID"].ToString();
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
			strSql.Append("select ID,UserID,Content,SummitTime,Score,ConfirmState,ConfirmTime,ConfirmManagerID ");
			strSql.Append(" FROM BonusInfo ");
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
			strSql.Append("select count(1) FROM BonusInfo ");
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
			strSql.Append(")AS Row, T.*  from BonusInfo T ");
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
			parameters[0].Value = "BonusInfo";
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

