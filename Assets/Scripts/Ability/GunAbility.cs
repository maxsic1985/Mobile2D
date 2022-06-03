using JetBrains.Annotations;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class GunAbility : IAbility
{
    #region Field
    private readonly Rigidbody2D _viewPrefab;
    private readonly float _projectileSpeed;
    #endregion
    #region Life cycle
    public GunAbility(
    [NotNull] GameObject viewPrefab, float projectileSpeed)
    {
        _viewPrefab = viewPrefab.GetComponent<Rigidbody2D>();
        if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(GunAbility)} viewrequires { nameof(Rigidbody2D) } component!");
        _projectileSpeed = projectileSpeed;
    }
    #endregion
    #region IAbility
    public void Apply(IAbilityActivator activator)
    {
        var projectile = Object.Instantiate(_viewPrefab);
        projectile.AddForce(activator.GetViewObject().transform.right * _projectileSpeed,
        ForceMode2D.Force);
    }
    #endregion
}
