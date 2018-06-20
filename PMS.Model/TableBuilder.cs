using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    public class TableBuilder
    {
        String strTable;
        String strColumn;
        int intColType;
        int intOrder;
        String strColumnlist;
        int intPageSize;
        int intPageNum ;
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
    }
}
