using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NproProjectManagement.Interfaces;

using System;
using System.Threading.Tasks;


using System.Drawing;
using NproProjectManagement.Services;
using NproProjectManagement.Model;

namespace NproProjectManagement.Controllers
{
    [Route("projectapi")]
    [ApiController]
    public partial class ProjectController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectController(IProjectService ProjectService)
        {
            _projectService = ProjectService;

        }


        [HttpGet("GetProjects")]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var projects = await _projectService.GetProjectsAsync();
            if (projects == null)
            {
                return BadRequest("Error while reading Projects");
            }

            return Ok(projects);
        }

        [HttpGet("GetProjectById/{ProjectId}")]
        public async Task<IActionResult> GetprojectByIdAsync(int ProjectId)
        {
            var project = await _projectService.GetProjectByIdAsync(ProjectId);
            if (project == null)
            {
                return BadRequest("Error while reading project");
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> PostProjectAsync([FromBody] ProjectDetail model)
        {
            var project = await _projectService.PostProjectAsync(model);
            if (project == null)
            {
                return BadRequest("Error while saving project");
            }

            return Ok(project);
        }
        [HttpPut]
        public async Task<IActionResult> PutProjectAsync([FromBody] ProjectDetail model)
        {
            var project = await _projectService.PutProjectAsync(model);
            if (project == null)
            {
                return BadRequest("Error while updating project");
            }

            return Ok(project);
        }
        [HttpDelete("DeleteProjectByIdAsync/{projectId}")]
        public async Task<IActionResult> DeleteProjectByIdAsync(int projectId)
        {
            var response = await _projectService.DeleteProjectAsync(projectId);
            if (!response)
            {
                return BadRequest("Failed to delete project");
            }

            return Ok("Successfully deleted the project");
        }

    }
}
