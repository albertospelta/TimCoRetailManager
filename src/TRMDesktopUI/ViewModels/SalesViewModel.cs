using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private const int DefaultItemQuantity = 1;

        private readonly IProductEndpoint _productEndpoint;
        private BindingList<ProductModel> _products;
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
        private int _itemQuantity = DefaultItemQuantity;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await Initialize();
        }

        private async Task Initialize()
        {
            var products = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(products);
        }

        public BindingList<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<CartItemModel> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set 
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public string SubTotal
        {
            get => Cart.Sum((i) => i.Product.RetailPrice * i.QuantityInCart).ToString("C");
        }

        public string Tax
        {
            get => "$0.00";
        }

        public string Total
        {
            get => "$0.00";
        }

        public bool CanAddToCart
        {
            get
            {
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                    return true;

                return false;
            }
        }

        public void AddToCart()
        {
            var existingItem = Cart.SingleOrDefault((i) => i.Product == SelectedProduct);
            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;

                // HACK: there should be a better way of refreshing the cart DisplayText
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                var item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }
            
            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = DefaultItemQuantity;

            NotifyOfPropertyChange(() => SubTotal);
        }

        public bool CanRemoveFromCart
        {
            get
            {
                return false;
            }
        }

        public void RemoveFromCart()
        {
            NotifyOfPropertyChange(() => SubTotal);
        }

        public bool CanCheckOut
        {
            get
            {
                return false;
            }
        }

        public void CheckOut()
        {

        }
    }
}
