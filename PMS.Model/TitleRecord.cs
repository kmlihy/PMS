﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 选题记录实体
    /// </summary>
    public  class TitleRecord
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public TitleRecord()
        {   

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <param name="student">学生表</param>
        /// <param name="title">题目表</param>
        /// <param name="defeseTeamId">答辩小组</param> 
        /// <param name="recordCreateTime">创建时间</param>
        /// <param name="college">分院编号</param>
        public TitleRecord(int titleRecordId, Student student, Title title, int defeseTeamId, Profession profession, Plan plan, DateTime recordCreateTime, College college)
        {
            this.TitleRecordId = titleRecordId;
            this.student = student;
            this.title = title;
            this.DefeseTeamId = defeseTeamId;
            this.profession = profession;
            this.plan = plan;
            this.recordCreateTime = recordCreateTime;
            this.college = college;
        }

        /// <summary>
        /// 选题记录id
        /// </summary>
        public int TitleRecordId { get;set;}

        /// <summary>
        /// (外键专业表)
        /// </summary>
        public Profession profession { get; set; }

        /// <summary>
        /// (外键批次表)
        /// </summary>
        public Plan plan { get; set; }

        /// <summary>
        /// (外键学生表)
        /// </summary>
        public Student student{ get; set; }

        /// <summary>
        /// (外键题目表)
        /// </summary>
        public Title title{ get; set; }

        /// <summary>
        /// 答辩小组id(暂无)
        /// </summary>
        public int DefeseTeamId { get; set; }

        /// <summary>
        /// (外键教师表)
        /// </summary>
        public Teacher teacher { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime recordCreateTime { get; set; }

        /// <summary>
        /// （外键学院信息表）
        /// </summary>
        public College college { get; set; }
    }
}
