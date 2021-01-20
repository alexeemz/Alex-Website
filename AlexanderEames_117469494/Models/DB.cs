using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlexanderEames_117469494.Models
{
  
    public class DB
    {
        public static List<Recommendation> recommendations = new List<Recommendation>()
        {
             new Recommendation()
            {
                Name = "Lana Illiano",
                Title = "Dir. Web Operations - Northwell Health",
                Phone  = "N/A",
                Text = "Lana was my supervisor and head of the web production team that I worked with during my 6 month internship with Northwell Health",
                Email = "uilliano@northwell.edu",
                Location = "New York, USA"
            },
            new Recommendation()
            {
                Name = "Rory MacCarthy",
                Title = "Manager - Glandore Inn, Ireland",
                Phone  = "+353872931915",
                Text = "I have worked closely with Rory for over four years at the Glandore Inn where he was involved in my training and managing." +
                "\n",
                Email = "rorymaccarthy72@gmail.com",
                Location = "West Cork, Ireland"
            },
            new Recommendation()
            {
                Name = "Peter Hayward-Butt",
                Title = "CEO - Ethos Capital, Johannesburg",
                Text = "I spent a large amount of time working and staying with Peter whilst completing my internship with Ethos Private Equity.",
                Phone = "+27829221398",
                Email = "phayward-butt@ethos.co.za",
                Location = "Johannesburg, South Africa"
            },
            new Recommendation()
             {
                Name = "William Bartley",
                Title = "House Master - Bandon Grammar School",
                Text = "William was both my teacher and house master whilst I was boarding in Bandon Grammar School. I worked closely with him inside the classroom, as a student, and in other matters in my role as mentor and prefect in 5th and 6th year respectively.",
                Phone = "+353872905582",
                Email = "wbartley@bgsmail.ie"
            }
        };
    }

    public enum RelationshipType
    {
        Manager,
        Boss,
        [Display(Name ="Co-Worker")]
        CoWorker,
        Colleague,
        Friend,
        Student,
        Relative,
        Teacher
    }


    public class Recommendation : IValidatableObject
    {

        // This validation stops people from calling me smelly
        public class NotSmelly : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                String text = (String)value;
                if (!String.IsNullOrEmpty(text)) //I had to nest the below if statement as null reference exception if text was left empty
                {
                    if (text.Contains("Alex is smelly"))
                    {
                        return new ValidationResult("Please don't say that I am smelly :(");
                    }
                }
                return  ValidationResult.Success;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name == "Kate Eames") //This is my mum's name
            {
                yield return new ValidationResult("Mum! Stop embarrassing me!", new[] { "Name" }); //If my mum leaves a recommendation it will cause this error
            }
        }


        [Display(Name = "Your name: ")]
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Your name must be at least three letters.")]
        public string Name { get; set; }

        [Display(Name = "Your job title: ")]
        [Required(ErrorMessage = "Please enter your job title.")]
        [StringLength(35,MinimumLength = 3, ErrorMessage = "Job title must be between 3 and 35 characters.")]
        public string Title { get; set; }

        [Display(Name = "Your relationship to me: ")]
       /* [Required(ErrorMessage = "Please state your relationship to me.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Please enter your relationship to me. This must be between 3 and 25 characters.")] */
       public string Phone { get; set; }

        [Display(Name = "Write your recommendation here: ")]
        [Required(ErrorMessage = "Don't forget to write your recommendation!")]
        [NotSmelly]
        public string Text { get; set; }

        [Display(Name = "Your email address : ")]
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please check that you have entered a valid email address.")]
        public string Email { get; set; }

        public string Location { get; set; }

        
    }

}
