using Profile.Analytic;
using Tools;
namespace Profile
{
   public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            AnalyticTools = analyticTools;
            PlayerMoney = new Money(nameof(Money));
            PlayerSpeed = new Speed(nameof(Money));
            PlayerHealth = new Health(nameof(Health));
            PlayerForce = new Force(nameof(Force));
            PlayerBandetry = new Banditry(nameof(Banditry));
            CurrenMoney = new SubscriptionProperty<int>();
            CurrenMoney.Value = this.PlayerMoney.Money;
            CurrentCar = new Car(5,10,2,1);
        }
        public SubscriptionProperty<GameState> CurrentState { get; }
        public SubscriptionProperty<int> CurrenMoney { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }
        public Money PlayerMoney;
        public Speed PlayerSpeed;
        public Health PlayerHealth;
        public Force PlayerForce;
        public Banditry PlayerBandetry;
    }
}