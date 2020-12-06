using Microsoft.EntityFrameworkCore;
using StokTakip.Entities.Context;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class BaseService<TEntity> where TEntity : class
    {
        private readonly StokContext _stokContext;
        private readonly DbSet<TEntity> _DbSet;
        public BaseService(StokContext stokContext)
        {
            _stokContext = stokContext;
            _DbSet = _stokContext.Set<TEntity>();
        }


        public virtual ServiceResponse Create(TEntity model)
        {
            try
            {
                _DbSet.Add(model);
                _stokContext.SaveChanges();
                return new ServiceResponse { IsSuccess = true, Message = "Kayıt Başarılı bir şekilde eklendi" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { IsSuccess = false, Message = "Kayıt ekleme esnasında hata oluştu :" + ex.Message };
            }
        }
        public virtual ServiceResponse Update(TEntity model)
        {
            try
            {
                _DbSet.Update(model);
                _stokContext.SaveChanges();
                return new ServiceResponse { IsSuccess = true, Message = "Kayıt Başarılı bir şekilde güncellendi" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { IsSuccess = false, Message = "Kayıt güncelleme esnasında hata oluştu :" + ex.Message };
            }
        }


        public virtual ServiceResponse Delete(TEntity model)
        {
            try
            {
                _DbSet.Remove(model);
                _stokContext.SaveChanges();
                return new ServiceResponse { IsSuccess = true, Message = "Kayıt silme bir şekilde güncellendi" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { IsSuccess = false, Message = "Kayıt silme esnasında hata oluştu :" + ex.Message };
            }
        }

        public virtual List<TEntity> GetAll()
        {
            return _DbSet.ToList();
        }

        public virtual TEntity GetById(int Id)
        {
            return _DbSet.Find(Id);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return  _DbSet.Where(filter);
        }
    }
}
