// Узел бинарного дерева поиска

public class TreeNode
{
    public int Data; // Данные, хранящиеся в узле
    public TreeNode Left; // Левый потомок
    public TreeNode Right; // Правый потомок

    // Конструктор для создания нового узла с заданным значением
    public TreeNode(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

// Класс бинарного дерева поиска
public class BinarySearchTree
{
    private TreeNode root; // Корень дерева

    // Добавление нового узла в дерево
    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    // Рекурсивная функция для вставки нового узла
    private TreeNode InsertRec(TreeNode root, int data)
    {
        // Если дерево пустое, возвращаем новый узел
        if (root == null)
        {
            root = new TreeNode(data);
            return root;
        }

        // Иначе рекурсивно спускаемся по дереву
        if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }

        // Возвращаем (не изменённый) указатель узла
        return root;
    }

    // Обход дерева в порядке возрастания (инфиксный обход)
    public void InOrderTraversal()
    {
        InOrderRec(root);
        Console.WriteLine();
    }

    // Рекурсивная функция для инфиксного обхода
    private void InOrderRec(TreeNode root)
    {
        if (root != null)
        {
            InOrderRec(root.Left);
            Console.Write(root.Data + " ");
            InOrderRec(root.Right);
        }
    }

    // Удаление узла с заданным значением
    public void Delete(int data)
    {
        root = DeleteRec(root, data);
    }

    // Рекурсивная функция для удаления узла
    private TreeNode DeleteRec(TreeNode root, int data)
    {
        // Базовый случай: если дерево пустое
        if (root == null)
        {
            return root;
        }

        // Идем в левое поддерево
        if (data < root.Data)
        {
            root.Left = DeleteRec(root.Left, data);
        }
        // Идем в правое поддерево
        else if (data > root.Data)
        {
            root.Right = DeleteRec(root.Right, data);
        }
        // Если значение такое же, как у корня, то это узел для удаления
        else
        {
            // Узел с только одним потомком или без потомков
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }

            // Узел с двумя потомками: получаем inorder-преемника (наименьший в правом поддереве)
            root.Data = MinValue(root.Right);

            // Удаляем inorder-преемника
            root.Right = DeleteRec(root.Right, root.Data);
        }

        return root;
    }

    // Функция для нахождения наименьшего значения в дереве
    private int MinValue(TreeNode root)
    {
        int minValue = root.Data;
        while (root.Left != null)
        {
            minValue = root.Left.Data;
            root = root.Left;
        }

        return minValue;
    }

    public static void CallBinaryTree()
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Вставка элементов в дерево
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(70);
        bst.Insert(60);
        bst.Insert(80);

        Console.WriteLine("Инфиксный обход дерева:");
        bst.InOrderTraversal(); // Ожидаемый вывод: 20 30 40 50 60 70 80

        // Удаление элемента
        bst.Delete(20);
        Console.WriteLine("Инфиксный обход дерева после удаления элемента 20:");
        bst.InOrderTraversal(); // Ожидаемый вывод: 30 40 50 60 70 80

        bst.Delete(30);
        Console.WriteLine("Инфиксный обход дерева после удаления элемента 30:");
        bst.InOrderTraversal(); // Ожидаемый вывод: 40 50 60 70 80

        bst.Delete(50);
        Console.WriteLine("Инфиксный обход дерева после удаления элемента 50:");
        bst.InOrderTraversal(); // Ожидаемый вывод: 40 60 70 80
    }
}