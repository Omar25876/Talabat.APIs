using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
	public class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product>
	{
		public ProductWithBrandAndTypeSpecifications(ProductSpecParams Params) :base(P=>
		(!Params.TypeId.HasValue || P.ProductTypeId == Params.TypeId) 
		&& (!Params.BrandId.HasValue || P.ProductBrandId == Params.BrandId) )
		{
			Includes.Add(x => x.ProductBrand);
			Includes.Add(x => x.ProductType);

			if (!string.IsNullOrEmpty(Params.Sort))
			{
				switch (Params.Sort)
				{
					case "PriceAsc":
						AddOrderBy(P => P.Price );
						break;
					case "PriceDesc":
						AddOrderByDesceinding(P => P.Price);
						break;
					default:
						AddOrderBy(P => P.Name );
						break;
				}
			}


			ApplyPagination(Params.PageSize * (Params.PageIndex - 1) , Params.PageSize);

		}

		public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
		{
			Includes.Add(x => x.ProductBrand);
			Includes.Add(x => x.ProductType);

		}
	}
}
