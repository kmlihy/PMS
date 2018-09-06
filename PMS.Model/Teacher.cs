using System;
using System.Data;
namespace PMS.Model
{

    /// <summary>T_Teacher</summary>
    [Serializable()]
    public class Teacher
    {
        /// <summary>
        /// ��ʦ����Ա�˺�
        /// </summary>
        public string TeaAccount { get; set; }

        /// <summary>
        /// ��ʦ����Ա����
        /// </summary>
        public string TeaPwd { get; set; }
        
        /// <summary>
        /// ��ʦ����Ա����
        /// </summary>
        public string TeaName { get; set; }
       
        /// <summary>
        /// ��ʦ����Ա�Ա�
        /// </summary>
        public string Sex { get; set; }
        
        /// <summary>
        /// ��ʦ����Ա��ϵ�绰
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// ��ʦ����Ա����
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// �жϽ�ʦ�Ƿ񱻷��䵽���С��
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// ��Ժid(�����Ժ��)
        /// </summary>
        public College college { get; set; }

        /// <summary>
        /// ��ɫ�������(��������Ա0,��ʦ1,����Ա2)
        /// </summary>
        public int TeaType { get; set; }
        /// <summary>
        /// �޲ι��캯��
        /// </summary>
        public Teacher() { }

        /// <summary>
        /// �вι��캯��
        /// </summary>
        /// <param name="teaAccount"></param>
        /// <param name="teaPwd"></param>
        /// <param name="teaName"></param>
        /// <param name="sex"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="state">�жϽ�ʦ�Ƿ񱻷��䵽���С��</param>
        /// <param name="college"></param>
        /// <param name="teaType"></param>
        public Teacher(string teaAccount, string teaPwd, string teaName, string sex, string phone, string email, int state, College college, int teaType)
        {
            TeaAccount = teaAccount;
            TeaPwd = teaPwd;
            TeaName = teaName;
            Sex = sex;
            Phone = phone;
            Email = email;
            this.state = state;
            this.college = college;
            TeaType = teaType;
        }


    }
}
