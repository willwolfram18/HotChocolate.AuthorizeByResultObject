namespace WebApi.Types;

public class Item
{
    [GraphQLType(typeof(NonNullType<IdType>))]
    public Guid Id { get; set; }

    public string Name { get; set; }
}