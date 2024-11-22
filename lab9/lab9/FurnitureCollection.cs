using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9;

namespace lab9
{
    class FurnitureCollection : IList<Furniture>
    {
        private List<Furniture> furnitures;
        public FurnitureCollection()
        {
            furnitures = new List<Furniture>();
        }

        public int Count => furnitures.Count;

        public bool IsReadOnly => false;

        public void CopyTo(Furniture[] array, int arrayIndex)
        {
            furnitures.CopyTo(array, arrayIndex);
        }

        public Furniture this[int index] 
        {
            get
            {
                return furnitures[index];
            }
            set { furnitures[index] = value; }
        }

        public Furniture Search(int index)
        {
            return furnitures[(int)index];
        }

        public void Add(Furniture value)
        {
            furnitures.Add(value);
        }

        public bool Contains(Furniture value) {  return furnitures.Contains(value);}

        public void Clear()
        {
            furnitures.Clear();
        }

        public void Display()
        {
            foreach (var item in furnitures)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public int IndexOf(Furniture value) { return furnitures.IndexOf(value);}

        public void Insert(int index, Furniture value) { furnitures[index] = value;}

        public void RemoveAt(int index) { furnitures.RemoveAt(index);}

        public bool Remove(Furniture value) { return furnitures.Remove(value);}

        public IEnumerator<Furniture> GetEnumerator()
        {
            return furnitures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() { return furnitures.GetEnumerator(); }
    }
}
