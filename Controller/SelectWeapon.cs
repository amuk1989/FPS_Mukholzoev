using System;

namespace Geekbrains
{
    public class SelectWeapon: BaseController
    {

        public void Select(float value)
        {
            int weaponNumber = Convert.ToInt32(Math.Ceiling(value));

            ServiceLocator.Resolve<WeaponController>().Off();
            var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[weaponNumber]; //todo инкапсулировать
            if (tempWeapon != null)
            {
                ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
            }
        }
    }
}
