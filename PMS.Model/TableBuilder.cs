using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
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
