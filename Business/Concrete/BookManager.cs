using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
         IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Book> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IResult Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
