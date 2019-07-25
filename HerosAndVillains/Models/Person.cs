using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HerosAndVillains.Models
{
    public class People
    {
        public IEnumerable<Person> Persons { get; set; }
    }

    public class Person
    {
        public Person(string fName, string lName, string address, string birthdate, string intrests, byte[] picture)
        {

            PersonID = 0;
            FirstName = fName;
            LastName = lName;
            Address = address;
            BirthDate = Convert.ToDateTime(birthdate);
            Intrests = intrests;
            Picture = picture;
        }

        public Person()
        {
        }

        [Required]
        public Int32 PersonID { get; set; }

        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public String Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(512)]
        public String Intrests { get; set; }

        public byte[] Picture { get; set; }

        public string name { get; set; }
    }
}
