using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceBookAutoLike.Resources;
using System.Threading;

namespace FaceBookAutoLike
{
    public partial class Form1 : Form
    {

        private bool _isStart = true;
        private Thread thAction;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            txtToken.Text = DefaultValue.Token;
            txtVersion.Text = DefaultValue.Version;
            txtException.Text = DefaultValue.ExceptionList;
            txtGroupId.Text = DefaultValue.GroupId;
            txtCapFilter.Text = DefaultValue.CaptionFilter;
            txtComment.Text = DefaultValue.Comment;
            //cbComment.Checked = DefaultValue.EnableComment.Equals("1");
            //((RadioButton)Controls[Utilities.Reactions[Int32.Parse(DefaultValue.ReactionType)]]).Checked =
            //    true;

        }

        private void btnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnStart":
                    //WriteToResource();

                    var auto = new Auto();
                    auto.Token = txtToken.Text;
                    auto.Version = txtVersion.Text;

                    var rbChecked = tabReact.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);
                    var reactionType = Utilities.Reactions[Utilities.RBReactions.FirstOrDefault(x => x.Value == rbChecked?.Name).Key];
                    var delayTimeF = 120000;
                    var delayTimeP = 60000;

                    try
                    {
                        delayTimeF = Int32.Parse(txtDelayTimeF.Text);
                        delayTimeP = Int32.Parse(txtDelayTimeP.Text);
                    }
                    catch
                    {
                        //Ignore
                    }


                    //auto.AutoReactFriends(reactionType, delayTimeF, delayTimeP, 25);
                    var thAction = new Thread(() => Run(auto, reactionType, delayTimeF, delayTimeP, 25));
                    thAction.Start();
                    break;
                case "btnStop":
                    _isStart = false;
                    break;
            }

        }

        private void Run(Auto auto, string reactionType, int delayTimeF, int delayTimeP, int limit)
        {
            do
            {
                var startTime = dateTimePickerFrom.Value;
                var endTime = dateTimePickerEnd.Value;
                var timeNow = DateTime.Now;
                var rsStart = DateTime.Compare(timeNow, startTime);
                var rsEnd = DateTime.Compare(timeNow, endTime);
                if (rsStart >= 0 && rsEnd <= 0)
                {
                    auto.AutoReactFriends(reactionType, delayTimeF, delayTimeP, 25);
                }
                Thread.Sleep(1000);
            } while (_isStart);

            MessageBox.Show("Done");
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (txtException.Text.Equals("Bỏ qua không tương tác với ID nằm trong danh sách, phân các nhau bằng dấu ','"))
                txtException.Text = "";
            txtException.ForeColor = Color.Black;

        }

        private void AddText(object sender, EventArgs e)
        {
            if (txtException.Text == "")
            {
                txtException.ForeColor = Color.Gray;
                txtException.Text = "Bỏ qua không tương tác với ID nằm trong danh sách, phân các nhau bằng dấu ','";
            }
        }

        private void WriteToResource()
        {
            using (var rw = new ResourceWriter("DefaultValue"))
            {
                rw.AddResource("Token", txtToken.Text);
                rw.AddResource("Version", txtVersion.Text);
                rw.AddResource("ExceptionList", txtException.Text);
                rw.AddResource("GroupId", txtGroupId.Text);
                rw.AddResource("CaptionFilter", txtCapFilter.Text);
                rw.AddResource("Comment", txtComment.Text);
                rw.AddResource("EnableComment", cbComment.Checked);
                var rbChecked = Controls.OfType<RadioButton>()
                    .FirstOrDefault(r => r.Checked);
                rw.AddResource("ReactionType", Utilities.RBReactions.FirstOrDefault(x => x.Value == rbChecked?.Name).Key);

            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.

            try
            {
                _isStart = false;
                // Ignore any errors that might occur while closing the file handle.
            }
            catch { }
        }

    }

}
