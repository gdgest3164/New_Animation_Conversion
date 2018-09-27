namespace New_Animation_Conversion
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.under_btn = new System.Windows.Forms.Label();
            this.close_btn = new System.Windows.Forms.Label();
            this.move_panner = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.brocas = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.result_text = new System.Windows.Forms.GroupBox();
            this.result_context = new System.Windows.Forms.TextBox();
            this.get_btn = new System.Windows.Forms.Button();
            this.all_radio = new System.Windows.Forms.RadioButton();
            this.now_radio = new System.Windows.Forms.RadioButton();
            this.future_radio = new System.Windows.Forms.RadioButton();
            this.now_date_text = new System.Windows.Forms.Label();
            this.tab2 = new System.Windows.Forms.Panel();
            this.move_panner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.result_text.SuspendLayout();
            this.tab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // under_btn
            // 
            this.under_btn.AutoSize = true;
            this.under_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.under_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.under_btn.Location = new System.Drawing.Point(881, 9);
            this.under_btn.Name = "under_btn";
            this.under_btn.Size = new System.Drawing.Size(18, 19);
            this.under_btn.TabIndex = 0;
            this.under_btn.Text = "_";
            this.under_btn.Click += new System.EventHandler(this.under_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.AutoSize = true;
            this.close_btn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.Location = new System.Drawing.Point(905, 9);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(18, 19);
            this.close_btn.TabIndex = 1;
            this.close_btn.Text = "X";
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // move_panner
            // 
            this.move_panner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.move_panner.Controls.Add(this.label2);
            this.move_panner.Controls.Add(this.under_btn);
            this.move_panner.Controls.Add(this.close_btn);
            this.move_panner.Location = new System.Drawing.Point(0, 0);
            this.move_panner.Name = "move_panner";
            this.move_panner.Size = new System.Drawing.Size(931, 42);
            this.move_panner.TabIndex = 2;
            this.move_panner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_panner_MouseDown);
            this.move_panner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move_panner_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Animation Conversion";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Location = new System.Drawing.Point(931, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 588);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Location = new System.Drawing.Point(-9, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 573);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Purple;
            this.panel3.Location = new System.Drawing.Point(-1, 577);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(935, 10);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Purple;
            this.panel4.Location = new System.Drawing.Point(1, -7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(932, 8);
            this.panel4.TabIndex = 6;
            // 
            // brocas
            // 
            this.brocas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.brocas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brocas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.brocas.FormattingEnabled = true;
            this.brocas.Location = new System.Drawing.Point(6, 20);
            this.brocas.Name = "brocas";
            this.brocas.Size = new System.Drawing.Size(221, 487);
            this.brocas.TabIndex = 8;
            this.brocas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.brocas_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brocas);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 511);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "방송사";
            // 
            // url
            // 
            this.url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.url.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.url.Location = new System.Drawing.Point(300, 14);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(608, 19);
            this.url.TabIndex = 10;
            this.url.Text = "http://cal.syoboi.jp/tid/3262/time";
            this.url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.url_KeyUp);
            this.url.MouseDown += new System.Windows.Forms.MouseEventHandler(this.input_box_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "URL :";
            // 
            // result_text
            // 
            this.result_text.Controls.Add(this.result_context);
            this.result_text.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.result_text.Location = new System.Drawing.Point(249, 39);
            this.result_text.Name = "result_text";
            this.result_text.Size = new System.Drawing.Size(659, 429);
            this.result_text.TabIndex = 12;
            this.result_text.TabStop = false;
            this.result_text.Text = "결과";
            // 
            // result_context
            // 
            this.result_context.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.result_context.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.result_context.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_context.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.result_context.Location = new System.Drawing.Point(6, 14);
            this.result_context.Multiline = true;
            this.result_context.Name = "result_context";
            this.result_context.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.result_context.Size = new System.Drawing.Size(647, 409);
            this.result_context.TabIndex = 13;
            // 
            // get_btn
            // 
            this.get_btn.BackColor = System.Drawing.Color.Purple;
            this.get_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.get_btn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.get_btn.Location = new System.Drawing.Point(684, 474);
            this.get_btn.Name = "get_btn";
            this.get_btn.Size = new System.Drawing.Size(224, 40);
            this.get_btn.TabIndex = 13;
            this.get_btn.Text = "추출";
            this.get_btn.UseVisualStyleBackColor = false;
            this.get_btn.Click += new System.EventHandler(this.get_btn_Click);
            // 
            // all_radio
            // 
            this.all_radio.AutoSize = true;
            this.all_radio.Checked = true;
            this.all_radio.Location = new System.Drawing.Point(253, 487);
            this.all_radio.Name = "all_radio";
            this.all_radio.Size = new System.Drawing.Size(47, 16);
            this.all_radio.TabIndex = 14;
            this.all_radio.TabStop = true;
            this.all_radio.Text = "전체";
            this.all_radio.UseVisualStyleBackColor = true;
            // 
            // now_radio
            // 
            this.now_radio.AutoSize = true;
            this.now_radio.Location = new System.Drawing.Point(306, 487);
            this.now_radio.Name = "now_radio";
            this.now_radio.Size = new System.Drawing.Size(47, 16);
            this.now_radio.TabIndex = 15;
            this.now_radio.Text = "현재";
            this.now_radio.UseVisualStyleBackColor = true;
            // 
            // future_radio
            // 
            this.future_radio.AutoSize = true;
            this.future_radio.Location = new System.Drawing.Point(359, 487);
            this.future_radio.Name = "future_radio";
            this.future_radio.Size = new System.Drawing.Size(47, 16);
            this.future_radio.TabIndex = 16;
            this.future_radio.Text = "미래";
            this.future_radio.UseVisualStyleBackColor = true;
            // 
            // now_date_text
            // 
            this.now_date_text.AutoSize = true;
            this.now_date_text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.now_date_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.now_date_text.Location = new System.Drawing.Point(412, 487);
            this.now_date_text.Name = "now_date_text";
            this.now_date_text.Size = new System.Drawing.Size(76, 16);
            this.now_date_text.TabIndex = 17;
            this.now_date_text.Text = "현재시간";
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.groupBox1);
            this.tab2.Controls.Add(this.get_btn);
            this.tab2.Controls.Add(this.now_date_text);
            this.tab2.Controls.Add(this.all_radio);
            this.tab2.Controls.Add(this.url);
            this.tab2.Controls.Add(this.result_text);
            this.tab2.Controls.Add(this.future_radio);
            this.tab2.Controls.Add(this.now_radio);
            this.tab2.Controls.Add(this.label1);
            this.tab2.Location = new System.Drawing.Point(12, 48);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(912, 518);
            this.tab2.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(932, 578);
            this.Controls.Add(this.tab2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.move_panner);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.move_panner.ResumeLayout(false);
            this.move_panner.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.result_text.ResumeLayout(false);
            this.result_text.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label under_btn;
        private System.Windows.Forms.Label close_btn;
        private System.Windows.Forms.Panel move_panner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox brocas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox result_text;
        private System.Windows.Forms.TextBox result_context;
        private System.Windows.Forms.Button get_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton all_radio;
        private System.Windows.Forms.RadioButton now_radio;
        private System.Windows.Forms.RadioButton future_radio;
        private System.Windows.Forms.Label now_date_text;
        private System.Windows.Forms.Panel tab2;
    }
}

