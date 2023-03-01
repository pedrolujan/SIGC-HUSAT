using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUtil
{
    public class PaginableBindingSource : BindingSource
    {
        private int _pageSize;
        private int _currentPage;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                Reset();
            }
        }
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        public int CurrentPageIndex
        {
            get { return (Position / PageSize) + 1; }
        }

        public int TotalPages
        {
            get { return (Count + PageSize - 1) / PageSize; }
        }

        public PaginableBindingSource() : base() { }

        public PaginableBindingSource(IContainer container) : base(container) { }

        public override int Add(object value)
        {
            int newIndex = base.Add(value);
            Reset();
            return newIndex;
        }

        public void AddRange(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                base.Add(item);
            }
            Reset();
        }

        public override void Clear()
        {
            base.Clear();
            Reset();
        }

        public override void Insert(int index, object value)
        {
            base.Insert(index, value);
            Reset();
        }

        public void InsertRange(int index, IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                base.Insert(index++, item);
            }
            Reset();
        }

        public override void Remove(object value)
        {
            base.Remove(value);
            Reset();
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            Reset();
        }

        private void Reset()
        {
            int newIndex = (Position / PageSize) * PageSize;
            base.Position = Math.Min(newIndex, Count - 1);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }




}
