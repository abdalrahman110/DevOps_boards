using dotnetAPI.Context;
using dotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        //to make changes in database:-
        private readonly TeamLeaderDbContext _context = new TeamLeaderDbContext();


        //get api to retrieve all Projects : ---------- DB done
        [HttpGet]
        public ActionResult<List<Project>> GetAll()
        {
            return _context.Projects.ToList();
        }


        //get api to retrive Projects with specific Id : ---------- DB done
        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {

            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        //post api to create new Project : ---------- DB done
        [HttpPost]
        public ActionResult<Project> Addproject(Project project)
        {
            //LeaderServices.Addproject(project);
            if (project == null)
            {
                return BadRequest();
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok(_context.Projects.ToList());  //returns code 200 and the all list of Projects
            //return CreatedAtAction(nameof(GetAll), new { id = project.Id }, project);
        }

        //update api to update Project data

        [HttpPut]
        public ActionResult Updateproject(Project newproject)
        {
            if (newproject == null)
            {
                return NotFound("new projectvv error");
            }
            //make sure if the project with id is existed
            var currentproject = _context.Projects.Find(newproject.Id);
            if (currentproject == null)
            {
                return NotFound("Project not found");
            }

            currentproject.Id = newproject.Id;
            currentproject.PName = newproject.PName;


            _context.SaveChanges();
            return Ok(_context.Projects.ToList()); //returns code  200 and the all list of Projects
        }


        //delete api to remove project from the list : ---------- DB done
        [HttpDelete("{id}")]
        public ActionResult Deleteproject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return Ok(_context.Projects.ToList());//returns code  200 and the all list of Projects

        }
    }
}
