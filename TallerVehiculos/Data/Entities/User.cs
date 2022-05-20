﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using TallerVehiculos.Enums;
using TallerVehiculos.Models;

namespace TallerVehiculos.Data.Entities {



    public class User : IdentityUser
    {


        [MaxLength(20)]

        [Required]

        public string Document { get; set; }



        [Display(Name = "First Name")]

        [MaxLength(50)]

        [Required]

        public string FirstName { get; set; }



        [Display(Name = "Last Name")]

        [MaxLength(50)]

        [Required]

        public string LastName { get; set; }



        [MaxLength(100)]

        public string Address { get; set; }



        [Display(Name = "Image")]

        public Guid ImageId { get; set; }

        public Ciudades City { get; set; }

        //TODO: Pending to put the correct paths 

        [Display(Name = "Image")]

        public string ImageFullPath => ImageId == Guid.Empty

            ? $"https://localhost:44390/images/noimage.png"

            : $"https://tallervehiculosdemo.blob.core.windows.net/users/{ImageId}";



        [Display(Name = "User Type")]

        public UserType UserType { get; set; }



        //public City City { get; set; }



        [Display(Name = "User")]

        public string FullName => $"{FirstName} {LastName}";



        [Display(Name = "User")]

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }
}


