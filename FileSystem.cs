using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class FileSystem
    {
        //DirInfo()
        public static void DirInfo(string path) {
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.Write("now directory:");

            Console.WriteLine(dir);
            //获取文件夹 
            Console.Write("folder(s):");
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Console.Write(d.Name);
                CodeControl.PrintTab();
            }
            Console.WriteLine();
            //获取文件
            Console.Write("file(s):");
            FileInfo[] dirf = dir.GetFiles("*.*");
            foreach (FileInfo fi in dirf)
            {
                Console.Write(fi.Name);
                CodeControl.PrintTab();
            }
            Console.WriteLine();
            CodeControl.PrintLine();
        }

        //GoBack()
        public static string GoBack(string path) {
            
            FileSystem.DirInfo(path + "\\..");
            return path + "\\..";
        }

        //GoInto()
        public static string GoInto(string path, string filename)
        {
            FileSystem.DirInfo(path + "\\" + filename);
            
            return path + "\\" + filename;
        }

        //FileExists()
        public static string FileExists(string file)
        {
            while (!File.Exists(file))
            {
                Console.WriteLine("File do not exists. Try again.");
                Console.WriteLine("input the instructon:\n1;continue;\n2:exit");
                string f = Console.ReadLine();
                switch (f) {
                    case "1":
                        Console.WriteLine("File do not exists. Try again.");
                        file = Console.ReadLine();
                        file = @"D:\project" + "\\" + file;
                        break;
                    case "2": return null;
                    default: CodeControl.PrintError(); break;
                }
            }
            Console.WriteLine("File do exist.");
            Console.WriteLine();
            return file;
        }
        

        //GetData()
        public static List<Staff> GetData(string file)
        {
            int i = 0;
            string line;
            string[] stringArray = new string[6];
            char[] charArray = new char[] { ',' };
            List<Staff> L = new List<Staff>();
   
            try
            {
                if(file != null){
                FileStream aFile = new FileStream(file, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);

                line = sr.ReadLine();
                stringArray = line.Split(charArray);
                Console.WriteLine("It shows:");

                foreach (string column in stringArray)
                {
                    Console.Write("{0,-10}", column);
                }
                Console.WriteLine();
                line = sr.ReadLine();
                Console.WriteLine("{0}", line);
                while (line != null)
                {
                    stringArray = line.Split(charArray);
                    
                    Staff s = new Staff(stringArray);
                    L.Add(s);
                  
                    i++;
                    line = sr.ReadLine();
                    Console.WriteLine("{0}", line);
                }
                sr.Close();
            }else{
                Console.WriteLine("file is null.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("IOException.");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        
            return L;
        }
    }
}
