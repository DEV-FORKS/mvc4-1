// -----------------------------------------------------------------------
// <copyright file="IDepartmentDataSource.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace eManager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IDepartmentDataSource
    {
        
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get;  }
        void Save();

    }
}
