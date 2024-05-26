#region Graphs

GraphMatrix.CallDeepGraphMatrix();
Console.WriteLine();

GraphMatrix.CallBreadthSearchMatrix();
Console.WriteLine();

GraphList.CallDepthSearchList();
Console.WriteLine();

GraphList.CallBreadthSearchList();
Console.WriteLine();

#endregion

#region Lists

DoublyLinkedList.CallDoubleLinkedList();
Console.WriteLine();

CircularLinkedList.CallCircleList();
Console.WriteLine();

#endregion

#region Tree

BinarySearchTree.CallBinaryTree();
Console.WriteLine();

#endregion

#region HashTables

HashTableChaining<string, int>.CallHashTableChaining();
Console.WriteLine();

HashTableLinearProbing<string, int>.CallLinearProb();
Console.WriteLine();

HashTableQuadraticProbing<string, int>.CallQuadraticProb();
Console.WriteLine();

HashTableDoubleHashing<string, int>.CallDoubleHashing();
Console.WriteLine();

#endregion