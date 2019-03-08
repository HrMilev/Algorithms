using System;

public class Stack<T>
{
    private T[] stackArray;
    private int pointer;

    public Stack()
    {
        this.stackArray = new T[4];
        this.pointer = -1;
    }

    public void Push(T item)
    {
        if (pointer == stackArray.Length-1)
        {
            T[] temp = new T[pointer * 2];
            Array.Copy(stackArray, temp,stackArray.Length);
            stackArray = temp;
        }
        pointer++;
        stackArray[pointer] = item;
    }

    public T Peek()
    {
        if (pointer<0)
        {
            throw new Exception("Stack is empty");
        }
        else
        {
            return stackArray[pointer];
        }
    }

    public T Pop()
    {
        if (pointer < 0)
        {
            throw new Exception("Stack is empty");
        }
        else
        {
            pointer--;
            return stackArray[pointer+1];
        }

    }

}

class MainClass
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>();
        for (int i = 1; i < 8; i++)
        {
            stack.Push(i);
        }
        Console.WriteLine(stack.Peek());
        for (int i = 1; i < 8; i++)
        {
            stack.Pop();
        }
        Console.WriteLine(stack.Peek());

    }
}