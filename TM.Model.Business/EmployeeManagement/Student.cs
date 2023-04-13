﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TM.Model.Business.EmployeeManagement
{
    [Table("TBL_STUDENT_DTL")]
    public class EmployeeDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string schoolId { get; set; }
        public string grade { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
    }
}