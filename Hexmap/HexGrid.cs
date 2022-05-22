using System;

namespace Hexgrid
{
    public class HexGrid
    {

        private Tile[][] grid;
        private int N;

        // create a hexmap to store tiles
        // N is the radius of the hexagon shapes grid
        // Store Hex(q, r) at array[r][q - max(0, N-r)].
        public HexGrid(int N)
        {
            int q, r;

            this.N = N;

            grid = new Tile[2 * N + 1][];

            for(r = 0; r <= 2*N; r++)
            {
                grid[r] = new Tile[2 * N + 1 - Math.Abs(N - r)];
            }

            Fill(0);
        }

        // Store Hex(q, r) at array[r][q - max(0, N-r)]
        public void SetTile(int q, int r, Tile tile)
        {
            // -3  - 3
            //Console.WriteLine(r.ToString() + "][" + (q - Math.Max(0, N - r)).ToString() );
            //grid[r][q - Math.Max(0, N - r)] = tile; 
            Console.WriteLine((q+N).ToString() + "][" + (r+N).ToString() );

            grid[q + N][r + N] = tile; 

        }
        public Tile GetTile(int q, int r) { return grid[r][q - Math.Max(0, N - r)];  }

        public void Fill(int val)
        {
            int q, r;
            int r1, r2;
            Tile tile;

            for (q = -N; q <= N; q++)
            {
                r1 = Math.Max(-N, -q - N);
                r2 = Math.Min(N, -q + N);
                for (r = r1; r <= r2; r++)
                {
                    tile = new Tile(q, r);
                    Console.WriteLine(q.ToString() + "," + r.ToString());
                    SetTile(q, r, tile);
                }
            }
        }

        public void Print()
        {
            int q, r;
            int r1, r2;
            Tile tile;

            for (q = -N; q <= N; q++)
            {
                r1 = Math.Max(-N, -q - N);
                r2 = Math.Min(N, -q + N);
                for (r = r1; r <= r2; r++)
                {
                    GetTile(q, r).Print();
                }
            }
        }

        public int Size()
        {
            int i, sum;

            sum = 1;
            for(i = 1; i <= N; i++)
            {
                sum += i * 6;
            }
            return sum;
        } 

    }
}
