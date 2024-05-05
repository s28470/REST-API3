using JetBrains.Annotations;
using REST3.Repos;

namespace TestProject1.Src.Repos;

[TestSubject(typeof(ShopRepository))]
public class ShopRepositoryTest
{

    [Fact]
    public void GetProductAsync()
    {
        ShopRepository shopRepository = new ShopRepository(); 
        Assert.NotNull(        shopRepository.GetProductAsync(7)
        );
    }
    
    [Fact]
    public void GetWarehouseAsync()
    {
        ShopRepository shopRepository = new ShopRepository();
        Assert.NotNull(shopRepository.GetWarehouseAsync(2));
    }

    [Fact]
    public void GetOrderAsync()
    {
        ShopRepository shopRepository = new ShopRepository();
        Assert.NotNull(shopRepository.GetOrderAsync(7, 125));
    }
}