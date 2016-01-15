using System.Collections;
using System.Windows.Forms;

namespace InSimSniffer {
    public interface IColumnSorter : IComparer {
        int Column { get; set; }
        SortOrder Order { get; set; }
    }
}
