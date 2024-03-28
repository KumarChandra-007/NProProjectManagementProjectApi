using NproProjectManagement.Model;

namespace NproProjectManagement.Repository.Interface
{
    public interface IProjectRepository
    {
        Task<List<ProjectDetail>> GetProjectsAsync();

        Task<ProjectDetail> GetProjectByIdAsync(int id);
        Task<ProjectDetail> InsertProjectAsync(ProjectDetail project);
        Task<ProjectDetail> UpdateProjectAsync(ProjectDetail project);
        Task<bool> DeleteProjectAsync(int projectId);

    }
}

    

