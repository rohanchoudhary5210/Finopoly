using UnityEngine;
using System;

namespace Finopoly.Core
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Player Resources")]
        [SerializeField] private int currentMoney = 1000;
        [SerializeField] private int happiness = 50; // 0 to 100
        [SerializeField] private int riskLevel = 10; // 0 to 100
        [SerializeField] private int careerLevel = 1;

        [Header("Game Progress")]
        [SerializeField] private int age = 18;
        private const int MaxAge = 65;

        // Events for UI updates
        public event Action<int> OnMoneyChanged;
        public event Action<int> OnHappinessChanged;
        public event Action<int> OnAgeChanged;
        public event Action OnGameOver;

        public int CurrentMoney => currentMoney;
        public int Happiness => happiness;
        public int Age => age;

        public void ModifyMoney(int amount)
        {
            currentMoney += amount;
            OnMoneyChanged?.Invoke(currentMoney);

            if (currentMoney < 0)
            {
                Debug.LogWarning("Player is in debt!");
                // Potential game over condition or debt penalty
            }
        }

        public void ModifyHappiness(int amount)
        {
            happiness = Mathf.Clamp(happiness + amount, 0, 100);
            OnHappinessChanged?.Invoke(happiness);

            if (happiness <= 0)
            {
                TriggerGameOver("You have lost all hope. Game Over.");
            }
        }

        public void AdvanceAge()
        {
            age++;
            OnAgeChanged?.Invoke(age);

            if (age >= MaxAge)
            {
                TriggerGameOver("Congratulations! You reached retirement.");
            }
        }

        private void TriggerGameOver(string reason)
        {
            Debug.Log($"Game Over: {reason}");
            OnGameOver?.Invoke();
        }
    }
}
