using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ABB_Nacho : MonoBehaviour
{
    [SerializeField] ItemData _normalCrystal;
    [SerializeField] ItemData _blueCrystal;
    [SerializeField] ItemData _redCrystal;
    [SerializeField] ItemData _purpleCrystal;
    [SerializeField] ItemData _greenCrystal;
    [SerializeField] ItemData _orangeCrystal;
    [SerializeField] ItemData _pinkCrystal;

    private BinaryTree _arbol = new BinaryTree();

    private int[] crystals;

    private void Start()
    {
        crystals = new int[]
        {_normalCrystal.score,
        _blueCrystal.score,
        _redCrystal.score,
        _purpleCrystal.score,
        _greenCrystal.score,
        _orangeCrystal.score,
        _pinkCrystal.score
        };


        for (int i = 0; i < crystals.Length; i++)
        {
            _arbol.Add(crystals[i]);
        }

        Node node = _arbol.Find(5);
        int depth = _arbol.GetTreeDepth();

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

    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
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
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

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
                else
                    return Find(value, parent.RightNode);
            }
            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
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
