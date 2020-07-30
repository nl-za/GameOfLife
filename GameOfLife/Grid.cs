namespace GameOfLife
{
    public class Grid
    {
        public Grid(int rows, int columns)
        {
            Columns = columns;
            Rows = rows;
            Cells = new Cell[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }

        public Cell[,] Cells { get; set; }

        public int Rows { get; private set; }

        public int Columns { get; private set; }

    }
}
