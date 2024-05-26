public class GraphList
{
    public static void CallDepthSearchList()
    {
        int verticesCount = 5; // Количество вершин в графе
        List<int>[] graph = GenerateRandomGraph(verticesCount); // Генерируем случайный граф

        Console.WriteLine("Списки смежности графа:");
        PrintGraph(graph); // Выводим списки смежности на экран

        Console.WriteLine("\nОбход графа в глубину начиная с вершины 0:");
        bool[] visited = new bool[verticesCount]; // Массив для отслеживания посещённых вершин
        DepthFirstSearch(graph, 0, visited); // Выполняем обход в глубину начиная с вершины 0

        // Метод генерации случайного графа
        static List<int>[] GenerateRandomGraph(int verticesCount)
        {
            var random = new Random();
            List<int>[] graph = new List<int>[verticesCount]; // Создаём списки смежности для графа

            for (int i = 0; i < verticesCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (i != j && random.Next(0, 2) == 1) // Избегаем петель и случайным образом создаём ребро
                    {
                        graph[i].Add(j);
                    }
                }
            }

            return graph; // Возвращаем заполненные списки смежности
        }

        // Метод печати списков смежности
        static void PrintGraph(List<int>[] graph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                Console.Write(i + ": ");
                foreach (var vertex in graph[i])
                {
                    Console.Write(vertex + " ");
                }

                Console.WriteLine();
            }
        }

        // Метод обхода графа в глубину
        static void DepthFirstSearch(List<int>[] graph, int vertex, bool[] visited)
        {
            visited[vertex] = true; // Помечаем текущую вершину как посещённую
            Console.Write(vertex + " "); // Выводим текущую вершину

            foreach (var neighbor in graph[vertex]) // Перебираем всех соседей текущей вершины
            {
                if (!visited[neighbor]) // Если соседняя вершина не посещена
                {
                    DepthFirstSearch(graph, neighbor, visited); // Рекурсивно вызываем DFS для смежной вершины
                }
            }
        }
    }

    public static void CallBreadthSearchList()
    {
        int verticesCount = 10; // Количество вершин в графе
        List<int>[] graph = GenerateRandomGraph(verticesCount); // Генерируем случайный граф

        Console.WriteLine("Списки смежности графа:");
        PrintGraph(graph); // Выводим списки смежности на экран

        Console.WriteLine("\nОбход графа в ширину начиная с вершины 0:");
        BreadthFirstSearch(graph, 0); // Выполняем обход в ширину начиная с вершины 0

        // Метод генерации случайного графа
        static List<int>[] GenerateRandomGraph(int verticesCount)
        {
            var random = new Random();
            List<int>[] graph = new List<int>[verticesCount]; // Создаём списки смежности для графа

            for (int i = 0; i < verticesCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (i != j && random.Next(0, 2) == 1) // Избегаем петель и случайным образом создаём ребро
                    {
                        graph[i].Add(j);
                        graph[j].Add(i); // Для неориентированного графа добавляем обратное ребро
                    }
                }
            }

            return graph; // Возвращаем заполненные списки смежности
        }

        // Метод печати списков смежности
        static void PrintGraph(List<int>[] graph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                Console.Write(i + ": ");
                foreach (var vertex in graph[i])
                {
                    Console.Write(vertex + " ");
                }

                Console.WriteLine();
            }
        }

        // Метод обхода графа в ширину (BFS)
        static void BreadthFirstSearch(List<int>[] graph, int startVertex)
        {
            int verticesCount = graph.Length; // Получаем количество вершин
            bool[] visited = new bool[verticesCount]; // Массив для отслеживания посещённых вершин
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true; // Помечаем начальную вершину как посещённую
            queue.Enqueue(startVertex); // Добавляем начальную вершину в очередь

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue(); // Извлекаем вершину из очереди
                Console.Write(vertex + " "); // Выводим текущую вершину

                foreach (var neighbor in graph[vertex]) // Перебираем всех соседей текущей вершины
                {
                    if (!visited[neighbor]) // Если соседняя вершина не посещена
                    {
                        visited[neighbor] = true; // Помечаем вершину как посещённую
                        queue.Enqueue(neighbor); // Добавляем вершину в очередь
                    }
                }
            }
        }
    }
}