using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.APIs.DTOs
{
	public class OrderItemDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductUrl { get; set; }

		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}