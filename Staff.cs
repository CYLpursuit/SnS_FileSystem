using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Staff
    {
        protected string PwId;
        protected string StaffName;
        protected  string SeatNo;
        protected  string RoomId;
        protected  string Department;
        protected  string CostCenter;

        public Staff(string[] stringArray)
        {
            PwId = stringArray[0];
            StaffName = stringArray[1];
            SeatNo = stringArray[2];
            RoomId = stringArray[3];
            Department = stringArray[4];
            CostCenter = stringArray[5];
        }

        public override string ToString()
        {
            return PwId + "," + StaffName + "," + SeatNo + "," + RoomId + "," +
                Department + "," + CostCenter+"\n";
        }

        public string GetSeatNo()
        {
            return SeatNo;
        }

        public string GetRoomId()
        {
            return RoomId;
        }

        public string GetStaffName()
        {
            return StaffName;
        }

        public string GetPwId()
        {
            return PwId;
        }

        public string GetDepartment()
        {
            return Department;
        }

        public string GetCostCenter()
        {
            return CostCenter;
        }

        public string SetSeatNo(string seatno)
        {
            return SeatNo = seatno;
        }

        public string SetRoomId(string roomid)
        {
            return RoomId = roomid;
        }

        public string SetStaffName(string staffname)
        {
            return StaffName = staffname;
        }

        public string SetPwId(string pwid)
        {
            return PwId = pwid;
        }

        public string SetDepartment(string department)
        {
            return Department = department;
        }

        public string SetCostCenter(string costcenter)
        {
            return CostCenter = costcenter;
        }

        string test;
        public string Test
        {
            get
            { 
                return test;
            }
            set
            { 
                test = value;
            }
        }
       
    }
}

