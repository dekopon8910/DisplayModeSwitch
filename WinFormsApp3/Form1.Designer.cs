namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            btnAdd = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnManual = new Button();
            labelMode = new Label();
            btnAuto = new Button();
            labelSwitchMode = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(12, 78);
            listView1.Name = "listView1";
            listView1.Size = new Size(253, 344);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 49);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += buttonAdd_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // btnManual
            // 
            btnManual.Location = new Point(174, 49);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(75, 23);
            btnManual.TabIndex = 2;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // labelMode
            // 
            labelMode.AutoSize = true;
            labelMode.Location = new Point(12, 9);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(87, 15);
            labelMode.TabIndex = 3;
            labelMode.Text = "Display mode : ";
            // 
            // btnAuto
            // 
            btnAuto.Location = new Point(93, 49);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(75, 23);
            btnAuto.TabIndex = 4;
            btnAuto.Text = "Auto";
            btnAuto.UseVisualStyleBackColor = true;
            btnAuto.Click += btnAuto_Click;
            // 
            // labelSwitchMode
            // 
            labelSwitchMode.AutoSize = true;
            labelSwitchMode.Location = new Point(15, 31);
            labelSwitchMode.Name = "labelSwitchMode";
            labelSwitchMode.Size = new Size(84, 15);
            labelSwitchMode.TabIndex = 5;
            labelSwitchMode.Text = "Switch mode : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 434);
            Controls.Add(labelSwitchMode);
            Controls.Add(btnAuto);
            Controls.Add(labelMode);
            Controls.Add(btnManual);
            Controls.Add(btnAdd);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Display mode switcher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button btnAdd;
        private ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private Button btnManual;
        private Label labelMode;
        private Button btnAuto;
        private Label labelSwitchMode;
    }
}
