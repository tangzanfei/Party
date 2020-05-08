using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace PartyConstruction.DAL
{
	/// <summary>
	/// 数据访问类:UserInfoDAL
	/// </summary>
	public partial class UserInfoDAL
	{
		public UserInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "UserInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PartyConstruction.Model.DBUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("ID,Name,IsBranchMaster,IsManager,BranchID,Account,Password,ServicingBranchID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Name,@IsBranchMaster,@IsManager,@BranchID,@Account,@Password,@ServicingBranchID)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8),
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@IsBranchMaster", DbType.Boolean),
					new SQLiteParameter("@IsManager", DbType.Boolean),
					new SQLiteParameter("@BranchID", DbType.Int32,8),
					new SQLiteParameter("@Account", DbType.String,2147483647),
					new SQLiteParameter("@Password", DbType.String,2147483647),
					new SQLiteParameter("@ServicingBranchID", DbType.Int32,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.IsBranchMaster;
			parameters[3].Value = model.IsManager;
			parameters[4].Value = model.BranchID;
			parameters[5].Value = model.Account;
			parameters[6].Value = model.Password;
			parameters[7].Value = model.ServicingBranchID;

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
		public bool Update(PartyConstruction.Model.DBUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("Name=@Name,");
			strSql.Append("IsBranchMaster=@IsBranchMaster,");
			strSql.Append("IsManager=@IsManager,");
			strSql.Append("BranchID=@BranchID,");
			strSql.Append("Account=@Account,");
			strSql.Append("Password=@Password,");
			strSql.Append("ServicingBranchID=@ServicingBranchID");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@Name", DbType.String,2147483647),
					new SQLiteParameter("@IsBranchMaster", DbType.Boolean),
					new SQLiteParameter("@IsManager", DbType.Boolean),
					new SQLiteParameter("@BranchID", DbType.Int32,8),
					new SQLiteParameter("@Account", DbType.String,2147483647),
					new SQLiteParameter("@Password", DbType.String,2147483647),
					new SQLiteParameter("@ServicingBranchID", DbType.Int32,8),
					new SQLiteParameter("@ID", DbType.Int32,8)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.IsBranchMaster;
			parameters[2].Value = model.IsManager;
			parameters[3].Value = model.BranchID;
			parameters[4].Value = model.Account;
			parameters[5].Value = model.Password;
			parameters[6].Value = model.ServicingBranchID;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8)			};
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
			strSql.Append("delete from UserInfo ");
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
		public PartyConstruction.Model.DBUserInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,IsBranchMaster,IsManager,BranchID,Account,Password,ServicingBranchID from UserInfo ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8)			};
			parameters[0].Value = ID;

			PartyConstruction.Model.DBUserInfo model=new PartyConstruction.Model.DBUserInfo();
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
		public PartyConstruction.Model.DBUserInfo DataRowToModel(DataRow row)
		{
			PartyConstruction.Model.DBUserInfo model=new PartyConstruction.Model.DBUserInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["IsBranchMaster"]!=null && row["IsBranchMaster"].ToString()!="")
				{
					if((row["IsBranchMaster"].ToString()=="1")||(row["IsBranchMaster"].ToString().ToLower()=="true"))
					{
						model.IsBranchMaster=true;
					}
					else
					{
						model.IsBranchMaster=false;
					}
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
				if(row["BranchID"]!=null && row["BranchID"].ToString()!="")
				{
					model.BranchID=int.Parse(row["BranchID"].ToString());
				}
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["ServicingBranchID"]!=null && row["ServicingBranchID"].ToString()!="")
				{
					model.ServicingBranchID=int.Parse(row["ServicingBranchID"].ToString());
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
			strSql.Append("select ID,Name,IsBranchMaster,IsManager,BranchID,Account,Password,ServicingBranchID ");
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
				strSql.Append("order by T.ID desc");
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

