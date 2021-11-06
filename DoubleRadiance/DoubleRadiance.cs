using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;
using UnityEngine;
namespace DoubleRadiance
{
    public class DoubleRadiance:Mod,ITogglableMod
    {
        public override string GetVersion()
        {
            return "1.0.0.0";
        }
        public override void Initialize()
        {
            ModHooks.NewGameHook += AddFinder;
            ModHooks.SavegameLoadHook += Load;
            ModHooks.LanguageGetHook += ChangeText;
        }

        private string ChangeText(string key, string sheetTitle, string orig)
        {
            string result;
            switch (key)
            {
                case "GG_S_RADIANCE":
                    result = "被遗忘的光芒神姐妹";
                    break;
                case "ABSOLUTE_RADIANCE_SUPER":
                    result = "无上姐妹";
                    break;
                default:
                    result = Language.Language.GetInternal(key, sheetTitle);
                    break;
            }
            return result;
        }

        private void Load(int id)
        {
            AddFinder();
        }

        private void AddFinder()
        {
            GameManager.instance.gameObject.AddComponent<AbsFinder>();
        }
        public void Unload()
        {
            ModHooks.NewGameHook -= AddFinder;
            ModHooks.SavegameLoadHook -= Load;
            ModHooks.LanguageGetHook -= ChangeText;
            AbsFinder absFinder = GameManager.instance.gameObject.GetComponent<AbsFinder>();
            if(absFinder!=null)
            {
                UnityEngine.Object.Destroy(absFinder);
            }
        }
    }
}
