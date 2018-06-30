using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 分页实体类
    /// </summary>
    public class TableBuilder
    {
        /// <summary>
        /// 表名 
        /// </summary>
        String strTable;
        /// <summary>
        /// 按该列来进行分页 
        /// </summary>
        String strColumn;
        /// <summary>
        /// strColumn列的类型,0-数字类型,1-字符类型,2-日期时间类型 
        /// </summary>
        int intColType;
        /// <summary>
        /// 排序,0-顺序,1-倒序 
        /// </summary>
        int intOrder;
        /// <summary>
        /// 要查询出的字段列表,*表示全部字段 
        /// </summary>
        String strColumnlist;
        /// <summary>
        /// 每页记录数 
        /// </summary>
        int intPageSize;
        /// <summary>
        /// 指定页 
        /// </summary>
        int intPageNum ;
        /// <summary>
        /// 查询条件 
        /// </summary>
        String strWhere;

        /// <summary>
        /// 表名
        /// </summary>
        public string StrTable
        {
            get
            {
                return strTable;
            }

            set
            {
                strTable = value;
            }
        }

        /// <summary>
        /// 按该列来进行分页 
        /// </summary>
        public string StrColumn
        {
            get
            {
                return strColumn;
            }

            set
            {
                strColumn = value;
            }
        }

        /// <summary>
        /// strColumn列的类型,0-数字类型,1-字符类型,2-日期时间类型 
        /// </summary>
        public int IntColType
        {
            get
            {
                return intColType;
            }

            set
            {
                intColType = value;
            }
        }

        /// <summary>
        /// 排序,0-顺序,1-倒序 
        /// </summary>
        public int IntOrder
        {
            get
            {
                return intOrder;
            }

            set
            {
                intOrder = value;
            }
        }

        /// <summary>
        /// 每页记录数 
        /// </summary>
        public string StrColumnlist
        {
            get
            {
                return strColumnlist;
            }

            set
            {
                strColumnlist = value;
            }
        }

        /// <summary>
        /// 每页记录数 
        /// </summary>
        public int IntPageSize
        {
            get
            {
                return intPageSize;
            }

            set
            {
                intPageSize = value;
            }
        }

        /// <summary>
        /// 指定页 
        /// </summary>
        public int IntPageNum
        {
            get
            {
                return intPageNum;
            }

            set
            {
                intPageNum = value;
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string StrWhere
        {
            get
            {
                return strWhere;
            }

            set
            {
                strWhere = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTable">表名 </param>
        /// <param name="strColumn">按该列来进行分页 </param>
        /// <param name="intColType">strColumn列的类型,0-数字类型,1-字符类型,2-日期时间类型 </param>
        /// <param name="intOrder">排序,0-顺序,1-倒序 </param>
        /// <param name="strColumnlist">要查询出的字段列表,*表示全部字段 </param>
        /// <param name="intPageSize">每页记录数</param>
        /// <param name="intPageNum">指定页 </param>
        /// <param name="strWhere">查询条件 </param>
        public TableBuilder(string strTable, string strColumn, int intColType, int intOrder, string strColumnlist, int intPageSize, int intPageNum, string strWhere)
        {
            this.strTable = strTable;
            this.strColumn = strColumn;
            this.intColType = intColType;
            this.intOrder = intOrder;
            this.strColumnlist = strColumnlist;
            this.intPageSize = intPageSize;
            this.intPageNum = intPageNum;
            this.strWhere = strWhere;
        }

        public TableBuilder()
        {
        }
    }
}
