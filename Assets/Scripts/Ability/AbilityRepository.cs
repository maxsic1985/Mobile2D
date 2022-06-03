using System.Collections.Generic;

public class AbilityRepository : BaseController, IRepository<int, IAbility>
{
    #region Field
    public IReadOnlyDictionary<int, IAbility> Content => _abilityMap;
    private Dictionary<int, IAbility> _abilityMap = new Dictionary<int, IAbility>();
    #endregion
    #region Life cycle
    public AbilityRepository(IReadOnlyList<AbilityItemConfig> abilityItemConfigs)
    {
        foreach (var item in abilityItemConfigs)
        {
            _abilityMap[item.Id] = CreateAbility(item);
        }
    }
    private IAbility CreateAbility(AbilityItemConfig abilityItemConfig)
    {
        switch (abilityItemConfig.type)
        {
            case AbilityType.None: return AbilityStub.Default;
            case AbilityType.Gun: return new GunAbility(abilityItemConfig.view, abilityItemConfig.value);

            default:
                return AbilityStub.Default;

        }
    }
    #endregion

}
