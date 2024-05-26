public class GraphMatrix
{
    public static void CallDeepGraphMatrix()
    {
        int verticesCount = 5; // Количество вершин в графе
        int[,] graph = GenerateRandomGraph(verticesCount); // Генерируем случайный граф

        Console.WriteLine("Матрица смежности графа:");
        PrintGraph(graph); // Выводим матрицу смежности на экран

        Console.WriteLine("\nОбход графа в глубину начиная с вершины 0:");
        bool[] visited = new bool[verticesCount]; // Массив для отслеживания посещённых вершин
        DepthFirstSearch(graph, 0, visited); // Выполняем обход в глубину начиная с вершины 0

        // Метод генерации случайного графа
        static int[,] GenerateRandomGraph(int verticesCount)
        {
            var random = new Random();
            int[,] graph = new int[verticesCount, verticesCount]; // Создаём квадратную матрицу для графа

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (i != j) // Избегаем петель (связей вершины с самой собой)
                    {
                        graph[i, j] = random.Next(0, 2); // Случайным образом создаём ребро (0 или 1)
                    }
                }
            }

            return graph; // Возвращаем заполненную матрицу смежности
        }

        // Метод печати матрицы смежности
        static void PrintGraph(int[,] graph)
        {
            int verticesCount = graph.GetLength(0); // Получаем количество вершин
            for (int i = 0; i < verticesCount; i++) // Перебираем строки матрицы
            {
                for (int j = 0; j < verticesCount; j++) // Перебираем столбцы матрицы
                {
                    Console.Write(graph[i, j] + ", "); // Выводим значение элемента матрицы
                }

                Console.WriteLine(); // Переход на новую строку после вывода строки матрицы
            }
        }

        // Метод обхода графа в глубину
        static void DepthFirstSearch(int[,] graph, int vertex, bool[] visited)
        {
            visited[vertex] = true; // Помечаем текущую вершину как посещённую
            Console.Write(vertex + ", "); // Выводим текущую вершину

            int verticesCount = graph.GetLength(0); // Получаем количество вершин
            for (int i = 0; i < verticesCount; i++) // Перебираем все вершины графа
            {
                if (graph[vertex, i] == 1 && !visited[i]) // Если вершина смежная и не посещена
                {
                    DepthFirstSearch(graph, i, visited); // Рекурсивно вызываем DFS для смежной вершины
                }
            }
        }
    }


    public static void CallBreadthSearchMatrix()
    {
        int verticesCount = 10; // Количество вершин в графе
        int[,] graph = GenerateRandomGraph(verticesCount); // Генерируем случайный граф

        Console.WriteLine("Матрица смежности графа:");
        PrintGraph(graph); // Выводим матрицу смежности на экран

        Console.WriteLine("\nОбход графа в ширину начиная с вершины 0:");
        BreadthFirstSearch(graph, 0); // Выполняем обход в ширину начиная с вершины 0

        // Метод генерации случайного графа
        static int[,] GenerateRandomGraph(int verticesCount)
        {
            var random = new Random();
            int[,] graph = new int[verticesCount, verticesCount]; // Создаём квадратную матрицу для графа

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (i != j) // Избегаем петель (связей вершины с самой собой)
                    {
                        graph[i, j] = random.Next(0, 2); // Случайным образом создаём ребро (0 или 1)
                    }
                }
            }

            return graph; // Возвращаем заполненную матрицу смежности
        }

        // Метод печати матрицы смежности
        static void PrintGraph(int[,] graph)
        {
            int verticesCount = graph.GetLength(0); // Получаем количество вершин
            for (int i = 0; i < verticesCount; i++) // Перебираем строки матрицы
            {
                for (int j = 0; j < verticesCount; j++) // Перебираем столбцы матрицы
                {
                    Console.Write(graph[i, j] + " "); // Выводим значение элемента матрицы
                }

                Console.WriteLine(); // Переход на новую строку после вывода строки матрицы
            }
        }

        // Метод обхода графа в ширину (BFS)
        static void BreadthFirstSearch(int[,] graph, int startVertex)
        {
            int verticesCount = graph.GetLength(0); // Получаем количество вершин
            bool[] visited = new bool[verticesCount]; // Массив для отслеживания посещённых вершин
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true; // Помечаем начальную вершину как посещённую
            queue.Enqueue(startVertex); // Добавляем начальную вершину в очередь

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue(); // Извлекаем вершину из очереди
                Console.Write(vertex + " "); // Выводим текущую вершину

                for (int i = 0; i < verticesCount; i++) // Перебираем все вершины графа
                {
                    if (graph[vertex, i] == 1 && !visited[i]) // Если вершина смежная и не посещена
                    {
                        visited[i] = true; // Помечаем вершину как посещённую
                        queue.Enqueue(i); // Добавляем вершину в очередь
                    }
                }
            }
        }
    }
}