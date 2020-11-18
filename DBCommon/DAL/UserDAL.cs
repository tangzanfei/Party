using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace DBCommon.DAL
{
	/// <summary>
	/// 数据访问类:UserDAL
	/// </summary>
	public partial class UserDAL
	{
		public UserDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OpenID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where OpenID=@OpenID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@OpenID", DbType.String,2147483647)			};
			parameters[0].Value = OpenID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBCommon.Model.DBUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("OpenID,NickName,Name,IsManager,BranchID,ServicingBranchID,Session,LastLoginTime)");
			strSql.Append(" values (");
			strSql.Append("@OpenID,@NickName,@Name,@IsManager,@BranchID,@ServicingBranchID,@Session,@LastLoginTime)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@OpenID", DbType.String,2147483647),
					new SQLiteParameter("@NickName", DbType.String,2147483647),
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@IsManager", DbType.Boolean),
					new SQLiteParameter("@BranchID", DbType.String,2147483647),
					new SQLiteParameter("@ServicingBranchID", DbType.String,2147483647),
					new SQLiteParameter("@Session", DbType.String,2147483647),
					new SQLiteParameter("@LastLoginTime", DbType.DateTime)};
			parameters[0].Value = model.OpenID;
			parameters[1].Value = model.NickName;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.IsManager;
			parameters[4].Value = model.BranchID;
			parameters[5].Value = model.ServicingBranchID;
			parameters[6].Value = model.Session;
			parameters[7].Value = model.LastLoginTime;

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
		public bool Update(DBCommon.Model.DBUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("NickName=@NickName,");
			strSql.Append("Name=@Name,");
			strSql.Append("IsManager=@IsManager,");
			strSql.Append("BranchID=@BranchID,");
			strSql.Append("ServicingBranchID=@ServicingBranchID,");
			strSql.Append("Session=@Session,");
			strSql.Append("LastLoginTime=@LastLoginTime");
			strSql.Append(" where OpenID=@OpenID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@NickName", DbType.String,2147483647),
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@IsManager", DbType.Boolean),
					new SQLiteParameter("@BranchID", DbType.String,2147483647),
					new SQLiteParameter("@ServicingBranchID", DbType.String,2147483647),
					new SQLiteParameter("@Session", DbType.String,2147483647),
					new SQLiteParameter("@LastLoginTime", DbType.DateTime),
					new SQLiteParameter("@OpenID", DbType.String,2147483647)};
			parameters[0].Value = model.NickName;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.IsManager;
			parameters[3].Value = model.BranchID;
			parameters[4].Value = model.ServicingBranchID;
			parameters[5].Value = model.Session;
			parameters[6].Value = model.LastLoginTime;
			parameters[7].Value = model.OpenID;

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
		public bool Delete(string OpenID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where OpenID=@OpenID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@OpenID", DbType.String,2147483647)			};
			parameters[0].Value = OpenID;

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
		public bool DeleteList(string OpenIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where OpenID in ("+OpenIDlist + ")  ");
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
		public DBCommon.Model.DBUser GetModel(string OpenID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OpenID,NickName,Name,IsManager,BranchID,ServicingBranchID,Session,LastLoginTime from UserInfo ");
			strSql.Append(" where OpenID=@OpenID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@OpenID", DbType.String,2147483647)			};
			parameters[0].Value = OpenID;

			DBCommon.Model.DBUser model=new DBCommon.Model.DBUser();
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
		public DBCommon.Model.DBUser DataRowToModel(DataRow row)
		{
			DBCommon.Model.DBUser model=new DBCommon.Model.DBUser();
			if (row != null)
			{
				if(row["OpenID"]!=null)
				{
					model.OpenID=row["OpenID"].ToString();
				}
				if(row["NickName"]!=null)
				{
					model.NickName=row["NickName"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["IsManager"]!=null && row["IsManager"].ToString()!="")
				{
					if((row["IsManager"].ToString()=="1")||(row["IsManager"].ToString().ToLower()=="true"))
					{
						model.IsManager=true;
					}
					else
					{
						model.IsManager=false;
					}
				}
				if(row["BranchID"]!=null)
				{
					model.BranchID=row["BranchID"].ToString();
				}
				if(row["ServicingBranchID"]!=null)
				{
					model.ServicingBranchID=row["ServicingBranchID"].ToString();
				}
				if(row["Session"]!=null)
				{
					model.Session=row["Session"].ToString();
				}
				if(row["LastLoginTime"]!=null && row["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(row["LastLoginTime"].ToString());
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
			strSql.Append("select OpenID,NickName,Name,IsManager,BranchID,ServicingBranchID,Session,LastLoginTime ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
				strSql.Append("order by T.OpenID desc");
			}
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "OpenID";
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

