using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDebitCardDal: EfEntityRepositoryBase<DebitCard,RentACarContext>, IDebitCardDal
    {
    }
}
