using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_7_Uppgift_2_Grupp_2
{
    internal class BookingNode
    {
        public DateTime Time { get; set; }
        public string PatientName { get; set; }

        public BookingNode? Left { get; set; }
        public BookingNode? Right { get; set; }

        public BookingNode(DateTime time, string patientName) 
        {
            Time = time;
            PatientName = patientName;
        }

        public override string ToString()
        {
            return $"{Time} {PatientName}";
        }
    }
}
