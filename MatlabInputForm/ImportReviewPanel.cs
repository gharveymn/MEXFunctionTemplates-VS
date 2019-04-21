using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatlabInputForm
{
	class ImportReviewPanel : IPanel
	{

		private APIForm parent;
		MatlabConfiguration ml_config;

		public ImportReviewPanel(APIForm parent, MatlabConfiguration ml_config)
		{
			this.parent = parent;
			this.ml_config = ml_config;
			InitializeComponent();
		}

		private void InitializeComponent()
		{
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
			this.ToolTip1 = new MatlabInputForm.ToolTip();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.70213F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.29787F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 254);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// PlatformCheck
			// 
			this.PlatformCheck.AutoSize = true;
			this.PlatformCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlatformCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.PlatformCheck.Location = new System.Drawing.Point(476, 84);
			this.PlatformCheck.Name = "PlatformCheck";
			this.PlatformCheck.Size = new System.Drawing.Size(80, 28);
			this.PlatformCheck.TabIndex = 22;
			// 
			// APICheck
			// 
			this.APICheck.AutoSize = true;
			this.APICheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.APICheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.APICheck.Location = new System.Drawing.Point(476, 56);
			this.APICheck.Name = "APICheck";
			this.APICheck.Size = new System.Drawing.Size(80, 28);
			this.APICheck.TabIndex = 21;
			// 
			// ReleaseCheck
			// 
			this.ReleaseCheck.AutoSize = true;
			this.ReleaseCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReleaseCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.ReleaseCheck.Location = new System.Drawing.Point(476, 28);
			this.ReleaseCheck.Name = "ReleaseCheck";
			this.ReleaseCheck.Size = new System.Drawing.Size(80, 28);
			this.ReleaseCheck.TabIndex = 20;
			// 
			// MatlabRootCheck
			// 
			this.MatlabRootCheck.AutoSize = true;
			this.MatlabRootCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MatlabRootCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.MatlabRootCheck.Location = new System.Drawing.Point(476, 0);
			this.MatlabRootCheck.Name = "MatlabRootCheck";
			this.MatlabRootCheck.Size = new System.Drawing.Size(80, 28);
			this.MatlabRootCheck.TabIndex = 19;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(66, 0);
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
			this.label2.Location = new System.Drawing.Point(101, 28);
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
			this.label3.Location = new System.Drawing.Point(122, 56);
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
			this.label4.Location = new System.Drawing.Point(94, 84);
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
			this.label5.Location = new System.Drawing.Point(74, 112);
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
			this.CreateButton.Location = new System.Drawing.Point(395, 227);
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
			this.IncludePathText.Location = new System.Drawing.Point(153, 115);
			this.IncludePathText.Name = "IncludePathText";
			this.IncludePathText.Size = new System.Drawing.Size(317, 22);
			this.IncludePathText.TabIndex = 13;
			this.IncludePathText.TextChanged += new System.EventHandler(this.IncludePathText_TextChanged);
			// 
			// PlatformText
			// 
			this.PlatformText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlatformText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlatformText.Location = new System.Drawing.Point(153, 87);
			this.PlatformText.Name = "PlatformText";
			this.PlatformText.ReadOnly = true;
			this.PlatformText.Size = new System.Drawing.Size(317, 22);
			this.PlatformText.TabIndex = 14;
			// 
			// APIText
			// 
			this.APIText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.APIText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.APIText.Location = new System.Drawing.Point(153, 59);
			this.APIText.Name = "APIText";
			this.APIText.ReadOnly = true;
			this.APIText.Size = new System.Drawing.Size(317, 22);
			this.APIText.TabIndex = 15;
			// 
			// ReleaseText
			// 
			this.ReleaseText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReleaseText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReleaseText.Location = new System.Drawing.Point(153, 31);
			this.ReleaseText.Name = "ReleaseText";
			this.ReleaseText.ReadOnly = true;
			this.ReleaseText.Size = new System.Drawing.Size(317, 22);
			this.ReleaseText.TabIndex = 16;
			// 
			// MatlabRootText
			// 
			this.MatlabRootText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MatlabRootText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatlabRootText.Location = new System.Drawing.Point(153, 3);
			this.MatlabRootText.Name = "MatlabRootText";
			this.MatlabRootText.ReadOnly = true;
			this.MatlabRootText.Size = new System.Drawing.Size(317, 22);
			this.MatlabRootText.TabIndex = 17;
			// 
			// IncludePathCheck
			// 
			this.IncludePathCheck.AutoSize = true;
			this.IncludePathCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IncludePathCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.IncludePathCheck.Location = new System.Drawing.Point(476, 112);
			this.IncludePathCheck.Name = "IncludePathCheck";
			this.IncludePathCheck.Size = new System.Drawing.Size(80, 28);
			this.IncludePathCheck.TabIndex = 18;
			// 
			// LibPathText
			// 
			this.LibPathText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibPathText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LibPathText.Location = new System.Drawing.Point(153, 143);
			this.LibPathText.Name = "LibPathText";
			this.LibPathText.Size = new System.Drawing.Size(317, 22);
			this.LibPathText.TabIndex = 11;
			this.LibPathText.TextChanged += new System.EventHandler(this.LibPathText_TextChanged);
			// 
			// LibraryPathCheck
			// 
			this.LibraryPathCheck.AutoSize = true;
			this.LibraryPathCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibraryPathCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.LibraryPathCheck.Location = new System.Drawing.Point(476, 140);
			this.LibraryPathCheck.Name = "LibraryPathCheck";
			this.LibraryPathCheck.Size = new System.Drawing.Size(80, 28);
			this.LibraryPathCheck.TabIndex = 24;
			// 
			// DependsCheck
			// 
			this.DependsCheck.AutoSize = true;
			this.DependsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DependsCheck.Image = global::MatlabInputForm.Properties.Resources.success;
			this.DependsCheck.Location = new System.Drawing.Point(476, 168);
			this.DependsCheck.Name = "DependsCheck";
			this.DependsCheck.Size = new System.Drawing.Size(80, 28);
			this.DependsCheck.TabIndex = 25;
			// 
			// DependsText
			// 
			this.DependsText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DependsText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DependsText.Location = new System.Drawing.Point(153, 171);
			this.DependsText.Name = "DependsText";
			this.DependsText.Size = new System.Drawing.Size(317, 22);
			this.DependsText.TabIndex = 10;
			this.DependsText.TextChanged += new System.EventHandler(this.DependsText_TextChanged);
			// 
			// PreprocessorText
			// 
			this.PreprocessorText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PreprocessorText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PreprocessorText.Location = new System.Drawing.Point(153, 199);
			this.PreprocessorText.Name = "PreprocessorText";
			this.PreprocessorText.Size = new System.Drawing.Size(317, 22);
			this.PreprocessorText.TabIndex = 12;
			this.PreprocessorText.TextChanged += new System.EventHandler(this.PreprocessorText_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Right;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(12, 196);
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
			this.label7.Location = new System.Drawing.Point(77, 140);
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
			this.label8.Location = new System.Drawing.Point(66, 168);
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
			this.AbortButton.Location = new System.Drawing.Point(476, 227);
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

		}

		public void ShowPanel()
		{
			this.UpdateConfig();

			this.tableLayoutPanel1.SuspendLayout();
			parent.SuspendLayout();
			parent.AcceptButton = this.CreateButton;
			parent.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			parent.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			parent.CancelButton = this.AbortButton;
			parent.ClientSize = new System.Drawing.Size(559, 254);
			parent.Controls.Add(this.tableLayoutPanel1);
			parent.Icon = global::MatlabInputForm.Properties.Resources.matlab_logo;
			parent.Name = "ImportReviewForm";
			parent.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			parent.Text = "MEX Function Wizard - Import Review";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			parent.ResumeLayout(false);
		}

		public void HidePanel()
		{
			parent.Controls.Remove(this.tableLayoutPanel1);
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			parent.will_create = true;
			parent.Close();
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			this.HidePanel();
			parent.api_panel.ShowPanel();
		}

		public void UpdateConfig()
		{
			CheckResult check_result;
			string check_text;

			this.MatlabRootText.Text = ml_config.imports.MatlabRoot;
			this.ToolTip1.SetToolTip(this.MatlabRootText, this.MatlabRootText.Text);
			check_result = ml_config.imports.CheckMatlabRoot(out check_text);
			SetCheckInfo(this.MatlabRootCheck, check_result, check_text);

			this.ReleaseText.Text = ml_config.imports.Release;
			this.ToolTip1.SetToolTip(this.ReleaseText, this.ReleaseText.Text);
			check_result = ml_config.imports.CheckRelease(out check_text);
			SetCheckInfo(this.ReleaseCheck, check_result, check_text);

			this.APIText.Text = ml_config.imports.API;
			this.ToolTip1.SetToolTip(this.APIText, this.APIText.Text);
			check_result = ml_config.imports.CheckAPI(out check_text);
			SetCheckInfo(this.APICheck, check_result, check_text);

			this.PlatformText.Text = ml_config.imports.Platform;
			this.ToolTip1.SetToolTip(this.PlatformText, this.PlatformText.Text);
			check_result = ml_config.imports.CheckPlatform(out check_text);
			SetCheckInfo(this.PlatformCheck, check_result, check_text);

			this.IncludePathText.Text = ml_config.imports.IncludePath;
			this.ToolTip1.SetToolTip(this.IncludePathText, ml_config.imports.ReplaceMacro(this.IncludePathText.Text));

			this.PreprocessorText.Text = ml_config.imports.PreprocessorDefinitions;
			this.ToolTip1.SetToolTip(this.PreprocessorText, ml_config.imports.ReplaceMacro(this.PreprocessorText.Text));

			this.LibPathText.Text = ml_config.imports.LibraryPath;
			this.ToolTip1.SetToolTip(this.LibPathText, ml_config.imports.ReplaceMacro(this.LibPathText.Text));

			this.DependsText.Text = ml_config.imports.Dependencies;
			this.ToolTip1.SetToolTip(this.DependsText, ml_config.imports.ReplaceMacro(this.DependsText.Text));

		}

		private void SetCheckInfo(Label label, CheckResult chk, string text)
		{
			switch(chk)
			{
				case CheckResult.SUCCESS:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.success;
					break;
				}
				case CheckResult.WARNING:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.warning;
					break;
				}
				case CheckResult.FAILURE:
				{
					label.Image = global::MatlabInputForm.Properties.Resources.failure;
					break;
				}
			}
			ToolTip1.SetToolTip(label, text);
		}

		private void IncludePathText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.IncludePath = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckIncludePath(out tooltip_text);
			SetCheckInfo(IncludePathCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.IncludePathText.Text);
			ToolTip1.SetToolTip(IncludePathText, tooltip_text);
		}

		private void LibPathText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.LibraryPath = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckLibraryPath(out tooltip_text);
			SetCheckInfo(LibraryPathCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.LibPathText.Text);
			ToolTip1.SetToolTip(LibPathText, tooltip_text);

			/* check depends */
			chk = ml_config.imports.CheckDependencies(out tooltip_text);
			SetCheckInfo(DependsCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.DependsText.Text);
			ToolTip1.SetToolTip(DependsText, tooltip_text);
		}

		private void DependsText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.Dependencies = t.Text;
			string tooltip_text;
			CheckResult chk = ml_config.imports.CheckDependencies(out tooltip_text);
			SetCheckInfo(DependsCheck, chk, tooltip_text);
			tooltip_text = ml_config.imports.ReplaceMacro(this.DependsText.Text);
			ToolTip1.SetToolTip(DependsText, tooltip_text);
		}

		private void PreprocessorText_TextChanged(object sender, EventArgs e)
		{
			TextBox t = sender as TextBox;
			ml_config.imports.PreprocessorDefinitions = t.Text;
			string tooltip_text = ml_config.imports.ReplaceMacro(this.PreprocessorText.Text);
			ToolTip1.SetToolTip(PreprocessorText, tooltip_text);
		}

		private void AbortButton_Click(object sender, EventArgs e)
		{
			parent.DialogResult = DialogResult.Cancel;
			parent.Close();
		}

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
