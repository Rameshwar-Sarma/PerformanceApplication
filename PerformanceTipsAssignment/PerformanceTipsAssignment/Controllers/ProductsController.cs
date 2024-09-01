using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceTipsAssignment.Data;
using PerformanceTipsAssignment.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace UnifiedPerformanceApplication.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductsController(ApplicationDbContext context, IConnectionMultiplexer redis) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IConnectionMultiplexer _redis = redis;

        /// <summary>
        /// Retrieves a list of products from the database or Redis cache.
        /// </summary>
        /// <returns>A list of products</returns>

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            string cacheKey = "products";
            var db = _redis.GetDatabase();

            // Check if the product list is cached
            string? cachedProducts = await db.StringGetAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedProducts))
            {
                var products = JsonSerializer.Deserialize<List<Product>>(cachedProducts);
                return Ok(products);
            }

            // If not cached, get products from the database
            var productList = await _context.Products.ToListAsync();

            // Cache the result
            var serializedProducts = JsonSerializer.Serialize(productList);
            await db.StringSetAsync(cacheKey, serializedProducts, TimeSpan.FromMinutes(10));

            return Ok(productList);
        }
    }
}

