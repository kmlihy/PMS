using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Model;
using PMS.Dao;

namespace PMS.BLL
{
    using System.Data;
    using Result = Enums.OpResult;

    public class TeacherBll
    {
        private TeacherDao dao = new TeacherDao();
        private PublicProcedure pdao = new PublicProcedure();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teaAccount"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Teacher Login(string teaAccount, string pwd)
        {
            DataSet ds = dao.Select(teaAccount, pwd);
            if(ds!=null && ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if(row["teaAccount"].ToString() == teaAccount && row["teaPwd"].ToString() == pwd)
                {
                    Teacher teacher = dao.GetTeacher(row["teaAccount"].ToString());
                    //填充属性
                    return teacher;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        public Enums.OpResult Insert(Teacher teacher)
        {
            int count = dao.Insert(teacher);
            if (count > 0)
            {
                return Enums.OpResult.添加成功;
            }
            else
            {
                return Enums.OpResult.添加失败;
            }
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        ///<param name = "table" > 表名 </ param >
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>管理引用代表数据存在不可删除，记录不存在表示可以删除</returns>
        public Enums.OpResult isDelete(string table, string primarykeyname, string primarykey)
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
        /// 删除教师
        /// </summary>
        /// <param name="TeaAccount">教师主键</param>
        /// <returns></returns>
        public Enums.OpResult delete(String TeaAccount)
        {
            int count = dao.delete(TeaAccount);
            if (count > 0)
            {
                return Enums.OpResult.删除成功;
            }
            else
            {
                return Enums.OpResult.删除失败;
            }
        }
        /// <summary>
        /// 更新教师
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        public Enums.OpResult Updata(Teacher teacher)
        {
            int count = dao.Updata(teacher);
            if (count > 0)
            {
                return Enums.OpResult.更新成功;
            }
            else
            {
                return Enums.OpResult.更新失败;
            }
        }
        /// <summary>
        /// 得到教师实体对象
        /// </summary>
        /// <param name="TeaAccount">教师账号</param>
        /// <returns>教师实体</returns>
        public Teacher GetModel(String TeaAccount)
        {
            return dao.GetTeacher(TeaAccount);
        }

        /// <summary>
        /// 根据TableBuilder实体返回DataSet数据
        /// </summary>
        /// <param name="tablebuilder"></param>
        /// <param name="intPageCount"></param>
        /// <returns></returns>
        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount) {
            int pagecount;
            DataSet ds= pdao.SelectBypage(tablebuilder, out pagecount);
            intPageCount = pagecount;
            return ds;
        }
    }
}
