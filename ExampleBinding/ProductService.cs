using System.Collections.Generic;

//Класс сервис списка продуктов

namespace ExampleBinding
{
    public class ProductService
    {
        static readonly ProductModel product_one = new ProductModel(10, "product_1", (decimal)10.10);
        static readonly ProductModel product_two = new ProductModel(20, "product_2", (decimal)20.20);
        static readonly ProductModel product_three = new ProductModel(30, "product_3", (decimal)30.30);
        static readonly IDictionary<int, ProductModel> ProductList = new Dictionary<int, ProductModel>
        {
            {product_one.Id, product_one},
            {product_two.Id, product_two},
            {product_three.Id, product_three}
        };
        // Метод получения продукта по ID
        public ProductModel GetProduct(int id)
        {            
            ProductList.TryGetValue(id, out ProductModel product);
            return product;            
        }
        // Метод обновление продукта
        public void UpdateProduct(int id, string product_name, decimal price)
        { 
            ProductList.Remove(id);
            ProductModel pm = new ProductModel(id, product_name, price);
            ProductList.Add(id, pm);
        }
    }
}
