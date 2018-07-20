using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPlanner.FactorySolver2
{
    class ItemRecipe
    {
        // expensive recipes
        public static ItemRecipe IRON_PLATE = new ItemRecipe();
        public static ItemRecipe COPPER_PLATE = new ItemRecipe();
        public static ItemRecipe PLASTIC = new ItemRecipe();
        public static ItemRecipe IRON_GEAR_WHEEL = new ItemRecipe();
        public static ItemRecipe COAL = new ItemRecipe();
        public static ItemRecipe STEEL_PLATE = new ItemRecipe();
        public static ItemRecipe COPPER_CABLE = new ItemRecipe(0.5, 1, COPPER_PLATE, 2);
        public static ItemRecipe PIPE = new ItemRecipe(0.5, 2, IRON_PLATE);
        public static ItemRecipe ELECTRONIC_CIRCUIT = new ItemRecipe(0.5, 10, COPPER_CABLE, 2, IRON_PLATE);
        public static ItemRecipe ELECTRIC_MINING_DRILL = new ItemRecipe(2, 5, ELECTRONIC_CIRCUIT, 10, IRON_GEAR_WHEEL, 20, IRON_PLATE);
        public static ItemRecipe ADVANCED_CIRCUIT = new ItemRecipe(6, 8, COPPER_CABLE, 2, ELECTRONIC_CIRCUIT, 4, PLASTIC);
        public static ItemRecipe ENGINE_UNIT = new ItemRecipe(10, 1, IRON_GEAR_WHEEL, 2, PIPE, 1, STEEL_PLATE);
        public static ItemRecipe FIREARM_MAGAZINE = new ItemRecipe(1, 4, IRON_PLATE);
        public static ItemRecipe GRENADE = new ItemRecipe(8, 10, COAL, 5, IRON_PLATE);
        public static ItemRecipe GUN_TURRET = new ItemRecipe(8, 10, COPPER_PLATE, 10, IRON_GEAR_WHEEL, 20, IRON_PLATE);
        public static ItemRecipe INSERTER = new ItemRecipe(0.5, 1, ELECTRONIC_CIRCUIT, 1, IRON_GEAR_WHEEL, 1, IRON_PLATE);
        public static ItemRecipe TRANSPORT_BELT = new ItemRecipe(0.5, 1, IRON_GEAR_WHEEL, 1, IRON_PLATE);
        public static ItemRecipe PIERCING_ROUNDS_MAGAZINE = new ItemRecipe(3, 5, COPPER_PLATE, 1, FIREARM_MAGAZINE, 1, STEEL_PLATE);
        public static ItemRecipe MILITARY_SCIENCE_PACK = new ItemRecipe(10, 1, GRENADE, 1, GUN_TURRET, 1, PIERCING_ROUNDS_MAGAZINE, 2);
        public static ItemRecipe SCIENCE_PACK_1 = new ItemRecipe(5, 1, COPPER_PLATE, 1, IRON_GEAR_WHEEL);
        public static ItemRecipe SCIENCE_PACK_2 = new ItemRecipe(6, 1, INSERTER, 1, TRANSPORT_BELT);
        public static ItemRecipe SCIENCE_PACK_3 = new ItemRecipe(12, 1, ADVANCED_CIRCUIT, 1, ELECTRIC_MINING_DRILL, 1, ENGINE_UNIT);

        private double time;
        private ItemAmount[] itemAmounts;
        private int amountOut;

        public ItemRecipe()
        {
            this.time = 0;
            this.itemAmounts = new ItemAmount[0];
            this.amountOut = 1;
        }

        public ItemRecipe(double time, int amount1, ItemRecipe item1, int amountOut = 1)
        {
            this.time = time;
            this.itemAmounts = new ItemAmount[] { new ItemAmount(amount1, item1) };
            this.amountOut = amountOut;
        }

        public ItemRecipe(double time, int amount1, ItemRecipe item1, int amount2, ItemRecipe item2, int amountOut = 1)
        {
            this.time = time;
            this.itemAmounts = new ItemAmount[] { new ItemAmount(amount1, item1), new ItemAmount(amount2, item2) };
            this.amountOut = amountOut;
        }

        public ItemRecipe(double time, int amount1, ItemRecipe item1, int amount2, ItemRecipe item2, int amount3, ItemRecipe item3, int amountOut = 1)
        {
            this.time = time;
            this.itemAmounts = new ItemAmount[] { new ItemAmount(amount1, item1), new ItemAmount(amount2, item2), new ItemAmount(amount3, item3) };
            this.amountOut = amountOut;
        }

        private class ItemAmount
        {
            int count;
            ItemRecipe item;
            public ItemAmount(int count, ItemRecipe item)
            {
                this.count = count;
                this.item = item;
            }
        }
    }
}
