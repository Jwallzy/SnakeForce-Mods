using UnityEngine;
using SnakeForce_Mods;
using BepInEx.Configuration;

namespace SnakeForce_Mods.Modules.World
{
    public class WORLD_OBJs
    {
        public static void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                var Drums = Main.FindObjectsOfType<Breakable>();
                foreach (var obj in Drums)
                {
                    obj.boomForce = 1000;
                    obj.boomHurt = 99;
                    obj.breakDelay = 0.1f;
                    obj.health = 1;
                    obj.boomRadius = 20.0f;
                    Debug.Log("Drums Set!");
                }
            }
        }
    }
}
