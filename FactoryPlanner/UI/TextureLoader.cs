using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace FactoryPlanner.UI
{
    class TextureLoader
    {
        public static GraphicsDevice graphicsDevice;
        public static Texture2D ASSEMBLING_MACHINE_2 { get { return LoadTexture(@"..\..\..\..\Images\Entity\assembling-machine-2\hr-assembling-machine-2.png"); } }
        public static Texture2D ASSEMBLING_MACHINE_2_SHADOW { get { return LoadTexture(@"..\..\..\..\Images\Entity\assembling-machine-2\hr-assembling-machine-2-shadow.png"); } }

        private static Dictionary<String, Texture2D> loaded = new Dictionary<string, Texture2D>();
        private static Texture2D LoadTexture(string filePath)
        {
            if (!loaded.ContainsKey(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    loaded[filePath] = Texture2D.FromStream(graphicsDevice, fileStream);
                }
            }
            return loaded[filePath];
        }

        internal static Texture2D GetIcon(string iconName)
        {
            return LoadTexture(@"..\..\..\..\Images\Icons\" + iconName + ".png");
        }
    }
}
