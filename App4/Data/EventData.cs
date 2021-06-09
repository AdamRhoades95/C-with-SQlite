using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App4.Data
{
    [Table("Events")]
    public class EventData
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Host { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        [ManyToMany(typeof(PersonEvent))]
        public List<PersonData> Participants { get; set; }

    }
}
