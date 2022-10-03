using UnityEngine;
using SnakeForce_Mods;
using BepInEx.Configuration;


namespace SnakeForce_Mods.Modules.World
{
    public class ENEMIES
    {
        public static ConfigEntry<KeyCode> keycodeEnemyHP;
        public static ConfigEntry<KeyCode> keycodeByeEnemy;
        public static ConfigEntry<KeyCode> keycodeComeEnemy;
        public static ConfigEntry<int> EnemyHPz;

        public static void Update()
        {
            if (Input.GetKey(keycodeEnemyHP.Value))
            {
                EnemyHP();
                Debug.Log("Enemies Have Been Killed!");
            }
            if (Input.GetKeyDown(keycodeByeEnemy.Value))
            {
                EnemyGoByeBye();
            }
        }

        public static void EnemyHP()
        {
            var enemies = Main.FindObjectsOfType<EnemyMove>();
            foreach (EnemyMove enemy in enemies)
            {
                enemy.GetComponent<Combat>().health = EnemyHPz.Value;
                Debug.Log("Applying Death To Enemies!");
            }
        }

        // Works but needs work, can't re-enable them after disabling them!
        public static void EnemyGoByeBye()
        {
            var Enemies = Main.FindObjectsOfType<EnemyMove>();
            foreach (EnemyMove Enemy in Enemies)
            {
                if (Enemy.gameObject.activeSelf == true)
                {
                    Enemy.gameObject.SetActive(false);
                    Debug.Log("Enemies Going Ghost");
                }
            }
        }
    }
}