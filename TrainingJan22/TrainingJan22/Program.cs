using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace TrainingJan22
{
    internal class Program
    {


        [Serializable]
        public class Employee
        {
            string employeeName,desg;
            string email;
            public string EmployeeName
            {
                get { return employeeName; }
                set { employeeName = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Desg
            {
                get { return desg; }
                set { desg = value; }
            }
            
        }

        public static void WritetoFile(Employee emp)
        {
            Stream savefilestream = File.Create("D://dotNETGithub//" + emp.EmployeeName);
            BinaryFormatter serializable = new BinaryFormatter();
            serializable.Serialize(savefilestream, emp);
            savefilestream.Close();
        }
        public static Employee ReadFromFile(string filename)
        {
            string filelocation = "D://dotNETGithub/" + filename;
            if (File.Exists(filelocation))
            {
                Console.WriteLine("Reading from saved file");
                Stream openfilestream = File.OpenRead(filelocation);
                BinaryFormatter deserializer = new BinaryFormatter();
                Employee emp = (Employee)deserializer.Deserialize(openfilestream);
                return emp;
            }
            return null;
        }

        static void Main(string[] args)
        {
            /*StoreEmployeeDetails store = new StoreEmployeeDetails();
            Employee emp = new Employee();
            Console.WriteLine("Enter Employee Name");
            emp.EmployeeNameName = Console.ReadLine();
            Console.WriteLine("Enter Email Id");
            emp.Email = Console.ReadLine();
            Console.WriteLine("Enter Designation");
            emp.Desg = Console.ReadLine();
            store.SaveToFile(emp);
            store.ReadFromFile();*/

            /*bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the Option.\n Press 1 for Check file\nPress 2 to copy file\nPress 3 to rename file\nPress 0 to exit");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the file path");
                        string path = Console.ReadLine();
                        string result = (File.Exists(path)) ? "The File exists" : "The file does not exist";
                        Console.WriteLine(result);
                        break;
                    case 2:
                        Console.WriteLine("Enter source path");
                        string source = Console.ReadLine();
                        Console.WriteLine("Enter destination path");
                        string destination = Console.ReadLine();
                        File.Copy(source, destination);
                        Console.WriteLine("File is moved");
                        break;
                    case 3:
                        Console.WriteLine("Enter the path of file");
                        string file = Console.ReadLine();
                        Console.WriteLine("Enter the new name");
                        string name = Console.ReadLine();
                        File.Move(file, name, true);
                        Console.WriteLine("File is renamed");
                        break;
                    case 0:
                        flag = true;
                        break;
                }
            }*/


            /*FileStream fs = new FileStream("D:\\DotNET\\binarytext.txt", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(10);
            bw.Write('A');
            bw.Write(true);
            bw.Flush();
            bw.Close();
            FileStream fs1 = new FileStream("D:\\DotNET\\binarytext.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs1);    
            int i = br.ReadInt32();
            char a = br.ReadChar();
            bool b = br.ReadBoolean();
            Console.WriteLine(i);
            Console.WriteLine(a);
            Console.WriteLine(b);*/
            Employee emp = new Employee();
            emp.EmployeeName = "Hemang";
            emp.Email = "dgfhh";
            emp.Desg = "SDE";
            //WritetoFile(emp);
            Employee emp1 = ReadFromFile("Hemang");

            Console.WriteLine(emp1.EmployeeName);
            Console.WriteLine(emp1.Email);
            Console.WriteLine(emp1.Desg);
        }
    }
}
