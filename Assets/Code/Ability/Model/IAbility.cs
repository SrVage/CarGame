using Code.Tools;
using UnityEngine;

namespace Code.Ability.Model
{
    public interface IAbility
    {
        void Apply(IAbilityActivator abilityActivator);
    }

    public interface IAbilityActivator
    {
        GameObject GetViewObject();
    }

    public interface IAbilityRepository:IRepository<int, IAbility>
    {
        
    }
    
    public class AbilityStub:IAbility
    {
        public void Apply(IAbilityActivator abilityActivator)
        {
            //Stub
        }
    }
}