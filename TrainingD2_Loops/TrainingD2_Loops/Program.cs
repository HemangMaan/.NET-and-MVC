using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingD2_Loops
{
    internal class Program
    {
        /*public static void WoodMeasurments(int[,] measurements)
        {
            foreach(var measurement in measurements)
            {
                Console.WriteLine(measurement);
            }
        }*/
        static void Main(string[] args)
        {
            /*int[,] m = new Int32[5,3];
            m[0,0] = 1;
            m[0,1] = 1;
            m[0, 2] = m[0,0]*m[0,1];
            m[1,0] = 2;
            m[1,1] = 2;
            m[1,2] = m[1, 0] * m[1, 1];
            m[2,0] = 3;
            m[2,1] = 4;
            m[2,2] = m[2, 0] * m[2, 1];
            m[3,0] = 4;
            m[3,1] = 5;
            m[3,2] = m[3, 0] * m[3, 1];
            m[4,0] = 5;
            m[4,1] = 5;
            m[4,2] = m[4, 0] * m[4, 1];

            int[][] ma = new int[4][]
            {
                new int[] {55, 67, 74 },
                new int[] {33, 59,76},
                new int[] {98, 87,57,98 },
                new int[] {45,53}
            };
            int[] arr = { 7, 6, 5, 4, 3, 2, 1 };
            int[] arr1 = new int[4];
            Array.Copy(arr,arr1,3);
            for(int i=0; i<arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }
            int[,] ap = new Int32[3, 4];
            ap[2,3] = 1;
            ap[1, 1] = 2;
            ap[2, 1] = 3;
            foreach(int i in ap)
            {
                Console.WriteLine(i);
            }*/
            /*int [] arr2 = { 12,23,11,19,33,55,22};
            int [] arr3 = new int[8];
            Array.Copy(arr2,3,arr3,2,4);
            foreach(int Ar in arr3)
            {
                Console.WriteLine(Ar);
            }
            for(int i=0; i<10; i++)
            {
                if (i == 5)
                    break;
                Console.WriteLine(i);
            }
            string name = "sandeep";
            string myname = "sandeep";
            Console.WriteLine(name==myname);
            Console.WriteLine(name.Equals(myname));*/
            /*int[] arr = { 12, 23, 11, 19, 33, 55, 22 };
            //1. sum of array
            int sum=0,temp;
            foreach(int a in arr)
            {
                sum += a;
            }
            Console.WriteLine(sum);
            //2. sorting of array
            for(int j=1; j<arr.Length-1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    j = -1;
                }
            }
            foreach(int a in arr)
            {
                Console.WriteLine(a);
            }
            //3. even number
            foreach(var a in arr)
            {
                if (a % 2 == 0)
                {
                    Console.WriteLine(a);
                }
            }
            //4. color check
            string color = Console.ReadLine();
            switch (color)
            {
                case "Red":
                    Console.WriteLine("Red color is written");
                    break;
                case "Green":
                    Console.WriteLine("Green color is written");
                    break;
                case "Blue":
                    Console.WriteLine("Blue color is written");
                    break;
                default: 
                    Console.WriteLine("wrong color");
                    break;
            }
            //5. 2D array
            int [,] height_weight_speed = new int[2,3];
            height_weight_speed[0,0] = 5;
            height_weight_speed[0,1] = 45;
            height_weight_speed[0, 2] = 3;
            height_weight_speed[1, 0] = 4;
            height_weight_speed[1, 1] = 50;
            height_weight_speed[1, 2] = 6;
            for(int i=0; i<2; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Console.Write(height_weight_speed[i,j]+" ");
                }
                Console.WriteLine();
            }*/

            /*string[,] details = new string[5, 3];
            for (int i = 0; i < 5; i++)
            {
                details[i, 0] = Console.ReadLine();
                details[i, 1] = Console.ReadLine();
                details[i, 2] = Console.ReadLine();
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(details[i, j] + " ");
                }
                Console.WriteLine();
            }*/
            Console.WriteLine("Enter the number of string to add");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[n];
            Console.WriteLine("Enter the string: ");
            string p;
            string rev = "";
            int i = 0;
            while (i<n)
            {
                p=Console.ReadLine();
                rev = "";
                while (p.Length < 3)
                {
                    Console.WriteLine("Length is less than 3 write again");
                    p = Console.ReadLine();
                }
                int l = p.Length - 1;
                while (l >= 0)
                {
                    rev = rev + p[l];
                    l--;
                }
                if (p == rev)
                {
                    Console.WriteLine("wooohooo The stirng is palindrome");
                }
                arr[i] = p;
                i++;
            }
            string temp = "";
            for (i = 0; i <= arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (string.Compare(arr[i],arr[j])>0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }
        }
    }
}
