namespace VirtualPlayerSetting
{
	partial class FrmSelectDir
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			LbPlayer = new ListBox();
			label1 = new Label();
			BtnDelete = new Button();
			BtnExport = new Button();
			BtnImport = new Button();
			SuspendLayout();
			// 
			// LbPlayer
			// 
			LbPlayer.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right  ;
			LbPlayer.FormattingEnabled = true;
			LbPlayer.ItemHeight = 15;
			LbPlayer.Location = new Point( 12, 27 );
			LbPlayer.Name = "LbPlayer";
			LbPlayer.SelectionMode = SelectionMode.MultiExtended;
			LbPlayer.Size = new Size( 368, 304 );
			LbPlayer.TabIndex = 0;
			LbPlayer.DoubleClick += LbPlayer_DoubleClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point( 12, 9 );
			label1.Name = "label1";
			label1.Size = new Size( 114, 15 );
			label1.TabIndex = 2;
			label1.Text = "Double-click to load";
			// 
			// BtnDelete
			// 
			BtnDelete.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Right  ;
			BtnDelete.BackColor = Color.SandyBrown;
			BtnDelete.Location = new Point( 336, 347 );
			BtnDelete.Name = "BtnDelete";
			BtnDelete.Size = new Size( 44, 25 );
			BtnDelete.TabIndex = 1;
			BtnDelete.Text = "Del";
			BtnDelete.UseVisualStyleBackColor = false;
			BtnDelete.Click += BtnDelete_Click;
			// 
			// BtnExport
			// 
			BtnExport.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Left  ;
			BtnExport.Location = new Point( 12, 341 );
			BtnExport.Name = "BtnExport";
			BtnExport.Size = new Size( 59, 31 );
			BtnExport.TabIndex = 1;
			BtnExport.Text = "Export";
			BtnExport.UseVisualStyleBackColor = true;
			BtnExport.Click += BtnExport_Click;
			// 
			// BtnImport
			// 
			BtnImport.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Left  ;
			BtnImport.Location = new Point( 77, 341 );
			BtnImport.Name = "BtnImport";
			BtnImport.Size = new Size( 59, 31 );
			BtnImport.TabIndex = 1;
			BtnImport.Text = "Import";
			BtnImport.UseVisualStyleBackColor = true;
			BtnImport.Click += BtnImport_Click;
			// 
			// FrmSelectDir
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 392, 384 );
			Controls.Add( label1 );
			Controls.Add( BtnDelete );
			Controls.Add( BtnImport );
			Controls.Add( BtnExport );
			Controls.Add( LbPlayer );
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FrmSelectDir";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Select";
			Load += FrmSelectDir_Load;
			ResumeLayout( false );
			PerformLayout();
		}

		#endregion

		private ListBox LbPlayer;
		private Label label1;
		private Button BtnDelete;
		private Button BtnExport;
		private Button BtnImport;
	}
}