
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolCMS.Models
{
    public class File
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwa pliku jest wymagana")]
        [Display(Name = "Nazwa pliku")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "Rozszerzenie jest wymagane")]
        [Display(Name = "Rozszerzenie")]
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