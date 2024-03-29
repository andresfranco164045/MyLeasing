﻿using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public Property Property { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? "https://myleasingfranco.azurewebsites.net/images/Properties/noImage.png"
            : $"https://myleasingfranco.azurewebsites.net{ImageUrl.Substring(1)}";
    }

}
