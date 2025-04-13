using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
	public class ProductWithFilterationForCountSpec : BaseSpecification<Product>
	{
		public ProductWithFilterationForCountSpec(ProductSpecParams Params) : base(P =>
		(!Params.TypeId.HasValue || P.ProductTypeId == Params.TypeId)
		&& (!Params.BrandId.HasValue || P.ProductBrandId == Params.BrandId))
		{ 
		}
	}
}
