using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ArrayList
{
    class Program
    {
        static SqlConnection con;
        static string DatabaseName="PaymentsInfo";
        static string tableName = "Payments";
        static SqlCommand sql;
        static SqlDataReader reader;
        static void Main(string[] args)
        {
            /*
            int[] duplicateNumber =new int[5] ;


            for(int i=0;i<5;i++)
            {
                Console.Write("Enter Number:");
                var  str = Console.ReadLine();
                duplicateNumber[i] = Int32.Parse(str);
            }

            Console.WriteLine("Origional Numbers are: ");
            foreach (int number in duplicateNumber)
            {
                Console.WriteLine(number);

            }


            List<int> outputList = RemoveDuplicates( duplicateNumber);
            Console.WriteLine("Unique Number are: ");
            foreach(int number in outputList)
            {
                Console.WriteLine(number);
                
            }

            Console.WriteLine("Enter string to get character count for t");
            String CharCountString = Console.ReadLine();
            Console.WriteLine("'Number of characters t in string: " + WordCount(CharCountString));
            

            Console.WriteLine("Fibonacci Series is:");
            FibonacciSerries(10);

            

            Console.WriteLine("Swap numbers:");
            swapnum(5, 7);

            Console.ReadLine();*/

            ConnectDatabase("HIBAIL57666\\SQLEXPRESS", "master", "sa", "Aditi01*");
            con.Close();
            
            if (!DatabaseConnectionStatus("HIBAIL57666\\SQLEXPRESS", DatabaseName, "sa", "Aditi01*"))
            {
                ConnectDatabase("HIBAIL57666\\SQLEXPRESS", "master", "sa", "Aditi01*");
                CreateDatabase(DatabaseName);
            }
            else
            {
                ConnectDatabase("HIBAIL57666\\SQLEXPRESS", "master", "sa", "Aditi01*");
            }

            InsertRecord("1", 100, 'C', "Desc", "");
            RetrievePaymentRecords();
        }

        public static bool DatabaseConnectionStatus(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                var connetionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password}";
                con = new SqlConnection(connetionString);
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception e)
            {   
                return false;
            }
        }

        static void ConnectDatabase(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                var connetionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password}";
                con = new SqlConnection(connetionString);
                con.Open();
                sql = new SqlCommand($"Create Database {DatabaseName};", con);
            }
            catch (Exception e)
            {
                throw new Exception("Issue with Database Connection");
            }
        }

        public static void CreateDatabase(string DatabaseName)
        {
            ConnectDatabase("HIBAIL57666\\SQLEXPRESS", "master", "sa", "Aditi01*");
            
            string sqlCommand = $"Create Database {DatabaseName};";
            sql = new SqlCommand($"Create Database {DatabaseName};", con);
            sql.ExecuteNonQuery();

            sql.CommandText = $"Create table [dbo].{tableName} ( CustId nvarchar(128),Amt int,Type char,Description nvarchar(128))";
            sql.ExecuteNonQuery();
        }

        public static void InsertRecord(string custId,int amt,char type,string description,string date)
        {
            sql.CommandText = $"INSERT INTO [dbo].[Payments] Values ('{custId}',{amt},'{type}','{description}')";
            sql.Connection = con;
            sql.ExecuteNonQueryAsync();
        }

        public static void RetrievePaymentRecords()
        {
            sql.CommandText = $"select CustId from {tableName} ";

            reader = sql.ExecuteReader();
            Console.WriteLine("Database values are: ");
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(0));
            }
            Console.ReadLine();
        }


        static List<int> RemoveDuplicates( int[] numbers)
        {
            
            List<int> output = new List<int>();
            
            foreach(int number in numbers)
            {
                if (!output.Contains(number))
                {
                    output.Add(number);
                }
            }
            return output;
        }

        static int WordCount(string st)
        {
            string[] words;

            words = st.Split(' ');

            var wordCount = 0;

            foreach(string word in words)
            {
                if (word.ToLower().Contains("t"))
                {
                    wordCount++;
                }
            }

            return wordCount;
        }

        static void FibonacciSerries(int n)
        {
            int a = 1;int b = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);

            for(int i=3;i<=n;i++)
            {
                var c= a+b;
                Console.WriteLine(c);
                a = b;
                b = c;
            }
        }

        static void swapnum(int a,int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("After swap a: " + a + "b: " + b);
        }
    }
}
