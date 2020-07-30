using System;

namespace GameOfLife
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Count each cell's alive neighbours
        /// Ignore cells which are out of bounds
        /// Don't count itself
        /// Logic: Count each neighbour's state in row above cell, then same row and lastly in row below cell (max 8 neighbours)
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int CountAliveNeigbours(this Cell cell, Grid grid)
        {
            int alive = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int nextNeighbourRow = cell.RowPosition + i;
                    int nextNeigbourColumn = cell.ColumnPosition + j;

                    if (IsOutOfBounds(nextNeighbourRow, nextNeigbourColumn, grid) || IsSelf(i, j))
                    {
                        continue;
                    }

                    var neighbour = grid.Cells[nextNeighbourRow, nextNeigbourColumn];

                    alive += (int)neighbour.State;
                }
            }
            return alive;
        }

        /// <summary>
        /// Populates the grid randomly with dead and alive cells
        /// </summary>
        /// <param name="grid"></param>
        public static void PopulateGrid(this Grid grid)
        {
            Random random = new Random();

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    grid.Cells[i, j].State = (State)random.Next(0, 2);
                }
            }
        }

        /// <summary>
        /// Determines the state of each cell in the next generation
        /// </summary>
        /// <param name="currentGrid"></param>
        /// <returns>New grid containing cells in their new state</returns>
        public static Grid NextGeneration(this Grid currentGrid)
        {
            Grid newGrid = new Grid(currentGrid.Rows, currentGrid.Columns);

            for (int i = 0; i < currentGrid.Rows; i++)
            {
                for (int j = 0; j < currentGrid.Columns; j++)
                {
                    Cell currentCell = currentGrid.Cells[i, j];
                    int aliveNeighbours = currentCell.CountAliveNeigbours(currentGrid);

                    newGrid.Cells[i, j].State = Rules.GetNewState(currentCell.State, aliveNeighbours);
                }
            }

            return newGrid;
        }

        private static bool IsOutOfBounds(int row, int column, Grid grid)
        {
            if (row < 0 || row > grid.Rows - 1 || column < 0 || column > grid.Columns - 1)
            {
                return true;
            }
            return false;
        }

        private static bool IsSelf(int row, int column)
        {
            if (row == 0 && column == 0)
            {
                return true;
            }
            return false;
        }
    }
}
