public interface IUpgradableCar
{
    int Health { get; set; }
    float Speed { get; set; }
    int Power { get; set; }
    int Bandetry { get; set; }
    void Restore();
}