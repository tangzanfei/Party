/**  版本信息模板在安装目录下，可自行修改。
* UserActionData.cs
*
* 功 能： N/A
* 类 名： UserActionData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/4/23 星期四 上午 10:30:52   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace PartyConstruction.DAL
{
	/// <summary>
	/// 数据访问类:UserActionData
	/// </summary>
	public partial class UserActionData
	{
		public UserActionData()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "UserActionData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserActionData");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8)			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PartyConstruction.Model.UserActionData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserActionData(");
			strSql.Append("ID,ActionID,UserID,ManagerConfirmed,ManagerID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ActionID,@UserID,@ManagerConfirmed,@ManagerID)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8),
					new SQLiteParameter("@ActionID", DbType.Int32,8),
					new SQLiteParameter("@UserID", DbType.Int32,8),
					new SQLiteParameter("@ManagerConfirmed", DbType.Boolean),
					new SQLiteParameter("@ManagerID", DbType.Int32,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ActionID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.ManagerConfirmed;
			parameters[4].Value = model.ManagerID;

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
		public bool Update(PartyConstruction.Model.UserActionData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserActionData set ");
			strSql.Append("ActionID=@ActionID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("ManagerConfirmed=@ManagerConfirmed,");
			strSql.Append("ManagerID=@ManagerID");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ActionID", DbType.Int32,8),
					new SQLiteParameter("@UserID", DbType.Int32,8),
					new SQLiteParameter("@ManagerConfirmed", DbType.Boolean),
					new SQLiteParameter("@ManagerID", DbType.Int32,8),
					new SQLiteParameter("@ID", DbType.Int32,8)};
			parameters[0].Value = model.ActionID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ManagerConfirmed;
			parameters[3].Value = model.ManagerID;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserActionData ");
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
			strSql.Append("delete from UserActionData ");
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
		public PartyConstruction.Model.UserActionData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ActionID,UserID,ManagerConfirmed,ManagerID from UserActionData ");
			strSql.Append(" where ID=@ID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,8)			};
			parameters[0].Value = ID;

			PartyConstruction.Model.UserActionData model=new PartyConstruction.Model.UserActionData();
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
		public PartyConstruction.Model.UserActionData DataRowToModel(DataRow row)
		{
			PartyConstruction.Model.UserActionData model=new PartyConstruction.Model.UserActionData();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ActionID"]!=null && row["ActionID"].ToString()!="")
				{
					model.ActionID=int.Parse(row["ActionID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["ManagerConfirmed"]!=null && row["ManagerConfirmed"].ToString()!="")
				{
					if((row["ManagerConfirmed"].ToString()=="1")||(row["ManagerConfirmed"].ToString().ToLower()=="true"))
					{
						model.ManagerConfirmed=true;
					}
					else
					{
						model.ManagerConfirmed=false;
					}
				}
				if(row["ManagerID"]!=null && row["ManagerID"].ToString()!="")
				{
					model.ManagerID=int.Parse(row["ManagerID"].ToString());
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
			strSql.Append("select ID,ActionID,UserID,ManagerConfirmed,ManagerID ");
			strSql.Append(" FROM UserActionData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from UserActionData T ");
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
			parameters[0].Value = "UserActionData";
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

