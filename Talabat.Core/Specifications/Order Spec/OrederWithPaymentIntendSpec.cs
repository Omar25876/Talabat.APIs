using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Specifications.Order_Spec
{
	public class OrederWithPaymentIntendSpec : BaseSpecification<Order>
	{
		public OrederWithPaymentIntendSpec(string PaymentIntendId) : base(O => O.PaymentIntentId == PaymentIntendId)
		{
			//Includes.Add(O => O.DeliveryMethod);
			//Includes.Add(O => O.Items);
		}
		
	 
	}
}
