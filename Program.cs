using AutoMapper;
using AutoMapper.EquivalencyExpression;

var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddCollectionMappers();
    cfg.CreateMap<MenuDto, Menu>();
    cfg.CreateMap<ItemDto, Item>()
        .EqualityComparison((p, q) => p.ExternalId == q.ExternalId)
        .ForMember(f => f.Id, o => o.Ignore());
});

configuration.AssertConfigurationIsValid();
var mapper = configuration.CreateMapper();

var source = new MenuDto
{
    Items = new[] { new ItemDto() { ExternalId = "ABC-1", Content = "Veggie Burger" } },
};

var destination = new Menu
{
    Items = new[] { new Item { Id = 32, ExternalId = "ABC-1", Content = "Burger" } },
};

Console.WriteLine($"Items.HashCode(): {destination.Items.GetHashCode()}");
foreach (var foo in destination.Items)
    Console.WriteLine($"Id: {foo.Id}, ExternalId: {foo.ExternalId}, Content: {foo.Content}, HashCode: {foo.GetHashCode()}");

var plan = mapper.ConfigurationProvider.BuildExecutionPlan(typeof(MenuDto), typeof(Menu));

var mapped = mapper.Map(source, destination);

Console.WriteLine($"Items.HashCode(): {mapped.Items.GetHashCode()}");
foreach (var foo in mapped.Items)
    Console.WriteLine($"Id: {foo.Id}, ExternalId: {foo.ExternalId}, Content: {foo.Content}, HashCode: {foo.GetHashCode()}");