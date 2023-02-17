using ApiForAngular.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForAngular.Repository
{
    public class Repositary:BaseRepo,Irepo
    {

        public Repositary(IConfiguration config) : base(config)
    {

    }



    public async Task<List<Entity>> GetAllproduct()
    {
        try
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();

          
            param.Add("@action", "A");

            var cust = cn.Query<Entity>("op_product_tbl", param, commandType: CommandType.StoredProcedure).ToList();

            cn.Close();
            return cust;
        }
        catch (Exception ex)
        {
            return null;

        }
    }
    public async Task<Entity> GetProductByid(int pid)
    {
        try
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();

            param.Add("@pid", pid);
            param.Add("@action", "S");

            var cust = cn.Query<Entity>("op_product_tbl", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

            cn.Close();
            return cust;









     
        }
        catch (Exception ex)
        {
            return null;

        }
    }
    public async Task<int> CreateAndUpdate(Entity om)
    {
        try
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@pid", om.pid);
            param.Add("@pname", om.pname);
            param.Add("@price", om.price);
            param.Add("@pqty", om.pqty);

            var x = cn.Execute("save_update", param, commandType: CommandType.StoredProcedure);





         
            cn.Close();
            return x;
        }

        catch (Exception ex)
        {
            return 0;
        }
    }



    public async Task<int> Delete(int id)
    {
        try
        {
            var cn = CreateConnection();

            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();

            param.Add("@pid", id);
            param.Add("@action", "D");
            var x = cn.Execute("op_product_tbl", param, commandType: CommandType.StoredProcedure);




         
            cn.Close();
            return x;
        }

        catch (Exception ex)
        {
            return 0;
        }
    }


  
}
}
