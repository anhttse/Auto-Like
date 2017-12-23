using System;
using System.Collections.Generic;
using System.Data.EntityClient;
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
        private CancellationTokenSource cts;
        private Thread _thReaction;
        private Thread _thComment;
        private int _commentTarget = 0;
        private Auto _auto;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var eCsb = new EntityConnectionStringBuilder();
            eCsb.Provider = "System.Data.SqlClient";
            eCsb.ProviderConnectionString =
                @"data source=210.245.8.58;initial catalog=FBL;persist security info=True;user id=fbl;password=tsd@123;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            eCsb.Metadata = "res://*";
            Utilities.ConnectionString = eCsb.ToString();

            Application.ApplicationExit += OnApplicationExit;
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
                #region React

                case "btnStart":
                    //WriteToResource();
                    cts = new CancellationTokenSource();
                    _auto = new Auto();
                    _auto.Token = txtToken.Text;
                    _auto.Version = txtVersion.Text;

                    var rbChecked = tabReact.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);
                    var reactionType =
                        Utilities.Reactions[Utilities.RBReactions.FirstOrDefault(x => x.Value == rbChecked?.Name).Key];
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
                    _isStart = true;
                    _thReaction = new Thread(() => RunReact(_auto, reactionType, delayTimeF, delayTimeP, 25));
                    _thReaction.Start();
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    break;
                case "btnStop":
                    cts?.Cancel();
                    _isStart = false;

                    _thReaction.Abort();
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                    MessageBox.Show("Done");
                    break;

                #endregion


                #region Comment

                case "btnStartComment":

                    _auto = new Auto();
                    _auto.Token = txtToken.Text;
                    _auto.Version = txtVersion.Text;
                    var targetId = txtTartgetC.Text;
                    var message = txtComment.Text;
                    var fText = Utilities.convertToUnSign3(txtCFilter.Text);
                    var tks = fText.Split(',').ToList();
                    switch (_commentTarget)
                    {
                        case (int)Common.TargetComments.Group:
                            _thComment = new Thread(()=>RunComment(_auto, targetId, 25,message,6000,tks,0));
                            _thComment.Start();
                            break;
                        case (int)Common.TargetComments.YourPost:
                            break;
                        case (int)Common.TargetComments.FriendPost:
                            break;
                        case (int)Common.TargetComments.ReplyCommentInYourPost:
                            break;
                    }
                    break;

                    #endregion
            }

        }

        private void RunReact(Auto auto, string reactionType, int delayTimeF, int delayTimeP, int limit)
        {
            do
            {
                var startTime = dateTimePickerFrom.Value;
                var endTime = dateTimePickerEnd.Value;
                var timeNow = DateTime.Now;
                var rsStart = TimeSpan.Compare(timeNow.TimeOfDay, startTime.TimeOfDay);
                var rsEnd = TimeSpan.Compare(timeNow.TimeOfDay, endTime.TimeOfDay);
                if (rsStart >= 0 && rsEnd <= 0)
                {
                    this.pictureBox1.Image = global::FaceBookAutoLike.Properties.Resources.loading;
                    auto.AutoReactFriends(pictureBox1, reactionType, delayTimeF, delayTimeP, 10, cts.Token);
                }
                Thread.Sleep(1000);
            } while (_isStart);

        }

        private async void RunComment(Auto auto, string gId,int limit,string message, int delayTime, List<string> mFilter, int typeC)
        {
            do
            {
                await auto.AutoCommentPostOfGroup(gId, limit, message, delayTime, mFilter, typeC);
                Thread.Sleep(2000);
            } while (true);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _commentTarget = cbSelect.SelectedIndex;

        }

        private void txtCFilter_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Lọc từ trong bài viết, phân cách bằng dấu ','", txtCFilter);
        }

        private void txtCFilter_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(txtCFilter);
        }
    }

}
