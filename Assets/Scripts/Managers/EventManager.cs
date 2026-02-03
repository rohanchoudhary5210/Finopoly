using System.Collections.Generic;
using UnityEngine;
using Finopoly.Core;

namespace Finopoly.Managers
{
    public class EventManager : MonoBehaviour
    {
        [Header("Event Database")]
        [SerializeField] private List<GameEvent> studentEvents;
        [SerializeField] private List<GameEvent> adultEvents;
        
        public GameEvent GetRandomEvent(int age)
        {
            List<GameEvent> pool = GetEventPool(age);
            
            if (pool.Count == 0)
            {
                Debug.LogWarning("No events found for this age group!");
                return null;
            }

            return pool[Random.Range(0, pool.Count)];
        }

        private List<GameEvent> GetEventPool(int age)
        {
            // Simple stage logic
            if (age < 23) return studentEvents;
            return adultEvents;
        }

        public void ResolveChoice(GameEvent.EventChoice choice, PlayerStats stats)
        {
            // Determine success based on chance
            bool success = Random.value <= choice.successChance;

            if (success)
            {
                ApplyConsequences(choice.moneyCost, choice.happinessImpact, stats);
                Debug.Log($"Choice '{choice.buttonText}' Success!");
            }
            else
            {
                // Apply failure consequences
                ApplyConsequences(choice.failMoneyCost, choice.failHappinessImpact, stats);
                Debug.Log($"Choice '{choice.buttonText}' Failed!");
            }
        }

        private void ApplyConsequences(int money, int happiness, PlayerStats stats)
        {
            stats.ModifyMoney(money);
            stats.ModifyHappiness(happiness);
        }
    }
}
