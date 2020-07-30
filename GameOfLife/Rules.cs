namespace GameOfLife
{
    public static class Rules
    {
        public static State GetNewState(State currentState, int aliveNeighbours)
        {
            if (currentState == State.Dead && aliveNeighbours == 3) // Any dead cell with three live neighbours becomes a live cell.
            {
                return State.Alive;
            }
            else if (currentState == State.Alive && (aliveNeighbours == 2 || aliveNeighbours == 3)) // Any live cell with two or three live neighbours survives.
            {
                return State.Alive;
            }
            else
            {
                return State.Dead; // All other live cells die in the next generation. Similarly, all other dead cells stay dead.
            }
        }
    }
}
