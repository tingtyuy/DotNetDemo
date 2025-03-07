using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.DataTableModule
{
    public class DataTableModule
    {
        public static DataTable CreateTable(string? Tablename)
        {
            // 创建一个新的 DataTable
            DataTable table = new DataTable("Employees");
            // 定义列
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Position", typeof(string));
            table.Columns.Add("Salary", typeof(decimal));
            // 添加行
            table.Rows.Add(1, "Alice", "Manager", 75000.00m);
            table.Rows.Add(2, "Bob", "Developer", 65000.00m);
            table.Rows.Add(3, "Charlie", "Designer", 70000.00m);
            return table;
        }
        public static DataTable MergeTable(DataTable dataTableA,DataTable dataTableB) {

            dataTableA.Merge(dataTableB);
            return dataTableA;

        }

    }

}
