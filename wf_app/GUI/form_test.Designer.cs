namespace wf_app.GUI
{
    partial class form_test
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
            this._layout_table = new System.Windows.Forms.TableLayoutPanel();
            this._lvw_select_result = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._layout_table.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _layout_table
            // 
            this._layout_table.ColumnCount = 1;
            this._layout_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._layout_table.Controls.Add(this.panel1, 0, 1);
            this._layout_table.Controls.Add(this._lvw_select_result, 0, 2);
            this._layout_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layout_table.Location = new System.Drawing.Point(0, 0);
            this._layout_table.Name = "_layout_table";
            this._layout_table.RowCount = 3;
            this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layout_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._layout_table.Size = new System.Drawing.Size(597, 274);
            this._layout_table.TabIndex = 0;
            // 
            // _lvw_select_result
            // 
            this._lvw_select_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvw_select_result.Location = new System.Drawing.Point(3, 109);
            this._lvw_select_result.Name = "_lvw_select_result";
            this._lvw_select_result.Size = new System.Drawing.Size(591, 162);
            this._lvw_select_result.TabIndex = 0;
            this._lvw_select_result.UseCompatibleStateImageBehavior = false;
            this._lvw_select_result.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 100);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // form_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 274);
            this.Controls.Add(this._layout_table);
            this.Name = "form_test";
            this.Text = "form_test";
            this._layout_table.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _layout_table;
        private System.Windows.Forms.ListView _lvw_select_result;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}