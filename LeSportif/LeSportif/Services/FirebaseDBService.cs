using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.Services
{
    public interface IFirebaseDatabase
    {
        Task<string> GetUsername(string email);
        Task<bool> SetUser(string email, string name);
        Task<bool> UpdateUser(string email, string username);
    
     
    
    }
}
