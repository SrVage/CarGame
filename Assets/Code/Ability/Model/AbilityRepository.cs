using System.Collections.Generic;
using Code.Config;
using Code.Tools;

namespace Code.Ability.Model
{
    public class AbilityRepository:BaseRepository<int, IAbility, AbilityItemConfig>, IAbilityRepository
    {
        public AbilityRepository(List<AbilityItemConfig> configs) : base(configs)
        {
        }

        protected override IAbility CreateValue(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbitityType.None:
                    return new AbilityStub();
                    break;
                case AbitityType.Gun:
                    return new GunAbility(config);
                    break;
                default:
                    return new AbilityStub();
            }
        }
    }
}