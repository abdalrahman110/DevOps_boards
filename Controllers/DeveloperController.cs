using dotnetAPI.Context;
using dotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {

        //to make changes in database:-
        private readonly TeamLeaderDbContext tlcont = new TeamLeaderDbContext();


        //get api to retrieve all developers : ---------- DB done
        [HttpGet]
        public ActionResult<List<Developer>> GetAll()
        {
            return tlcont.Developers.ToList();
        }


        //get api to retrive developers with specific Id : ---------- DB done
        [HttpGet("{id}")]
        public ActionResult<Developer> Get(int id)
        {

            var dev = tlcont.Developers.Find(id);
            if (dev == null)
            {
                return NotFound();
            }
            return dev;
        }

        //post api to create new developer : ---------- DB done
        [HttpPost]
        public ActionResult<Developer> AddDev(Developer dev)
        {
            //LeaderServices.AddDev(dev);
            if (dev == null)
            {
                return BadRequest();
            }
            tlcont.Developers.Add(dev);
            tlcont.SaveChanges();
            return Ok(tlcont.Developers.ToList());  //returns code 200 and the all list of developers
            //return CreatedAtAction(nameof(GetAll), new { id = dev.Id }, dev);
        }

        //update api to update developer data

        [HttpPut]
        public ActionResult UpdateDev(Developer newDev)
        {
            if (newDev == null)
            {
                return NotFound("new devvv error");
            }
            //make sure if the dev with id is existed
            var currentDev = tlcont.Developers.Find(newDev.Id);
            if (currentDev == null)
            {
                return NotFound("developer not found");
            }

            currentDev.Id = newDev.Id;
            currentDev.Name = newDev.Name;
            currentDev.Title = newDev.Title;
            currentDev.Salary = newDev.Salary;
            currentDev.StartingDate = newDev.StartingDate;
            currentDev.ProjectId = newDev.ProjectId;
            currentDev.ProjectName = newDev.ProjectName;

            tlcont.SaveChanges();
            return Ok(tlcont.Developers.ToList()); //returns code  200 and the all list of developers
        }


        //delete api to remove dev from the list : ---------- DB done
        [HttpDelete("{id}")]
        public ActionResult DeleteDev(int id)
        {
            var dev = tlcont.Developers.Find(id);
            if (dev == null)
            {
                return NotFound();
            }
            tlcont.Developers.Remove(dev);
            tlcont.SaveChanges();
            return Ok(tlcont.Developers.ToList());//returns code  200 and the all list of developers

        }
    }
}
