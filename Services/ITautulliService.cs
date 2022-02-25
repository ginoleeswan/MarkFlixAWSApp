using MarkFlixAWSApp.Models;

namespace MarkFlixAWSApp.Services
{
    public interface ITautulliService
    {
        //Task<IEnumerable<User>> GetUsers();
        //Task<IEnumerable<HomeStat>> GetHomeStats();
        Task<IEnumerable<Content>> GetRecentlyAdded();
        //Task<IEnumerable<UserStats>> GetUserPlayerStats(string userId);
        Task<IEnumerable<Library>> GetLibraries();
        Task<IEnumerable<User>> GetLibraryUserStats(int sectionId);
        Task<IEnumerable<Content>> GetUserWatchHistory(string userName);
        Task<IEnumerable<Content>> GetAllWatchHistory();
        Task<IEnumerable<User>> GetMediaWatchHistory(int ratingKey);
        //Task<IEnumerable<PlayData>> GetPlaysPerMonth();
    }
}
