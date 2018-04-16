using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
namespace joins
{
    class alljoins
    {
        
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static SqlConnection con;
        static SqlCommand cmd;
        /// <summary>
        /// this method is for leftjoin
        /// left join: it will return all records from left table and matchable records from right table.
        /// </summary>
        public static void leftjoin()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                string s = "select star.name, moon.id from star left join moon on star.id=moon.id";
                cmd = new SqlCommand(s, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("=================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                    }
                    Console.WriteLine();
                }
            }catch(Exception e)
            {
                log.Info(e.Message);
            }  
            
        }
    
        /// <summary>
        /// this method is for rigth join
        /// right join:it will return all records from right table and matchable records from left table
        /// </summary>
        public static void rightjoin()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                string s = "select star.name, moon.id from star right join moon on star.id=moon.id";
                cmd = new SqlCommand(s, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("=================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this is method is for fulljoin
        /// full join:it will return matchable records from both the tables.
        /// </summary>
        public static void fulljoin()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                string s = "select star.name, moon.id from star full join moon on star.id=moon.id";
                cmd = new SqlCommand(s, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("=================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this method is for inner join
        /// inner join:matchble records from both the table
        /// </summary>
        public static void innerjoin()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                string s = "select star.name, moon.id from star inner join moon on star.id=moon.id";
                cmd = new SqlCommand(s, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("=================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this method is selfjoin
        /// self join:a table matches with itself
        /// </summary>
        public static void selfjoin()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                string s = "select star.name, star.id from star";
                cmd = new SqlCommand(s, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t" + "\t");
                }
                Console.WriteLine();
                Console.WriteLine("=================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        public static void Main(string[] args)
            {
            XmlConfigurator.Configure();
            
               //leftjoin();
              //rightjoin();
             //fulljoin();
            //innerjoin();
            selfjoin();
                Console.ReadLine();       
            }
    }
}