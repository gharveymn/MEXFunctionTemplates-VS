namespace MatlabInputForm
{
	partial class ImportReviewForm
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
			if(disposing && (components != null))
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.PlatformCheck = new System.Windows.Forms.Label();
			this.APICheck = new System.Windows.Forms.Label();
			this.ReleaseCheck = new System.Windows.Forms.Label();
			this.MatlabRootCheck = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.CreateButton = new System.Windows.Forms.Button();
			this.IncludePathText = new System.Windows.Forms.TextBox();
			this.PlatformText = new System.Windows.Forms.TextBox();
			this.APIText = new System.Windows.Forms.TextBox();
			this.ReleaseText = new System.Windows.Forms.TextBox();
			this.MatlabRootText = new System.Windows.Forms.TextBox();
			this.IncludePathCheck = new System.Windows.Forms.Label();
			this.LibPathText = new System.Windows.Forms.TextBox();
			this.LibraryPathCheck = new System.Windows.Forms.Label();
			this.DependsCheck = new System.Windows.Forms.Label();
			this.DependsText = new System.Windows.Forms.TextBox();
			this.PreprocessorText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.BackButton = new System.Windows.Forms.Button();
			this.AbortButton = new System.Windows.Forms.Button();
			this.ToolTip1 = new MatlabInputForm.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			this.tableLayoutPanel1.Controls.Add(this.PlatformCheck, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.APICheck, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.ReleaseCheck, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.MatlabRootCheck, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.CreateButton, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.IncludePathText, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.PlatformText, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.APIText, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ReleaseText, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.MatlabRootText, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.IncludePathCheck, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.LibPathText, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.LibraryPathCheck, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.DependsCheck, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.DependsText, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.PreprocessorText, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.BackButton, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.AbortButton, 2, 8);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 254);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// PlatformCheck
			// 
			this.PlatformCheck.AutoSize = true;
			this.PlatformCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlatformCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.PlatformCheck.Location = new System.Drawing.Point(515, 84);
			this.PlatformCheck.Name = "PlatformCheck";
			this.PlatformCheck.Size = new System.Drawing.Size(80, 28);
			this.PlatformCheck.TabIndex = 22;
			// 
			// APICheck
			// 
			this.APICheck.AutoSize = true;
			this.APICheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.APICheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.APICheck.Location = new System.Drawing.Point(515, 56);
			this.APICheck.Name = "APICheck";
			this.APICheck.Size = new System.Drawing.Size(80, 28);
			this.APICheck.TabIndex = 21;
			// 
			// ReleaseCheck
			// 
			this.ReleaseCheck.AutoSize = true;
			this.ReleaseCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReleaseCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.ReleaseCheck.Location = new System.Drawing.Point(515, 28);
			this.ReleaseCheck.Name = "ReleaseCheck";
			this.ReleaseCheck.Size = new System.Drawing.Size(80, 28);
			this.ReleaseCheck.TabIndex = 20;
			// 
			// MatlabRootCheck
			// 
			this.MatlabRootCheck.AutoSize = true;
			this.MatlabRootCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MatlabRootCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.MatlabRootCheck.Location = new System.Drawing.Point(515, 0);
			this.MatlabRootCheck.Name = "MatlabRootCheck";
			this.MatlabRootCheck.Size = new System.Drawing.Size(80, 28);
			this.MatlabRootCheck.TabIndex = 19;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(57, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "MATLAB Root";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(92, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 28);
			this.label2.TabIndex = 1;
			this.label2.Text = "Release";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(113, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 28);
			this.label3.TabIndex = 2;
			this.label3.Text = "API";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Right;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(85, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 28);
			this.label4.TabIndex = 3;
			this.label4.Text = "Platform";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Right;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(65, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 28);
			this.label5.TabIndex = 4;
			this.label5.Text = "Include Path";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CreateButton
			// 
			this.CreateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CreateButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CreateButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreateButton.Location = new System.Drawing.Point(434, 227);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(75, 24);
			this.CreateButton.TabIndex = 8;
			this.CreateButton.Text = "Create";
			this.CreateButton.UseVisualStyleBackColor = true;
			this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// IncludePathText
			// 
			this.IncludePathText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IncludePathText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncludePathText.Location = new System.Drawing.Point(144, 115);
			this.IncludePathText.Name = "IncludePathText";
			this.IncludePathText.Size = new System.Drawing.Size(365, 22);
			this.IncludePathText.TabIndex = 13;
			this.IncludePathText.TextChanged += new System.EventHandler(this.IncludePathText_TextChanged);
			// 
			// PlatformText
			// 
			this.PlatformText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlatformText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlatformText.Location = new System.Drawing.Point(144, 87);
			this.PlatformText.Name = "PlatformText";
			this.PlatformText.ReadOnly = true;
			this.PlatformText.Size = new System.Drawing.Size(365, 22);
			this.PlatformText.TabIndex = 14;
			// 
			// APIText
			// 
			this.APIText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.APIText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.APIText.Location = new System.Drawing.Point(144, 59);
			this.APIText.Name = "APIText";
			this.APIText.ReadOnly = true;
			this.APIText.Size = new System.Drawing.Size(365, 22);
			this.APIText.TabIndex = 15;
			// 
			// ReleaseText
			// 
			this.ReleaseText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReleaseText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReleaseText.Location = new System.Drawing.Point(144, 31);
			this.ReleaseText.Name = "ReleaseText";
			this.ReleaseText.ReadOnly = true;
			this.ReleaseText.Size = new System.Drawing.Size(365, 22);
			this.ReleaseText.TabIndex = 16;
			// 
			// MatlabRootText
			// 
			this.MatlabRootText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MatlabRootText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatlabRootText.Location = new System.Drawing.Point(144, 3);
			this.MatlabRootText.Name = "MatlabRootText";
			this.MatlabRootText.ReadOnly = true;
			this.MatlabRootText.Size = new System.Drawing.Size(365, 22);
			this.MatlabRootText.TabIndex = 17;
			// 
			// IncludePathCheck
			// 
			this.IncludePathCheck.AutoSize = true;
			this.IncludePathCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IncludePathCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.IncludePathCheck.Location = new System.Drawing.Point(515, 112);
			this.IncludePathCheck.Name = "IncludePathCheck";
			this.IncludePathCheck.Size = new System.Drawing.Size(80, 28);
			this.IncludePathCheck.TabIndex = 18;
			// 
			// LibPathText
			// 
			this.LibPathText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibPathText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LibPathText.Location = new System.Drawing.Point(144, 143);
			this.LibPathText.Name = "LibPathText";
			this.LibPathText.Size = new System.Drawing.Size(365, 22);
			this.LibPathText.TabIndex = 11;
			this.LibPathText.TextChanged += new System.EventHandler(this.LibPathText_TextChanged);
			// 
			// LibraryPathCheck
			// 
			this.LibraryPathCheck.AutoSize = true;
			this.LibraryPathCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibraryPathCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.LibraryPathCheck.Location = new System.Drawing.Point(515, 140);
			this.LibraryPathCheck.Name = "LibraryPathCheck";
			this.LibraryPathCheck.Size = new System.Drawing.Size(80, 28);
			this.LibraryPathCheck.TabIndex = 24;
			// 
			// DependsCheck
			// 
			this.DependsCheck.AutoSize = true;
			this.DependsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DependsCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.DependsCheck.Location = new System.Drawing.Point(515, 168);
			this.DependsCheck.Name = "DependsCheck";
			this.DependsCheck.Size = new System.Drawing.Size(80, 28);
			this.DependsCheck.TabIndex = 25;
			// 
			// DependsText
			// 
			this.DependsText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DependsText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DependsText.Location = new System.Drawing.Point(144, 171);
			this.DependsText.Name = "DependsText";
			this.DependsText.Size = new System.Drawing.Size(365, 22);
			this.DependsText.TabIndex = 10;
			this.DependsText.TextChanged += new System.EventHandler(this.DependsText_TextChanged);
			// 
			// PreprocessorText
			// 
			this.PreprocessorText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PreprocessorText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PreprocessorText.Location = new System.Drawing.Point(144, 199);
			this.PreprocessorText.Name = "PreprocessorText";
			this.PreprocessorText.Size = new System.Drawing.Size(365, 22);
			this.PreprocessorText.TabIndex = 12;
			this.PreprocessorText.TextChanged += new System.EventHandler(this.PreprocessorText_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Right;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(3, 196);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(135, 28);
			this.label6.TabIndex = 5;
			this.label6.Text = "Preprocessor Definitions";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Right;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(68, 140);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 28);
			this.label7.TabIndex = 6;
			this.label7.Text = "Library Path";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Right;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(57, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(81, 28);
			this.label8.TabIndex = 7;
			this.label8.Text = "Dependencies";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BackButton
			// 
			this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BackButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.BackButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BackButton.Location = new System.Drawing.Point(3, 227);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(75, 24);
			this.BackButton.TabIndex = 9;
			this.BackButton.Text = "Back";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// AbortButton
			// 
			this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AbortButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbortButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AbortButton.Location = new System.Drawing.Point(515, 227);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(80, 24);
			this.AbortButton.TabIndex = 26;
			this.AbortButton.Text = "Cancel";
			this.AbortButton.UseVisualStyleBackColor = true;
			this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
			// 
			// ToolTip1
			// 
			this.ToolTip1.AutoPopDelay = 50000;
			this.ToolTip1.InitialDelay = 250;
			this.ToolTip1.ReshowDelay = 0;
			// 
			// ImportReviewForm
			// 
			this.AcceptButton = this.CreateButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.AbortButton;
			this.ClientSize = new System.Drawing.Size(598, 254);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = global::MatlabInputForm.Properties.Resources.matlab_logo;
			this.Name = "ImportReviewForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MEX Function Wizard - Import Review";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button CreateButton;
		private System.Windows.Forms.TextBox DependsText;
		private System.Windows.Forms.TextBox LibPathText;
		private System.Windows.Forms.TextBox PreprocessorText;
		private System.Windows.Forms.TextBox IncludePathText;
		private System.Windows.Forms.TextBox PlatformText;
		private System.Windows.Forms.TextBox APIText;
		private System.Windows.Forms.TextBox ReleaseText;
		private System.Windows.Forms.TextBox MatlabRootText;
		private System.Windows.Forms.Button BackButton;
		private MatlabInputForm.ToolTip ToolTip1;
		private System.Windows.Forms.Label IncludePathCheck;
		private System.Windows.Forms.Label DependsCheck;
		private System.Windows.Forms.Label LibraryPathCheck;
		private System.Windows.Forms.Label PlatformCheck;
		private System.Windows.Forms.Label APICheck;
		private System.Windows.Forms.Label ReleaseCheck;
		private System.Windows.Forms.Label MatlabRootCheck;
		private System.Windows.Forms.Button AbortButton;
	}
}