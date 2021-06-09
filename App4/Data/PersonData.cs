using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App4.Data
{

    [Table("People")]
    public class PersonData
    {
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ManyToMany(typeof(PersonEvent))]
        public List<EventData> Events { get; set; }

    }
}