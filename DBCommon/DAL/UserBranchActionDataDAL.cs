using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace DBCommon.DAL
{
	/// <summary>
	/// 数据访问类:UserBranchActionDataDAL
	/// </summary>
	public partial class UserBranchActionDataDAL
	{
		public UserBranchActionDataDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserBranchActionData");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBUserBranchActionData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserBranchActionData(");
			strSql.Append("ID,ActionID,UserID,Checked,CheckTime)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ActionID,@UserID,@Checked,@CheckTime)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647),
					new SQLiteParameter("@ActionID", DbType.String,2147483647),
					new SQLiteParameter("@UserID", DbType.String,2147483647),
					new SQLiteParameter("@Checked", DbType.Boolean),
					new SQLiteParameter("@CheckTime", DbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ActionID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.Checked;
			parameters[4].Value = model.CheckTime;

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
		public bool Update(DBCommon.Model.DBUserBranchActionData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserBranchActionData set ");
			strSql.Append("ActionID=@ActionID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Checked=@Checked,");
			strSql.Append("CheckTime=@CheckTime");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ActionID", DbType.String,2147483647),
					new SQLiteParameter("@UserID", DbType.String,2147483647),
					new SQLiteParameter("@Checked", DbType.Boolean),
					new SQLiteParameter("@CheckTime", DbType.DateTime),
					new SQLiteParameter("@ID", DbType.String,2147483647)};
			parameters[0].Value = model.ActionID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Checked;
			parameters[3].Value = model.CheckTime;
			parameters[4].Value = model.ID;

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
			strSql.Append("delete from UserBranchActionData ");
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
			strSql.Append("delete from UserBranchActionData ");
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
		public DBCommon.Model.DBUserBranchActionData GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ActionID,UserID,Checked,CheckTime from UserBranchActionData ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.String,2147483647)			};
			parameters[0].Value = ID;

			DBCommon.Model.DBUserBranchActionData model=new DBCommon.Model.DBUserBranchActionData();
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
		public DBCommon.Model.DBUserBranchActionData DataRowToModel(DataRow row)
		{
			DBCommon.Model.DBUserBranchActionData model=new DBCommon.Model.DBUserBranchActionData();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ActionID"]!=null)
				{
					model.ActionID=row["ActionID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["Checked"]!=null && row["Checked"].ToString()!="")
				{
					if((row["Checked"].ToString()=="1")||(row["Checked"].ToString().ToLower()=="true"))
					{
						model.Checked=true;
					}
					else
					{
						model.Checked=false;
					}
				}
				if(row["CheckTime"]!=null && row["CheckTime"].ToString()!="")
				{
					model.CheckTime=DateTime.Parse(row["CheckTime"].ToString());
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
			strSql.Append("select ID,ActionID,UserID,Checked,CheckTime ");
			strSql.Append(" FROM UserBranchActionData ");
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
			strSql.Append("select count(1) FROM UserBranchActionData ");
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
			strSql.Append(")AS Row, T.*  from UserBranchActionData T ");
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
			parameters[0].Value = "UserBranchActionData";
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

