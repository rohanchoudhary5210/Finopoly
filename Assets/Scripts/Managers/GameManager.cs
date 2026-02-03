using UnityEngine;
using Finopoly.Core;

namespace Finopoly.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("References")]
        public PlayerStats playerStats;
        public EventManager eventManager;
        public UIManager uiManager;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        [Header("Board References")]
        public Finopoly.Board.BoardManager boardManager;
        public Finopoly.Board.PlayerController playerController;

        private void Start()
        {
            // 1. Setup Board
            boardManager.GenerateBoard();

            // 2. Setup Player
            playerController.Initialize(boardManager.StartNode);
            playerController.OnNodeArrival += HandleNodeArrival;

            // Start Game
            Debug.Log("Game Ready! Press Spin to Move.");
        }

        // Replaces "StartTurn"
        public void SpinWheel()
        {
            if (playerController.IsMoving) return;

            int steps = Random.Range(1, 7); // 1-6 Dice Roll
            Debug.Log($"Rolled a {steps}!");
            playerController.MoveSteps(steps);
        }

        private void HandleNodeArrival(Finopoly.Board.BoardNode node)
        {
            Debug.Log($"Landed on {node.type} ({node.name})");
            playerStats.AdvanceAge(); // Each move is a "turn"/time unit

            switch (node.type)
            {
                case Finopoly.Board.NodeType.Event:
                    GameEvent evt = eventManager.GetRandomEvent(playerStats.Age);
                    if(evt != null) uiManager.ShowEvent(evt);
                    break;
                
                case Finopoly.Board.NodeType.Payday:
                    playerStats.ModifyMoney(1000); // Salary
                    Debug.Log("Payday! +$1000");
                    break;

                case Finopoly.Board.NodeType.End:
                    Debug.Log("Retirement Reached!");
                    break;
            }
        }

        // Kept for compatibility with EventManager callback
        public void OnChoiceSelected(GameEvent.EventChoice choice)
        {
            eventManager.ResolveChoice(choice, playerStats);
            uiManager.HideEvent();
        }
    }
}
