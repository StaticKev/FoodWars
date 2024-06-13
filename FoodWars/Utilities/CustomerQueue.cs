using FoodWars.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Utilities
{
    public class CustomerQueue<T> where T : Customers
    {
        private T[] queue;
        private int maximumWeight;
        private int weight;
        private int front;
        private int rear;

        public CustomerQueue(int capacity, int maximumWeight)
        {
            this.queue = new T[capacity];
            this.maximumWeight = maximumWeight;
            this.weight = 0;
            this.front = -1;
            this.rear = -1;
        }

        public void EnQueue(T value)
        {
            int valueWeight = value.CountWeight();
            if (!(valueWeight <= maximumWeight - weight))
            {
                throw new ArgumentException("Queue weight exceeded!");
            }
            else
            {
                rear++;
                if (front == -1)
                {
                    front = 0;
                }

                if (isFull())
                {
                    rear--;
                    throw new StackOverflowException("Stack is full!");
                }
                else
                {
                    queue[rear] = value;
                }
            }
        }

        public T DeQueue()
        {
            if (front == queue.Length)
            {
                throw new ArgumentException("Reached end of queue!");
            }
            else if (isEmpty())
            {
                throw new ArgumentException("Queue is empty!");
            }
            else
            {
                return queue[front++];
            }
        }

        public T Peek()
        {
            if (isEmpty())
            {
                throw new ArgumentException("Queue is empty!");
            }
            else
            {
                return queue[front];
            }
        }

        public bool isFull()
        {
            return rear == queue.Length;
        }

        public bool isEmpty()
        {
            return front == rear + 1 || rear == -1;
        }

        public int size()
        {
            return queue.Length;
        }
    }
}
