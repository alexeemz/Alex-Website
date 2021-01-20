using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlexanderEames_117469494.Models;

namespace AlexanderEames_117469494.Controllers
{
    [Route("/References")]
    public class RecommendationController : Controller        /* /Testimonial/Home  */
    {
        [Route("View")] // ~/Recommendations/View
        public IActionResult Recommendations()
        {
            DB myDb = new DB();
            ViewBag.recommendations = DB.recommendations;
            return View();
        }

        [Route("New", Name = "AddRec")]// ~/Recommendations/New
        [HttpGet]
        public IActionResult Add()
        {

            /* ViewData["Title"] = "Make a Recommendation";
             List<String> RelationshipTypes = new List<string>
                 {
                 "Manager",
                 "Boss",
                 "Co-Worker",
                 "Colleague",
                 "Friend",
                 "Student",
                 "Relative"
                 };

             ViewBag.RelationshipTypes = RelationshipTypes; */

            return View();
        }


        [HttpPost]
        [Route("New", Name = "AddRec")]
        public IActionResult Add(Recommendation rec)
        {
            if (ModelState.IsValid)
            {
                DB myDb = new DB();
                DB.recommendations.Add(rec);
                return View("Thanks", rec);
            }
            else
            {
                return View(rec);
            }
        }
    }
}




       /*[HttpGet]
       [Route("Filtered/{recType?}", Name ="FilteredRec")] //~/Recommendations/Filtered/Boss
        public IActionResult Filtered(string recType)
        {
            List<Recommendation> recs = new List<Recommendation>();
            DB myDB = new DB();
           
            foreach (Recommendation rec in DB.recommendations)
            {
                if (recType == "Boss")
                {
                    if (rec.Relationship == RelationshipType.Boss)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "Manager")
                {
                    if (rec.Relationship == RelationshipType.Manager)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "CoWorker")
                {
                    if (rec.Relationship == RelationshipType.CoWorker)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "Colleague")
                {
                    if (rec.Relationship == RelationshipType.Colleague)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "Friend")
                {
                    if (rec.Relationship == RelationshipType.Friend)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "Student")
                {
                    if (rec.Relationship == RelationshipType.Student)
                    {
                        recs.Add(rec);
                    }
                }

                if (recType == "Relative")
                {
                    if (rec.Relationship == RelationshipType.Relative)
                    {
                        recs.Add(rec);
                    }
                }

            }
            ViewBag.Recommendations = recs;
            return View("FilteredRecs");
        }

    }
}*/
