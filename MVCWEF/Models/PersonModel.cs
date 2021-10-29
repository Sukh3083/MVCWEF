using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWEF.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime DOB { get; set; }


    }
}
