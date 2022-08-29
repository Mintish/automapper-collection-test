public class Item
{
    public int Id { get; set; }
    public string ExternalId { get; set; }
    public string Content { get; set; }
}

public class Menu
{
    public IEnumerable<Item> Items { get; set; }
}


public class ItemDto
{
    public string ExternalId { get; set; }
    public string Content { get; set; }
}

public class MenuDto
{
    public IEnumerable<ItemDto> Items { get; set; }
}