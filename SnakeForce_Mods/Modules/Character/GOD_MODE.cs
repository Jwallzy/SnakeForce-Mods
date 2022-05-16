using UnityEngine;
using SnakeForce_Mods;
using BepInEx.Configuration;


namespace SnakeForce_Mods.Modules.Character
{
    public class GOD_MODE
    {
        public static ConfigEntry<KeyCode> KeybindGmode;
        public static void Update()
        {
            if (Input.GetKeyUp(KeybindGmode.Value))
            {
                FollowerHP();
                Main.PlayerSearch();
                Main.FollowSearch();
                Main.player.GetComponent<Combat>().health = 99999;
                Main.player.GetComponent<Combat>().maxHealth = 99999;
                Main.player.GetComponent<Combat>().ignoreExplosion = true;
                Debug.Log("God Mode Applied!");
            }
        }

        public static void FollowerHP()
        {
            var Followers = Main.FindObjectsOfType<FollowerChanger>();

            foreach (FollowerChanger changer in Followers)
            {
                changer.GetComponent<Combat>().health = 99999;
                changer.GetComponent<Combat>().maxHealth = 99999;
                changer.GetComponent<Combat>().ignoreExplosion = true;
                Debug.Log("God Mode Applied To Followers");
            }
        }
    }
}
