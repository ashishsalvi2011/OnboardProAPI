using System.Data;

namespace OnboardPro.Interface
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
