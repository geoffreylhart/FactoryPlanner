using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPlanner.FactorySolver
{
    // geosteiner used: http://www.geosteiner.com/
    class Solver
    {
        public static FactoryState MakeBasicText(int size)
        {
            FactoryState startState = new FactoryState();
            for (int i = 0; i < size; i++)
            {
                startState.buildingSources.Add(new FactoryState.BuildingSource(i * 3, 0, 1));
                startState.buildingSources.Add(new FactoryState.BuildingSource(i * 3, 6, 2));
            }
            startState.buildingConsumers.Add(new FactoryState.BuildingConsumer(size * 3, 3, 1, 2));
            Console.WriteLine(5 * size - 2); // expectedCost
            return startState;
        }

        public static int Solve(FactoryState startState)
        {
            HashSet<FactoryState> explored = new HashSet<FactoryState>();
            SortedList<int, List<FactoryState>> priorityQueue = new SortedList<int, List<FactoryState>>();
            priorityQueue.Add(startState.cost + startState.Heuristic(), new List<FactoryState>() { startState });
            while (true)
            {
                var headList = priorityQueue.First().Value;
                var head = headList.Last();
                headList.RemoveAt(headList.Count - 1);
                if (explored.Contains(head)) continue;
                explored.Add(head);
                if (priorityQueue.First().Value.Count == 0) priorityQueue.RemoveAt(0);
                if (head.Heuristic() == 0)
                {
                    int totalCount = priorityQueue.Sum(x => x.Value.Count);
                    return head.cost;
                }
                foreach (var nextState in head.NextStates())
                {
                    if (explored.Contains(nextState)) continue;
                    int newCost = nextState.cost + nextState.Heuristic();
                    if (!priorityQueue.ContainsKey(newCost)) priorityQueue.Add(newCost, new List<FactoryState>());
                    if (newCost > 13) continue;
                    priorityQueue[newCost].Add(nextState);
                }
            }
            throw new NotImplementedException();
        }
    }
}
