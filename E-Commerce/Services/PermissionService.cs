using E_Commerce.DataAccess;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class PermissionService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public PermissionService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public List<Permission> GetAll()
        {
            return ctx.Permissions.ToList();
        }

        public int Delete(long optionId, long roleId)
        {
            try
            {
                Permission permission = ctx.Permissions.Single(s => s.OptionId == optionId && s.RoleId == roleId);
                ctx.Remove(permission);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }

        }

        public Permission Get(long optionId, long roleId)
        {
            try
            {
                return ctx.Permissions.SingleOrDefault(s => s.OptionId == optionId && s.RoleId == roleId);
            }
            catch
            {
                return null;
            }
        }
    }
}
