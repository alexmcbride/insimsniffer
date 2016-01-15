using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InSimSniffer {
    public class FilterTextBox : TextBox {
        private const int FilterDelay = 500;
        private Timer _filterTimer;

        public event EventHandler Filtered;

        public string[] FilterTerms { get; private set; }

        public bool HasFilterTerms {
            get { return FilterTerms != null && FilterTerms.Any(); }
        }

        public FilterTextBox()
            : base() {
            _filterTimer = new Timer();
            _filterTimer.Interval = FilterDelay;
            _filterTimer.Tick += OnFilterTimerTick;

            Text = StringResources.FilterDefaultString;
            ForeColor = SystemColors.ControlDark;
        }

        protected override void OnEnter(EventArgs e) {
            if (Text == StringResources.FilterDefaultString) {
                Clear();
                ForeColor = SystemColors.ControlText;
            }
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e) {
            if (String.IsNullOrWhiteSpace(Text)) {
                Text = StringResources.FilterDefaultString;
                ForeColor = SystemColors.ControlDark;
            }
            base.OnLeave(e);
        }

        protected override void OnKeyUp(KeyEventArgs e) {
            if (Char.IsLetterOrDigit((char)e.KeyValue) || 
                e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) {
                _filterTimer.Stop();
                _filterTimer.Start();
            }
            base.OnKeyUp(e);
        }

        private void OnFilterTimerTick(object sender, EventArgs e) {
            _filterTimer.Stop();

            FilterTerms = (from s in Text.Split()
                           where !String.IsNullOrWhiteSpace(s)
                           select s).Distinct().ToArray();

            OnFiltered(e);
        }

        protected virtual void OnFiltered(EventArgs e) {
            EventHandler temp = Filtered;
            if (temp != null) {
                temp(this, e);
            }
        }
    }
}
