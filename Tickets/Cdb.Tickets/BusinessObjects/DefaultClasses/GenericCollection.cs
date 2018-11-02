using DevExpress.Xpo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Tickets.BusinessObjects.DefaultClasses
{
    public class GenericCollection<TEntity, TInterface> : IList<TInterface> where TEntity : TInterface
    {
        private XPCollection<TEntity> inner;
        private IList<TEntity> list;
        public GenericCollection(XPCollection<TEntity> inner)
        {
            this.inner = inner;
            this.list = inner;
        }

        public TInterface this[int index]
        {
            get { return list[index]; }
            set { list[index] = (TEntity)value; }
        }

        public int Count => list.Count;
        public bool IsReadOnly => list.IsReadOnly;
        public void Add(TInterface item)
        {
            list.Add((TEntity)item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(TInterface item)
        {
            return list.Contains((TEntity)item);
        }

        public void CopyTo(TInterface[] array, int arrayIndex)
        {
            list.CopyTo(array.Cast<TEntity>().ToArray(), arrayIndex);
        }

        public IEnumerator<TInterface> GetEnumerator()
        {
            return list.Cast<TInterface>().GetEnumerator();
        }

        public int IndexOf(TInterface item)
        {
            return list.IndexOf((TEntity)item);
        }

        public void Insert(int index, TInterface item)
        {
            list.Insert(index, (TEntity)item);
        }

        public bool Remove(TInterface item)
        {
            return list.Remove((TEntity)item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }
}
