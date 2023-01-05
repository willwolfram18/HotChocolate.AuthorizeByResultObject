using WebApi.Authorization;

namespace WebApi.Types;

[CanAccess]
public class Item
{
    [GraphQLType(typeof(NonNullType<IdType>))]
    public Guid Id { get; set; }

    public string Name { get; set; }
}