namespace DataStructures
{
    //This is the data structure for a Node object within a linked-list. This Node stores
    //references to its preceding and following Nodes
    public class Node
    {
        #region Class Variables
        private int data { get; set; }
        private Node next { get; set; }    //ref to next node in linked list
        private Node prev { get; set; }     //ref to previous node in linked list
        #endregion

        #region Class Constructors
        //default Node constructor, no data passed
        public Node()
        {
            next = null;
            prev = null;
        }
        //Node constructor when data passed
        public Node(int _data)
        {
            next = null;
            prev = null;
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

        public Node GetNext()
        {
            return next;
        }

        public void SetNext(Node _next)
        {
            next = _next;
        }

        public Node GetPrev()
        {
            return prev;
        }

        public void SetPrev(Node _prev)
        {
            prev = _prev;
        }
        #endregion
    }
}
