﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanStudyOptionsLibrary.Models
{
    public class CourseModel
    {


        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Semester { get; set; }
        public string PreRequisite { get; set; }
        public bool Compulsory { get; set; }
        public int Credits { get; set; }
        public int Year { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public string CompulsoryYN
        {
            get
            {
                return Compulsory == true ? "Yes" : "No";
            }
        }
    }
}
