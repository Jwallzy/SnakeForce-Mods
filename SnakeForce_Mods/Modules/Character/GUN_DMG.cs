using BepInEx.Configuration;
using UnityEngine;

namespace SnakeForce_Mods.Modules.Character
{
    public class GUN_DMG
    {
        public static ConfigEntry<KeyCode> keycodeGun;
        public static ConfigEntry<int> P_Dmgval;
        public static ConfigEntry<int> F_Dmgval;
        public static ConfigEntry<int> F_BLval;
        public static ConfigEntry<int> P_BLval;
        public static ConfigEntry<int> P_BSval;
        public static ConfigEntry<int> F_BSval;

        public static void Update()
        {
            if (Input.GetKeyDown(keycodeGun.Value))
            {
                Main.PlayerSearch();
                Main.FollowSearch();
                FollowerDMG();
                Main.P_Control.GetComponent<Combat>().Gun.damage = P_Dmgval.Value;
                Main.P_Control.GetComponent<Combat>().Gun.bulletLife = P_BLval.Value;
                Main.P_Control.GetComponent<Combat>().Gun.speed = P_BSval.Value;
                Debug.Log("Gun Mode Applied To Player");
            }
        }

        public static void FollowerDMG()
        {
            var Followers = Main.FindObjectsOfType<FollowerChanger>();

            foreach (FollowerChanger changer in Followers)
            {
                changer.GetComponent<Combat>().Gun.damage = F_Dmgval.Value;
                changer.GetComponent<Combat>().Gun.bulletLife = F_BLval.Value;
                changer.GetComponent<Combat>().Gun.speed = F_BSval.Value;
                Debug.Log("Gun Mode Applied To Followers");
            }
        }
    }
}
