// Узел двусвязного списка

public class Node
{
    public int Data; // Данные, хранящиеся в узле
    public Node Next; // Ссылка на следующий узел
    public Node Previous; // Ссылка на предыдущий узел

    // Конструктор для создания нового узла с заданным значением
    public Node(int data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

// Класс двусвязного списка
public class DoublyLinkedList
{
    private Node head; // Начало списка (первый узел)
    private Node tail; // Конец списка (последний узел)

    // Добавление нового узла в конец списка
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            // Если список пуст, новый узел становится и головой, и хвостом
            head = newNode;
            tail = newNode;
        }
        else
        {
            // Если список не пуст, добавляем новый узел в конец и обновляем хвост
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
    }

    // Добавление нового узла в начало списка
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            // Если список пуст, новый узел становится и головой, и хвостом
            head = newNode;
            tail = newNode;
        }
        else
        {
            // Если список не пуст, добавляем новый узел в начало и обновляем голову
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
    }

    // Удаление узла с заданным значением
    public void Remove(int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
            {
                // Если узел найден, обновляем ссылки соседних узлов
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // Если удаляемый узел - это голова
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // Если удаляемый узел - это хвост
                    tail = current.Previous;
                }

                return; // Удалив узел, выходим из метода
            }

            current = current.Next; // Переходим к следующему узлу
        }
    }

    // Печать всех узлов списка
    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }

    public static void CallDoubleLinkedList()
    {
        DoublyLinkedList list = new DoublyLinkedList();

        // Добавление элементов в конец списка
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        Console.WriteLine("Список после добавления элементов в конец:");
        list.PrintList(); // Ожидаемый вывод: 10 20 30

        // Добавление элементов в начало списка
        list.AddFirst(5);
        list.AddFirst(1);
        Console.WriteLine("Список после добавления элементов в начало:");
        list.PrintList(); // Ожидаемый вывод: 1 5 10 20 30

        // Удаление элемента
        list.Remove(20);
        Console.WriteLine("Список после удаления элемента 20:");
        list.PrintList(); // Ожидаемый вывод: 1 5 10 30
    }
}