using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assuming TextMeshPro is used
using Finopoly.Core;

namespace Finopoly.Managers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Stats UI")]
        public TextMeshProUGUI moneyText;
        public TextMeshProUGUI happinessText;
        public TextMeshProUGUI ageText;

        [Header("Event UI")]
        public GameObject eventPanel;
        public TextMeshProUGUI eventTitle;
        public TextMeshProUGUI eventDescription;
        public Button choiceAButton;
        public Button choiceBButton;
        // Text inside buttons
        public TextMeshProUGUI choiceAText;
        public TextMeshProUGUI choiceBText;

        [Header("Action Phase UI")]
        public GameObject actionPanel;

        public void UpdateStats(int money, int happiness, int age)
        {
            if(moneyText) moneyText.text = $"${money}";
            if(happinessText) happinessText.text = $"Happy: {happiness}%";
            if(ageText) ageText.text = $"Age: {age}";
        }

        public void ShowEvent(GameEvent gEvent)
        {
            eventPanel.SetActive(true);
            actionPanel.SetActive(false);

            eventTitle.text = gEvent.eventTitle;
            eventDescription.text = gEvent.eventDescription;

            // Setup Buttons
            SetupButton(choiceAButton, choiceAText, gEvent.choiceA);
            SetupButton(choiceBButton, choiceBText, gEvent.choiceB);
        }

        private void SetupButton(Button btn, TextMeshProUGUI txt, GameEvent.EventChoice choice)
        {
            txt.text = choice.buttonText;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => GameManager.Instance.OnChoiceSelected(choice));
        }

        public void HideEvent()
        {
            eventPanel.SetActive(false);
        }

        public void ShowActionPhase()
        {
            actionPanel.SetActive(true);
        }
    }
}
