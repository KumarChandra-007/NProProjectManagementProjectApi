using NproProjectManagement.Model;

namespace NproProjectManagement.Interfaces
{
    public interface IProjectService
    {
         Task<List<ProjectDetail>> GetProjectsAsync();
        Task<ProjectDetail> GetProjectByIdAsync(int projectId);

        Task<ProjectDetail> PostProjectAsync(ProjectDetail model);
        Task<ProjectDetail> PutProjectAsync(ProjectDetail model);
        Task<bool> DeleteProjectAsync(int projectId);


    }
}