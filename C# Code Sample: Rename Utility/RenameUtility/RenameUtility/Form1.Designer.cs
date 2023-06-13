namespace RenameUtility
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FileDataView = new System.Windows.Forms.DataGridView();
            this.FileIconColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.DrivesComboBox = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.FolderNamesBox = new System.Windows.Forms.ComboBox();
            this.upButton = new System.Windows.Forms.Button();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.JumpToFolderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextRenamePrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextRenameSuffix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumRenameStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NumRenameIncrement = new System.Windows.Forms.NumericUpDown();
            this.RenameButton = new System.Windows.Forms.Button();
            this.CheckBoxSubfolders = new System.Windows.Forms.CheckBox();
            this.TextFilenameFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnFilenameContains = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.FilenameFilterButtons = new System.Windows.Forms.GroupBox();
            this.BtnFilenameEndsWith = new System.Windows.Forms.RadioButton();
            this.BtnFilenameStartsWith = new System.Windows.Forms.RadioButton();
            this.BtnFilenameMatches = new System.Windows.Forms.RadioButton();
            this.TextExtensionBox = new System.Windows.Forms.TextBox();
            this.ExtensionFilterButtons = new System.Windows.Forms.GroupBox();
            this.BtnExtensionEndsWith = new System.Windows.Forms.RadioButton();
            this.BtnExtensionStartsWith = new System.Windows.Forms.RadioButton();
            this.BtnExtensionMatches = new System.Windows.Forms.RadioButton();
            this.BtnExtensionContains = new System.Windows.Forms.RadioButton();
            this.KeepExtCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.FileDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRenameStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRenameIncrement)).BeginInit();
            this.FilenameFilterButtons.SuspendLayout();
            this.ExtensionFilterButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDataView
            // 
            this.FileDataView.AllowUserToAddRows = false;
            this.FileDataView.AllowUserToDeleteRows = false;
            this.FileDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileDataView.ColumnHeadersVisible = false;
            this.FileDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileIconColumn,
            this.FileNameColumn});
            this.FileDataView.Location = new System.Drawing.Point(147, 34);
            this.FileDataView.Name = "FileDataView";
            this.FileDataView.ReadOnly = true;
            this.FileDataView.RowHeadersVisible = false;
            this.FileDataView.Size = new System.Drawing.Size(571, 283);
            this.FileDataView.TabIndex = 1;
            this.FileDataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileDataView_CellDoubleClick);
            // 
            // FileIconColumn
            // 
            this.FileIconColumn.Frozen = true;
            this.FileIconColumn.HeaderText = "";
            this.FileIconColumn.Name = "FileIconColumn";
            this.FileIconColumn.ReadOnly = true;
            this.FileIconColumn.Width = 27;
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.HeaderText = "";
            this.FileNameColumn.Name = "FileNameColumn";
            this.FileNameColumn.ReadOnly = true;
            this.FileNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FileNameColumn.Width = 535;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jump to drive:";
            // 
            // DrivesComboBox
            // 
            this.DrivesComboBox.FormattingEnabled = true;
            this.DrivesComboBox.Location = new System.Drawing.Point(86, 67);
            this.DrivesComboBox.Name = "DrivesComboBox";
            this.DrivesComboBox.Size = new System.Drawing.Size(55, 21);
            this.DrivesComboBox.TabIndex = 3;
            this.DrivesComboBox.SelectedIndexChanged += new System.EventHandler(this.DrivesComboBox_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fileIcon.png");
            this.imageList1.Images.SetKeyName(1, "folderIcon.png");
            // 
            // FolderNamesBox
            // 
            this.FolderNamesBox.FormattingEnabled = true;
            this.FolderNamesBox.Location = new System.Drawing.Point(10, 150);
            this.FolderNamesBox.Name = "FolderNamesBox";
            this.FolderNamesBox.Size = new System.Drawing.Size(121, 21);
            this.FolderNamesBox.TabIndex = 4;
            this.FolderNamesBox.Visible = false;
            // 
            // upButton
            // 
            this.upButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upButton.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.upButton.Location = new System.Drawing.Point(109, 34);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(32, 30);
            this.upButton.TabIndex = 5;
            this.upButton.Text = "á";
            this.upButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(147, 15);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(35, 13);
            this.DirectoryLabel.TabIndex = 6;
            this.DirectoryLabel.Text = "label2";
            // 
            // JumpToFolderButton
            // 
            this.JumpToFolderButton.Location = new System.Drawing.Point(10, 94);
            this.JumpToFolderButton.Name = "JumpToFolderButton";
            this.JumpToFolderButton.Size = new System.Drawing.Size(127, 24);
            this.JumpToFolderButton.TabIndex = 7;
            this.JumpToFolderButton.Text = "Jump to folder";
            this.JumpToFolderButton.UseVisualStyleBackColor = true;
            this.JumpToFolderButton.Click += new System.EventHandler(this.JumpToFolderButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filename";
            // 
            // TextRenamePrefix
            // 
            this.TextRenamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextRenamePrefix.Location = new System.Drawing.Point(442, 391);
            this.TextRenamePrefix.Name = "TextRenamePrefix";
            this.TextRenamePrefix.Size = new System.Drawing.Size(100, 20);
            this.TextRenamePrefix.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Prefix";
            // 
            // TextRenameSuffix
            // 
            this.TextRenameSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TextRenameSuffix.Location = new System.Drawing.Point(618, 391);
            this.TextRenameSuffix.Name = "TextRenameSuffix";
            this.TextRenameSuffix.Size = new System.Drawing.Size(100, 20);
            this.TextRenameSuffix.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Suffix";
            // 
            // NumRenameStart
            // 
            this.NumRenameStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumRenameStart.Location = new System.Drawing.Point(548, 391);
            this.NumRenameStart.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.NumRenameStart.Name = "NumRenameStart";
            this.NumRenameStart.Size = new System.Drawing.Size(64, 20);
            this.NumRenameStart.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Init Number";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Increment By";
            // 
            // NumRenameIncrement
            // 
            this.NumRenameIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumRenameIncrement.Location = new System.Drawing.Point(548, 430);
            this.NumRenameIncrement.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.NumRenameIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumRenameIncrement.Name = "NumRenameIncrement";
            this.NumRenameIncrement.Size = new System.Drawing.Size(64, 20);
            this.NumRenameIncrement.TabIndex = 17;
            this.NumRenameIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RenameButton
            // 
            this.RenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameButton.Location = new System.Drawing.Point(657, 477);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(61, 23);
            this.RenameButton.TabIndex = 18;
            this.RenameButton.Text = "Rename!";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // CheckBoxSubfolders
            // 
            this.CheckBoxSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxSubfolders.AutoSize = true;
            this.CheckBoxSubfolders.Location = new System.Drawing.Point(467, 481);
            this.CheckBoxSubfolders.Name = "CheckBoxSubfolders";
            this.CheckBoxSubfolders.Size = new System.Drawing.Size(184, 17);
            this.CheckBoxSubfolders.TabIndex = 19;
            this.CheckBoxSubfolders.Text = "Rename files in subfolders as well";
            this.CheckBoxSubfolders.UseVisualStyleBackColor = true;
            // 
            // TextFilenameFilter
            // 
            this.TextFilenameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextFilenameFilter.Location = new System.Drawing.Point(15, 360);
            this.TextFilenameFilter.Name = "TextFilenameFilter";
            this.TextFilenameFilter.Size = new System.Drawing.Size(100, 20);
            this.TextFilenameFilter.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Filters";
            // 
            // BtnFilenameContains
            // 
            this.BtnFilenameContains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFilenameContains.AutoSize = true;
            this.BtnFilenameContains.Checked = true;
            this.BtnFilenameContains.Location = new System.Drawing.Point(6, 19);
            this.BtnFilenameContains.Name = "BtnFilenameContains";
            this.BtnFilenameContains.Size = new System.Drawing.Size(66, 17);
            this.BtnFilenameContains.TabIndex = 22;
            this.BtnFilenameContains.TabStop = true;
            this.BtnFilenameContains.Text = "Contains";
            this.BtnFilenameContains.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Extension";
            // 
            // FilenameFilterButtons
            // 
            this.FilenameFilterButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilenameFilterButtons.Controls.Add(this.BtnFilenameEndsWith);
            this.FilenameFilterButtons.Controls.Add(this.BtnFilenameStartsWith);
            this.FilenameFilterButtons.Controls.Add(this.BtnFilenameMatches);
            this.FilenameFilterButtons.Controls.Add(this.BtnFilenameContains);
            this.FilenameFilterButtons.Location = new System.Drawing.Point(15, 383);
            this.FilenameFilterButtons.Name = "FilenameFilterButtons";
            this.FilenameFilterButtons.Size = new System.Drawing.Size(100, 117);
            this.FilenameFilterButtons.TabIndex = 24;
            this.FilenameFilterButtons.TabStop = false;
            // 
            // BtnFilenameEndsWith
            // 
            this.BtnFilenameEndsWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFilenameEndsWith.AutoSize = true;
            this.BtnFilenameEndsWith.Location = new System.Drawing.Point(6, 88);
            this.BtnFilenameEndsWith.Name = "BtnFilenameEndsWith";
            this.BtnFilenameEndsWith.Size = new System.Drawing.Size(74, 17);
            this.BtnFilenameEndsWith.TabIndex = 25;
            this.BtnFilenameEndsWith.Text = "Ends With";
            this.BtnFilenameEndsWith.UseVisualStyleBackColor = true;
            // 
            // BtnFilenameStartsWith
            // 
            this.BtnFilenameStartsWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFilenameStartsWith.AutoSize = true;
            this.BtnFilenameStartsWith.Location = new System.Drawing.Point(6, 65);
            this.BtnFilenameStartsWith.Name = "BtnFilenameStartsWith";
            this.BtnFilenameStartsWith.Size = new System.Drawing.Size(77, 17);
            this.BtnFilenameStartsWith.TabIndex = 24;
            this.BtnFilenameStartsWith.Text = "Starts With";
            this.BtnFilenameStartsWith.UseVisualStyleBackColor = true;
            // 
            // BtnFilenameMatches
            // 
            this.BtnFilenameMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnFilenameMatches.AutoSize = true;
            this.BtnFilenameMatches.Location = new System.Drawing.Point(6, 42);
            this.BtnFilenameMatches.Name = "BtnFilenameMatches";
            this.BtnFilenameMatches.Size = new System.Drawing.Size(66, 17);
            this.BtnFilenameMatches.TabIndex = 23;
            this.BtnFilenameMatches.Text = "Matches";
            this.BtnFilenameMatches.UseVisualStyleBackColor = true;
            // 
            // TextExtensionBox
            // 
            this.TextExtensionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextExtensionBox.Location = new System.Drawing.Point(121, 360);
            this.TextExtensionBox.Name = "TextExtensionBox";
            this.TextExtensionBox.Size = new System.Drawing.Size(100, 20);
            this.TextExtensionBox.TabIndex = 25;
            // 
            // ExtensionFilterButtons
            // 
            this.ExtensionFilterButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExtensionFilterButtons.Controls.Add(this.BtnExtensionEndsWith);
            this.ExtensionFilterButtons.Controls.Add(this.BtnExtensionStartsWith);
            this.ExtensionFilterButtons.Controls.Add(this.BtnExtensionMatches);
            this.ExtensionFilterButtons.Controls.Add(this.BtnExtensionContains);
            this.ExtensionFilterButtons.Location = new System.Drawing.Point(121, 386);
            this.ExtensionFilterButtons.Name = "ExtensionFilterButtons";
            this.ExtensionFilterButtons.Size = new System.Drawing.Size(100, 117);
            this.ExtensionFilterButtons.TabIndex = 26;
            this.ExtensionFilterButtons.TabStop = false;
            // 
            // BtnExtensionEndsWith
            // 
            this.BtnExtensionEndsWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExtensionEndsWith.AutoSize = true;
            this.BtnExtensionEndsWith.Location = new System.Drawing.Point(6, 88);
            this.BtnExtensionEndsWith.Name = "BtnExtensionEndsWith";
            this.BtnExtensionEndsWith.Size = new System.Drawing.Size(74, 17);
            this.BtnExtensionEndsWith.TabIndex = 25;
            this.BtnExtensionEndsWith.Text = "Ends With";
            this.BtnExtensionEndsWith.UseVisualStyleBackColor = true;
            // 
            // BtnExtensionStartsWith
            // 
            this.BtnExtensionStartsWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExtensionStartsWith.AutoSize = true;
            this.BtnExtensionStartsWith.Location = new System.Drawing.Point(6, 65);
            this.BtnExtensionStartsWith.Name = "BtnExtensionStartsWith";
            this.BtnExtensionStartsWith.Size = new System.Drawing.Size(77, 17);
            this.BtnExtensionStartsWith.TabIndex = 24;
            this.BtnExtensionStartsWith.Text = "Starts With";
            this.BtnExtensionStartsWith.UseVisualStyleBackColor = true;
            // 
            // BtnExtensionMatches
            // 
            this.BtnExtensionMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExtensionMatches.AutoSize = true;
            this.BtnExtensionMatches.Location = new System.Drawing.Point(6, 42);
            this.BtnExtensionMatches.Name = "BtnExtensionMatches";
            this.BtnExtensionMatches.Size = new System.Drawing.Size(66, 17);
            this.BtnExtensionMatches.TabIndex = 23;
            this.BtnExtensionMatches.Text = "Matches";
            this.BtnExtensionMatches.UseVisualStyleBackColor = true;
            // 
            // BtnExtensionContains
            // 
            this.BtnExtensionContains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExtensionContains.AutoSize = true;
            this.BtnExtensionContains.Checked = true;
            this.BtnExtensionContains.Location = new System.Drawing.Point(6, 19);
            this.BtnExtensionContains.Name = "BtnExtensionContains";
            this.BtnExtensionContains.Size = new System.Drawing.Size(66, 17);
            this.BtnExtensionContains.TabIndex = 22;
            this.BtnExtensionContains.TabStop = true;
            this.BtnExtensionContains.Text = "Contains";
            this.BtnExtensionContains.UseVisualStyleBackColor = true;
            // 
            // KeepExtCheckBox
            // 
            this.KeepExtCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.KeepExtCheckBox.AutoSize = true;
            this.KeepExtCheckBox.Checked = true;
            this.KeepExtCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeepExtCheckBox.Location = new System.Drawing.Point(551, 458);
            this.KeepExtCheckBox.Name = "KeepExtCheckBox";
            this.KeepExtCheckBox.Size = new System.Drawing.Size(100, 17);
            this.KeepExtCheckBox.TabIndex = 27;
            this.KeepExtCheckBox.Text = "Keep Extension";
            this.KeepExtCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 510);
            this.Controls.Add(this.KeepExtCheckBox);
            this.Controls.Add(this.ExtensionFilterButtons);
            this.Controls.Add(this.TextExtensionBox);
            this.Controls.Add(this.FilenameFilterButtons);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TextFilenameFilter);
            this.Controls.Add(this.CheckBoxSubfolders);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.NumRenameIncrement);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NumRenameStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextRenameSuffix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextRenamePrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.JumpToFolderButton);
            this.Controls.Add(this.DirectoryLabel);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.FolderNamesBox);
            this.Controls.Add(this.DrivesComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileDataView);
            this.Name = "Form1";
            this.Text = "Rename Utility";
            ((System.ComponentModel.ISupportInitialize)(this.FileDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRenameStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRenameIncrement)).EndInit();
            this.FilenameFilterButtons.ResumeLayout(false);
            this.FilenameFilterButtons.PerformLayout();
            this.ExtensionFilterButtons.ResumeLayout(false);
            this.ExtensionFilterButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView FileDataView;
        private System.Windows.Forms.DataGridViewImageColumn FileIconColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DrivesComboBox;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox FolderNamesBox;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Button JumpToFolderButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextRenamePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextRenameSuffix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumRenameStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NumRenameIncrement;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.CheckBox CheckBoxSubfolders;
        private System.Windows.Forms.TextBox TextFilenameFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton BtnFilenameContains;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox FilenameFilterButtons;
        private System.Windows.Forms.RadioButton BtnFilenameEndsWith;
        private System.Windows.Forms.RadioButton BtnFilenameStartsWith;
        private System.Windows.Forms.RadioButton BtnFilenameMatches;
        private System.Windows.Forms.TextBox TextExtensionBox;
        private System.Windows.Forms.GroupBox ExtensionFilterButtons;
        private System.Windows.Forms.RadioButton BtnExtensionEndsWith;
        private System.Windows.Forms.RadioButton BtnExtensionStartsWith;
        private System.Windows.Forms.RadioButton BtnExtensionMatches;
        private System.Windows.Forms.RadioButton BtnExtensionContains;
        private System.Windows.Forms.CheckBox KeepExtCheckBox;
    }
}

