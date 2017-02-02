using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_1
{
    class TetrisBag
    {
        private List<int> bagList;
        private int counter=0;
        private int rand;
        private Random bagGen;
        public TetrisBag()
        {
            bagList = new List<int>();
            GenerateNewBag();
        }

        private void GenerateNewBag()
        {
            bagGen = new Random();
            for (int i = 0; i < 7; i++)
            {
                do
                {
                    rand = bagGen.Next(0, 7);
                } while (bagList.Contains(rand));
                bagList.Add(rand);
            }
        }

        internal int GetCurrent()
        {
            return bagList[counter];
        }

        internal int GetNext()
        {
            counter++;
            if (counter == 7)
            {
                counter = 0;
                bagList.Clear();
                GenerateNewBag();
            }
            return bagList[counter];
        }
    }
}
