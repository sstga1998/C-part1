using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Modal;

namespace WindowsFormsApp1.Controller
{
    public class Class1
    {
        public string IDname { get; private set; }
        public string ID { get; private set; }
        public string NameContact { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        /// <summary> 
        /// Lấy list theo mã ID từ file
        /// </summary>
        /// <param name="Files">Đường dẫn tới file chứa dữ liệu</param>
        /// <param name="idname">ID</param>
        /// <returns>Sinh viên theo mã sinh viên hoặc null nếu không thấy</returns>
        public static List<ListName> GetList(string Files)
        {
            if (File.Exists(Files))
            {
                var listLines = File.ReadAllLines(Files);
                List<ListName> listName = new List<ListName>();
                foreach (var line in listLines)
                {
                    var rs = line.Split(new char[] { '#' });
                        ListName list = new ListName
                        {
                            IDname = rs[0],
                            ID = rs[1],
                            NameContact = rs[2],
                            Phone = rs[3],
                            Email = rs[4],
                        };
                      
                            listName.Add(list);
                }
                return listName;

            }
            else
                return null;
        }

        internal static object GetDB(string pathListDataFile, string id)
        {
            throw new NotImplementedException();
        }

        public static List<Class1> SearchContacts(string Files, string value)
        {
            if (File.Exists(Files))
            {
                List<Class1> contacts = new List<Class1>();
                var listLines = File.ReadAllLines(Files);
                foreach (var line in listLines)
                {
                    var rs = line.Split(new char[] { '#' });
                    var name = rs[1].ToLower();
                    if (name.Contains(value.ToLower()))
                    {
                        Class1 contact = new Class1
                        {
                            IDname = rs[0],
                            //ID = rs[1],
                            NameContact = rs[2],
                            Phone = rs[3],
                            Email = rs[4],
                        };
                        contacts.Add(contact);
                    }
                }
                return contacts;
            }
            else
            {
                return null;
            }
        }



        public static void deleteContact(string Files, string contactID)
        {
            if (File.Exists(Files))
            {
                var listContacts = File.ReadAllLines(Files);
                File.WriteAllText(Files, "");
                foreach (var lineContact in listContacts)
                {
                    var rsContact = lineContact.Split(new char[] { '#' });
                    if (rsContact[0] != contactID)
                    {
                        File.AppendAllText(Files, lineContact + "\r\n");
                    }
                }

            }
        }
    }
}
