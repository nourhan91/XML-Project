
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Take_request = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.XML_output_location = new System.Windows.Forms.TextBox();
            this.Display_files = new System.Windows.Forms.TabPage();
            this.clear_button = new System.Windows.Forms.Button();
            this.show_output = new System.Windows.Forms.Button();
            this.show_input = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Errors_list = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.Take_request.SuspendLayout();
            this.Display_files.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(823, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 43);
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
            "Check Consistency",
            "Check indentation",
            "Minify xml file",
            "Convert XML to JSON",
            "Compress XML file",
            "Decompress XML file"});
            this.choosereq.Location = new System.Drawing.Point(250, 26);
            this.choosereq.Name = "choosereq";
            this.choosereq.Size = new System.Drawing.Size(258, 22);
            this.choosereq.TabIndex = 1;
            this.choosereq.SelectedIndexChanged += new System.EventHandler(this.choosereq_SelectedIndexChanged);
            // 
            // choose_label
            // 
            this.choose_label.AutoSize = true;
            this.choose_label.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.choose_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.choose_label.Location = new System.Drawing.Point(7, 23);
            this.choose_label.Name = "choose_label";
            this.choose_label.Size = new System.Drawing.Size(142, 22);
            this.choose_label.TabIndex = 2;
            this.choose_label.Text = "Choose Operation";
            // 
            // write_label
            // 
            this.write_label.AutoSize = true;
            this.write_label.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.write_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.write_label.Location = new System.Drawing.Point(3, 132);
            this.write_label.Name = "write_label";
            this.write_label.Size = new System.Drawing.Size(241, 22);
            this.write_label.TabIndex = 4;
            this.write_label.Text = "please write XML file location";
            this.write_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // XML_file_location
            // 
            this.XML_file_location.Location = new System.Drawing.Point(347, 132);
            this.XML_file_location.Name = "XML_file_location";
            this.XML_file_location.Size = new System.Drawing.Size(356, 22);
            this.XML_file_location.TabIndex = 5;
            this.XML_file_location.TextChanged += new System.EventHandler(this.XML_file_location_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Take_request);
            this.tabControl1.Controls.Add(this.Display_files);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1208, 860);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Take_request
            // 
            this.Take_request.Controls.Add(this.label1);
            this.Take_request.Controls.Add(this.XML_output_location);
            this.Take_request.Controls.Add(this.choose_label);
            this.Take_request.Controls.Add(this.button1);
            this.Take_request.Controls.Add(this.XML_file_location);
            this.Take_request.Controls.Add(this.write_label);
            this.Take_request.Controls.Add(this.choosereq);
            this.Take_request.Location = new System.Drawing.Point(4, 23);
            this.Take_request.Name = "Take_request";
            this.Take_request.Padding = new System.Windows.Forms.Padding(3);
            this.Take_request.Size = new System.Drawing.Size(1200, 833);
            this.Take_request.TabIndex = 0;
            this.Take_request.Text = "Take_request";
            this.Take_request.UseVisualStyleBackColor = true;
            this.Take_request.Click += new System.EventHandler(this.Take_request_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Condensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please Write XML output Location";
            // 
            // XML_output_location
            // 
            this.XML_output_location.Location = new System.Drawing.Point(347, 192);
            this.XML_output_location.Name = "XML_output_location";
            this.XML_output_location.Size = new System.Drawing.Size(356, 22);
            this.XML_output_location.TabIndex = 9;
            this.XML_output_location.TextChanged += new System.EventHandler(this.XML_output_location_TextChanged);
            // 
            // Display_files
            // 
            this.Display_files.Controls.Add(this.clear_button);
            this.Display_files.Controls.Add(this.show_output);
            this.Display_files.Controls.Add(this.show_input);
            this.Display_files.Controls.Add(this.richTextBox2);
            this.Display_files.Controls.Add(this.richTextBox1);
            this.Display_files.Location = new System.Drawing.Point(4, 23);
            this.Display_files.Name = "Display_files";
            this.Display_files.Padding = new System.Windows.Forms.Padding(3);
            this.Display_files.Size = new System.Drawing.Size(1200, 833);
            this.Display_files.TabIndex = 1;
            this.Display_files.Text = "Display_files";
            this.Display_files.UseVisualStyleBackColor = true;
            this.Display_files.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // clear_button
            // 
            this.clear_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clear_button.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.clear_button.Location = new System.Drawing.Point(539, 709);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(96, 41);
            this.clear_button.TabIndex = 4;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // show_output
            // 
            this.show_output.Location = new System.Drawing.Point(789, 9);
            this.show_output.Name = "show_output";
            this.show_output.Size = new System.Drawing.Size(117, 29);
            this.show_output.TabIndex = 3;
            this.show_output.Text = "show_output";
            this.show_output.UseVisualStyleBackColor = true;
            this.show_output.Click += new System.EventHandler(this.button3_Click);
            // 
            // show_input
            // 
            this.show_input.Location = new System.Drawing.Point(194, 9);
            this.show_input.Name = "show_input";
            this.show_input.Size = new System.Drawing.Size(119, 29);
            this.show_input.TabIndex = 2;
            this.show_input.Text = "Show_input";
            this.show_input.UseVisualStyleBackColor = true;
            this.show_input.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(598, 44);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(607, 634);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(587, 634);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Errors_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1200, 833);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Show Errors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Errors_list
            // 
            this.Errors_list.Location = new System.Drawing.Point(5, 15);
            this.Errors_list.Name = "Errors_list";
            this.Errors_list.Size = new System.Drawing.Size(732, 785);
            this.Errors_list.TabIndex = 0;
            this.Errors_list.Text = "";
            this.Errors_list.TextChanged += new System.EventHandler(this.Errors_list_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 749);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "XML_Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Take_request.ResumeLayout(false);
            this.Take_request.PerformLayout();
            this.Display_files.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox choosereq;
        private System.Windows.Forms.Label choose_label;
        private System.Windows.Forms.Label write_label;
        private System.Windows.Forms.TextBox XML_file_location;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Take_request;
        private System.Windows.Forms.TabPage Display_files;
        private System.Windows.Forms.Button show_output;
        private System.Windows.Forms.Button show_input;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XML_output_location;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox Errors_list;
    }
}

