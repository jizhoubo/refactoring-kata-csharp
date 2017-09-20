using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private readonly Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            return _orders.Format();
        }
    }

    public static class FormatterExtension
    {
        public static string Format(this Product product)
        {
            var sizeString = $"\"size\": \"{product.SizeInEnglish()}\", ";
            var formatedString = 
                $"{{" +
                    $"\"code\": \"{product.Code}\", " +
                    $"\"color\": \"{product.ColorInEnglish()}\", " +
                    $"{(product.Size == Product.SIZE_NOT_APPLICABLE ? "" : sizeString)}" +
                    $"\"price\": {product.Price}, " +
                    $"\"currency\": \"{product.Currency}\"" +
                $"}}";
            return formatedString;
        }

        public static string Format(this Order order)
        {
            var productsStr = Aggregate(order.Products, Format);
            var formatedString = 
                $"{{" +
                    $"\"id\": {order.Id}, " +
                    $"\"products\": [{productsStr}]" +
                $"}}";
            return formatedString;
        }

        public static string Format(this Orders orders)
        {
            var ordersStr = Aggregate(orders.AllOrders, Format);
            var formatedString = $"{{\"orders\": [{ordersStr}]}}";
            return formatedString;
        }

        private static string ColorInEnglish(this Product product)
        {
            var dic =
                new[] { "blue", "red", "yellow" }
                .Zip(Enumerable.Range(1, 3), (v, k) => new { k, v })
                .ToDictionary(x => x.k, x => x.v);
            return dic.ContainsKey(product.Color) ? dic[product.Color] : "no color";
        }
        private static string SizeInEnglish(this Product product)
        {
            var dic =
                new[] { "XS", "S", "M", "L", "XL", "XXL" }
                .Zip(Enumerable.Range(1, 6), (v, k) => new { k, v })
                .ToDictionary(x => x.k, x => x.v);
            return dic.ContainsKey(product.Size) ? dic[product.Size] : "Invalid Size";
        }

        private static string Aggregate<T>(IList<T> list, Func<T, string> formatter)
        {
            return string.Join(", ", list.Select(formatter).ToArray());
        }
    }

}