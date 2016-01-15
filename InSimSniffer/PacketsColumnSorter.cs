using System.Windows.Forms;
using InSimSniffer.Library;

namespace InSimSniffer {
    public class PacketsColumnSorter : IColumnSorter {
        public int Column { get; set; }
        public SortOrder Order { get; set; }

        public PacketsColumnSorter() {
            Column = 1;
            Order = SortOrder.Ascending;
        }

        public int Compare(object x, object y) {
            SniffedPacket a = (SniffedPacket)((ListViewItem)x).Tag;
            SniffedPacket b = (SniffedPacket)((ListViewItem)y).Tag;
            int compare = 0;

            if (Column == 0) {
                compare = a.PacketType.CompareTo(b.PacketType);
            }
            else if (Column == 1) {
                compare = a.ElapsedTime.CompareTo(b.ElapsedTime);
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
