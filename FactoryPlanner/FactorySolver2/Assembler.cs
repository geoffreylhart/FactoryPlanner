using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPlanner.FactorySolver2
{
    class Assembler : Entity
    {
        private ItemRecipe item;

        public Assembler(ItemRecipe item)
        {
            this.item = item;
        }
    }
}
