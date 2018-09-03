using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class FileCRUD
    {
        //CRUD()
        public static int CRUD(List<Staff> L, string file)
        {
            Console.WriteLine("Input the instruction\n1:Insert;\n2:Retrieve;\n3:Update;\n4:Delete;\n*:exit");
            string f = Console.ReadLine();
            if(f=="1"){
                InsertData(L, file);
            }
            else if (f == "2") {
                Retrieve(L, file);
            }
            else if (f == "3") {
                Update(L,file);
            }
            else if (f == "4") {
                Delete(L,file);
            }
            else if (f == "*")
            {
                return 0;
            }
            else { return 0; }
            return 1;
        }


        //InsertData()
        public static List<Staff> InsertData(List<Staff> L, string file)
        {
            Staff s;
            string line;
            string[] stringArray = new string[6];
            char[] charArray = new char[] { ',' };
            StreamWriter sw;
            sw = File.AppendText(file);

            Console.WriteLine(@"input your information as the famart:\\nPwId,StaffName,SeatNo,RoomId,Department,CostCenter\\nClose with # in next line");
            line = Console.ReadLine();
            
            while (line != "#")
            {
                stringArray = line.Split(charArray);
                
                s = new Staff(stringArray);

                    L.Add(s);

                    sw.WriteLine(s.ToString());
                    line = Console.ReadLine();
            }
            CodeControl.PrintFinish();                
             
            sw.Close();
            return L;
        }

        //Retrieve()
        public static List<Staff> Retrieve(List<Staff> L, string file)
        {
            Console.WriteLine("choose the index number\n1:PwId;\n2:StaffName;\n3:SeatNo;\n4:for firstname");
            string f=Console.ReadLine();
            Console.WriteLine("input the index data:");
            string str = Console.ReadLine();
            List<Staff> result = null;

            switch (f)
            {
                case "1": result = (from s in L where s.GetPwId() == str select s).ToList<Staff>(); break;
                case "2": result = (from s in L where s.GetStaffName() == str select s).ToList<Staff>(); break;
                case "3": result = (from s in L where s.GetSeatNo() == str select s).ToList<Staff>(); break;
                case "4": result = (from s in L where (s.GetStaffName().StartsWith(str)) select s).ToList<Staff>(); break;
                default: CodeControl.PrintError(); break;
            }
            

            foreach (Staff s in result)
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine("there are(is) {0} records matched.", result.Count);

            return result;
        }


        //Update()
        public static List<Staff> Update(List<Staff> L, string file)
        {
                Console.WriteLine("choose the index number you want to update\n1:PwId;\n2:StaffName;\n3:SeatNo");
                string f = Console.ReadLine();
                
                switch (f)
                {
                    case "1":
                        Set(L,file,"1");
                        break;
                    case "2":
                        Set(L,file,"2");
                        break;
                    case "3":
                        Set(L,file,"3");     
                        break;
                    default: CodeControl.PrintError(); break;
                }

            return L;
        }

        public static void Set(List<Staff> L, string file, string set)
        {
            Console.WriteLine("Let's do the Retrieve first.");
            List<Staff> result = Retrieve(L, file);
            string stringArray = "RoomId,StaffName,SeatNo,PwId,Department,CostCenter\n";
            Console.WriteLine("input the update data:");
            string str = Console.ReadLine();

            for (int i = 0; i < L.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (L[i] == result[j])
                    {
                        switch (set)
                        {
                            case "1": L[i].SetPwId(str); break;
                            case "2": L[i].SetStaffName(str); break;
                            case "3": L[i].SetSeatNo(str); break;
                        }
                    }
                }
            }

            File.Delete(file);
            File.AppendAllText(file, stringArray);

            foreach (var s in L)
            {
                File.AppendAllText(file, s.ToString());
            }
        }

        //Delete()
        public static List<Staff> Delete( List<Staff> L, string file)
        {
            Console.WriteLine("input the instruction\n1:rows;\n2;Retrieve");
            string f = Console.ReadLine();

            string stringArray = "PwId,StaffName,SeatNo,RoomId,Department,CostCenter\n";

            switch (f)
            {
                case "1": 
                    Console.WriteLine("the begining row:");
                    int br=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("the ending row:");
                    int er=Convert.ToInt32(Console.ReadLine());

                    File.Delete(file);

                    File.AppendAllText(file, stringArray);

                    for (int i = 0; i <L.Count; i++)
                        {
                            if ((i >= 0 && i < br-1) || (i > er-1 && i <= L.Count-1))
                                
                                File.AppendAllText(file, L[i].ToString());
                        }
                    break;
                case "2":
                    Console.WriteLine("Let's do the Retrieve first.");
                    List<Staff> result = Retrieve(L,file);

                    for (int i = 0; i < L.Count; i++)
                              {
                                  for (int j = 0; j < result.Count; j++)
                                  {
                                      if (L[i] == result[j])
                                      {
                                          L.Remove(L[i]);
                                      }
                                  }
                              }
                        File.Delete(file);
                        File.AppendAllText(file, stringArray);
                        for (int k = 0; k < L.Count; k++)
                        {
                            File.AppendAllText(file, L[k].ToString());
                        }

                        CodeControl.PrintFinish();
                    break;
                default: CodeControl.PrintError(); break;
            }            

            return L;
        }

    }
}
