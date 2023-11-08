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
			BtnLoad = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// LbPlayer
			// 
			LbPlayer.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right  ;
			LbPlayer.FormattingEnabled = true;
			LbPlayer.ItemHeight = 15;
			LbPlayer.Location = new Point( 12, 27 );
			LbPlayer.Name = "LbPlayer";
			LbPlayer.Size = new Size( 368, 304 );
			LbPlayer.TabIndex = 0;
			LbPlayer.DoubleClick += LbPlayer_DoubleClick;
			// 
			// BtnLoad
			// 
			BtnLoad.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Left  ;
			BtnLoad.Location = new Point( 12, 341 );
			BtnLoad.Name = "BtnLoad";
			BtnLoad.Size = new Size( 105, 31 );
			BtnLoad.TabIndex = 1;
			BtnLoad.Text = "Load External";
			BtnLoad.UseVisualStyleBackColor = true;
			BtnLoad.Click += BtnLoad_Click;
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
			// FrmSelectDir
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 392, 384 );
			Controls.Add( label1 );
			Controls.Add( BtnLoad );
			Controls.Add( LbPlayer );
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FrmSelectDir";
			Text = "FrmSelectDir";
			Load += FrmSelectDir_Load;
			ResumeLayout( false );
			PerformLayout();
		}

		#endregion

		private ListBox LbPlayer;
		private Button BtnLoad;
		private Label label1;
	}
}