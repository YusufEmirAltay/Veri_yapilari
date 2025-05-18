using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Abstract
{
	public interface IGeneric<T> where T : class
	{
		void Insert(T item);
		void Update(T item);
		void Delete(T item);
		T GetByID(int id);
		List<T> GetList();
	}
}
