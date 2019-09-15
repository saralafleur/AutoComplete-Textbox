using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NCR.LogReader.WinForm.Controls
{
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private String _formerValue = String.Empty;
        public String[] Values { get; set; }
        /// <summary>
        /// When True a Tab will insert 2 spaces.
        /// </summary>
        public bool TabAs2Spaces { get; set; }
        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
            TabAs2Spaces = true;
            Multiline = true;
            AcceptsTab = true;
        }
        private void InitializeComponent()
        {
            _listBox = new ListBox();
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {

                            var start = GetStartOfCurrentWord();
                            var end = GetEndOfCurrentWord();

                            Text = Text.Substring(0, start) +
                                   _listBox.SelectedItem.ToString() +
                                   Text.Substring(end, Text.Length - end);

                            _formerValue = Text;
                            SelectionStart = start + _listBox.SelectedItem.ToString().Length;
                            ResetListBox();
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        if (e.KeyCode == Keys.Tab && TabAs2Spaces)
                        {
                            var currentSelectionStart = SelectionStart;
                            Text = Text.Insert(SelectionStart, "  ");
                            SelectionStart = currentSelectionStart + 2;
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                        {
                            _listBox.SelectedIndex++;
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                        {
                            _listBox.SelectedIndex--;
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// Returns the Index where the Word starts based on SelectionStart
        /// </summary>
        private int GetStartOfCurrentWord()
        {
            var index = SelectionStart;

            // Walk to the beginning of the word
            while (index >= 1
                   && Text[index - 1] != ' '
                   && Text[index - 1] != '\n')
                index--;

            return index;
        }
        private int GetEndOfCurrentWord()
        {
            var index = SelectionStart;

            // Walk to the beginning of the word
            while (index <= Text.Length
                   && Text[index - 1] != ' '
                   && Text[index - 1] != '\r')
                index++;

            return index - 1;
        }

        private string GetWord()
        {
            if (Text.Length == 0)
                return string.Empty;

            var start = GetStartOfCurrentWord();

            var value = Text.Substring(start, TextLength - start);
            var match = Regex.Match(value, @"^([\w\-]+)", RegexOptions.IgnoreCase);
            return match.Value;
        }
        private void UpdateListBox()
        {
            if (Text == _formerValue)
                return;

            _formerValue = this.Text;
            string word = GetWord();

            if (Values == null || word.Length == 0)
            {
                ResetListBox();
                return;
            }
            string[] matches = Array.FindAll(Values,
                                             x => (x.ToLower().Contains(word.ToLower())));
            if (matches.Length == 0)
            {
                ResetListBox();
                return;
            }

            if (matches.Length == 1 && matches[0] == word)
            {
                ResetListBox();
                return;
            }

            ShowListBox();
            _listBox.BeginUpdate();
            _listBox.Items.Clear();
            Array.ForEach(matches, x => _listBox.Items.Add(x));
            _listBox.SelectedIndex = 0;
            _listBox.Height = 0;
            _listBox.Width = 0;
            Focus();
            using (Graphics graphics = _listBox.CreateGraphics())
            {
                var width = 0;
                for (int i = 0; i < _listBox.Items.Count; i++)
                {
                    if (i < 20)
                        _listBox.Height += _listBox.GetItemHeight(i);
                    int itemWidth = (int)graphics.MeasureString(((string)_listBox.Items[i]) + "_", _listBox.Font).Width;
                    if (itemWidth > width)
                        width = itemWidth;
                }
                _listBox.Width = width;
            }
            _listBox.EndUpdate();
        }
        private void ShowListBox()
        {
            if (!_isAdded)
            {
                //Form parentForm = this.FindForm(); // new line added
                //parentForm.Controls.Add(_listBox); // adds it to the form
                Parent.Controls.Add(_listBox); // adds it to the form
                _isAdded = true;
            }

            if (!_listBox.Visible)
            {

                Point pt;
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
                    var start = GetStartOfCurrentWord();
                    pt = GetPositionFromCharIndex(start);
                    if (SelectionStart == 0) pt.X = 0;
                }

                _listBox.Left = pt.X + Left;
                _listBox.Top = pt.Y + Top + Font.Height + 6;
            }

            _listBox.Visible = true;
            _listBox.BringToFront();
        }
        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

    }
}
