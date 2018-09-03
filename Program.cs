using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static int Main(string[] args)
        {
            
            //List-Object
            List<Staff> L = new List<Staff>();
            Console.WriteLine("Welcome.");
            ConsoleApplication1.CodeControl.PrintLine();

            //DefaultFile
            const string DefaultFile = @"D:\project";
            string path = DefaultFile;

            //DirInfo
            FileSystem.DirInfo(DefaultFile);

            while(true){
            //Instruction()
            Console.WriteLine("Input the instruction:\n1:go into a cataloge;\n2:go back the cataloge;\n3:open a file;\n*:exit");
            string F = Console.ReadLine();

            //switch
            switch (F)
            {
                case "1": Console.WriteLine("please input the foldername:");
                    string folder = Console.ReadLine();
                    path = FileSystem.GoInto(path, folder);
                    break;
                case "2": path = FileSystem.GoBack(path);
                    break;
                case "3": Console.WriteLine("please input the filename:");
                    string file = Console.ReadLine();
                    file = DefaultFile + "\\" + file;
                    file = FileSystem.FileExists(file);
                    if (File.Exists(file))
                    {
                        L = FileSystem.GetData(file);
                        FileCRUD.CRUD(L, file);
                    }
                    else {
                        CodeControl.PrintLine();
                        return 0; }
                    break;
                case "*": CodeControl.PrintLine();
                    return 0;
                default: CodeControl.PrintError(); break;
            }
            }

            Console.ReadKey();
            return 0;
        }
    }
}
