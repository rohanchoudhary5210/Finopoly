#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Finopoly.Core;
using System.IO;

namespace Finopoly.EditorUtils
{
    public class ContentGenerator : MonoBehaviour
    {
        [MenuItem("Finopoly/Generate Sample Events")]
        public static void GenerateEvents()
        {
            EnsureDirectory("Assets/Resources/Events/Student");
            EnsureDirectory("Assets/Resources/Events/Adult");

            // Student Event 1
            CreateEvent("Student", "PartTimeJob", "Part-Time Job Offer", 
                "A local café is hiring. It pays well but will eat into your study time.",
                "Take the job", 500, -10, 0,
                "Focus on studies", 0, 0, 5);

            // Student Event 2
            CreateEvent("Student", "PartyTime", "Campus Party", 
                "Everyone is going to the big weekend bash.",
                "Go Party!", -100, 20, -5,
                "Stay home", 0, -5, 5);

            // Student Event 3 - Fee Hike
            CreateEvent("Student", "TuitionHike", "Tuition Fee Hike", 
                "The university raised fees unexpectedly. You need to pay up.",
                "Pay ($1000)", -1000, 0, 0,
                "Take Loan (Happiness Hit)", 0, -30, 0);

            // Adult Event 1
            CreateEvent("Adult", "CarTrouble", "Car Breakdown", 
                "Your car engine creates a suspicious smoke. It needs repairs.",
                "Fix it ($500)", -500, 5, 0,
                "DIY Repair (Risk)", 0, 0, 0, 0.4f, -1000, -10);

            // Adult Event 2 - Rent Increase
            CreateEvent("Adult", "RentIncrease", "Rent Increase", 
                "Landlord wants $200 more per month.",
                "Pay it", -2400, 5, 0,
                "Move Out (Costly Move)", -1000, -10, 0);

            // Adult Event 3 - Stock Market
            CreateEvent("Adult", "StockMarket", "Market Boom", 
                "Tech stocks are rallying! Do you want to invest?",
                "Invest $2000", -2000, 5, 0,
                "Stay Safe", 0, 0, 0, 0.7f, 0, -20); // 70% chance to double? Logic needs EventManager tweak for gains, for now it's just stat mods.

            AssetDatabase.SaveAssets();
            Debug.Log("Sample Events Generated in Assets/Resources/Events/");
        }

        private static void CreateEvent(string subfolder, string fileName, string title, string desc,
            string btnA, int costA, int hapA, int carA,
            string btnB, int costB, int hapB, int carB,
            float chanceB = 1.0f, int failCostB = 0, int failHapB = 0)
        {
            GameEvent evt = ScriptableObject.CreateInstance<GameEvent>();
            evt.eventTitle = title;
            evt.eventDescription = desc;
            
            evt.choiceA = new GameEvent.EventChoice 
            { 
                buttonText = btnA, moneyCost = costA, happinessImpact = hapA, careerImpact = carA, successChance = 1f 
            };
            
            evt.choiceB = new GameEvent.EventChoice 
            { 
                buttonText = btnB, moneyCost = costB, happinessImpact = hapB, careerImpact = carB, 
                successChance = chanceB, failMoneyCost = failCostB, failHappinessImpact = failHapB 
            };

            string path = $"Assets/Resources/Events/{subfolder}/{fileName}.asset";
            AssetDatabase.CreateAsset(evt, path);
        }

        private static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
#endif
