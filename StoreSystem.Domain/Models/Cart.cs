using StoreSystem.Domain.Entities;
using System.Collections;

namespace StoreSystem.Domain.Models;

public class Cart : IEnumerable<KeyValuePair<Product, int>>
{
    private readonly Dictionary<Product, int> _products;
    public Customer? Customer { get; set; }

    public decimal TotalAmount => _products.Sum(p => p.Key.Price * p.Value);

    public Cart()
    {
        _products = new Dictionary<Product, int>();
    }

    public void Clear() => _products.Clear();

    public void Add(Product product, int count)
    {
        if (_products.ContainsKey(product))
        {
            _products[product] += count;
        }
        else
        {
            _products.Add(product, count);
        }
    }

    public void Remove(Product product)
    {
        _products.Remove(product);
    }

    public void UpdateCount(Product product, int newCount)
    {
        if (newCount <= 0) return;
        _products[product] = newCount;
    }

    public IEnumerator<KeyValuePair<Product, int>> GetEnumerator()
    {
        foreach (var pair in _products)
        {
            yield return pair;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
