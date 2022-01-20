using System;
using System.IO;
using System.Collections;
namespace Training20Jan
{
    /*class Program
    {
        public static void readfromfile(String filename)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
                String data = reader.ReadToEnd();
                Console.WriteLine(data);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("file not found");
            }
            finally
            {
                Console.WriteLine("file operation over");
            }
        }
        public static void Main(string[] args)
        {
            readfromfile("c:\\sample\\myfile.txt");
            Console.ReadLine();
        }
    }*/
    /*class AgeException : SystemException
    {
        public AgeException(int age) : base("invalid age " + age)
        {
        }
    }
    class Candidate
    {
        public void checkage(int age)
        {
            if (age < 18)
            {
                throw new AgeException(age);
            }
            else
            {
                Console.WriteLine("candidate is eligible for interview");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Candidate obj = new Candidate();
            try
            {
                obj.checkage(15);
            }
            catch (AgeException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }*/

    class LengthException : SystemException
    {
        public LengthException(string a) : base(a + " Size of field is less")
        {
        }
    }

    public class ArrayInput
    {
        public void getInput()
        {
            int[] arr = new int[5];
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    arr[i] = i;
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Array Exception case completed");
            }
        }
    }

    /*public class User
    {
        public void userDataExc()
        {
            try
            {
                Console.WriteLine("Enter username");
                string name = Console.ReadLine();
                Console.WriteLine("Enter passwrod");
                string psd = Console.ReadLine();
                if (name.Length < 10 && psd.Length < 6)
                {
                    throw new LengthException("username and password");
                }
                else if (psd.Length < 6)
                {
                    throw new LengthException("password");
                }
                else if (name.Length < 10)
                {
                    throw new LengthException("username");
                }
                else
                {
                    Console.WriteLine("Every thing is fine");
                }
            }
            catch (LengthException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("length exception completed");
            }
        }
    }
    internal class Program

    {
        static void Main(string[] args)
        {
            ArrayInput a = new ArrayInput();
            a.getInput();
            User user = new User();
            user.userDataExc();
        }
    }*/


    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

