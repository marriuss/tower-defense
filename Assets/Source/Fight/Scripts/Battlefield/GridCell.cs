public struct GridCell
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public GridCell(int row, int column)
    {
        Row = row;
        Column = column;
    }
}