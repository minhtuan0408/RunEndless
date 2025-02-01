using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeehaviourTree
{
    public enum  Status { Success, Failure, Running }
    public class Node
    {
        public readonly string name;
        public Status StatusChild;
        public Node(string name = "node")
        {
            this.name = name;
        }

        public readonly List<Node> children = new List<Node>();
        protected int currentChild;

        public void AddChild(Node child) => children.Add(child);

        public virtual Status Process() => children[currentChild].StatusChild;
        
        public virtual void Reset()
        {
            currentChild = 0;
            foreach (Node child in children)
            {
                child.Reset();
            }
        }
    }


    public class Leaf : Node
    {
        public Leaf(IStrategy strategy, string name ) : base(name)
        {
            this.strategy = strategy;

        }

        private readonly IStrategy strategy;
        public override Status Process () => strategy.Process();
        public override void Reset() => strategy.Reset();

    }

    public class Selector : Node
    {
        private int cnt = 0;
        private bool tick = false;

        public override Status Process()
        {
            if (tick)
            {
                return Status.Success;
            }
            Status status = children[cnt].Process();
            if (status == Status.Success) 
            {
                tick = true;
            }
            return Status.Running;
        }
        public override void Reset() 
        {
            cnt = Random.Range(0, children.Count);
        }
    }

    public class BehaviourTree : Node
    {
        public override Status Process()
        {
            while (currentChild < children.Count)
            {
                Status status = children[currentChild].Process();
                if (status == Status.Running)
                {
                    return Status.Running;
                }
                currentChild++;
            }
            currentChild = 0;
            foreach (Node child in children)
            {
                child.Reset();
            }
            return Status.Success;
        }
    }
}
