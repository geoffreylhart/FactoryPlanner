using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FactoryPlanner.FactorySolver2
{
    // A much more complete factory state than before, intended to be rendered
    class FactoryState2
    {
        Entity[,] map = new Entity[45, 45];
        List<EntityPlacement> entityPlacements = new List<EntityPlacement>();

        private class EntityPlacement
        {
            public int x, y;
            Entity entity;

            public EntityPlacement(int x, int y, Entity entity)
            {
                this.x = x;
                this.y = y;
                this.entity = entity;
            }
        }

        public FactoryState2()
        {
        }

        internal static FactoryState2 TestState1()
        {
            var testState = new FactoryState2();
            // add assemblers
            testState.AddAssembler(14, 2, ItemRecipe.PIPE);
            testState.AddAssembler(14, 5, ItemRecipe.ELECTRIC_MINING_DRILL);
            for (int i = 0; i < 6; i++) testState.AddAssembler(19 + i * 3, 6, ItemRecipe.ENGINE_UNIT);
            for (int i = 0; i < 3; i++) testState.AddAssembler(10 + i * 3, 11, ItemRecipe.ADVANCED_CIRCUIT);
            for (int i = 0; i < 6; i++) testState.AddAssembler(19 + i * 3, 11, ItemRecipe.SCIENCE_PACK_3);
            testState.AddAssembler(7, 14, ItemRecipe.COPPER_CABLE);
            testState.AddAssembler(12, 18, ItemRecipe.FIREARM_MAGAZINE);
            testState.AddAssembler(16, 17, ItemRecipe.PIERCING_ROUNDS_MAGAZINE);
            for (int i = 0; i < 3; i++) testState.AddAssembler(19 + i * 3, 17, ItemRecipe.MILITARY_SCIENCE_PACK);
            for (int i = 0; i < 3; i++) testState.AddAssembler(28 + i * 3, 18, ItemRecipe.SCIENCE_PACK_1);
            for (int i = 0; i < 2; i++) testState.AddAssembler(14 + i * 3, 23, ItemRecipe.GRENADE);
            for (int i = 0; i < 2; i++) testState.AddAssembler(20 + i * 3, 22, ItemRecipe.GUN_TURRET);
            testState.AddAssembler(26, 22, ItemRecipe.TRANSPORT_BELT);
            for (int i = 0; i < 3; i++) testState.AddAssembler(29 + i * 3, 24, ItemRecipe.SCIENCE_PACK_2);
            testState.AddAssembler(24, 28, ItemRecipe.INSERTER);
            return testState;
        }

        private void AddAssembler(int x, int y, ItemRecipe itemRecipe)
        {
            Assembler assembler = new Assembler(itemRecipe);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    map[x + i, y + j] = assembler;
                }
            }
            entityPlacements.Add(new EntityPlacement(x, y, assembler));
        }

        public static Texture2D myTexture = null;
        internal void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateScale(20));
            if (myTexture == null)
            {
                FileStream filestream = new FileStream("..\\..\\..\\..\\Images\\Entities\\assembling-machine-2.png", FileMode.Open);
                myTexture = Texture2D.FromStream(graphicsDevice, filestream);
            }
            foreach (var entity in entityPlacements)
            {
                spriteBatch.Draw(myTexture, new Rectangle(entity.x - 1, entity.y - 1, 3, 3), Color.White);
            }
            spriteBatch.End();
        }
    }
}
