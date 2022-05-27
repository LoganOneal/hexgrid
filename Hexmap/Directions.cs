namespace Hexgrid
{
    // maps onto _dirVector for traversing the grid. 

    public static class Directions
    {
        public enum AxialDirection
        {
            E = 0, 
            NE = 1, 
            NW = 2, 
            W = 3, 
            SW = 4, 
            SE = 5, 
            N = 6, 
            S = 7
        }

        public static (int delta_q, int delta_r)[] AxialTileVector =  { (1, 0), (1, -1), (0, -1), (-1, 0), (-1, 1), (0, 1) };

        public static (int delta_q, int delta_r, AxialDirection d)[] AxialVertexVector = { (0, 0, AxialDirection.N), (0, -1, AxialDirection.S), (-1, 1, AxialDirection.N),
                                                                                                      (0, 0, AxialDirection.S), (0, 1, AxialDirection.N), (1, -1, AxialDirection.S) };

        public static (int delta_q, int delta_r, AxialDirection d)[] AxialEdgeVector = { (0, 0, AxialDirection.NE), (0, 0, AxialDirection.NW), (0, 0, AxialDirection.W),
                                                                                                              (-1, 1, AxialDirection.NE), (0, 1, AxialDirection.NW), (1, 0, AxialDirection.W) };
    }

}
