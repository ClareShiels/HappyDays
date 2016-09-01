using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyDaysOne.Models
{
    public class Address
    {
        //PK
        public int ID { get; set; }
        //fk to child 
        [ForeignKey("Child")]
        public int ChildID { get; set; }
        
        //fk to club
        [ForeignKey("Club")]
        public int ClubID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public string PostCode { get; set; }

        //navigation properties, lazy loading 1:1 Relationship

        public virtual Child Child { get; set; }

        public virtual Club Club { get; set; }
    }
}