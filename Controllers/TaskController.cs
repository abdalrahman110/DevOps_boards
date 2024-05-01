using dotnetAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //to make changes in database:-
        private readonly TeamLeaderDbContext _context = new TeamLeaderDbContext();


        //get api to retrieve all Tasks : ---------- DB done
        [HttpGet]
        public ActionResult<List<Models.Task>> GetAll()
        {

            return _context.Tasks.ToList();
        }


        //get api to retrive Tasks with specific Id : ---------- DB done
        [HttpGet("{id}")]
        public ActionResult<Models.Task> Get(int id)
        {

            var Task = _context.Tasks.Find(id);
            if (Task == null)
            {
                return NotFound();
            }
            return Task;
        }

        //post api to create new Task : ---------- DB done
        [HttpPost]
        public ActionResult<Models.Task> AddTask(Models.Task Task)
        {
            //LeaderServices.AddTask(Task);
            if (Task == null)
            {
                return BadRequest();
            }
            _context.Tasks.Add(Task);
            _context.SaveChanges();
            return Ok(_context.Tasks.ToList());  //returns code 200 and the all list of Tasks
            //return CreatedAtAction(nameof(GetAll), new { id = Task.Id }, Task);
        }

        //update api to update Task data

        [HttpPut]
        public ActionResult UpdateTask(Models.Task newTask)
        {
            if (newTask == null)
            {
                return NotFound("new Task error");
            }
            //make sure if the Task with id is existed
            var currentTask = _context.Tasks.Find(newTask.Id);
            if (currentTask == null)
            {
                return NotFound("Task not found");
            }

            currentTask.Id = newTask.Id;
            currentTask.Title = newTask.Title;
            currentTask.Description = newTask.Description;
            currentTask.AssignedTo = newTask.AssignedTo;
            currentTask.AssignedTo = newTask.ProjectId;
            currentTask.Status = newTask.Status;


            _context.SaveChanges();
            return Ok(_context.Tasks.ToList()); //returns code  200 and the all list of Tasks
        }


        //delete api to remove Task from the list : ---------- DB done
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var Task = _context.Tasks.Find(id);
            if (Task == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(Task);
            _context.SaveChanges();
            return Ok(_context.Tasks.ToList());//returns code  200 and the all list of Tasks

        }
    }
}
