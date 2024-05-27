namespace Deques;

class QueueNode(int data)
{
    public int data = data;
    public QueueNode next;
}

class LinkedListQueue
{
    public QueueNode front;
    public QueueNode rear;

    /// <summary>
    /// The Enqueue function adds a new node with a given value to the end of a queue.
    /// </summary>
    /// <param name="value">The `value` parameter in the `Enqueue` method represents the value that you
    /// want to add to the queue. This value will be stored in a new `QueueNode` object and added to the
    /// end of the queue.</param>
    /// <returns>
    /// The method is returning a boolean value of `true`.
    /// </returns>
    public bool Enqueue(int value)
    {
        QueueNode node = new(value);

        if (rear == null)
            front = node;
        else
            rear.next = node;

        rear = node;

        return true;
    }

    /// <summary>
    /// The Dequeue function removes and returns the front or rear element of a queue based on the
    /// specified action.
    /// </summary>
    /// <param name="action">The `action` parameter in the `Dequeue` method is used to determine whether
    /// to dequeue from the front or the rear of the queue. If `action` is 1, it dequeues from the front
    /// of the queue, and if `action` is 2, it dequeues from</param>
    /// <returns>
    /// The Dequeue method returns an integer value, which is the data value of the node that is
    /// dequeued from the queue. If the dequeue operation is successful, the method returns the value of
    /// the dequeued node. If the dequeue operation fails (e.g., the queue is empty or an invalid action
    /// is provided), the method returns -1.
    /// </returns>
    public int Dequeue(int action)
    {
        int value;
        QueueNode tmpNode;

        if (!(front == null) && action == 1)
        {
            if (front == rear)
                rear = null;
            value = front.data;
            front = front.next;
            return value;
        }
        else if (!(rear == null) && action == 2)
        {
            value = rear.data;
            tmpNode = front;

            if (front == rear)
            {
                front = null;
                rear = null;

                return value;
            }

            while (tmpNode.next != rear && tmpNode.next != null)
                tmpNode = tmpNode.next;

            rear = tmpNode;
            rear.next = null;

            return value;
        }
        else
            return -1;
    }

    public void Print()
    {
        QueueNode tmp = front;
        string output = "";

        while (tmp != null)
        {
            output += $"[{tmp.data}]";
            tmp = tmp.next;
        }

        if (output != "")
            WriteLine($"當前雙向佇列為：{output}");
        else
            WriteLine("雙向佇列已經空了！");
    }
}

class Program
{
    private static LinkedListQueue queue;
    private static int count = 0;

    public static void Execute()
    {
        queue = new();
        bool loop = true;

        while (loop)
            loop = Action();
    }

    /// <summary>
    /// The function `Action` performs operations on a double-ended queue based on user input, allowing
    /// for adding, removing from front or back, and ending the queue example.
    /// </summary>
    /// <returns>
    /// The `Action` method returns a boolean value. If the user chooses to add or remove an element
    /// from the queue, the method returns `true`. If the user chooses to end the queue example, the
    /// method returns `false`.
    /// </returns>
    private static bool Action()
    {
        int data;

        switch (GetInput.GetInt("[1]加入[2]取出[3]結束："))
        {
            case 1:
                data = GetInput.GetInt("請輸入資料：");
                queue.Enqueue(data);
                WriteLine($"從雙向佇列後端加入第{++count}筆資料，值為{data}。");
                queue.Print();
                return true;
            case 2:
                data = GetInput.GetInt("[1]前端[2]後端");
                string peak = data == 1 ? "前端" : "後端";
                if (data != 1 && data != 2)
                    goto default;
                data = queue.Dequeue(data);
                if (data != -1)
                {
                    count--;
                    WriteLine($"從雙向佇列{peak}取出的元素資料值為：{data}");
                }
                queue.Print();
                return true;
            default:
                queue.Print();
                WriteLine("結束雙向佇列範例。");
                return false;
        }
    }
}
