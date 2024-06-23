using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Utilities
{
    public class CustomerQueue
    {
        #region Data Members
        private Customers[] queue;
        private int front;
        private int rear;
        #endregion

        #region Constructors
        public CustomerQueue(int capacity)
        {
            this.queue = new Customers[capacity];
            this.front = -1;
            this.rear = -1;
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
            return rear == queue.Length;
        }

        public bool IsEmpty()
        {
            return rear == -1;
        }

        public bool HasNext()
        {
            return front < rear + 1;
        }

        public int Size()
        {
            return queue.Length;
        }
        #endregion

    }
}
