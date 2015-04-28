using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class FileExtension
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; }
    }
}