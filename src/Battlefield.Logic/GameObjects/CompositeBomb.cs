namespace Battlefield.Logic.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Battlefield.Logic.Fields;

    public class CompositeBomb : Cell
    {
        private IList<Cell> chainedBombs;

        public CompositeBomb()
        {
            this.ChainedBombs = new List<Cell>();
        }

        public IList<Cell> ChainedBombs
        {
            get { return this.chainedBombs; }
            set { this.chainedBombs = value; }
        }

        public void Add(Cell clonedCell)
        {
            this.chainedBombs.Add(clonedCell);
        }

        public int ChainReact(IField field)
        {
            var bombsDetonated = this.chainedBombs.Sum(bomb => field.Explode(bomb, false, null));

            this.chainedBombs.Clear();

            return bombsDetonated;
        }
    }
}
