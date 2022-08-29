using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Database
{
  public  class InMemoryDatabaseEmployee<T> : IDbWrapperEmployee<T> where T : EmployeeBase
	
	{ 
   private Dictionary<Tuple<string, string>, EmployeeBase> DatabaseInstance;

	public InMemoryDatabaseEmployee()
	{
		DatabaseInstance = new Dictionary<Tuple<string, string>, EmployeeBase>();
	}

	public bool Insert(T data)
	{
		try
		{
			DatabaseInstance.Add(Tuple.Create(data.SiteId, data.EmployeeCode), data);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool Update(T data)
	{
		try
		{
			if (DatabaseInstance.ContainsKey(Tuple.Create(data.SiteId, data.EmployeeCode)))
			{
				DatabaseInstance.Remove(Tuple.Create(data.SiteId, data.EmployeeCode));
				Insert(data);
				return true;
			}

			return false;
		}
		catch
		{
			return false;
		}
	}

	public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
	{
		try
		{
			var entities = FindAll();
			return entities.Where(expression.Compile());
		}
		catch
		{
			return Enumerable.Empty<T>();
		}
	}

	public IEnumerable<T> FindAll()
	{
		try
		{
			return DatabaseInstance.Values.OfType<T>();
		}
		catch
		{
			return Enumerable.Empty<T>();
		}
	}

	public bool Delete(Expression<Func<T, bool>> expression)
	{
		try
		{
			var entities = FindAll();
			var entity = entities.Where(expression.Compile());
			foreach (var EmployeeBase in entity)
			{
				DatabaseInstance.Remove(Tuple.Create(EmployeeBase.SiteId, EmployeeBase.EmployeeCode));
			}

			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool DeleteAll()
	{
		try
		{
			DatabaseInstance.Clear();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool UpdateAll(Expression<Func<T, bool>> filter, string fieldToUpdate, object newValue)
	{
		try
		{
			var entities = FindAll();
			var entity = entities.Where(filter.Compile());
			foreach (var EmployeeBase in entity)
			{
				var newEntity = UpdateProperty(EmployeeBase, fieldToUpdate, newValue);

				DatabaseInstance.Remove(Tuple.Create(EmployeeBase.SiteId, EmployeeBase.EmployeeCode));
				Insert(newEntity);
			}

			return true;
		}
		catch
		{
			return false;
		}
	}

	private T UpdateProperty(T EmployeeBase, string key, object value)
	{
		Type t = typeof(T);
		var prop = t.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

		if (prop == null)
		{
			throw new Exception("Property not found");
		}

		prop.SetValue(EmployeeBase, value, null);
		return EmployeeBase;
	}

	public Task<bool> InsertAsync(T data)
	{
		return Task.FromResult(Insert(data));
	}

	public Task<bool> UpdateAsync(T data)
	{
		return Task.FromResult(Update(data));
	}

	public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
	{
		return Task.FromResult(Find(expression));
	}

	public Task<IEnumerable<T>> FindAllAsync()
	{
		return Task.FromResult(FindAll());
	}

	public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
	{
		return Task.FromResult(Delete(expression));
	}

	public Task<bool> DeleteAllAsync()
	{
		return Task.FromResult(DeleteAll());
	}

	public Task<bool> UpdateAllAsync(Expression<Func<T, bool>> filter, string fieldToUpdate, object newValue)
	{
		return Task.FromResult(UpdateAll(filter, fieldToUpdate, newValue));
	}


}
}
