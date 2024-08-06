namespace DataStructures
{
    //This is the data structure for a Node object within a linked-list. This Node stores
    //references to its preceding and following Nodes
    public class Node
    {
        #region Class Variables
        private int data { get; set; }
        private Node parent { get; set; }
        private Node nextLeft { get; set; }
        private Node nextRight { get; set; }
        #endregion

        #region Class Constructors
        //default Node constructor, no data passed
        public Node()
        {
            nextLeft = null;
            nextRight = null;
        }
        //Node constructor when data passed
        public Node(int _data)
        {
            nextLeft = null;
            nextRight = null;
            data = _data;
        }
        #endregion

        #region Get/Set Functions
        //as class variables are private, must be retrieved or set via the get/set functions below
        public int GetData()
        {
            return data;
        }

        public void SetData(int _data)
        {
            data = _data;
        }

        public Node GetParent() 
        {
            return parent;
        }

        public void SetParent(Node _parent) 
        {
            parent = _parent;
        }

        public Node GetLeft()
        {
            return nextLeft;
        }

        public void SetLeft(Node _nextLeft)
        {
            nextLeft = _nextLeft;
        }

        public Node GetRight()
        {
            return nextRight;
        }

        public void SetRight(Node _nextRight)
        {
            nextRight = _nextRight;
        }
        #endregion
    }
}
