using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class Page
    {
        public int Id { get; set; }

        public virtual User Author { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        //pliki podczepione

    }
}