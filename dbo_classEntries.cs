using System;
namespace gradeDistributionMiddleware
{
    public class dbo_classEntries
    {
        public int entry_id { get; set; }
        public string Department { get; set; }
        public string College { get; set; }
        public DateTime Semester { get; set; }
        public int Section { get; set; }
        public string Instructor { get; set; }
        public int A_Frequency { get; set; }
        public int B_Frequency { get; set;}
        public int C_Frequency { get; set;} 
        public int D_Frequency { get; set;}
        public int F_Frequency { get; set;}
        public int a_f_total { get; set; }
        public float GPA { get; set; }
        public int I_frequency { get; set; }
        public int S_frequency { get; set; }
        public int U_frequency { get; set; }
        public int X_frequency { get; set; }
        public int total { get; set; }
    }
}
