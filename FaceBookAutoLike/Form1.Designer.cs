using System.Drawing;
using System.Windows.Forms;

namespace FaceBookAutoLike
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbCmt = new System.Windows.Forms.Label();
            this.cbComment = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tabReact = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCheckGroup = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDelayTimeP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDelayTimeF = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbAngry = new System.Windows.Forms.RadioButton();
            this.rbSad = new System.Windows.Forms.RadioButton();
            this.rbWow = new System.Windows.Forms.RadioButton();
            this.rbHaha = new System.Windows.Forms.RadioButton();
            this.rbLove = new System.Windows.Forms.RadioButton();
            this.rbLike = new System.Windows.Forms.RadioButton();
            this.txtException = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabReact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbCmt);
            this.tabPage2.Controls.Add(this.cbComment);
            this.tabPage2.Controls.Add(this.txtComment);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbCmt
            // 
            this.lbCmt.AutoSize = true;
            this.lbCmt.Location = new System.Drawing.Point(61, 179);
            this.lbCmt.Name = "lbCmt";
            this.lbCmt.Size = new System.Drawing.Size(51, 13);
            this.lbCmt.TabIndex = 44;
            this.lbCmt.Text = "Comment";
            // 
            // cbComment
            // 
            this.cbComment.AutoSize = true;
            this.cbComment.Location = new System.Drawing.Point(478, 178);
            this.cbComment.Name = "cbComment";
            this.cbComment.Size = new System.Drawing.Size(59, 17);
            this.cbComment.TabIndex = 43;
            this.cbComment.Text = "Enable";
            this.cbComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbComment.UseVisualStyleBackColor = true;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(148, 156);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(324, 60);
            this.txtComment.TabIndex = 42;
            // 
            // tabReact
            // 
            this.tabReact.Controls.Add(this.pictureBox1);
            this.tabReact.Controls.Add(this.label14);
            this.tabReact.Controls.Add(this.textBox1);
            this.tabReact.Controls.Add(this.btnCheckGroup);
            this.tabReact.Controls.Add(this.dateTimePickerEnd);
            this.tabReact.Controls.Add(this.label13);
            this.tabReact.Controls.Add(this.label12);
            this.tabReact.Controls.Add(this.dateTimePickerFrom);
            this.tabReact.Controls.Add(this.label11);
            this.tabReact.Controls.Add(this.label10);
            this.tabReact.Controls.Add(this.txtDelayTimeP);
            this.tabReact.Controls.Add(this.label9);
            this.tabReact.Controls.Add(this.label8);
            this.tabReact.Controls.Add(this.label7);
            this.tabReact.Controls.Add(this.txtDelayTimeF);
            this.tabReact.Controls.Add(this.txtVersion);
            this.tabReact.Controls.Add(this.label6);
            this.tabReact.Controls.Add(this.label5);
            this.tabReact.Controls.Add(this.txtCapFilter);
            this.tabReact.Controls.Add(this.label4);
            this.tabReact.Controls.Add(this.txtGroupId);
            this.tabReact.Controls.Add(this.btnStop);
            this.tabReact.Controls.Add(this.btnStart);
            this.tabReact.Controls.Add(this.label3);
            this.tabReact.Controls.Add(this.rbAngry);
            this.tabReact.Controls.Add(this.rbSad);
            this.tabReact.Controls.Add(this.rbWow);
            this.tabReact.Controls.Add(this.rbHaha);
            this.tabReact.Controls.Add(this.rbLove);
            this.tabReact.Controls.Add(this.rbLike);
            this.tabReact.Controls.Add(this.txtException);
            this.tabReact.Controls.Add(this.label2);
            this.tabReact.Controls.Add(this.txtToken);
            this.tabReact.Controls.Add(this.label1);
            this.tabReact.Location = new System.Drawing.Point(4, 22);
            this.tabReact.Name = "tabReact";
            this.tabReact.Padding = new System.Windows.Forms.Padding(3);
            this.tabReact.Size = new System.Drawing.Size(599, 355);
            this.tabReact.TabIndex = 0;
            this.tabReact.Text = "Reaction";
            this.tabReact.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            
            this.pictureBox1.Location = new System.Drawing.Point(448, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Group name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(391, 20);
            this.textBox1.TabIndex = 56;
            // 
            // btnCheckGroup
            // 
            this.btnCheckGroup.Location = new System.Drawing.Point(463, 146);
            this.btnCheckGroup.Name = "btnCheckGroup";
            this.btnCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCheckGroup.TabIndex = 55;
            this.btnCheckGroup.Text = "check";
            this.btnCheckGroup.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(342, 275);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(84, 20);
            this.dateTimePickerEnd.TabIndex = 54;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 281);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "to";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "From";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(210, 275);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(84, 20);
            this.dateTimePickerFrom.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(63, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Set Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "(s)";
            // 
            // txtDelayTimeP
            // 
            this.txtDelayTimeP.Location = new System.Drawing.Point(478, 39);
            this.txtDelayTimeP.Name = "txtDelayTimeP";
            this.txtDelayTimeP.Size = new System.Drawing.Size(46, 20);
            this.txtDelayTimeP.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(386, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Delay Time/Post";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(361, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "(s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Delay Time/Friend";
            // 
            // txtDelayTimeF
            // 
            this.txtDelayTimeF.Location = new System.Drawing.Point(313, 39);
            this.txtDelayTimeF.Name = "txtDelayTimeF";
            this.txtDelayTimeF.Size = new System.Drawing.Size(46, 20);
            this.txtDelayTimeF.TabIndex = 44;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(148, 39);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(46, 20);
            this.txtVersion.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "API Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Caption filter";
            // 
            // txtCapFilter
            // 
            this.txtCapFilter.Location = new System.Drawing.Point(148, 202);
            this.txtCapFilter.Name = "txtCapFilter";
            this.txtCapFilter.Size = new System.Drawing.Size(391, 20);
            this.txtCapFilter.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "GroupID";
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(148, 148);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(309, 20);
            this.txtGroupId.TabIndex = 35;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(368, 312);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(174, 37);
            this.btnStop.TabIndex = 34;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Enabled = false;
            this.btnStop.Click += new System.EventHandler(this.btnClick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(152, 312);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(161, 37);
            this.btnStart.TabIndex = 33;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Reactions";
            // 
            // rbAngry
            // 
            this.rbAngry.AutoSize = true;
            this.rbAngry.Location = new System.Drawing.Point(448, 241);
            this.rbAngry.Name = "rbAngry";
            this.rbAngry.Size = new System.Drawing.Size(52, 17);
            this.rbAngry.TabIndex = 31;
            this.rbAngry.Text = "Angry";
            this.rbAngry.UseVisualStyleBackColor = true;
            // 
            // rbSad
            // 
            this.rbSad.AutoSize = true;
            this.rbSad.Location = new System.Drawing.Point(398, 241);
            this.rbSad.Name = "rbSad";
            this.rbSad.Size = new System.Drawing.Size(44, 17);
            this.rbSad.TabIndex = 30;
            this.rbSad.Text = "Sad";
            this.rbSad.UseVisualStyleBackColor = true;
            // 
            // rbWow
            // 
            this.rbWow.AutoSize = true;
            this.rbWow.Location = new System.Drawing.Point(342, 241);
            this.rbWow.Name = "rbWow";
            this.rbWow.Size = new System.Drawing.Size(50, 17);
            this.rbWow.TabIndex = 29;
            this.rbWow.Text = "Wow";
            this.rbWow.UseVisualStyleBackColor = true;
            // 
            // rbHaha
            // 
            this.rbHaha.AutoSize = true;
            this.rbHaha.Location = new System.Drawing.Point(285, 241);
            this.rbHaha.Name = "rbHaha";
            this.rbHaha.Size = new System.Drawing.Size(51, 17);
            this.rbHaha.TabIndex = 28;
            this.rbHaha.Text = "Haha";
            this.rbHaha.UseVisualStyleBackColor = true;
            // 
            // rbLove
            // 
            this.rbLove.AutoSize = true;
            this.rbLove.Location = new System.Drawing.Point(230, 241);
            this.rbLove.Name = "rbLove";
            this.rbLove.Size = new System.Drawing.Size(49, 17);
            this.rbLove.TabIndex = 27;
            this.rbLove.Text = "Love";
            this.rbLove.UseVisualStyleBackColor = true;
            // 
            // rbLike
            // 
            this.rbLike.AutoSize = true;
            this.rbLike.Checked = true;
            this.rbLike.Location = new System.Drawing.Point(179, 241);
            this.rbLike.Name = "rbLike";
            this.rbLike.Size = new System.Drawing.Size(45, 17);
            this.rbLike.TabIndex = 26;
            this.rbLike.TabStop = true;
            this.rbLike.Text = "Like";
            this.rbLike.UseVisualStyleBackColor = true;
            // 
            // txtException
            // 
            this.txtException.ForeColor = System.Drawing.Color.Gray;
            this.txtException.Location = new System.Drawing.Point(148, 62);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.Size = new System.Drawing.Size(391, 83);
            this.txtException.TabIndex = 25;
            this.txtException.Text = "Bỏ qua không tương tác với ID nằm trong danh sách, phân các nhau bằng dấu \',\'";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Exception List";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(148, 16);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(391, 20);
            this.txtToken.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Token";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabReact);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(607, 381);
            this.tabControl.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 380);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Auto Reactions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabReact.ResumeLayout(false);
            this.tabReact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbCmt;
        private System.Windows.Forms.CheckBox cbComment;
        public System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TabPage tabReact;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCheckGroup;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDelayTimeP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDelayTimeF;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCapFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbAngry;
        private System.Windows.Forms.RadioButton rbSad;
        private System.Windows.Forms.RadioButton rbWow;
        private System.Windows.Forms.RadioButton rbHaha;
        private System.Windows.Forms.RadioButton rbLove;
        private System.Windows.Forms.RadioButton rbLike;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
    }
}

