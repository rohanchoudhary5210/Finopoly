using UnityEngine;
using System.Collections;
using System;

namespace Finopoly.Board
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        
        public BoardNode CurrentNode { get; private set; }
        public bool IsMoving { get; private set; }

        public event Action<BoardNode> OnNodeArrival;

        public void Initialize(BoardNode startNode)
        {
            CurrentNode = startNode;
            transform.position = startNode.transform.position;
        }

        public void MoveSteps(int steps)
        {
            if (IsMoving) return;
            StartCoroutine(MoveRoutine(steps));
        }

        private IEnumerator MoveRoutine(int steps)
        {
            IsMoving = true;

            for (int i = 0; i < steps; i++)
            {
                if (CurrentNode.nextNodes == null || CurrentNode.nextNodes.Count == 0)
                    break;

                // Simple pathing: take first option (Branching logic can be added here)
                BoardNode next = CurrentNode.nextNodes[0]; 
                
                yield return StartCoroutine(MoveToNode(next));
                CurrentNode = next;
            }

            IsMoving = false;
            OnNodeArrival?.Invoke(CurrentNode);
        }

        private IEnumerator MoveToNode(BoardNode target)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = target.transform.position;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }
            transform.position = endPos;
        }
    }
}
