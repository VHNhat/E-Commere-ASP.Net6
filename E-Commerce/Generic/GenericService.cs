using E_Commerce.DataAccess;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Generic
{
    public class GenericService<T> : IGenericService<T> where T : AbstractModel
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;
        private DbSet<T> entities;

        /*public GenericService(Context context)
        {
            this.ctx = context;
            entities = ctx.Set<T>();
        }*/

        public GenericService(IConfiguration config)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
        }

        public GenericService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
            entities = ctx.Set<T>();
        }

        public int Add(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.LastModifiedAt = DateTime.Now;
                entities.Add(entity);
                int res = ctx.SaveChanges();
                Console.WriteLine(res);
                return res;
            }
            catch
            {
                return -1;
            }
        }

        public int Delete(long id)
        {
            try
            {
                var entity = entities.Single(s => s.Id == id);
                entities.Remove(entity);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }
            
        }

        public T Get(long id)
        {
            try
            {
                return entities.SingleOrDefault(s => s.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public int Update(T entity)
        {
            try
            {
                entities.Remove(entity);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }
            
        }
    }
}
