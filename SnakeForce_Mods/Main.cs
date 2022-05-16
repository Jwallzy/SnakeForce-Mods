using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SnakeForce_Mods
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations]

        public const string
            MODNAME = "SnakeForceMods",
            AUTHOR = "Mizar",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "1.0.0.0";

        internal readonly ManualLogSource log;
        internal readonly Harmony harmony;
        internal readonly Assembly assembly;
        public readonly string modFolder;

        #endregion

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }

        #region[References]
        public static PlayerControl P_Control;
        public static FollowerChanger[] F_Changer;
        public static GameObject player;
        #endregion

        public void Start() { harmony.PatchAll(assembly); InitConfig(); }

        #region[PlayerSearch]
        public static void PlayerSearch()
        {
            P_Control = FindObjectOfType<PlayerControl>();
            player = P_Control.gameObject;
            player.GetComponent<Combat>();
            player.GetComponent<Aimer>();
            player.GetComponent<Gun>();
        }

        public static void FollowSearch()
        {
            F_Changer = FindObjectsOfType<FollowerChanger>();
            foreach (FollowerChanger FC in F_Changer)
            {
                FC.GetComponent<Combat>();
                FC.GetComponent<Aimer>();
            }
        }
        #endregion

        public void Update()
        {
            Modules.Character.GOD_MODE.Update();
            Modules.Character.SPEED.Update();
        }

        public void InitConfig()
        {
            Modules.Character.GOD_MODE.KeybindGmode = Config.Bind("Cheats", "God Mode", KeyCode.Keypad0, "GODMODE!");
            Modules.Character.SPEED.keycodeSpeed = Config.Bind("Cheats", "Character speed", KeyCode.Keypad1, "SPEED!");
            Modules.Character.SPEED.speedSpeed = Config.Bind("Cheats", "Speed slider", 8f, new ConfigDescription("Value of speed", new AcceptableValueRange<float>(0f, 999f)));
        }
    }
}
