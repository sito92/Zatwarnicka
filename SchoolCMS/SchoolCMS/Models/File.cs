﻿
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


        public string FileName { get; set; }


        public string Extension { get; set; }


        [Display(Name = "Rozmiar")]
        public int Size { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime UploadDateTime { get; set; }
        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; }

        public virtual ICollection<InformationSource> InformationSources { get; set; }

        //public News News {get; set;}

        public int AuthorId {get; set; }

        public string FilePath
        {
            get { return "~/App_Data/Uploads/"+FileName + Extension; }
        }
       
    }
}