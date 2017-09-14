using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrx.BusinessLogic.Services
{
    public interface IQueryService<TDataModel,TEntity>
    {
        TDataModel GetById(int id);

        IEnumerable<TDataModel> GetAll(object options);

        TDataModel MapToListModel(TEntity transaction);

        TDataModel MapToEditModel(TEntity transaction);

        //TEntity MapToEntity(TDataModel model);
    }
}
