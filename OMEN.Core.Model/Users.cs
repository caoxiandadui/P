using System;

namespace OMEN.Core.Model
{
    public class Users
    {
        private int _userid;
        private int _deptid;
        private string _usercode;
        private string _firstpy;
        private string _loginname;
        private string _pwd;
        private string _username;
        private string _usertype;
        private int _gender;
        private DateTime? _birthday;
        private string _email;
        private string _tel;
        private string _phone;
        private string _qq;
        private string _description;
        private string _professtitle;
        private string _idcard;
        private string _nativeplace;
        private string _homeaddress;
        private string _nation;
        private string _major;
        private string _education;
        private string _school;
        private string _degree;
        private DateTime? _joinindate;
        private DateTime? _dimissiondate;
        private string _dimissioncause;
        private int _deletemark = 0;
        private int _isadmin = 0;
        private int _status = 1;
        private int _createid;
        private string _createname;
        private DateTime _createdate = DateTime.Now;

        /// <summary>
        /// 主键ID
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
		/// 部门ID
        /// </summary>
        public int DeptID
        {
            get { return _deptid; }
            set { _deptid = value; }
        }
        /// <summary>
		/// 编号
        /// </summary>
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
        }
        /// <summary>
		/// 助记码 拼音首字母
        /// </summary>
        public string FirstPY
        {
            get { return _firstpy; }
            set { _firstpy = value; }
        }
        /// <summary>
		/// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }
        /// <summary>
		/// 密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        /// <summary>
		/// 姓名
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
		/// 人员类型
        /// </summary>
        public string UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }
        /// <summary>
		/// 性别 0男 1女
        /// </summary>
        public int Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
		/// 生日
        /// </summary>
        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        /// <summary>
		/// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
		/// 固定电话
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
		/// 移动电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
		/// QQ号
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        /// <summary>
		/// 描述说明
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
		/// 职称
        /// </summary>
        public string ProFessTitle
        {
            get { return _professtitle; }
            set { _professtitle = value; }
        }
        /// <summary>
		/// 身份证号
        /// </summary>
        public string IDCard
        {
            get { return _idcard; }
            set { _idcard = value; }
        }
        /// <summary>
		/// NativePlace
        /// </summary>
        public string NativePlace
        {
            get { return _nativeplace; }
            set { _nativeplace = value; }
        }
        /// <summary>
		/// 家庭住址
        /// </summary>
        public string HomeAddress
        {
            get { return _homeaddress; }
            set { _homeaddress = value; }
        }
        /// <summary>
		/// 民族
        /// </summary>
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }
        /// <summary>
		/// 专业
        /// </summary>
        public string Major
        {
            get { return _major; }
            set { _major = value; }
        }
        /// <summary>
		/// 最高学历
        /// </summary>
        public string Education
        {
            get { return _education; }
            set { _education = value; }
        }
        /// <summary>
		/// 毕业院校
        /// </summary>
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }
        /// <summary>
		/// 最高学位
        /// </summary>
        public string Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }
        /// <summary>
		/// 入职日期
        /// </summary>
        public DateTime? JoinInDate
        {
            get { return _joinindate; }
            set { _joinindate = value; }
        }
        /// <summary>
		/// 离职日期
        /// </summary>
        public DateTime? DimissionDate
        {
            get { return _dimissiondate; }
            set { _dimissiondate = value; }
        }
        /// <summary>
		/// 离职原因
        /// </summary>
        public string DimissionCause
        {
            get { return _dimissioncause; }
            set { _dimissioncause = value; }
        }
        /// <summary>
		/// 删除标记 0正常 1删除
        /// </summary>
        public int DeleteMark
        {
            get { return _deletemark; }
            set { _deletemark = value; }
        }
        /// <summary>
		/// 是否系统管理员 
        /// </summary>
        public int IsAdmin
        {
            get { return _isadmin; }
            set { _isadmin = value; }
        }
        /// <summary>
		/// 状态 0 停用 1启用
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
		/// 添加人ID
        /// </summary>
        public int CreateID
        {
            get { return _createid; }
            set { _createid = value; }
        }
        /// <summary>
		/// 添加人名称
        /// </summary>
        public string CreateName
        {
            get { return _createname; }
            set { _createname = value; }
        }
        /// <summary>
		/// 添加时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

    }
}
