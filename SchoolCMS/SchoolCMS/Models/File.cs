
using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolCMS.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public DateTime UploadDateTime { get; set; }
        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; }

        public virtual ICollection<InformationSource> InformationSources { get; set; }

        //public News News {get; set;}



        public string FilePath
        {
            get { return "~/App_Data/Uploads/"+FileName + Extension; }
        }
       
    }
}