using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HappyDaysOne.Models;

namespace HappyDaysOne.ViewModels
{
    public class TopActivity
    {
        public AgeGroup AgeGroup { get; set; }
        
        public int ActivityCount { get; set; }
    }
}
