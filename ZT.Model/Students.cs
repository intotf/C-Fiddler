using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model
{
    /// <summary>
    /// 学生信息
    /// </summary>
    public class Students
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// 本班Id
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 孩子Id
        /// </summary>
        public string childId { get; set; }

        /// <summary>
        /// 字符串转 User 实体
        /// </summary>
        /// <param name="userStr"></param>
        public static Students StrToUser(string studentStr)
        {
            var arr = studentStr.Split('|');
            if (arr.Length == 5)
            {
                return new Students { StudentId = arr[0], ClassId = arr[1], ClassName = arr[2], StudentName = arr[3], childId = arr[4] };
            }
            return default(Students);
        }

        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Students> GetAllStudents()
        {
            var userLines = File.ReadAllLines("students.txt");
            foreach (var item in userLines.Where(t => string.IsNullOrEmpty(t) == false))
            {
                var model = Students.StrToUser(item);
                if (model != null)
                {
                    yield return model;
                }
            }
        }
    }
}
