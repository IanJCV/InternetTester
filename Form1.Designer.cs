namespace InternetTester
{
    partial class InternetTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternetTester));
            upDownText = new DraggableLabel();
            lastPingText = new DraggableLabel();
            lastUpdatedText = new DraggableLabel();
            check_onTop = new CheckBox();
            openPanel1 = new OpenPanel();
            button_Close = new Button();
            openPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // upDownText
            // 
            upDownText.AutoSize = true;
            upDownText.BackColor = Color.Transparent;
            upDownText.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            upDownText.Location = new Point(104, 70);
            upDownText.Name = "upDownText";
            upDownText.Size = new Size(74, 25);
            upDownText.TabIndex = 8;
            upDownText.Text = "DOWN";
            upDownText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lastPingText
            // 
            lastPingText.AutoSize = true;
            lastPingText.Location = new Point(3, 24);
            lastPingText.Name = "lastPingText";
            lastPingText.Size = new Size(58, 15);
            lastPingText.TabIndex = 7;
            lastPingText.Text = "last ping: ";
            // 
            // lastUpdatedText
            // 
            lastUpdatedText.AutoSize = true;
            lastUpdatedText.Location = new Point(3, 9);
            lastUpdatedText.Name = "lastUpdatedText";
            lastUpdatedText.Size = new Size(91, 15);
            lastUpdatedText.TabIndex = 6;
            lastUpdatedText.Text = "last updated at: ";
            // 
            // check_onTop
            // 
            check_onTop.AutoSize = true;
            check_onTop.Location = new Point(3, 139);
            check_onTop.Name = "check_onTop";
            check_onTop.Size = new Size(61, 19);
            check_onTop.TabIndex = 5;
            check_onTop.Text = "on top";
            check_onTop.UseVisualStyleBackColor = true;
            check_onTop.CheckedChanged += check_onTop_CheckedChanged;
            // 
            // openPanel1
            // 
            openPanel1.BackColor = Color.Transparent;
            openPanel1.Controls.Add(button_Close);
            openPanel1.Controls.Add(upDownText);
            openPanel1.Controls.Add(lastPingText);
            openPanel1.Controls.Add(lastUpdatedText);
            openPanel1.Controls.Add(check_onTop);
            openPanel1.Dock = DockStyle.Fill;
            openPanel1.Location = new Point(0, 0);
            openPanel1.Name = "openPanel1";
            openPanel1.Size = new Size(284, 161);
            openPanel1.TabIndex = 9;
            // 
            // button_Close
            // 
            button_Close.Location = new Point(236, 135);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(45, 23);
            button_Close.TabIndex = 9;
            button_Close.Text = "close";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // InternetTester
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(openPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InternetTester";
            Text = "InternetTester";
            openPanel1.ResumeLayout(false);
            openPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CheckBox check_onTop;
        private DraggableLabel lastPingText;
        private DraggableLabel lastUpdatedText;
        private DraggableLabel upDownText;
        private OpenPanel openPanel1;
        private Button button_Close;
    }
}
