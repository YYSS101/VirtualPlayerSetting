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
			PbCutin = new PictureBox();
			BtnCutinAdd = new Button();
			BtnCutinDel = new Button();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) PbCutin  ).BeginInit();
			SuspendLayout();
			// 
			// PbIcon
			// 
			PbIcon.BorderStyle = BorderStyle.FixedSingle;
			PbIcon.Location = new Point( 12, 91 );
			PbIcon.Name = "PbIcon";
			PbIcon.Size = new Size( 128, 128 );
			PbIcon.SizeMode = PictureBoxSizeMode.Zoom;
			PbIcon.TabIndex = 0;
			PbIcon.TabStop = false;
			// 
			// BtnIconAdd
			// 
			BtnIconAdd.Location = new Point( 12, 225 );
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
			LbSounds.Location = new Point( 163, 141 );
			LbSounds.Name = "LbSounds";
			LbSounds.Size = new Size( 399, 184 );
			LbSounds.TabIndex = 2;
			LbSounds.DoubleClick += LbSounds_DoubleClick;
			// 
			// BtnSoundAdd
			// 
			BtnSoundAdd.Location = new Point( 163, 331 );
			BtnSoundAdd.Name = "BtnSoundAdd";
			BtnSoundAdd.Size = new Size( 75, 23 );
			BtnSoundAdd.TabIndex = 1;
			BtnSoundAdd.Text = "Add";
			BtnSoundAdd.UseVisualStyleBackColor = true;
			BtnSoundAdd.Click += BtnSoundAdd_Click;
			// 
			// BtnSoundDel
			// 
			BtnSoundDel.Location = new Point( 244, 331 );
			BtnSoundDel.Name = "BtnSoundDel";
			BtnSoundDel.Size = new Size( 47, 23 );
			BtnSoundDel.TabIndex = 1;
			BtnSoundDel.Text = "Del";
			BtnSoundDel.UseVisualStyleBackColor = true;
			BtnSoundDel.Click += BtnSoundDel_Click;
			// 
			// BtnLoad
			// 
			BtnLoad.Location = new Point( 12, 12 );
			BtnLoad.Name = "BtnLoad";
			BtnLoad.Size = new Size( 128, 23 );
			BtnLoad.TabIndex = 1;
			BtnLoad.Text = "Load";
			BtnLoad.UseVisualStyleBackColor = true;
			BtnLoad.Click += BtnLoad_Click;
			// 
			// BtnSave
			// 
			BtnSave.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Right  ;
			BtnSave.Location = new Point( 488, 413 );
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
			TbName.Size = new Size( 392, 23 );
			TbName.TabIndex = 3;
			TbName.KeyPress += TbName_KeyPress;
			// 
			// BtnSoundPlay
			// 
			BtnSoundPlay.Location = new Point( 488, 331 );
			BtnSoundPlay.Name = "BtnSoundPlay";
			BtnSoundPlay.Size = new Size( 75, 23 );
			BtnSoundPlay.TabIndex = 1;
			BtnSoundPlay.Text = "Play";
			BtnSoundPlay.UseVisualStyleBackColor = true;
			BtnSoundPlay.Click += BtnSoundPlay_Click;
			// 
			// PbCutin
			// 
			PbCutin.BorderStyle = BorderStyle.FixedSingle;
			PbCutin.Location = new Point( 12, 254 );
			PbCutin.Name = "PbCutin";
			PbCutin.Size = new Size( 128, 128 );
			PbCutin.SizeMode = PictureBoxSizeMode.Zoom;
			PbCutin.TabIndex = 4;
			PbCutin.TabStop = false;
			// 
			// BtnCutinAdd
			// 
			BtnCutinAdd.Location = new Point( 12, 388 );
			BtnCutinAdd.Name = "BtnCutinAdd";
			BtnCutinAdd.Size = new Size( 75, 23 );
			BtnCutinAdd.TabIndex = 1;
			BtnCutinAdd.Text = "Add";
			BtnCutinAdd.UseVisualStyleBackColor = true;
			BtnCutinAdd.Click += BtnCutinAdd_Click;
			// 
			// BtnCutinDel
			// 
			BtnCutinDel.Location = new Point( 93, 388 );
			BtnCutinDel.Name = "BtnCutinDel";
			BtnCutinDel.Size = new Size( 47, 23 );
			BtnCutinDel.TabIndex = 1;
			BtnCutinDel.Text = "Del";
			BtnCutinDel.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.BackColor = Color.LightBlue;
			button1.Location = new Point( 163, 112 );
			button1.Name = "button1";
			button1.Size = new Size( 75, 23 );
			button1.TabIndex = 1;
			button1.Text = "Startup";
			button1.UseVisualStyleBackColor = false;
			button1.Click += BtnSoundAdd_Click;
			// 
			// button2
			// 
			button2.BackColor = Color.LightBlue;
			button2.Location = new Point( 244, 112 );
			button2.Name = "button2";
			button2.Size = new Size( 75, 23 );
			button2.TabIndex = 1;
			button2.Text = "Attack";
			button2.UseVisualStyleBackColor = false;
			button2.Click += BtnSoundAdd_Click;
			// 
			// button3
			// 
			button3.BackColor = Color.LightBlue;
			button3.Location = new Point( 325, 112 );
			button3.Name = "button3";
			button3.Size = new Size( 75, 23 );
			button3.TabIndex = 1;
			button3.Text = "Skill";
			button3.UseVisualStyleBackColor = false;
			button3.Click += BtnSoundAdd_Click;
			// 
			// button4
			// 
			button4.BackColor = Color.LightBlue;
			button4.Location = new Point( 406, 112 );
			button4.Name = "button4";
			button4.Size = new Size( 75, 23 );
			button4.TabIndex = 1;
			button4.Text = "Die";
			button4.UseVisualStyleBackColor = false;
			button4.Click += BtnSoundAdd_Click;
			// 
			// button5
			// 
			button5.BackColor = Color.LightBlue;
			button5.Location = new Point( 487, 112 );
			button5.Name = "button5";
			button5.Size = new Size( 75, 23 );
			button5.TabIndex = 1;
			button5.Text = "Winner";
			button5.UseVisualStyleBackColor = false;
			button5.Click += BtnSoundAdd_Click;
			// 
			// FrmMain
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 575, 448 );
			Controls.Add( PbCutin );
			Controls.Add( TbName );
			Controls.Add( LbSounds );
			Controls.Add( BtnCutinDel );
			Controls.Add( BtnSoundDel );
			Controls.Add( BtnSave );
			Controls.Add( BtnLoad );
			Controls.Add( BtnSoundPlay );
			Controls.Add( button5 );
			Controls.Add( button4 );
			Controls.Add( button3 );
			Controls.Add( button2 );
			Controls.Add( button1 );
			Controls.Add( BtnSoundAdd );
			Controls.Add( BtnCutinAdd );
			Controls.Add( BtnIconAdd );
			Controls.Add( PbIcon );
			Name = "FrmMain";
			Text = "Form1";
			FormClosed += FrmMain_FormClosed;
			Load += Form1_Load;
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).EndInit();
			( (System.ComponentModel.ISupportInitialize) PbCutin  ).EndInit();
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
		private PictureBox PbCutin;
		private Button BtnCutinAdd;
		private Button BtnCutinDel;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
	}
}