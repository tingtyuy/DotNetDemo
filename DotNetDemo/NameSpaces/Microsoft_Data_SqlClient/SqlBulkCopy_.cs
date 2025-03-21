using Masuit.Tools.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.Microsoft_Data_SqlClient
{
    /// <summary>
    /// 允许你使用其他源的数据有效地批量加载 SQL Server 表。
    /// </summary>
    public class SqlBulkCopy_
    {
        private readonly DbContext _dbContext;
        public SqlBulkCopy_(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CopyExistedData<T>(DbSet<T> table, Action<DataRow> action, int insertRowTotalCount = 2000000, int copyRowCount = 200000) where T : class
        {
            var list = _dbContext.Set<T>().Take(copyRowCount).AsNoTracking().ToList();
            var dt = list.ToDataTable(null);
            var _copyRowCount = dt.Rows.Count;
            Console.WriteLine($"{_copyRowCount} data ready !");
            var conn = _dbContext.Database.GetConnectionString();
            using SqlConnection destinationConnection = new SqlConnection(conn);
            destinationConnection.Open();
            using var sqlBulkCopy = new SqlBulkCopy(destinationConnection);
            sqlBulkCopy.DestinationTableName = "dbo.UserActionLog";
            sqlBulkCopy.BulkCopyTimeout = Int32.MaxValue;
            var copyedRowCount = _copyRowCount;
            while (insertRowTotalCount < copyedRowCount)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    action.Invoke(dt.Rows[i]);
                }
                sqlBulkCopy.WriteToServer(dt);
                copyedRowCount += copyedRowCount;
                Console.WriteLine($"{_copyRowCount} data is inserted ,  total is {copyedRowCount} data ");
            }
            Console.WriteLine($"{copyedRowCount} data  none !");
        }
    }
}
