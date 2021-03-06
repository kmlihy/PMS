﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Dao;
using PMS.Model;

namespace PMS.BLL
{
    using System.Data;
    using Result = Enums.OpResult;
    public class TitleBll
    {
        private TitleDao dao = new TitleDao();
        private PublicProcedure pdao = new PublicProcedure();

        /// <summary>
        /// 添加题目
        /// </summary>
        /// <param name="news">题目实体</param>
        /// <returns>返回处理结果</returns>
        public Enums.OpResult Insert(Title title)
        {
            int count = dao.Insert(title);
            if (count>0)
            {
                return Result.添加成功;
            }
            else
            {
                return Result.添加失败;
            }
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        ///<param name = "table" > 表名 </ param >
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>管理引用代表数据存在不可删除，记录不存在表示可以删除</returns>
        public Enums.OpResult IsDelete(string table, string primarykeyname, string primarykey)
        {
            int row = pdao.isDelete(table, primarykeyname, primarykey);
            if (row > 0)
            {
                return Enums.OpResult.关联引用;
            }
            else
            {
                return Enums.OpResult.记录不存在;
            }
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="news">题目实体</param>
        /// <returns>返回处理结果</returns>
        public Enums.OpResult Delete(int titleId)
        {
            int count = dao.Delete(titleId);
            if (count>0)
            {
                return Result.删除成功;
            }
            else
            {
                return Result.删除失败;
            }
        }

        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="title">题目对象</param>
        /// <returns></returns>
        public Enums.OpResult Update(Title title)
        {
            int count = dao.Update(title);
            if (count>0)
            {
                return Result.更新成功;
            }
            else
            {
                return Result.更新失败;
            }
        }
        /// <summary>
        /// 判断批次是否激活
        /// </summary>
        /// <param name="planId">批次id</param>
        /// <returns>1为激活，0为非激活</returns>
        public bool selectByplanId(string planId)
        {
            int count = dao.selectByplanId(planId);
            if(count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据标题查询题目信息
        /// </summary>
        /// <param name="title">题目标题</param>
        /// <returns>返回查询结果</returns>
        public DataSet Select(string title)
        {
            return dao.Select(title);
        }

        /// <summary>
        /// 根据专业id，批次id获取除指导教师外的题目信息
        /// </summary>
        /// <param name="proId">专业id</param>
        /// <param name="planId">批次id</param>
        /// <param name="teaAccount">教师账号</param>
        /// <returns></returns>
        public DataSet SelectByProId(int proId,int planId, string teaAccount)
        {
            DataSet ds = dao.SelectByProId(proId,planId, teaAccount);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页查询方法
        /// </summary>
        /// <param name="tablebuilder">参数实体</param>
        /// <param name="intPageCount">输出参数，总页数</param>
        /// <returns>返回分页结果数据</returns>
        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount)
        {
            DataSet ds = pdao.SelectBypage(tablebuilder, out intPageCount);         
                return ds;
        }
        /// <summary>
        /// 获得题目实体对象
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public Title GetTitle(int titleId)
        {
           return dao.GetTitle(titleId);
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int upload(DataTable dt)
        {
            int row = dao.upload(dt);
            return row;
        }
    }
}
