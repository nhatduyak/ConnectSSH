using System.Windows.Forms;
using System.Drawing;
using System;
using System.ComponentModel;
namespace ConnectSSH
{
    partial class FormMain
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listipaddress = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer_SetIDtoIP = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.checkUploadfile = new System.Windows.Forms.CheckBox();
            this.txtsource = new System.Windows.Forms.TextBox();
            this.txtdest = new System.Windows.Forms.TextBox();
            this.btbrowSourcefolder = new System.Windows.Forms.Button();
            this.bttranfer = new System.Windows.Forms.Button();
            this.btRunRenci = new System.Windows.Forms.Button();
            this.listcommand = new System.Windows.Forms.ListBox();
            this.btAddCommand = new System.Windows.Forms.Button();
            this.txtCommandadd = new System.Windows.Forms.TextBox();
            this.txtipaddress = new System.Windows.Forms.TextBox();
            this.btloadList = new System.Windows.Forms.Button();
            this.btexport = new System.Windows.Forms.Button();
            this.btload = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btexportListOK = new System.Windows.Forms.Button();
            this.btcheckip = new System.Windows.Forms.Button();
            this.gridviewIP = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btinstall1ded = new System.Windows.Forms.Button();
            this.checkinstAll1deb = new System.Windows.Forms.CheckBox();
            this.txtpath1deb = new System.Windows.Forms.TextBox();
            this.txtipdebfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btbrow1deb = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btinstallfull = new System.Windows.Forms.Button();
            this.checkinstAllfull = new System.Windows.Forms.CheckBox();
            this.txtpahtinstfull = new System.Windows.Forms.TextBox();
            this.btbrowfull = new System.Windows.Forms.Button();
            this.listBoxInstalldeb = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtpathlua = new System.Windows.Forms.TextBox();
            this.btexcLua = new System.Windows.Forms.Button();
            this.bttranferputty = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewIP)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listipaddress
            // 
            this.listipaddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listipaddress.FormattingEnabled = true;
            this.listipaddress.Location = new System.Drawing.Point(3, 2);
            this.listipaddress.Name = "listipaddress";
            this.listipaddress.Size = new System.Drawing.Size(156, 303);
            this.listipaddress.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1800000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer_SetIDtoIP
            // 
            this.timer_SetIDtoIP.Enabled = true;
            this.timer_SetIDtoIP.Interval = 3600000;
            this.timer_SetIDtoIP.Tick += new System.EventHandler(this.timer_SetIDtoIP_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(175, 14);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 52);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Run";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // checkUploadfile
            // 
            this.checkUploadfile.AutoSize = true;
            this.checkUploadfile.Location = new System.Drawing.Point(165, 214);
            this.checkUploadfile.Name = "checkUploadfile";
            this.checkUploadfile.Size = new System.Drawing.Size(76, 17);
            this.checkUploadfile.TabIndex = 2;
            this.checkUploadfile.Text = "UploadFile";
            this.checkUploadfile.UseVisualStyleBackColor = true;
            this.checkUploadfile.CheckedChanged += new System.EventHandler(this.checkUploadfile_CheckedChanged);
            // 
            // txtsource
            // 
            this.txtsource.Enabled = false;
            this.txtsource.Location = new System.Drawing.Point(247, 212);
            this.txtsource.Name = "txtsource";
            this.txtsource.Size = new System.Drawing.Size(303, 20);
            this.txtsource.TabIndex = 3;
            this.txtsource.Text = "D:/";
            // 
            // txtdest
            // 
            this.txtdest.Enabled = false;
            this.txtdest.Location = new System.Drawing.Point(247, 238);
            this.txtdest.Name = "txtdest";
            this.txtdest.Size = new System.Drawing.Size(303, 20);
            this.txtdest.TabIndex = 3;
            this.txtdest.Text = "/private/var/mobile/";
            // 
            // btbrowSourcefolder
            // 
            this.btbrowSourcefolder.Location = new System.Drawing.Point(556, 209);
            this.btbrowSourcefolder.Name = "btbrowSourcefolder";
            this.btbrowSourcefolder.Size = new System.Drawing.Size(35, 23);
            this.btbrowSourcefolder.TabIndex = 4;
            this.btbrowSourcefolder.Text = "...";
            this.btbrowSourcefolder.UseVisualStyleBackColor = true;
            this.btbrowSourcefolder.Click += new System.EventHandler(this.btbrowSourcefolder_Click);
            // 
            // bttranfer
            // 
            this.bttranfer.Location = new System.Drawing.Point(360, 264);
            this.bttranfer.Name = "bttranfer";
            this.bttranfer.Size = new System.Drawing.Size(90, 31);
            this.bttranfer.TabIndex = 5;
            this.bttranfer.Text = "Tranfer File";
            this.bttranfer.UseVisualStyleBackColor = true;
            this.bttranfer.Click += new System.EventHandler(this.bttranfer_Click);
            // 
            // btRunRenci
            // 
            this.btRunRenci.Location = new System.Drawing.Point(175, 72);
            this.btRunRenci.Name = "btRunRenci";
            this.btRunRenci.Size = new System.Drawing.Size(75, 52);
            this.btRunRenci.TabIndex = 1;
            this.btRunRenci.Text = "renci";
            this.btRunRenci.UseVisualStyleBackColor = true;
            this.btRunRenci.Click += new System.EventHandler(this.btRunRenci_Click);
            // 
            // listcommand
            // 
            this.listcommand.FormattingEnabled = true;
            this.listcommand.Location = new System.Drawing.Point(293, 98);
            this.listcommand.Name = "listcommand";
            this.listcommand.Size = new System.Drawing.Size(475, 108);
            this.listcommand.TabIndex = 7;
            this.listcommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listcommand_KeyDown);
            // 
            // btAddCommand
            // 
            this.btAddCommand.Location = new System.Drawing.Point(693, 43);
            this.btAddCommand.Name = "btAddCommand";
            this.btAddCommand.Size = new System.Drawing.Size(75, 23);
            this.btAddCommand.TabIndex = 8;
            this.btAddCommand.Text = "add";
            this.btAddCommand.UseVisualStyleBackColor = true;
            this.btAddCommand.Click += new System.EventHandler(this.btAddCommand_Click);
            // 
            // txtCommandadd
            // 
            this.txtCommandadd.Location = new System.Drawing.Point(337, 14);
            this.txtCommandadd.Multiline = true;
            this.txtCommandadd.Name = "txtCommandadd";
            this.txtCommandadd.Size = new System.Drawing.Size(350, 59);
            this.txtCommandadd.TabIndex = 9;
            // 
            // txtipaddress
            // 
            this.txtipaddress.Location = new System.Drawing.Point(3, 311);
            this.txtipaddress.Name = "txtipaddress";
            this.txtipaddress.Size = new System.Drawing.Size(107, 20);
            this.txtipaddress.TabIndex = 10;
            this.txtipaddress.Text = "192.168.1.";
            // 
            // btloadList
            // 
            this.btloadList.Location = new System.Drawing.Point(116, 308);
            this.btloadList.Name = "btloadList";
            this.btloadList.Size = new System.Drawing.Size(43, 23);
            this.btloadList.TabIndex = 11;
            this.btloadList.Text = "load";
            this.btloadList.UseVisualStyleBackColor = true;
            this.btloadList.Click += new System.EventHandler(this.btloadList_Click);
            // 
            // btexport
            // 
            this.btexport.Location = new System.Drawing.Point(165, 308);
            this.btexport.Name = "btexport";
            this.btexport.Size = new System.Drawing.Size(48, 23);
            this.btexport.TabIndex = 12;
            this.btexport.Text = "export";
            this.btexport.UseVisualStyleBackColor = true;
            this.btexport.Click += new System.EventHandler(this.btexport_Click);
            // 
            // btload
            // 
            this.btload.Location = new System.Drawing.Point(693, 14);
            this.btload.Name = "btload";
            this.btload.Size = new System.Drawing.Size(75, 23);
            this.btload.TabIndex = 13;
            this.btload.Text = "load";
            this.btload.UseVisualStyleBackColor = true;
            this.btload.Click += new System.EventHandler(this.btload_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 376);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bttranferputty);
            this.tabPage1.Controls.Add(this.listcommand);
            this.tabPage1.Controls.Add(this.btload);
            this.tabPage1.Controls.Add(this.listipaddress);
            this.tabPage1.Controls.Add(this.btexport);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btloadList);
            this.tabPage1.Controls.Add(this.btStart);
            this.tabPage1.Controls.Add(this.txtipaddress);
            this.tabPage1.Controls.Add(this.btRunRenci);
            this.tabPage1.Controls.Add(this.txtCommandadd);
            this.tabPage1.Controls.Add(this.checkUploadfile);
            this.tabPage1.Controls.Add(this.btAddCommand);
            this.tabPage1.Controls.Add(this.txtsource);
            this.tabPage1.Controls.Add(this.txtdest);
            this.tabPage1.Controls.Add(this.bttranfer);
            this.tabPage1.Controls.Add(this.btbrowSourcefolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btexportListOK);
            this.tabPage2.Controls.Add(this.btcheckip);
            this.tabPage2.Controls.Add(this.gridviewIP);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Check list IP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btexportListOK
            // 
            this.btexportListOK.Location = new System.Drawing.Point(257, 35);
            this.btexportListOK.Name = "btexportListOK";
            this.btexportListOK.Size = new System.Drawing.Size(75, 23);
            this.btexportListOK.TabIndex = 1;
            this.btexportListOK.Text = "export list";
            this.btexportListOK.UseVisualStyleBackColor = true;
            this.btexportListOK.Click += new System.EventHandler(this.btexportListOK_Click);
            // 
            // btcheckip
            // 
            this.btcheckip.Location = new System.Drawing.Point(257, 6);
            this.btcheckip.Name = "btcheckip";
            this.btcheckip.Size = new System.Drawing.Size(75, 23);
            this.btcheckip.TabIndex = 1;
            this.btcheckip.Text = "Check IP";
            this.btcheckip.UseVisualStyleBackColor = true;
            this.btcheckip.Click += new System.EventHandler(this.btcheckip_Click);
            // 
            // gridviewIP
            // 
            this.gridviewIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Status});
            this.gridviewIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridviewIP.Location = new System.Drawing.Point(3, 3);
            this.gridviewIP.Name = "gridviewIP";
            this.gridviewIP.Size = new System.Drawing.Size(248, 344);
            this.gridviewIP.TabIndex = 0;
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.listBoxInstalldeb);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Install deb";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btinstall1ded);
            this.groupBox2.Controls.Add(this.checkinstAll1deb);
            this.groupBox2.Controls.Add(this.txtpath1deb);
            this.groupBox2.Controls.Add(this.txtipdebfile);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btbrow1deb);
            this.groupBox2.Location = new System.Drawing.Point(526, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 339);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Install 1 deb";
            // 
            // btinstall1ded
            // 
            this.btinstall1ded.Location = new System.Drawing.Point(57, 98);
            this.btinstall1ded.Name = "btinstall1ded";
            this.btinstall1ded.Size = new System.Drawing.Size(75, 23);
            this.btinstall1ded.TabIndex = 4;
            this.btinstall1ded.Text = "Install";
            this.btinstall1ded.UseVisualStyleBackColor = true;
            this.btinstall1ded.Click += new System.EventHandler(this.btinstall1ded_Click);
            // 
            // checkinstAll1deb
            // 
            this.checkinstAll1deb.AutoSize = true;
            this.checkinstAll1deb.Location = new System.Drawing.Point(9, 49);
            this.checkinstAll1deb.Name = "checkinstAll1deb";
            this.checkinstAll1deb.Size = new System.Drawing.Size(123, 17);
            this.checkinstAll1deb.TabIndex = 3;
            this.checkinstAll1deb.Text = "Install All file in folder";
            this.checkinstAll1deb.UseVisualStyleBackColor = true;
            // 
            // txtpath1deb
            // 
            this.txtpath1deb.Location = new System.Drawing.Point(9, 72);
            this.txtpath1deb.Name = "txtpath1deb";
            this.txtpath1deb.Size = new System.Drawing.Size(191, 20);
            this.txtpath1deb.TabIndex = 2;
            this.txtpath1deb.Text = "D:/";
            // 
            // txtipdebfile
            // 
            this.txtipdebfile.Location = new System.Drawing.Point(29, 13);
            this.txtipdebfile.Name = "txtipdebfile";
            this.txtipdebfile.Size = new System.Drawing.Size(145, 20);
            this.txtipdebfile.TabIndex = 2;
            this.txtipdebfile.Text = "192.168.1.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // btbrow1deb
            // 
            this.btbrow1deb.Location = new System.Drawing.Point(206, 69);
            this.btbrow1deb.Name = "btbrow1deb";
            this.btbrow1deb.Size = new System.Drawing.Size(30, 23);
            this.btbrow1deb.TabIndex = 0;
            this.btbrow1deb.Text = "...";
            this.btbrow1deb.UseVisualStyleBackColor = true;
            this.btbrow1deb.Click += new System.EventHandler(this.btbrow1deb_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btinstallfull);
            this.groupBox1.Controls.Add(this.checkinstAllfull);
            this.groupBox1.Controls.Add(this.txtpahtinstfull);
            this.groupBox1.Controls.Add(this.btbrowfull);
            this.groupBox1.Location = new System.Drawing.Point(162, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 339);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install list";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Set phan quyen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btinstallfull
            // 
            this.btinstallfull.Location = new System.Drawing.Point(57, 74);
            this.btinstallfull.Name = "btinstallfull";
            this.btinstallfull.Size = new System.Drawing.Size(75, 23);
            this.btinstallfull.TabIndex = 8;
            this.btinstallfull.Text = "Install";
            this.btinstallfull.UseVisualStyleBackColor = true;
            this.btinstallfull.Click += new System.EventHandler(this.btinstallfull_Click);
            // 
            // checkinstAllfull
            // 
            this.checkinstAllfull.AutoSize = true;
            this.checkinstAllfull.Location = new System.Drawing.Point(9, 25);
            this.checkinstAllfull.Name = "checkinstAllfull";
            this.checkinstAllfull.Size = new System.Drawing.Size(123, 17);
            this.checkinstAllfull.TabIndex = 7;
            this.checkinstAllfull.Text = "Install All file in folder";
            this.checkinstAllfull.UseVisualStyleBackColor = true;
            // 
            // txtpahtinstfull
            // 
            this.txtpahtinstfull.Location = new System.Drawing.Point(9, 48);
            this.txtpahtinstfull.Name = "txtpahtinstfull";
            this.txtpahtinstfull.Size = new System.Drawing.Size(191, 20);
            this.txtpahtinstfull.TabIndex = 6;
            this.txtpahtinstfull.Text = "D:/";
            // 
            // btbrowfull
            // 
            this.btbrowfull.Location = new System.Drawing.Point(206, 45);
            this.btbrowfull.Name = "btbrowfull";
            this.btbrowfull.Size = new System.Drawing.Size(30, 23);
            this.btbrowfull.TabIndex = 5;
            this.btbrowfull.Text = "...";
            this.btbrowfull.UseVisualStyleBackColor = true;
            this.btbrowfull.Click += new System.EventHandler(this.btbrowfull_Click);
            // 
            // listBoxInstalldeb
            // 
            this.listBoxInstalldeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxInstalldeb.FormattingEnabled = true;
            this.listBoxInstalldeb.Location = new System.Drawing.Point(0, 3);
            this.listBoxInstalldeb.Name = "listBoxInstalldeb";
            this.listBoxInstalldeb.Size = new System.Drawing.Size(156, 342);
            this.listBoxInstalldeb.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtpathlua);
            this.tabPage4.Controls.Add(this.btexcLua);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(776, 350);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Run lua";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtpathlua
            // 
            this.txtpathlua.Location = new System.Drawing.Point(8, 8);
            this.txtpathlua.Name = "txtpathlua";
            this.txtpathlua.Size = new System.Drawing.Size(300, 20);
            this.txtpathlua.TabIndex = 1;
            this.txtpathlua.Text = "/private/var/mobile/";
            // 
            // btexcLua
            // 
            this.btexcLua.Location = new System.Drawing.Point(308, 6);
            this.btexcLua.Name = "btexcLua";
            this.btexcLua.Size = new System.Drawing.Size(75, 23);
            this.btexcLua.TabIndex = 0;
            this.btexcLua.Text = "Exc Lua";
            this.btexcLua.UseVisualStyleBackColor = true;
            // 
            // bttranferputty
            // 
            this.bttranferputty.Location = new System.Drawing.Point(475, 264);
            this.bttranferputty.Name = "bttranferputty";
            this.bttranferputty.Size = new System.Drawing.Size(96, 31);
            this.bttranferputty.TabIndex = 14;
            this.bttranferputty.Text = "Tranfer Putty";
            this.bttranferputty.UseVisualStyleBackColor = true;
            this.bttranferputty.Click += new System.EventHandler(this.bttranferputty_Click);
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(784, 376);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewIP)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }
        private Button button1;
        //private IContainer components = null;
        private ListBox listipaddress;
        #endregion
        private Timer timer_SetIDtoIP;
        private Button btStart;
        private CheckBox checkUploadfile;
        private TextBox txtsource;
        private TextBox txtdest;
        private Button btbrowSourcefolder;
        private Button bttranfer;
        private Button btRunRenci;
        private ListBox listcommand;
        private Button btAddCommand;
        private TextBox txtCommandadd;
        private TextBox txtipaddress;
        private Button btloadList;
        private Button btexport;
        private Button btload;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btexportListOK;
        private Button btcheckip;
        private DataGridView gridviewIP;
        private DataGridViewTextBoxColumn IP;
        private DataGridViewTextBoxColumn Status;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private Button btinstall1ded;
        private CheckBox checkinstAll1deb;
        private TextBox txtpath1deb;
        private TextBox txtipdebfile;
        private Label label1;
        private Button btbrow1deb;
        private GroupBox groupBox1;
        private ListBox listBoxInstalldeb;
        private Button btinstallfull;
        private CheckBox checkinstAllfull;
        private TextBox txtpahtinstfull;
        private Button btbrowfull;
        private TabPage tabPage4;
        private TextBox txtpathlua;
        private Button btexcLua;
        private Button button2;
        private Button bttranferputty;
    }
}

