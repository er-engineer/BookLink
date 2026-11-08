using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> GetById(Guid id);
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
    }
}
