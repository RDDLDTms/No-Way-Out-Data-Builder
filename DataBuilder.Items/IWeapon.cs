using NWO_Abstractions;

namespace DataBuilder.Items
{
    /// <summary>
    /// Оружие
    /// </summary>
    public interface IWeapon : IItem
    {
        /// <summary>
        /// Тип воздействия для оружия
        /// </summary>
        public ILeverageClass WeaponLeverageType { get; }
    }
}
