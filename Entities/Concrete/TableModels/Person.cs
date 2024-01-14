﻿using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => FirstName+ "" + LastName;
        public DateTime DateofBirth { get; set; }
        public string Adress{ get; set; }
        public string Email { get; set; }
        public string Website{ get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string CVPath { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [DisplayName("Download File")]
        public IFormFile CvFile { get; set; }
        public Position Position { get; set; }
        


    }
}
