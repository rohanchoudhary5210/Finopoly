#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro; // Assuming standard, but using standard Text if TMP is tricky without setup
using Finopoly.Managers;
using Finopoly.Core;
using Finopoly.Board;

namespace Finopoly.EditorUtils
{
    public class SceneSetupTool : MonoBehaviour
    {
        [MenuItem("Finopoly/Auto-Setup Scene")]
        public static void SetupScene()
        {
            // 1. Create Core Managers
            GameObject gmObj = SetupGameObject("GameManager", null);
            var gameManager = GetOrAddComponent<GameManager>(gmObj);
            var playerStats = GetOrAddComponent<PlayerStats>(gmObj);
            var eventManager = GetOrAddComponent<EventManager>(gmObj);
            var uiManager = GetOrAddComponent<UIManager>(gmObj);

            // 2. Create Board System
            GameObject boardObj = SetupGameObject("BoardSystem", null);
            var boardManager = GetOrAddComponent<BoardManager>(boardObj);
            
            // Create Player Token
            GameObject playerObj = SetupGameObject("PlayerToken", null);
            var playerController = GetOrAddComponent<PlayerController>(playerObj);
            var sr = GetOrAddComponent<SpriteRenderer>(playerObj);
            sr.color = Color.blue; // Placeholder visual

            // 3. Create UI
            GameObject canvasObj = SetupGameObject("Canvas", null);
            var canvas = GetOrAddComponent<Canvas>(canvasObj);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            GetOrAddComponent<CanvasScaler>(canvasObj);
            GetOrAddComponent<GraphicRaycaster>(canvasObj);

            // UI - Top Panel
            GameObject topPanel = SetupUIObject("TopPanel", canvasObj);
            SetRect(topPanel, 0, 1, 1, 1, 0, -100); // Top bar
            
            var moneyText = CreateText(topPanel, "MoneyText", "$0");
            var happinessText = CreateText(topPanel, "HappinessText", ":)");
            var ageText = CreateText(topPanel, "AgeText", "Age: 18");

            // UI - Event Center
            GameObject eventPanel = SetupUIObject("EventPanel", canvasObj);
            var titleText = CreateText(eventPanel, "Title", "Event Title");
            var descText = CreateText(eventPanel, "Description", "Event Description...");
            
            // UI - Buttons
            var btnA = CreateButton(eventPanel, "ButtonA", "Choice A");
            var btnB = CreateButton(eventPanel, "ButtonB", "Choice B");

            // UI - Spin Button
            var spinPanel = SetupUIObject("BottomPanel", canvasObj);
            SetRect(spinPanel, 0, 0, 1, 0, 0, 100); // Bottom bar
            var spinBtn = CreateButton(spinPanel, "SpinButton", "SPIN!");

            // 4. Wiring References
            // GameManager
            gameManager.playerStats = playerStats;
            gameManager.eventManager = eventManager;
            gameManager.uiManager = uiManager;
            gameManager.boardManager = boardManager;
            gameManager.playerController = playerController;

            // UIManager
            uiManager.moneyText = moneyText;
            uiManager.happinessText = happinessText;
            uiManager.ageText = ageText;
            uiManager.eventPanel = eventPanel;
            uiManager.eventTitle = titleText;
            uiManager.eventDescription = descText;
            uiManager.choiceAButton = btnA;
            uiManager.choiceBButton = btnB;
            // Note: UIManager Button Text fields might need manual drag if not exposed as GameObject or Text
            
            // BoardManager setup (Prefab needs to exist, otherwise warn)
            string nodePrefabPath = "Assets/Prefabs/NodePrefab.prefab";
            GameObject nodePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(nodePrefabPath);
            if(nodePrefab == null) 
            {
                // Create a temporary one if missing
                GameObject tempNode = new GameObject("NodePrefab");
                tempNode.AddComponent<BoardNode>();
                tempNode.AddComponent<SpriteRenderer>();
                
                if(!AssetDatabase.IsValidFolder("Assets/Prefabs")) AssetDatabase.CreateFolder("Assets", "Prefabs");
                nodePrefab = PrefabUtility.SaveAsPrefabAsset(tempNode, nodePrefabPath);
                DestroyImmediate(tempNode);
            }
            boardManager.nodePrefab = nodePrefab;
            boardManager.boardContainer = boardObj.transform;

            // Event System
            if(Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
            {
                GameObject es = new GameObject("EventSystem");
                es.AddComponent<UnityEngine.EventSystems.EventSystem>();
                es.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            }

            Debug.Log("<color=green>Scene Setup Complete!</color>");
        }

        private static GameObject SetupGameObject(string name, GameObject parent)
        {
            GameObject obj = GameObject.Find(name);
            if (obj == null) obj = new GameObject(name);
            if (parent != null) obj.transform.SetParent(parent.transform, false);
            return obj;
        }

        private static T GetOrAddComponent<T>(GameObject obj) where T : Component
        {
            T comp = obj.GetComponent<T>();
            if (comp == null) comp = obj.AddComponent<T>();
            return comp;
        }

        private static GameObject SetupUIObject(string name, GameObject parent)
        {
            GameObject obj = SetupGameObject(name, parent);
            GetOrAddComponent<RectTransform>(obj);
            return obj;
        }

        private static TextMeshProUGUI CreateText(GameObject parent, string name, string content)
        {
            GameObject obj = SetupUIObject(name, parent);
            var txt = GetOrAddComponent<TextMeshProUGUI>(obj);
            txt.text = content;
            txt.color = Color.black;
            txt.fontSize = 24;
            return txt;
        }

        private static Button CreateButton(GameObject parent, string name, string label)
        {
            GameObject obj = SetupGameObject(name, parent);
            var img = GetOrAddComponent<Image>(obj);
            img.color = Color.white;
            var btn = GetOrAddComponent<Button>(obj);
            
            // Create label
            CreateText(obj, "Label", label);
            
            // Layout (simple)
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 50);

            return btn;
        }

        private static void SetRect(GameObject obj, float anchorMinX, float anchorMinY, float anchorMaxX, float anchorMaxY, float height, float posY)
        {
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(anchorMinX, anchorMinY);
            rt.anchorMax = new Vector2(anchorMaxX, anchorMaxY);
            rt.sizeDelta = new Vector2(0, height); // Height
            rt.anchoredPosition = new Vector2(0, posY);
        }
    }
}
#endif
