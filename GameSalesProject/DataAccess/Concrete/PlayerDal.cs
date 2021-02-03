using GameSalesProject.DataAccess.Abstract;
using GameSalesProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameSalesProject.DataAccess.Concrete
{
    public class PlayerDal : RepositoryBase<Player>,IPlayerDal
    {

    }
}
