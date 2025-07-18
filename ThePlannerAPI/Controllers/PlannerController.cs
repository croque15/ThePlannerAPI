using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ThePlannerAPI.Models;


namespace ThePlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannerController : ControllerBase
    {
        private static List<Resource> people = new List<Resource>
        {
            new Resource { Id = 1, Name = "Cristina Roque" },
            new Resource { Id = 2, Name = "John Doe" }
        };

        private static List<TaskAssignment> tasks = new List<TaskAssignment>
        {
            new TaskAssignment {
                Id = 1,
                TaskName = "Design",
                ResourceId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3)
            },
            new TaskAssignment
            {
                Id = 2,
                TaskName = "Development",
                ResourceId = 2,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5)
            }
        };

        [HttpGet("people")]
        public ActionResult<List<Resource>> GetPeople()
        {
            return Ok(people);
        }

        [HttpGet("tasks")]
        public ActionResult<List<TaskAssignment>> GetTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("tasks/by-person/{personId}")]
        public ActionResult<List<TaskAssignment>> GetTasksByResource(int personId)
        {
            var assignedTasks = tasks.Where(t => t.ResourceId == personId).ToList();
            return Ok(assignedTasks);   
        }

        [HttpPost("people")]
        public ActionResult<Resource> AddResource([FromBody] Resource newResource)
        {
            newResource.Id = people.Max(p => p.Id) + 1;
            people.Add(newResource);
            return CreatedAtAction(nameof(GetPeople), new { id = newResource.Id }, newResource);
        }

        [HttpPost("tasks")]
        public ActionResult<TaskAssignment> AddTask([FromBody] TaskAssignment newTask)
        {
            newTask.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(newTask);
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }
    } 
}
