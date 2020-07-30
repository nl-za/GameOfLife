namespace GameOfLife
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            RowPosition = row;
            ColumnPosition = column;
        }

        public State State { get; set; }

        public int RowPosition { get; private set; }

        public int ColumnPosition { get; private set; }
    }
}
