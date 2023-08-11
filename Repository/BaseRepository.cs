using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using System.Linq.Expressions;

namespace PlantNestApp.Repository
{
	public interface IBaseRepository<T> where T : Base
	{
		Task<DataTablesResponseDTO<T> > BuildResponseForDataTableLibrary(Expression<Func<T, bool>> filter, string columName = "id", bool columASC = false, int start = 1, int draw = 0, int length = 10);
		Task<ViewDTO<T>> GetAllAsync();
		Task<ViewDTO<T>> GetByIdAsync(int id);
		Task <ViewDTO<T>> CreteAsync(T entity);
		 Task <ViewDTO<T>> UpdateAsync( T entity);
		Task< ViewDTO<T>> DeleteAsync(int id);
	}
	public class BaseRepository<T> : IBaseRepository<T> where T : Base
	{
		protected ApplicationDbContext _db;
		protected DbSet<T> _dbset;

		public BaseRepository(ApplicationDbContext context)  //ctor -> contructor
		{
			_db = context;
			_dbset = context.Set<T>();
		}

		public async Task<DataTablesResponseDTO<T>> BuildResponseForDataTableLibrary(Expression<Func<T, bool>> filter, string columName = "id", bool columASC = false, int start = 1, int draw = 0, int length = 10)
		{
			var result = new DataTablesResponseDTO<T>();
			var dataRows =  _dbset.AsQueryable();
			if (filter != null)
			{
				dataRows = dataRows.Where(filter);
			}
			var totalRows = dataRows.Count();
			dataRows = dataRows.Skip(start).Take(length);
			var propertyInfo = typeof(T).GetProperty(columName);
			var parameter = Expression.Parameter(typeof(T), "p");
			var property =  Expression.Property(parameter, propertyInfo);
			var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);
			if (columASC == false)
			{
				dataRows = dataRows.OrderByDescending(lambda);
			}
			else
			{
				dataRows =  dataRows.OrderBy(lambda);
			}
			result.data = await dataRows.ToListAsync();
			result.recordsTotal = totalRows;
			result.recordsFiltered = totalRows;
			result.draw = draw;
			return result;
		}

		public async Task<ViewDTO<T>> CreteAsync(T entity)
		{
			var result = new ViewDTO<T>();
			if (entity != null)
			{
				 await _dbset.AddAsync(entity);
				await _db.SaveChangesAsync();
				result.Message = "Thêm Thành Công";
				result.StatusCode = 200;

				
			}
			return result;
		}

		public async Task< ViewDTO<T> > DeleteAsync(int id)
		{

			var result = new ViewDTO<T>();
			if (id > 0)
			{
				var deleted = await _dbset.FindAsync(id);
				if (deleted != null)
				{
					 _dbset.Remove(deleted);
					await _db.SaveChangesAsync();
					result.Message = "Xóa dữ liệu thành công!";
					result.StatusCode = 200;
				}
			}
			return result;
		}

		

		public async Task< ViewDTO<T> > GetAllAsync()
		{
			var result = new ViewDTO<T>();
			result.DataRows = await _dbset.AsQueryable().ToListAsync();
			return result;
		}

		public async Task<ViewDTO<T>> GetByIdAsync(int id)
		{
			var result = new ViewDTO<T>();
			var dataItem = await _dbset.FindAsync(id);

			if (dataItem != null)
			{
				result.DataRows.Add(dataItem);
				result.StatusCode = 200;
				result.Message = "Tìm kiếm theo Id thành công!";
			}

			return result;
		}
		public async Task< ViewDTO<T> > UpdateAsync( T entity)
		{
			var result = new ViewDTO<T>();
			if (entity != null)
			{ 
				 _dbset.Update(entity);
				await _db.SaveChangesAsync();
				result.StatusCode = 200;
				result.Message = "Cập nhật thành công!";
			}

			return result;
		}

		
	}
}
