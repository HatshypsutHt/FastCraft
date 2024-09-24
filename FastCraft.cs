using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("FastCraft", "Hatshypsut", "1.0.0")]
    [Description("Reduces crafting time for all items to be much faster")]

    public class FastCraft : RustPlugin
    {
        // Час для крафту, у відсотках від стандартного (наприклад, 0.1 = 10% від стандартного часу)
        private const float CraftSpeedMultiplier = 0.1f;

        private void OnServerInitialized()
        {
            // Застосовуємо прискорення крафту після ініціалізації сервера
            ReduceCraftingTimes();
        }

        private void ReduceCraftingTimes()
        {
            foreach (var blueprint in ItemManager.bpList)
            {
                if (blueprint != null)
                {
                    // Зменшуємо час крафту для кожного предмета
                    blueprint.time = blueprint.time * CraftSpeedMultiplier;
                }
            }

            Puts($"Crafting times have been reduced by {CraftSpeedMultiplier * 100}% for all items.");
        }
    }
}
