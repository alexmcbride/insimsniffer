using System.Windows.Forms;
using InSimSniffer.Library;

namespace InSimSniffer {
    public class DetailsColumnSorter : IColumnSorter {
        public int Column { get; set; }
        public SortOrder Order { get; set; }

        public DetailsColumnSorter() {
            Column = 0;
            Order = SortOrder.Ascending;
        }

        public int Compare(object x, object y) {
            SniffedValue a = (SniffedValue)((ListViewItem)x).Tag;
            SniffedValue b = (SniffedValue)((ListViewItem)y).Tag;
            int compare = 0;

            if (Column == 0) {
                compare = a.Index.CompareTo(b.Index);
            }
            else if (Column == 1) {
                compare = a.Value.CompareTo(b.Value);
            }
            else if (Column == 2) {
                compare = a.Information.CompareTo(b.Information);
            }

            if (Order == SortOrder.Ascending) {
                return compare;
            }
            else if (Order == SortOrder.Descending) {
                return (-compare);
            }
            return 0;
        }
    }
}
