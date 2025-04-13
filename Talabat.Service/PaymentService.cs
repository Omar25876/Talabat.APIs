using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Repositories;
using Talabat.Core.Service;
using Product = Talabat.Core.Entities.Product;

namespace Talabat.Service
{
	public class PaymentService : IPaymentService
	{
		private readonly IConfiguration _configuration;
		private readonly IBasketRepository _basketRepository;
		private readonly IUnitOfWork _unitOfWork;

		public PaymentService(IConfiguration configuration, IBasketRepository basketRepository, IUnitOfWork unitOfWork)
		{
			_configuration = configuration;
			_basketRepository = basketRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId)
		{
			StripeConfiguration.ApiKey = _configuration["StripeKeys:SecretKey"];
			var Basket = await _basketRepository.GetBasketAsync(basketId);
			if (Basket == null) return null;
			var ShippingPrice = 0m;


			if (Basket.DeliveryMethodId.HasValue)
			{
				var DeliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(Basket.DeliveryMethodId.Value);
				ShippingPrice = DeliveryMethod.Cost;
			}

			if (Basket.Items.Count > 0)
			{
				foreach (var item in Basket.Items)
				{
					var Product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
					if (item.Price != Product.Price)
					{
						item.Price = Product.Price;
					}
				}

			}


			var SubTotal = Basket.Items.Sum(item => item.Price * item.Quantity);

			var service = new PaymentIntentService();
			PaymentIntent paymentIntent;

			if (string.IsNullOrEmpty(Basket.PaymentIntentId))
			{
				var options = new PaymentIntentCreateOptions
				{
					Amount = (long)((SubTotal + ShippingPrice) * 100),
					Currency = "usd",
					PaymentMethodTypes = new List<string>
					{
						"card",
					},
				};

				paymentIntent = await service.CreateAsync(options);
				Basket.PaymentIntentId = paymentIntent.Id;
				Basket.ClientSecret = paymentIntent.ClientSecret;
			}
			else
			{
				var options = new PaymentIntentUpdateOptions
				{
					Amount = (long)((SubTotal + ShippingPrice) * 100),
				};
				paymentIntent = await service.UpdateAsync(Basket.PaymentIntentId, options);
				Basket.PaymentIntentId = paymentIntent.Id;
				Basket.ClientSecret = paymentIntent.ClientSecret;

			}


			await _basketRepository.UpdateBasketAsync(Basket);

			return Basket;
		}
	}
}
