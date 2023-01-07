// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World, Sorter!");

int[] random_array = new int[] {5, 2, 9, 1};
IntBubbleSorter sorter = new IntBubbleSorter();
int operations = sorter.Sort(random_array);
for (int i = 0; i < random_array.Length; i++) {
    Console.WriteLine($"{i} {random_array[i]}");
}

Console.WriteLine();
Console.WriteLine($"operations: {operations}");


double[] random_array_double = new double[] {5.2, 2, 9.3, 1};
DoubleBubbleSorter sorter_double = new DoubleBubbleSorter();
int operations_double = sorter_double.Sort(random_array_double);
for (int i = 0; i < random_array_double.Length; i++) {
    Console.WriteLine($"{i} {random_array_double[i]}");
}

Console.WriteLine();
Console.WriteLine($"operations: {operations_double}");