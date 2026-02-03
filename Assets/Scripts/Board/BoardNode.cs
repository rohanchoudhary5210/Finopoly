using UnityEngine;
using System.Collections.Generic;

namespace Finopoly.Board
{
    public enum NodeType
    {
        Standard,
        Event,
        Payday,
        Decision,
        Start,
        End
    }

    public class BoardNode : MonoBehaviour
    {
        [Header("Node Settings")]
        public NodeType type;
        public string nodeName;
        
        [Header("Navigation")]
        public List<BoardNode> nextNodes; // Supports branching paths

        private void OnDrawGizmos()
        {
            Gizmos.color = GetNodeColor();
            Gizmos.DrawSphere(transform.position, 0.3f);

            if (nextNodes != null)
            {
                Gizmos.color = Color.white;
                foreach (var node in nextNodes)
                {
                    if(node != null)
                        Gizmos.DrawLine(transform.position, node.transform.position);
                }
            }
        }

        public Color GetNodeColor()
        {
            switch (type)
            {
                case NodeType.Start: return Color.green;
                case NodeType.End: return Color.black;
                case NodeType.Payday: return Color.yellow;
                case NodeType.Event: return Color.red;
                case NodeType.Decision: return Color.cyan;
                default: return Color.white;
            }
        }
    }
}
