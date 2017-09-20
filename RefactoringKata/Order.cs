using System.Collections.Generic;

namespace RefactoringKata
{
    public class Order
    {
        public int Id { get; private set; }
        public IList<Product> Products => _products;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            Id = id;
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProduct(int j)
        {
            return _products[j];
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}