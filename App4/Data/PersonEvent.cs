using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App4.Data
{
    [Table("Attendance")]
    public class PersonEvent
    {
        [PrimaryKey, AutoIncrement]
        public int EventKey { get; set; }
        
        public string PersonName { get; set; }

        
        public string EventTitle { get; set; }

        public string RSVPResponse { get; set; }
    }
}
