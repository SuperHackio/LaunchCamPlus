namespace LaunchCamPlus.CameraPanels
{
    partial class CameraPanelBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IDLabel = new Label();
            TypeLabel = new Label();
            TypeComboBox = new ExtraControls.ColourComboBox();
            IDTextBox = new ExtraControls.ColourTextBox();
            SuspendLayout();
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            IDLabel.Location = new Point(3, 6);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(21, 13);
            IDLabel.TabIndex = 1;
            IDLabel.Text = "ID:";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TypeLabel.Location = new Point(3, 32);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(34, 13);
            TypeLabel.TabIndex = 3;
            TypeLabel.Text = "Type:";
            // 
            // TypeComboBox
            // 
            TypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TypeComboBox.AutoCompleteMode = AutoCompleteMode.Append;
            TypeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            TypeComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            TypeComboBox.FlatStyle = FlatStyle.Flat;
            TypeComboBox.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Location = new Point(43, 29);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(395, 21);
            TypeComboBox.TabIndex = 4;
            TypeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;
            // 
            // IDTextBox
            // 
            IDTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            IDTextBox.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            IDTextBox.Location = new Point(43, 3);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.Size = new Size(395, 20);
            IDTextBox.TabIndex = 0;
            IDTextBox.TextChanged += IDTextBox_TextChanged;
            // 
            // CameraPanelBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TypeComboBox);
            Controls.Add(TypeLabel);
            Controls.Add(IDLabel);
            Controls.Add(IDTextBox);
            Name = "CameraPanelBase";
            Size = new Size(441, 441);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label TypeLabel;
        private LaunchCamPlus.ExtraControls.ColourComboBox TypeComboBox;
        private LaunchCamPlus.ExtraControls.ColourTextBox IDTextBox;
    }
}
