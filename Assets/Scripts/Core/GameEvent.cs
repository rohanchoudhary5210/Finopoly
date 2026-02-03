using UnityEngine;

namespace Finopoly.Core
{
    [CreateAssetMenu(fileName = "NewEvent", menuName = "Finopoly/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        [Header("Event Display")]
        public string eventTitle;
        [TextArea(3, 5)]
        public string eventDescription;
        public Sprite eventIcon;

        [Header("Choices")]
        public EventChoice choiceA;
        public EventChoice choiceB;

        [System.Serializable]
        public class EventChoice
        {
            public string buttonText;
            
            [Header("Consequences")]
            public int moneyCost; // Negative to cost, positive to gain
            public int happinessImpact;
            public int careerImpact;
            
            [Tooltip("Probability of success (0-1). 1 = Always succeeds.")]
            [Range(0f, 1f)]
            public float successChance = 1f;

            [Header("Failure Consequences (if risky)")]
            public int failMoneyCost;
            public int failHappinessImpact;
        }
    }
}
