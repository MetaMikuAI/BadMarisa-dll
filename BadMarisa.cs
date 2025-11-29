using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;
using System;

namespace BadMarisa
{
    [BepInPlugin("com.metamiku.badmarisa", "BadMarisa", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        public string pluginInfo = "BadMarisa By MetaMiku v1.0.1";
        private Text myText;
        public Canvas targetCanvas;
        
        void Start()
        {
            init_text();
            
            var harmony = new Harmony("com.metamiku.badmarisa");
            harmony.PatchAll();
        }

        void init_text()
        {
            var gameManager = ManagerBase<GameManager>.Instance;
            if (gameManager == null)
            {
                Logger.LogError("GameManager instance not found!");
                return;
            }

            if (gameManager.CanvasUI != null)
            {
                targetCanvas = gameManager.CanvasUI.GetComponent<Canvas>();
                Logger.LogInfo("Using CanvasUI as target canvas.");
            }
            else if (gameManager.CanvasSystem != null)
            {
                targetCanvas = gameManager.CanvasSystem.GetComponent<Canvas>();
                Logger.LogInfo("Using CanvasSystem as target canvas.");
            }

            if (targetCanvas == null)
            {
                Logger.LogError("No Canvas found from GameManager!");
                return;
            }

            GameObject textObj = new GameObject("BadMarisaText");
            textObj.transform.SetParent(targetCanvas.transform, false);

            myText = textObj.AddComponent<Text>();
            myText.font = Font.CreateDynamicFontFromOSFont("Microsoft YaHei", 24);
            myText.fontSize = 20;
            myText.color = Color.black;
            myText.fontStyle = FontStyle.Bold;
            myText.alignment = TextAnchor.LowerLeft;
            myText.text = "BadMarisa Loaded";
            myText.horizontalOverflow = HorizontalWrapMode.Overflow;
            myText.verticalOverflow = VerticalWrapMode.Overflow;

            Outline outline = textObj.AddComponent<Outline>();
            outline.effectColor = Color.white;
            outline.effectDistance = new Vector2(2, 2);

            RectTransform rect = textObj.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(0, 0);
            rect.pivot = new Vector2(0, 0);
            rect.anchoredPosition = new Vector2(40, 20);
            rect.sizeDelta = new Vector2(400, 50);

            Logger.LogInfo("BadMarisa Text created on game canvas.");
        }

        void Update()
        {
            if (myText == null)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                myText.enabled = !myText.enabled;
            }

            var currentDataHub = ManagerBase<CurrentDataHub>.Instance;
            var dataHub = ManagerBase<DataHub>.Instance;
            var bookStackList = currentDataHub.bookStackList;
            var bookStack = 0L;
            for (int i = 0; i < bookStackList.Count; i++)
            {
                bookStack += bookStackList[i];
            }
            var marisaHP = currentDataHub.marisaHP;
            var pointB = currentDataHub.pointB;
            var nowPhase = (int)Traverse.Create(currentDataHub).Field("nowPhase").GetValue();
            var maxStackSys = dataHub.maxStackSys;
            var maxBookStack = maxStackSys[nowPhase];

            myText.text = $"[BadMarisa v1.0.1] bookStack: {bookStack}/{maxBookStack}    marisaHP: {marisaHP}    B点: {pointB}";
        }
    }

    [HarmonyPatch(typeof(HintTips), "Refresh")]
    class HintTips_Refresh_Patch
    {
        static void Postfix(HintTips __instance)
        {
            var myTXT = Traverse.Create(__instance).Field<Text>("myTXT").Value;
            if (myTXT != null)
            {
                myTXT.text += "\n[/] BadMarisa 统计信息";
            }
        }
    }

}
