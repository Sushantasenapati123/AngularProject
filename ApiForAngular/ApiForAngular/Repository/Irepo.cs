using ApiForAngular.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular.Repository
{
   public interface Irepo
    {
        Task<List<Entity>> GetAllproduct();
        Task<Entity> GetProductByid(int pid);
        Task<int> CreateAndUpdate(Entity p);
        Task<int> Delete(int id);
    }
}
