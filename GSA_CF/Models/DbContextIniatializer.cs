using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GSA_CF.Models
{
    public class DbContextIniatializer : DropCreateDatabaseIfModelChanges<DbDataContext>
    {
    }
}