using System;
using UnityEngine;

public class NewABB : MonoBehaviour
{
    [SerializeField] private ItemData _normalCrystal;
    [SerializeField] private ItemData _blueCrystal;
    [SerializeField] private ItemData _redCrystal;
    [SerializeField] private ItemData _purpleCrystal;
    [SerializeField] private ItemData _greenCrystal;
    [SerializeField] private ItemData _orangeCrystal;
    [SerializeField] private ItemData _pinkCrystal;

    private readonly BinaryTree _arbol = new();

    private int[] crystals;

    private void Start()
    {
        crystals = new[]
        {
            _normalCrystal.score,
            _blueCrystal.score,
            _redCrystal.score,
            _purpleCrystal.score,
            _greenCrystal.score,
            _orangeCrystal.score,
            _pinkCrystal.score
        };


        for (var i = 0; i < crystals.Length; i++) _arbol.Add(crystals[i]);

        var node = _arbol.Find(5);
        var depth = _arbol.GetTreeDepth();

        Debug.Log("PreOrder Traversal:");
        _arbol.TraversePreOrder(_arbol.Root);

        Debug.Log("InOrder Traversal:");
        _arbol.TraverseInOrder(_arbol.Root);

        Debug.Log("PostOrder Traversal:");
        _arbol.TraversePostOrder(_arbol.Root);

        _arbol.Remove(_normalCrystal.score);
        _arbol.Remove(_pinkCrystal.score);

        Debug.Log("PreOrder Traversal After Removing Operation:");
        _arbol.TraversePreOrder(_arbol.Root);
    }

    private class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    private class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightNode;
                else
                    //Exist same value
                    return false;
            }

            var newNode = new Node();
            newNode.Data = value;

            if (Root == null) //Tree ise empty
            {
                Root = newNode;
            }
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public Node Find(int value)
        {
            return Find(value, Root);
        }

        public void Remove(int value)
        {
            Root = Remove(Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data)
            {
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            else if (key > parent.Data)
            {
                parent.RightNode = Remove(parent.RightNode, key);
            }

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            var minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return GetTreeDepth(Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        // en estos metodos de recorrido meter que instancie los prefabs de los cristales.
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Debug.Log(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Debug.Log(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Debug.Log(parent.Data + " ");
            }
        }
    }
}