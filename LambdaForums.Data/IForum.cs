using LambdaForums.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambdaForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        //CRUD
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateforumDescription(int forumId, string newDescription);
    }
}
