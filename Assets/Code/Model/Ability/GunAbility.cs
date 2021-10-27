using Code.Model.Config;
using Code.Tools;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Model.Ability
{
    public class GunAbility:IAbility
    {
        private readonly AbilityItemConfig _config;
        private readonly Rigidbody2D _viewPrefab;
        private readonly float _projectSpeed;

        public GunAbility(AbilityItemConfig config)
        {
            _config = config;
        }
        
        public GunAbility(float projectSpeed, [NotNull] string viewPath)
        {
            var go = ResourceLoader.LoadPrefab(new ResourcePath() { PathResource = viewPath });
            _viewPrefab = go.GetComponent<Rigidbody2D>();
            _projectSpeed = projectSpeed;
        }

        public void Apply(IAbilityActivator abilityActivator)
        {
            var projectile = Object.Instantiate(_viewPrefab);
            projectile.AddForce(abilityActivator.GetViewObject().transform.right*_projectSpeed,
                ForceMode2D.Force);
        }
    }
}