using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPlanner.FactorySolver
{
    // built for use with priority queue
    // TODO: keeping things simple for now and allowing impossible belt overlaps (so we don't have to keep track of a grid)
    class FactoryState
    {
        public int cost = 0;
        public List<BuildingSource> buildingSources = new List<BuildingSource>();
        public List<BeltSource> beltSources = new List<BeltSource>();
        public List<BuildingConsumer> buildingConsumers = new List<BuildingConsumer>();
        public SortedSet<Position> blockedPositions = new SortedSet<Position>(); // super inefficient, of course
        private static int[] xOffset = new int[] { 0, 0, -1, 1 };
        private static int[] yOffset = new int[] { 1, -1, 0, 0 };

        public struct BuildingSource : IComparable<BuildingSource>
        {
            public int x, y, itemType;
            public BuildingSource(int x, int y, int itemType)
            {
                this.x = x;
                this.y = y;
                this.itemType = itemType;
            }

            public int CompareTo(BuildingSource other)
            {
                if (x != other.x) return x.CompareTo(other.x);
                if (y != other.y) return y.CompareTo(other.y);
                if (itemType != other.itemType) return itemType.CompareTo(other.itemType);
                return 0;
            }
        }

        public struct BeltSource : IComparable<BeltSource>
        {
            // itemType of 0 means empty
            // direction 0,1,2,3 = up,down,left,right
            public int x, y, itemType1, itemType2, direction;
            public BeltSource(int x, int y, int itemType1, int itemType2, int direction)
            {
                this.x = x;
                this.y = y;
                this.itemType1 = itemType1;
                this.itemType2 = itemType2;
                this.direction = direction;
            }

            public int CompareTo(BeltSource other)
            {
                if (x != other.x) return x.CompareTo(other.x);
                if (y != other.y) return y.CompareTo(other.y);
                if (itemType1 != other.itemType1) return itemType1.CompareTo(other.itemType1);
                if (itemType2 != other.itemType2) return itemType2.CompareTo(other.itemType2);
                if (direction != other.direction) return direction.CompareTo(other.direction);
                return 0;
            }
        }

        public struct BuildingConsumer : IComparable<BuildingConsumer>
        {
            public int x, y, itemType1, itemType2;
            public BuildingConsumer(int x, int y, int itemType1, int itemType2)
            {
                this.x = x;
                this.y = y;
                this.itemType1 = itemType1;
                this.itemType2 = itemType2;
            }

            public int CompareTo(BuildingConsumer other)
            {
                if (x != other.x) return x.CompareTo(other.x);
                if (y != other.y) return y.CompareTo(other.y);
                if (itemType1 != other.itemType1) return itemType1.CompareTo(other.itemType1);
                if (itemType2 != other.itemType2) return itemType2.CompareTo(other.itemType2);
                return 0;
            }
        }

        public struct Position : IComparable<Position>
        {
            public int x, y;
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int CompareTo(Position other)
            {
                if (x != other.x) return x.CompareTo(other.x);
                if (y != other.y) return y.CompareTo(other.y);
                return 0;
            }

            public override bool Equals(object obj)
            {
                Position that = (Position)obj;
                return x == that.x && y == that.y;
            }

            public override int GetHashCode()
            {
                return 31 * x + y;
            }
        }

        // estimate remaining cost to complete this factory
        internal int Heuristic()
        {
            if (buildingSources.Count == 0 && beltSources.Count == 0) return 0;
            // simplest heuristic, width+height
            int minx = int.MaxValue;
            int maxx = int.MinValue;
            int miny = int.MaxValue;
            int maxy = int.MinValue;
            foreach (var source in buildingSources)
            {
                minx = Math.Min(minx, source.x + 2);
                maxx = Math.Max(maxx, source.x - 2);
                miny = Math.Min(miny, source.y + 2);
                maxy = Math.Max(maxy, source.y - 2);
            }
            foreach (var source in beltSources)
            {
                minx = Math.Min(minx, source.x);
                maxx = Math.Max(maxx, source.x);
                miny = Math.Min(miny, source.y);
                maxy = Math.Max(maxy, source.y);
            }
            foreach (var source in buildingConsumers)
            {
                minx = Math.Min(minx, source.x + 2);
                maxx = Math.Max(maxx, source.x - 2);
                miny = Math.Min(miny, source.y + 2);
                maxy = Math.Max(maxy, source.y - 2);
            }
            return Math.Max(maxx - minx + 1, 0) + Math.Max(maxy - miny + 1, 0) - 1 - beltSources.Count;
        }

        private static int[] bxOffset = new int[] { -1, 0, 1, 1, 0, -1, -3, -3, -3, 3, 3, 3 };
        private static int[] byOffset = new int[] { 3, 3, 3, -3, -3, -3, -1, 0, 1, 1, 0, -1 };
        private static int[] bxOffset2 = new int[] { -1, 0, 1, 1, 0, -1, -2, -2, -2, 2, 2, 2 };
        private static int[] byOffset2 = new int[] { 2, 2, 2, -2, -2, -2, -1, 0, 1, 1, 0, -1 };
        private static bool[] bIsLeft = new bool[] { false, true, true, false, true, false, false, true, false, true, false, true, true, false, true, false };
        internal IEnumerable<FactoryState> NextStates()
        {
            // extract from a building onto a belt
            for (int i = 0; i < buildingSources.Count; i++)
            {
                // 48 ways to export from a building onto a new belt
                for (int j = 0; j < 12; j++)
                {
                    int newx = buildingSources[i].x + bxOffset[j];
                    int newy = buildingSources[i].y + byOffset[j];
                    int newx2 = buildingSources[i].x + bxOffset2[j];
                    int newy2 = buildingSources[i].y + byOffset2[j];
                    bool beltExistsAlready = beltSources.Any(x => x.x == newx && x.y == newy);
                    if (beltExistsAlready)
                    {
                        //bool occupied = blockedPositions.Contains(new Position(newx2, newy2));
                        //if (occupied) continue;
                        int theBelt = beltSources.FindIndex(x => x.x == newx && x.y == newy);
                        FactoryState nextState = this.Clone();
                        nextState.buildingSources.RemoveAt(i);
                        bool isLeft = bIsLeft[j / 3 * 4 + beltSources[theBelt].direction];
                        int itemTypeInLane = isLeft ? beltSources[theBelt].itemType1 : beltSources[theBelt].itemType2;
                        if (itemTypeInLane == 0 || itemTypeInLane == buildingSources[i].itemType)
                        {
                            BeltSource moddedBelt = beltSources[theBelt];
                            if (isLeft)
                            {
                                moddedBelt.itemType1 = buildingSources[i].itemType;
                            }
                            else
                            {
                                moddedBelt.itemType2 = buildingSources[i].itemType;
                            }
                            nextState.beltSources[theBelt] = moddedBelt;
                            //nextState.blockedPositions.Add(new Position(newx2, newy2));
                            nextState.cost++;
                            nextState.Finalize();
                            yield return nextState;
                        }
                    }
                    else
                    {
                        //bool occupied = blockedPositions.Contains(new Position(newx, newy));
                        //occupied |= blockedPositions.Contains(new Position(newx2, newy2));
                        //if (occupied) continue;
                        for (int k = 0; k < 4; k++) // direction of new belt
                        {
                            FactoryState nextState = this.Clone();
                            nextState.buildingSources.RemoveAt(i);
                            bool isLeft = bIsLeft[j / 3 * 4 + k];
                            nextState.beltSources.Add(new BeltSource(newx, newy, isLeft ? buildingSources[i].itemType : 0, isLeft ? 0 : buildingSources[i].itemType, k));
                            nextState.cost += 2;
                            //nextState.blockedPositions.Add(new Position(newx, newy));
                            //nextState.blockedPositions.Add(new Position(newx2, newy2));
                            nextState.Finalize();
                            yield return nextState;
                        }
                    }
                }
            }
            //if (buildingSources.Count > 0) yield break; // force building export exploration first (can't do this yet)
            // progress a belt
            for (int i = 0; i < beltSources.Count; i++)
            {
                int newx = beltSources[i].x + xOffset[beltSources[i].direction];
                int newy = beltSources[i].y + yOffset[beltSources[i].direction];
                //bool occupied = blockedPositions.Contains(new Position(newx, newy));
                //if (occupied) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (new int[] { 1, 0, 3, 2 }[beltSources[i].direction] == j) continue; // let's not go backwards
                    FactoryState nextState = this.Clone();
                    BeltSource moddedSource = nextState.beltSources[i];
                    moddedSource.x = newx;
                    moddedSource.y = newy;
                    moddedSource.direction = j;
                    int colx = moddedSource.x + xOffset[moddedSource.direction];
                    int coly = moddedSource.y + yOffset[moddedSource.direction];
                    if (beltSources.Any(x => x.x == colx && x.y == coly && x.direction == j && x.itemType1 == moddedSource.itemType1 && x.itemType2 == moddedSource.itemType2))
                    {
                        // the two belts combine
                        nextState.beltSources.RemoveAt(i);
                        nextState.cost++;
                        //nextState.blockedPositions.Add(new Position(newx, newy));
                        nextState.Finalize();
                        yield return nextState;
                    }
                    else
                    {
                        nextState.beltSources[i] = moddedSource;
                        nextState.cost++;
                        //nextState.blockedPositions.Add(new Position(newx, newy));
                        nextState.Finalize();
                        yield return nextState;
                    }
                }
            }
            // TODO: merge 2 belts
            // consume from belt
            // TODO: do occupied for this
            for (int i = 0; i < beltSources.Count; i++)
            {
                var nextState = this.Clone();
                var belt = beltSources[i];
                var moddedBelt = nextState.beltSources[i];
                bool anyConsumer1 = buildingConsumers.Any(x => (x.itemType1 == belt.itemType1 || x.itemType2 == belt.itemType1) && Math.Abs(x.x - belt.x) == 3 && Math.Abs(x.y - belt.y) < 2);
                anyConsumer1 |= buildingConsumers.Any(x => (x.itemType1 == belt.itemType1 || x.itemType2 == belt.itemType1) && Math.Abs(x.y - belt.y) == 3 && Math.Abs(x.x - belt.x) < 2);
                bool anyConsumer2 = buildingConsumers.Any(x => (x.itemType1 == belt.itemType2 || x.itemType2 == belt.itemType2) && Math.Abs(x.x - belt.x) == 3 && Math.Abs(x.y - belt.y) < 2);
                anyConsumer2 |= buildingConsumers.Any(x => (x.itemType1 == belt.itemType2 || x.itemType2 == belt.itemType2) && Math.Abs(x.y - belt.y) == 3 && Math.Abs(x.x - belt.x) < 2);
                if (anyConsumer1) moddedBelt.itemType1 = 0;
                if (anyConsumer2) moddedBelt.itemType2 = 0;
                nextState.beltSources[i] = moddedBelt;
                if (moddedBelt.itemType1 == 0 && moddedBelt.itemType2 == 0) nextState.beltSources.RemoveAt(i);
                nextState.cost++;
                nextState.Finalize();
                yield return nextState;
            }
            // TODO: consume from building
        }

        private FactoryState Clone()
        {
            FactoryState newState = new FactoryState();
            newState.cost = cost;
            newState.buildingSources.AddRange(buildingSources);
            newState.beltSources.AddRange(beltSources);
            newState.buildingConsumers.AddRange(buildingConsumers);
            //foreach (var pos in blockedPositions) newState.blockedPositions.Add(pos);
            return newState;
        }

        public override bool Equals(object obj)
        {
            FactoryState that = obj as FactoryState;
            if (cost != that.cost) return false;
            if (buildingSources.Count != that.buildingSources.Count) return false;
            if (beltSources.Count != that.beltSources.Count) return false;
            if (buildingConsumers.Count != that.buildingConsumers.Count) return false;
            //if (blockedPositions.Count != that.blockedPositions.Count) return false;
            for (int i = 0; i < buildingSources.Count; i++)
            {
                if (buildingSources[i].x != that.buildingSources[i].x) return false;
                if (buildingSources[i].y != that.buildingSources[i].y) return false;
                if (buildingSources[i].itemType != that.buildingSources[i].itemType) return false;
            }
            for (int i = 0; i < beltSources.Count; i++)
            {
                if (beltSources[i].x != that.beltSources[i].x) return false;
                if (beltSources[i].y != that.beltSources[i].y) return false;
                if (beltSources[i].itemType1 != that.beltSources[i].itemType1) return false;
                if (beltSources[i].itemType2 != that.beltSources[i].itemType2) return false;
                if (beltSources[i].direction != that.beltSources[i].direction) return false;
            }
            for (int i = 0; i < buildingConsumers.Count; i++)
            {
                if (buildingConsumers[i].x != that.buildingConsumers[i].x) return false;
                if (buildingConsumers[i].y != that.buildingConsumers[i].y) return false;
                if (buildingConsumers[i].itemType1 != that.buildingConsumers[i].itemType1) return false;
                if (buildingConsumers[i].itemType2 != that.buildingConsumers[i].itemType2) return false;
            }
            if (!blockedPositions.SetEquals(that.blockedPositions)) return false;
            return true;
        }


        private int hashCode;
        private bool doneHash;
        public override int GetHashCode()
        {
            if (doneHash) return hashCode;
            int hash = cost;
            hash = 31 * hash + buildingSources.Count;
            hash = 31 * hash + beltSources.Count;
            hash = 31 * hash + buildingConsumers.Count;
            //hash = 31 * hash + blockedPositions.Count;
            for (int i = 0; i < buildingSources.Count; i++)
            {
                hash = 31 * hash + buildingSources[i].x;
                hash = 31 * hash + buildingSources[i].y;
                hash = 31 * hash + buildingSources[i].itemType;
            }
            for (int i = 0; i < beltSources.Count; i++)
            {
                hash = 31 * hash + beltSources[i].x;
                hash = 31 * hash + beltSources[i].y;
                hash = 31 * hash + beltSources[i].itemType1;
                hash = 31 * hash + beltSources[i].itemType2;
                hash = 31 * hash + beltSources[i].direction;
            }
            for (int i = 0; i < buildingConsumers.Count; i++)
            {
                hash = 31 * hash + buildingConsumers[i].x;
                hash = 31 * hash + buildingConsumers[i].y;
                hash = 31 * hash + buildingConsumers[i].itemType1;
                hash = 31 * hash + buildingConsumers[i].itemType2;
            }
            //foreach (var pos in blockedPositions)
            //{
            //    hash = 31 * hash + pos.x;
            //    hash = 31 * hash + pos.y;
            //}
            hashCode = hash;
            doneHash = true;
            return hash;
        }

        // sort everything for use with equals and hash
        public void Finalize()
        {
            buildingSources.Sort();
            beltSources.Sort();
            buildingConsumers.Sort();
            //blockedPositions.Sort();
        }
    }
}
