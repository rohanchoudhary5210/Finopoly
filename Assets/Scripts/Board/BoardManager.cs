using UnityEngine;
using System.Collections.Generic;

namespace Finopoly.Board
{
    public class BoardManager : MonoBehaviour
    {
        [Header("Generation Settings")]
        public GameObject nodePrefab;
        public int boardLength = 40;
        public float nodeSpacing = 2f;
        public Transform boardContainer;

        public BoardNode StartNode { get; private set; }

        public void GenerateBoard()
        {
            // Simple straight line generator for prototype
            BoardNode previousNode = null;

            for (int i = 0; i < boardLength; i++)
            {
                Vector3 position = new Vector3(i * nodeSpacing, 0, 0); // Horizontal line
                GameObject nodeObj = Instantiate(nodePrefab, position, Quaternion.identity, boardContainer);
                nodeObj.name = $"Node_{i}";
                
                BoardNode node = nodeObj.GetComponent<BoardNode>();
                
                // Assign Types
                if (i == 0) node.type = NodeType.Start;
                else if (i == boardLength - 1) node.type = NodeType.End;
                else if (i % 5 == 0) node.type = NodeType.Payday;
                else if (i % 3 == 0) node.type = NodeType.Event;
                else node.type = NodeType.Standard;

                // Link
                if (previousNode != null)
                {
                    previousNode.nextNodes = new List<BoardNode> { node };
                }
                else
                {
                    StartNode = node;
                }

                previousNode = node;
            }
        }
    }
}
