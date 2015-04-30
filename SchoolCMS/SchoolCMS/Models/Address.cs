using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public string PostCode { get; set; }
    }
}