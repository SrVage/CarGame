using System.Collections.Generic;
using Code.Model.Tools;
using UnityEngine;

namespace Code.Model.Ability
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