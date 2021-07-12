
namespace final_project
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
            this.button1 = new System.Windows.Forms.Button();
            this.choosereq = new System.Windows.Forms.ComboBox();
            this.choose_label = new System.Windows.Forms.Label();
            this.write_label = new System.Windows.Forms.Label();
            this.XML_file_location = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(759, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // choosereq
            // 
            this.choosereq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.choosereq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.choosereq.FormattingEnabled = true;
            this.choosereq.Items.AddRange(new object[] {
            "Check cosistancy",
            "Check indentation",
            "Convert XML to JSON",
            "Show o/p XML file",
            "Show I/P XML file",
            "Minify xml file",
            "Compress XML file"});
            this.choosereq.Location = new System.Drawing.Point(440, 69);
            this.choosereq.Name = "choosereq";
            this.choosereq.Size = new System.Drawing.Size(258, 26);
            this.choosereq.TabIndex = 1;
            this.choosereq.SelectedIndexChanged += new System.EventHandler(this.choosereq_SelectedIndexChanged);
            // 
            // choose_label
            // 
            this.choose_label.AutoSize = true;
            this.choose_label.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.choose_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.choose_label.Location = new System.Drawing.Point(43, 67);
            this.choose_label.Name = "choose_label";
            this.choose_label.Size = new System.Drawing.Size(119, 29);
            this.choose_label.TabIndex = 2;
            this.choose_label.Text = "choose_req";
            // 
            // write_label
            // 
            this.write_label.AutoSize = true;
            this.write_label.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.write_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.write_label.Location = new System.Drawing.Point(43, 230);
            this.write_label.Name = "write_label";
            this.write_label.Size = new System.Drawing.Size(305, 29);
            this.write_label.TabIndex = 4;
            this.write_label.Text = "please write XML file location";
            this.write_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // XML_file_location
            // 
            this.XML_file_location.Location = new System.Drawing.Point(440, 225);
            this.XML_file_location.Name = "XML_file_location";
            this.XML_file_location.Size = new System.Drawing.Size(356, 26);
            this.XML_file_location.TabIndex = 5;
            this.XML_file_location.TextChanged += new System.EventHandler(this.XML_file_location_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(440, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 26);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(43, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Please Enter file name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 366);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(924, 26);
            this.textBox2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XML_file_location);
            this.Controls.Add(this.write_label);
            this.Controls.Add(this.choose_label);
            this.Controls.Add(this.choosereq);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "XML_Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox choosereq;
        private System.Windows.Forms.Label choose_label;
        private System.Windows.Forms.Label write_label;
        private System.Windows.Forms.TextBox XML_file_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

