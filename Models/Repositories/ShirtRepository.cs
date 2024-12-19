namespace shirt_api.Models.Repositories;

public static class ShirtRepository
{
    private static List<Shirt> shirts = new List<Shirt>
    {
        new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
        new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 35, Size = 12},
        new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Pink", Gender = "Women", Price = 28, Size = 8},
        new Shirt { ShirtId = 4, Brand = "Your Brand", Color = "Yellow", Gender = "Women", Price = 30, Size = 9}
    };

    public static bool ShirtExists(int id)
    {
        return shirts.Any(x => x.ShirtId == id);
    }

    public static List<Shirt> GetAllShirts()
    {
        return shirts;
    }

    public static Shirt? GetShirtById(int id)
    {
        return shirts.FirstOrDefault(x => x.ShirtId == id);
    }
}
