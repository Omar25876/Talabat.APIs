using Talabat.APIs.DTOs;

namespace Talabat.APIs.Helpers
{
	public class Pagination<T>
	{

		public Pagination(int pageSize, int pageIndex, IReadOnlyList<T> mapproducts, int count)
		{
			PageSize = pageSize;
			PageIndex = pageIndex;
			Data = mapproducts;
			Count = count;
		}

		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public int Count { get; set; }

		public IReadOnlyList<T> Data { get; set; }
	}
}
