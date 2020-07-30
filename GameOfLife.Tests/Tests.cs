using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ShouldPopulateGrid()
        {
            Grid grid = new Grid(10, 10);
            grid.PopulateGrid();

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    Assert.IsNotNull(grid.Cells[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShouldCountAliveNeigbours()
        {
            Grid grid = new Grid(2, 2);

            grid.Cells[0, 0] = new Cell(0, 0) { State = State.Dead };
            grid.Cells[0, 1] = new Cell(0, 1) { State = State.Alive };
            grid.Cells[1, 0] = new Cell(1, 0) { State = State.Dead };
            grid.Cells[1, 1] = new Cell(1, 1) { State = State.Dead };

            Cell cell = grid.Cells[0, 0];

            int aliveCount = cell.CountAliveNeigbours(grid);

            Assert.AreEqual(1, aliveCount);
        }

        // Any dead cell with three live neighbours becomes a live cell.
        [TestMethod]
        public void DeadCellThreeNeighbours_Alive()
        {
            State state = Rules.GetNewState(State.Dead, 3);

            Assert.AreEqual(State.Alive, state);
        }

        [TestMethod]
        public void DeadCellMoreThanThreeNeighbours_Dead()
        {
            State state = Rules.GetNewState(State.Dead, 4);

            Assert.AreEqual(State.Dead, state);
        }

        [TestMethod]
        public void DeadCellLessThanThreeNeighbours_Dead()
        {
            State state = Rules.GetNewState(State.Dead, 2);

            Assert.AreEqual(State.Dead, state);
        }

        // Any live cell with two or three live neighbours survives.
        [TestMethod]
        public void LiveCellTwoNeighbours_Alive()
        {
            State state = Rules.GetNewState(State.Alive, 2);

            Assert.AreEqual(State.Alive, state);
        }

        [TestMethod]
        public void LiveCellThreeNeighbours_Alive()
        {
            State state = Rules.GetNewState(State.Alive, 3);

            Assert.AreEqual(State.Alive, state);
        }

        [TestMethod]
        public void LiveCellLessThanTwoNeighbours_Dead()
        {
            State state = Rules.GetNewState(State.Alive, 1);

            Assert.AreEqual(State.Dead, state);
        }

        [TestMethod]
        public void LiveCellMoreThanThreeNeighbours_Dead()
        {
            State state = Rules.GetNewState(State.Alive, 4);

            Assert.AreEqual(State.Dead, state);
        }

        [TestMethod]
        public void ShoudDieUnderPopulation()
        {
            Grid grid = new Grid(2, 2);

            grid.Cells[0, 0] = new Cell(0, 0) { State = State.Dead };
            grid.Cells[0, 1] = new Cell(0, 1) { State = State.Alive };
            grid.Cells[1, 0] = new Cell(1, 0) { State = State.Dead };
            grid.Cells[1, 1] = new Cell(1, 1) { State = State.Dead };

            Grid newGrid = grid.NextGeneration();

            Cell newCell = newGrid.Cells[0, 1];

            Assert.AreEqual(State.Dead, newCell.State);
        }

        [TestMethod]
        public void ShoudBecomeAlive()
        {
            Grid grid = new Grid(2, 2);

            grid.Cells[0, 0] = new Cell(0, 0) { State = State.Alive };
            grid.Cells[0, 1] = new Cell(0, 1) { State = State.Dead };
            grid.Cells[1, 0] = new Cell(1, 0) { State = State.Alive };
            grid.Cells[1, 1] = new Cell(1, 1) { State = State.Alive };

            Grid newGrid = grid.NextGeneration();

            Cell newCell = newGrid.Cells[0, 1];

            Assert.AreEqual(State.Alive, newCell.State);
        }
    }
}
