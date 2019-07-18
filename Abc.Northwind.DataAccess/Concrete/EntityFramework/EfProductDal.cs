using Abc.Core.EntityFramework;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntitiyRepositoryBase<Product, NortwindContext>, IProductDal
    {

    }
    

}
