namespace VirtualPlayerSetting
{
	partial class FrmMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			PbIcon = new PictureBox();
			BtnIconAdd = new Button();
			LbSounds = new ListBox();
			BtnSoundAdd = new Button();
			BtnSoundDel = new Button();
			BtnLoad = new Button();
			BtnSave = new Button();
			TbName = new TextBox();
			BtnSoundPlay = new Button();
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).BeginInit();
			SuspendLayout();
			// 
			// PbIcon
			// 
			PbIcon.BorderStyle = BorderStyle.FixedSingle;
			PbIcon.Location = new Point( 38, 119 );
			PbIcon.Name = "PbIcon";
			PbIcon.Size = new Size( 128, 128 );
			PbIcon.TabIndex = 0;
			PbIcon.TabStop = false;
			// 
			// BtnIconAdd
			// 
			BtnIconAdd.Location = new Point( 38, 253 );
			BtnIconAdd.Name = "BtnIconAdd";
			BtnIconAdd.Size = new Size( 75, 23 );
			BtnIconAdd.TabIndex = 1;
			BtnIconAdd.Text = "Add";
			BtnIconAdd.UseVisualStyleBackColor = true;
			BtnIconAdd.Click += BtnIconAdd_Click;
			// 
			// LbSounds
			// 
			LbSounds.FormattingEnabled = true;
			LbSounds.ItemHeight = 15;
			LbSounds.Location = new Point( 268, 82 );
			LbSounds.Name = "LbSounds";
			LbSounds.Size = new Size( 174, 124 );
			LbSounds.TabIndex = 2;
			LbSounds.DoubleClick += LbSounds_DoubleClick;
			// 
			// BtnSoundAdd
			// 
			BtnSoundAdd.Location = new Point( 268, 212 );
			BtnSoundAdd.Name = "BtnSoundAdd";
			BtnSoundAdd.Size = new Size( 75, 23 );
			BtnSoundAdd.TabIndex = 1;
			BtnSoundAdd.Text = "Add";
			BtnSoundAdd.UseVisualStyleBackColor = true;
			BtnSoundAdd.Click += BtnSoundAdd_Click;
			// 
			// BtnSoundDel
			// 
			BtnSoundDel.Location = new Point( 349, 212 );
			BtnSoundDel.Name = "BtnSoundDel";
			BtnSoundDel.Size = new Size( 75, 23 );
			BtnSoundDel.TabIndex = 1;
			BtnSoundDel.Text = "Del";
			BtnSoundDel.UseVisualStyleBackColor = true;
			BtnSoundDel.Click += BtnSoundDel_Click;
			// 
			// BtnLoad
			// 
			BtnLoad.Location = new Point( 12, 12 );
			BtnLoad.Name = "BtnLoad";
			BtnLoad.Size = new Size( 75, 23 );
			BtnLoad.TabIndex = 1;
			BtnLoad.Text = "Load";
			BtnLoad.UseVisualStyleBackColor = true;
			BtnLoad.Click += BtnLoad_Click;
			// 
			// BtnSave
			// 
			BtnSave.Location = new Point( 713, 415 );
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size( 75, 23 );
			BtnSave.TabIndex = 1;
			BtnSave.Text = "Save";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// TbName
			// 
			TbName.Location = new Point( 12, 62 );
			TbName.Name = "TbName";
			TbName.Size = new Size( 201, 23 );
			TbName.TabIndex = 3;
			TbName.KeyPress += TbName_KeyPress;
			// 
			// BtnSoundPlay
			// 
			BtnSoundPlay.Location = new Point( 268, 241 );
			BtnSoundPlay.Name = "BtnSoundPlay";
			BtnSoundPlay.Size = new Size( 75, 23 );
			BtnSoundPlay.TabIndex = 1;
			BtnSoundPlay.Text = "Play";
			BtnSoundPlay.UseVisualStyleBackColor = true;
			BtnSoundPlay.Click += BtnSoundPlay_Click;
			// 
			// FrmMain
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 800, 450 );
			Controls.Add( TbName );
			Controls.Add( LbSounds );
			Controls.Add( BtnSoundDel );
			Controls.Add( BtnSave );
			Controls.Add( BtnLoad );
			Controls.Add( BtnSoundPlay );
			Controls.Add( BtnSoundAdd );
			Controls.Add( BtnIconAdd );
			Controls.Add( PbIcon );
			Name = "FrmMain";
			Text = "Form1";
			FormClosed += FrmMain_FormClosed;
			Load += Form1_Load;
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).EndInit();
			ResumeLayout( false );
			PerformLayout();
		}

		#endregion

		private PictureBox PbIcon;
		private Button BtnIconAdd;
		private ListBox LbSounds;
		private Button BtnSoundAdd;
		private Button BtnSoundDel;
		private Button BtnLoad;
		private Button BtnSave;
		private TextBox TbName;
		private Button BtnSoundPlay;
	}
}