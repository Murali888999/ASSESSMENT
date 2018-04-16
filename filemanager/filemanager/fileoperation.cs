using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;

namespace filemanager
{
    class fileoperation
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static String directory = "";
        /// <summary>
        /// this method is for to show all files from selected directory
        /// </summary>
        public static void Opertion()
        {
            try
            {
                Console.WriteLine("Enter Directory Name");
                directory = Console.ReadLine();
                if (Directory.Exists(directory))
                {
                    string[] dirs = Directory.GetDirectories(directory);
                    Console.WriteLine("The files are avaliable in " + directory + " is:");
                    foreach (string dir in dirs)
                    {
                        Console.WriteLine(dir);
                    }
                }
                else
                {
                    Console.WriteLine("directory not avaliable!");
                }
            }catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this method is for creating file to particular path
        /// </summary>
        public static void FileUpload()
        {
            try
            {
                Console.WriteLine("Enter filename with directory");
                String s = Console.ReadLine();
                if (File.Exists(s))
                {
                    Console.WriteLine("file already avaliable");
                }
                else
                {
                    File.Create(s);
                    Console.WriteLine("file created");
                }
            }catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this method is for creating sub-folder.
        /// </summary>
        public static void CreateSubFolder()
        {
            try
            {
                Console.WriteLine("Enter Directory");
                String s = Console.ReadLine();
                if (Directory.Exists(s))
                {
                    Console.WriteLine("Directory Already avaliable");
                }
                else
                {
                    Directory.CreateDirectory(s);
                    Console.WriteLine("created Directory");
                }
            }
            catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this method is for deleting the particular file
        /// </summary>
        public static void DeleteFile()
        {
            try
            {
                Console.WriteLine("Enter file loction to delete");
                String s = Console.ReadLine();
                if (File.Exists(s))
                {
                    File.Delete(s);
                    Console.WriteLine("'File deleted");
                }
                else
                {
                    Console.WriteLine("File not avaliable!");
                }
            }catch(Exception e)
            {
                log.Info(e.Message);
            }
        }
        /// <summary>
        /// this is the method for seraching particular file.
        /// </summary>
        public static void SerachFile()
        {
            try
            {
                Console.WriteLine("Enter file loction");
                String s = Console.ReadLine();
                if (File.Exists(s))
                {
                    Console.WriteLine("File is avaliable");
                }
                else
                {
                    Console.WriteLine("File not avaliable!");
                }
            }
            catch(Exception e)
            {
                log.Error(e.Message);
            }
        }
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
              //  Opertion();
           // DeleteFile();
            //SerachFile();
           FileUpload();
            Console.ReadLine();
        }
    }
}