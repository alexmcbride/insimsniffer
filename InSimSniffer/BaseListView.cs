using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace InSimSniffer {
    public class BaseListView : ListView {
        private static readonly Color DefaultRowColour = SystemColors.Window;
        private static readonly Color AlternatingRowColour = Color.FromArgb(248, 248, 248);
        public event EventHandler ItemSelected;
        public event EventHandler ItemDeselected;

        public new ContextMenuStrip ContextMenuStrip { get; set; }
        public ListViewItem SelectedItem { get; private set; }

        public IColumnSorter ColumnSorter {
            get { return (IColumnSorter)ListViewItemSorter; }
            set { ListViewItemSorter = value; }
        }

        public BaseListView()
            : base() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // BaseListView
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullRowSelect = true;
            this.HideSelection = false;
            this.View = System.Windows.Forms.View.Details;
            this.ResumeLayout(false);
        }

        [DebuggerStepThrough]
        protected override void OnNotifyMessage(Message m) {
            // Eat background paint message (reduced flicker).
            if (m.Msg != WM_ERASEBKGND) {
                base.OnNotifyMessage(m);
            }
        }

        [DebuggerStepThrough]
        protected override void OnDrawItem(DrawListViewItemEventArgs e) {
            // Update alternating row colours.
            if ((e.ItemIndex + 1) % 2 == 0) {
                e.Item.BackColor = AlternatingRowColour;
            }
            else {
                e.Item.BackColor = DefaultRowColour;
            }

            e.DrawDefault = true;

            base.OnDrawItem(e);
        }

        [DebuggerStepThrough]
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e) {
            e.DrawDefault = true;

            base.OnDrawColumnHeader(e);
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                if (SelectedItem != null) {
                    SelectedItem = null;
                    OnItemDeselected(EventArgs.Empty);
                }

                SelectedItem = e.Item;
                OnItemSelected(EventArgs.Empty);
            }
            else {
                SelectedItem = null;
                OnItemDeselected(EventArgs.Empty);
            }

            base.OnItemSelectionChanged(e);
        }

        protected virtual void OnItemSelected(EventArgs e) {
            EventHandler temp = ItemSelected;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnItemDeselected(EventArgs e) {
            EventHandler temp = ItemDeselected;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.C) {
                CopyToClipboard();
            }

            if (e.Control && e.KeyCode == Keys.A) {
                SelectAll();
            }

            base.OnKeyDown(e);
        }

        public void CopyToClipboard() {
            if (SelectedItems.Count == 0) {
                return;
            }

            // Get column widths.
            int[] colWidths = new int[Columns.Count];
            foreach (ListViewItem item in SelectedItems) {
                for (int i = 0; i < item.SubItems.Count; i++) {
                    if (item.SubItems[i].Text.Length > colWidths[i]) {
                        colWidths[i] = item.SubItems[i].Text.Length;
                    }
                }
            }

            // Get lines.
            string[] lines = new string[SelectedItems.Count];
            for (int i = 0; i < SelectedItems.Count; i++) {
                string[] items = new string[SelectedItems[i].SubItems.Count];
                for (int j = 0; j < SelectedItems[i].SubItems.Count; j++) {
                    items[j] = SelectedItems[i].SubItems[j].Text.PadRight(colWidths[j]);
                }
                lines[i] = String.Join(" ", items);
            }

            // Set text to clipboard.
            string text = String.Join((string)Environment.NewLine, lines);
            Clipboard.SetText(text, TextDataFormat.UnicodeText);
        }

        public void SelectAll() {
            if (MultiSelect) {
                BeginUpdate();
                foreach (ListViewItem item in Items) {
                    item.Selected = true;
                }
                EndUpdate();
            }
        }

        public void ClearSelection() {
            BeginUpdate();
            foreach (ListViewItem item in SelectedItems) {
                item.Selected = false;
            }
            EndUpdate();
        }

        public void SelectLastItem() {
            if (Items.Count > 0) {
                Items[Items.Count - 1].Selected = true;
            }
        }

        public void ScrollToLastItem() {
            if (Items.Count > 0) {
                Items[Items.Count - 1].EnsureVisible();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ContextMenuStrip != null) {
                ListViewItem item = GetItemAt(e.X, e.Y);
                if (item != null) {
                    ContextMenuStrip.Show(Cursor.Position);
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e) {
            if (ColumnSorter != null) {
                if (e.Column == ColumnSorter.Column) {
                    if (ColumnSorter.Order == SortOrder.Ascending) {
                        ColumnSorter.Order = SortOrder.Descending;
                    }
                    else {
                        ColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else {
                    ColumnSorter.Column = e.Column;
                    ColumnSorter.Order = SortOrder.Ascending;
                }

                Sort();
            }

            base.OnColumnClick(e);
        }

        #region Scroll Event
        // Window messages
        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONUP = 0x0202;
        // ScrollBar types
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        // ScrollBar interfaces
        private const int SIF_TRACKPOS = 0x10;
        private const int SIF_RANGE = 0x01;
        private const int SIF_POS = 0x04;
        private const int SIF_PAGE = 0x02;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;
        // ListView messages
        private const uint LVM_SCROLL = 0x1014;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETGROUPINFO = (LVM_FIRST + 147);

        public event EventHandler<ScrollEventArgs> Scroll;
        protected virtual void OnScroll(ScrollEventArgs e) {
            if (Scroll != null) {
                Scroll(this, e);
            }
        }

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);

            switch (m.Msg) {
                case WM_VSCROLL:
                    OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                    break;
                case WM_MOUSEWHEEL:
                    OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                    break;
                case WM_KEYDOWN:
                    switch (m.WParam.ToInt32()) {
                        case (int)Keys.Down:
                            OnScroll(new ScrollEventArgs(ScrollEventType.SmallDecrement, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                        case (int)Keys.Up:
                            OnScroll(new ScrollEventArgs(ScrollEventType.SmallIncrement, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                        case (int)Keys.PageDown:
                            OnScroll(new ScrollEventArgs(ScrollEventType.SmallDecrement, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                        case (int)Keys.PageUp:
                            OnScroll(new ScrollEventArgs(ScrollEventType.SmallIncrement, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                        case (int)Keys.Home:
                            OnScroll(new ScrollEventArgs(ScrollEventType.First, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                        case (int)Keys.End:
                            OnScroll(new ScrollEventArgs(ScrollEventType.Last, NativeMethods.GetScrollPos(this.Handle, SB_VERT)));
                            break;
                    }
                    break;
            }
        }
        #endregion
    }
}
