using BehaviorTree;
using UnityEngine;

namespace _Main._Resources.Scripts.Utilities.TDA.ABB
{
    public class BinaryTree : MonoBehaviour
    {
        public abstract class Tree : MonoBehaviour
        {

            private Node _root = null;

            protected void Start()
            {
                _root = SetupTree();
            }

            private void Update()
            {
                if (_root != null)
                    _root.Evaluate();
            }

            protected abstract Node SetupTree();

        }
        
        
        
        
    }
}
