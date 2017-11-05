using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TYSJ
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public static void Show(string text, string windowtext)
        {
            MessageForm message = new MessageForm();
            message.Label.Text = text;
            message.Text = windowtext;
            message.ShowDialog();
        }

        public static void Show(string text)
        {
            MessageForm message = new MessageForm();
            message.Label.Text = text;
            message.ShowDialog();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            this.Height = Label.Height + 100;
            this.Width = Label.Width + 100;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
