namespace WebApi.Types;

public class Query
{
    private static readonly IEnumerable<Item> s_items = new[]
    {
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Foo"
        },
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Bar"
        },
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Baz"
        }
    };

    [UsePaging]
    public IExecutable<Item> GetItems()
    {
        return s_items.AsQueryable().AsExecutable();
    }
}