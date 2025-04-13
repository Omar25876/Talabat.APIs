using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Reository.Data
{
	public static class StoreContextSeed
	{

		public static async Task SeedAsync(StoreContext dbContext)
		{
			if (!dbContext.ProductBrands.Any())
			{
				var BrandsData = File.ReadAllText("../Talabat.Reository/Data/DataSeed/brands.json");
				var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
				if (Brands?.Count > 0)
				{
					foreach (var Brand in Brands)
					{
						await dbContext.Set<ProductBrand>().AddAsync(Brand);

					}
					await dbContext.SaveChangesAsync();

				}
			}


			if(!dbContext.ProductTypes.Any())
			{
				var TypesData = File.ReadAllText("../Talabat.Reository/Data/DataSeed/types.json");
				var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
				if (Types?.Count > 0)
				{
					foreach (var Type in Types)
					{
						await dbContext.Set<ProductType>().AddAsync(Type);
					}
					await dbContext.SaveChangesAsync();
				}
			}


			if(!dbContext.Products.Any())
			{
				var ProductsData = File.ReadAllText("../Talabat.Reository/Data/DataSeed/products.json");
				var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
				if (Products?.Count > 0)
				{
					foreach (var Product in Products)
					{
						await dbContext.Set<Product>().AddAsync(Product);
					}
					await dbContext.SaveChangesAsync();
				}
			}

			if (!dbContext.DeliveryMethods.Any())
			{
				
				var DeliveryMethodsData = File.ReadAllText("../Talabat.Reository/Data/DataSeed/delivery.json");
				var DeliveryMethodsD = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodsData);
				if (DeliveryMethodsD?.Count > 0)
				{
					foreach (var DeliveryMethods in DeliveryMethodsD)
					{
						await dbContext.Set<DeliveryMethod>().AddAsync(DeliveryMethods);
					}
					await dbContext.SaveChangesAsync();
				}
			}


		}
	}
}
