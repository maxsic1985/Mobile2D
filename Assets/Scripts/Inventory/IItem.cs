public interface IItem
{
    int Id { get; }
    ItemInfo Info { get; }

    bool Locked { get;  set; }
}
