// Узел кольцевого списка

public class CircleNode
{
    public int Data; // Данные, хранящиеся в узле
    public CircleNode Next; // Ссылка на следующий узел

    // Конструктор для создания нового узла с заданным значением
    public CircleNode(int data)
    {
        Data = data;
        Next = null;
    }
}

// Класс кольцевого списка
public class CircularLinkedList
{
    private CircleNode head; // Начало списка (первый узел)
    private CircleNode tail; // Конец списка (последний узел)

    // Добавление нового узла в конец списка
    public void AddLast(int data)
    {
        CircleNode newNode = new CircleNode(data);
        if (head == null)
        {
            // Если список пуст, новый узел становится и головой, и хвостом
            head = newNode;
            tail = newNode;
            tail.Next = head; // Создаем кольцо, указывая, что следующий элемент после хвоста - это голова
        }
        else
        {
            // Если список не пуст, добавляем новый узел в конец и обновляем хвост
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head; // Обновляем кольцо
        }
    }

    // Добавление нового узла в начало списка
    public void AddFirst(int data)
    {
        CircleNode newNode = new CircleNode(data);
        if (head == null)
        {
            // Если список пуст, новый узел становится и головой, и хвостом
            head = newNode;
            tail = newNode;
            tail.Next = head; // Создаем кольцо, указывая, что следующий элемент после хвоста - это голова
        }
        else
        {
            // Если список не пуст, добавляем новый узел в начало и обновляем голову
            newNode.Next = head;
            head = newNode;
            tail.Next = head; // Обновляем кольцо
        }
    }

    // Удаление узла с заданным значением
    public void Remove(int data)
    {
        if (head == null) return; // Если список пуст, ничего не делаем

        CircleNode current = head;
        CircleNode previous = null;

        // Поиск узла для удаления
        do
        {
            if (current.Data == data)
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                    if (current == tail)
                    {
                        tail = previous; // Обновляем хвост, если удаляем последний элемент
                    }
                }
                else
                {
                    // Если удаляемый узел - это голова
                    if (head == tail)
                    {
                        // Если это единственный узел в списке
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        head = head.Next;
                        tail.Next = head; // Обновляем кольцо
                    }
                }

                return; // Удалив узел, выходим из метода
            }

            previous = current;
            current = current.Next;
        } while (current != head);
    }

    // Печать всех узлов списка
    public void PrintList()
    {
        if (head == null) return; // Если список пуст, ничего не делаем

        CircleNode current = head;
        do
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        } while (current != head);

        Console.WriteLine();
    }

    public static void CallCircleList()
    {
        CircularLinkedList list = new CircularLinkedList();

        // Добавление элементов в конец списка
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(3);
        Console.WriteLine("Список после добавления элементов в конец церкел:");
        list.PrintList(); // Ожидаемый вывод: 10 20 30

        // Добавление элементов в начало списка
        list.AddFirst(55546);
        list.AddFirst(1);
        Console.WriteLine("Список после добавления элементов в начало  церкел:");
        list.PrintList(); // Ожидаемый вывод: 1 5 10 20 30

        // Удаление элемента
        list.Remove(20);
        Console.WriteLine("Список после удаления элемента 20 церкел:");
        list.PrintList(); // Ожидаемый вывод: 1 5 10 30
    }
}