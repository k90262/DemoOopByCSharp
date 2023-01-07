public class DoubleSortHandler : SortHandler
{
    private double[] array = null;

    public int Length()
    {
        return array.Length;
    }

    public bool OutOfOrder(int index)
    {
        return (array[index] > array[index+1]);
    }

    public void SetArray(object array)
    {
        this.array = (double[]) array;
    }

    public void Swap(int index)
    {
        double temp = array[index];
        array[index] = array[index+1];
        array[index+1] = temp;
    }
}