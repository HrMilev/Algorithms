using System;
using System.Linq;
using System.Threading.Tasks;

public class Queue<T>
{
    private T[] queueArray;
    private int tail;
    private int head;

    public Queue()
    {
        this.queueArray = new T[4];
    }

    public void Enqueue(T item)
    {
        if (tail == queueArray.Length)
        {
            int count = tail - head;
            T[] temp = new T[count * 2];
            Array.Copy(queueArray, head, temp, 0, count);
            queueArray = temp;
            head = 0;
            tail = count;
        }
        queueArray[tail++] = item;
    }

    public T Dequeue()
    {
        if (head==tail)
        {
            throw new Exception("Queue is empty");
        }
        return queueArray[head++];
    }
}

class Client
{
    static void Main()
    {
        Queue<int> q = new Queue<int>();
        for (int i = 1; i < 10; i++)
        {
            q.Enqueue(i);
        }
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine(q.Dequeue());
        }
        for (int i = 1; i < 8; i++)
        {
            q.Enqueue(i);
        }
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine(q.Dequeue());
        }
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine(q.Dequeue());
        }

    }
}
