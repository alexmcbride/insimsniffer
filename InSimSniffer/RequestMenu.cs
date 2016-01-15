using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using InSimSniffer.Library.Packets;
using InSimSniffer.Library;

namespace InSimSniffer {
    public class RequestMenu : ToolStripMenuItem {
        public event EventHandler<TinyRequestEventArgs> TinyRequest;
        public event EventHandler<SmallRequestEventArgs> SmallRequest;

        public new bool Enabled {
            get {
                return DropDownItems.Count > 0 ? DropDownItems[0].Enabled : false;
            }

            set {
                foreach (ToolStripItem item in DropDownItems) {
                    item.Enabled = value;
                }
            }
        }

        public RequestMenu()
            : base() {
            foreach (TinyType tiny in PacketTypeHelper.RequestableTinyTypes) {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = tiny.ToString();
                item.Tag = tiny;
                item.Click += new EventHandler(OnTinyRequestMenuItemClick);
                DropDownItems.Add(item);
            }

            DropDownItems.Add(new ToolStripSeparator());

            foreach (SmallType small in PacketTypeHelper.RequestableSmallTypes) {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = small.ToString();
                item.Tag = small;
                item.Click += new EventHandler(OnSmallRequestMenuItemClick);
                DropDownItems.Add(item);
            }
        }

        private void OnTinyRequestMenuItemClick(object sender, EventArgs e) {
            TinyType tiny = (TinyType)((ToolStripMenuItem)sender).Tag;

            OnTinyRequest(new TinyRequestEventArgs(tiny));
        }

        private void OnSmallRequestMenuItemClick(object sender, EventArgs e) {
            SmallType small = (SmallType)((ToolStripMenuItem)sender).Tag;

            OnSmallRequest(new SmallRequestEventArgs(small));
        }

        protected virtual void OnTinyRequest(TinyRequestEventArgs e) {
            EventHandler<TinyRequestEventArgs> temp = TinyRequest;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnSmallRequest(SmallRequestEventArgs e) {
            EventHandler<SmallRequestEventArgs> temp = SmallRequest;
            if (temp != null) {
                temp(this, e);
            }
        }
    }
}
