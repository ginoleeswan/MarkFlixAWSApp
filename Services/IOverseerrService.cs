using MarkFlixAWSApp.Models;

namespace MarkFlixAWSApp.Services
{
    public interface IOverseerrService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Models.Request>> GetRequests(int? id);
        Task<Content> GetMediaDetails(string? type, int? id);
    }
}
