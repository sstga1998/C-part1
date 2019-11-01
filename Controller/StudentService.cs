using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Modal;

namespace WindowsFormsApp1.Controller
{
    public class StudentService
    {
        /// <summary> Lấy sinh viên theo mã sinh viên từ MockData
        /// </summary>
        /// <param name="idStudent">Mã sinh viên</param>
        /// <returns>Sinh viên có mã tương ứng hoặc null</returns>
        public static student GetStudent(string idStudent)
        {
            student student = new student
            {
                IDStudent = idStudent,
                FirstName = "Giang",
                LastName = "Nguyễn",
                DOB = new DateTime(1998, 1, 26),
                POB = "Quảng Trị",
                Gender = GENDER.Female
            };
            //student.ListHistoryLearning = null;
            student.ListHistoryLearning = new List<HistoryLearning>();
            for (int i = 0; i < 12; i++)
            {
                HistoryLearning historyLearning = new HistoryLearning
                {
                    IDHistoryLearning = i.ToString(),
                    YearFrom = 2004 + i,
                    YearEnd = 2005 + i,
                    Address = "TH Gio Mai",
                    IDStudent = idStudent,
                };
                student.ListHistoryLearning.Add(historyLearning);
            }
            return student;
        }

        internal static ICollection<HistoryLearning> GetHistoryLearnings(object pathLearningHistoryDataFile, string maSinhVien)
        {
            throw new NotImplementedException();
        }

        /// <summary> 
        /// Lấy sinh viên theo mã sinh viên từ file
        /// </summary>
        /// <param name="pathDataFile">Đường dẫn tới file chứa dữ liệu</param>
        /// <param name="idStudent">Mã sinh viên</param>
        /// <returns>Sinh viên theo mã sinh viên hoặc null nếu không thấy</returns>
        public static student GetStudent(string pathDataFile, string idStudent)
        {
            if (File.Exists(pathDataFile))
            {
                CultureInfo culture = CultureInfo.InvariantCulture;
                var listLines = File.ReadAllLines(pathDataFile); //mở file và đọc hết tất cả các dòng => đóng file
                foreach (var line in listLines)
                {
                    var rs = line.Split(new char[] { '#' });
                    student student = new student
                    {
                        IDStudent = rs[0],
                        LastName = rs[1],
                        FirstName = rs[2],
                        Gender = rs[3] == "Male" ? GENDER.Male : (rs[3] == "Female" ? GENDER.Female : GENDER.Other),
                        DOB = DateTime.ParseExact(rs[4], "yyyy-MM-dd", culture),
                        POB = rs[5]
                    };
                    if (student.IDStudent == idStudent)
                        return student;
                }
                return null;
            }
            return null;
        }

        /// <summary> 
        /// Lấy sinh viên theo mã sinh viên từ file
        /// </summary>
        /// <param name="pathDataFile">Đường dẫn tới file chứa dữ liệu</param>
        /// <param name="idStudent">Mã sinh viên</param>
        /// <returns>Sinh viên theo mã sinh viên hoặc null nếu không thấy</returns>
        public static List<HistoryLearning> GetHistoryLearnings(string pathDataFile, string idStudent)
        {
            if (File.Exists(pathDataFile))
            { 
            var listLines = File.ReadAllLines(pathDataFile);
            List<HistoryLearning> listHistory = new List<HistoryLearning>();
            foreach (var line in listLines)
            {
                var rs = line.Split(new char[] { '#'});
                HistoryLearning history = new HistoryLearning
                {
                    IDHistoryLearning = rs[0],
                    YearFrom = int.Parse(rs[1]),
                    YearEnd = int.Parse(rs[2]),
                    Address = rs[3],
                    IDStudent = rs[4]
                };
                if (history.IDStudent == idStudent)
                    listHistory.Add(history);
            }
            return listHistory;

        }
        else 
            return null;
        } 
       
    }

}






