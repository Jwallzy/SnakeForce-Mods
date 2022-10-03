using UnityEngine;
using SnakeForce_Mods;
using BepInEx.Configuration;

namespace SnakeForce_Mods.Modules.World
{
    public class TIME
    {
        public static ConfigEntry<KeyCode> keycodeTime;

        public static void Update()
        {
            if (Input.GetKeyDown(keycodeTime.Value))
            {
                if (Main.Ltimer != null)
                {
                    Main.Set1 = !Main.Set1;
                    Main.Ltimer.timer.paused = !Main.Set1;
                    Debug.Log("Timer Paused!");
                }
                else if (Main.Ltimer == null)
                {
                    Main.Ltimer = Main.FindObjectOfType<LevelTimer>();
                    Debug.Log("Ltimer not found!");
                }
            }
        }
    }
}
