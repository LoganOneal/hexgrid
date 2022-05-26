using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexgrid
{
    public class GenericHexGrid<T> : IEnumerable<T> where T : new()
    {
        private int _N;
        private T[] _data;

        public GenericHexGrid(int N) 
        {
            int size;

            size = 1;
            for(int i = 1; i <= N; i++)
            {
                size += i * 6;
            }

            _data = new T[size];
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = new T();
            }

            _N = N;
        }

        public T GetTile(int q, int r)
        {
            int row = r + _N;
            int col = q + _N;
            int idx = (row * (2 * _N + 1)) + col;
            //return _data[idx];
            return _data[0];
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
