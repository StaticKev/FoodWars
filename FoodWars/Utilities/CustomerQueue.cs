using System;

namespace FoodWars.Utilities
{
    public class CustomerQueue
    {
        #region Data Members
        private int size;
        private Customers[] queue;
        private int front;
        private int rear;
        #endregion

        #region Constructors
        public CustomerQueue(int size)
        {
            this.Size = size;
            this.queue = new Customers[this.Size];
            this.front = -1;
            this.rear = -1;
        }
        #endregion

        #region Properties
        public int Size
        {
            get => this.size;
            private set
            {
                if (this.size < 1) throw new ArgumentException("Size must be greater than zero!");
                else this.size = value;
            } 
        }
        #endregion 

        #region Methods
        public void EnQueue(Customers value)
        {
            rear++;
            if (front == -1)
            {
                front = 0;
            }

            if (IsFull())
            {
                rear--;
                throw new StackOverflowException("Stack is full!");
            }
            else
            {
                queue[rear] = value;
            }
        }

        public Customers DeQueue()
        {
            if (!HasNext())
            {
                throw new ArgumentException("Reached end of queue!");
            }
            else if (IsEmpty())
            {
                throw new ArgumentException("Queue is empty!");
            }
            else
            {
                return queue[front++];
            }
        }

        public Customers Peek()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Queue is empty!");
            }
            else
            {
                return queue[front];
            }
        }

        public bool IsFull()
        {
            return rear == this.Size;
        }

        public bool IsEmpty()
        {
            return rear == -1;
        }

        public bool HasNext()
        {
            return front < rear + 1;
        }
        #endregion

    }
}
