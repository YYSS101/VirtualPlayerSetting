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
			radioButton1 = new RadioButton();
			radioButton2 = new RadioButton();
			radioButton3 = new RadioButton();
			radioButton4 = new RadioButton();
			radioButton5 = new RadioButton();
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) PbCutin  ).BeginInit();
			SuspendLayout();
			// 
			// PbIcon
			// 
			PbIcon.BorderStyle = BorderStyle.FixedSingle;
			PbIcon.Location = new Point( 12, 65 );
			PbIcon.Name = "PbIcon";
			PbIcon.Size = new Size( 128, 128 );
			PbIcon.SizeMode = PictureBoxSizeMode.Zoom;
			PbIcon.TabIndex = 0;
			PbIcon.TabStop = false;
			// 
			// BtnIconAdd
			// 
			BtnIconAdd.Location = new Point( 12, 199 );
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
			LbSounds.Location = new Point( 163, 92 );
			LbSounds.Name = "LbSounds";
			LbSounds.Size = new Size( 399, 184 );
			LbSounds.TabIndex = 2;
			LbSounds.DoubleClick += LbSounds_DoubleClick;
			// 
			// BtnSoundAdd
			// 
			BtnSoundAdd.Location = new Point( 163, 282 );
			BtnSoundAdd.Name = "BtnSoundAdd";
			BtnSoundAdd.Size = new Size( 75, 23 );
			BtnSoundAdd.TabIndex = 1;
			BtnSoundAdd.Text = "Add";
			BtnSoundAdd.UseVisualStyleBackColor = true;
			BtnSoundAdd.Click += BtnSoundAdd_Click;
			// 
			// BtnSoundDel
			// 
			BtnSoundDel.Location = new Point( 244, 282 );
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
			BtnSave.Location = new Point( 485, 384 );
			BtnSave.Name = "BtnSave";
			BtnSave.Size = new Size( 75, 23 );
			BtnSave.TabIndex = 1;
			BtnSave.Text = "Save";
			BtnSave.UseVisualStyleBackColor = true;
			BtnSave.Click += BtnSave_Click;
			// 
			// TbName
			// 
			TbName.Location = new Point( 163, 13 );
			TbName.Name = "TbName";
			TbName.Size = new Size( 400, 23 );
			TbName.TabIndex = 3;
			TbName.KeyPress += TbName_KeyPress;
			// 
			// BtnSoundPlay
			// 
			BtnSoundPlay.Location = new Point( 488, 282 );
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
			// radioButton1
			// 
			radioButton1.Appearance = Appearance.Button;
			radioButton1.Checked = true;
			radioButton1.Location = new Point( 163, 62 );
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size( 55, 24 );
			radioButton1.TabIndex = 5;
			radioButton1.TabStop = true;
			radioButton1.Text = "Startup";
			radioButton1.TextAlign = ContentAlignment.MiddleCenter;
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			radioButton2.Appearance = Appearance.Button;
			radioButton2.Location = new Point( 224, 62 );
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new Size( 55, 25 );
			radioButton2.TabIndex = 5;
			radioButton2.Text = "Attack";
			radioButton2.TextAlign = ContentAlignment.MiddleCenter;
			radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			radioButton3.Appearance = Appearance.Button;
			radioButton3.Location = new Point( 285, 62 );
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new Size( 55, 25 );
			radioButton3.TabIndex = 5;
			radioButton3.Text = "Skill";
			radioButton3.TextAlign = ContentAlignment.MiddleCenter;
			radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			radioButton4.Appearance = Appearance.Button;
			radioButton4.Location = new Point( 346, 62 );
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new Size( 55, 25 );
			radioButton4.TabIndex = 5;
			radioButton4.Text = "Die";
			radioButton4.TextAlign = ContentAlignment.MiddleCenter;
			radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			radioButton5.Appearance = Appearance.Button;
			radioButton5.Location = new Point( 407, 62 );
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new Size( 55, 25 );
			radioButton5.TabIndex = 5;
			radioButton5.Text = "Win";
			radioButton5.TextAlign = ContentAlignment.MiddleCenter;
			radioButton5.UseVisualStyleBackColor = true;
			// 
			// FrmMain
			// 
			AutoScaleDimensions = new SizeF( 7F, 15F );
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size( 573, 419 );
			Controls.Add( radioButton5 );
			Controls.Add( radioButton4 );
			Controls.Add( radioButton3 );
			Controls.Add( radioButton2 );
			Controls.Add( radioButton1 );
			Controls.Add( PbCutin );
			Controls.Add( TbName );
			Controls.Add( LbSounds );
			Controls.Add( BtnCutinDel );
			Controls.Add( BtnSoundDel );
			Controls.Add( BtnSave );
			Controls.Add( BtnLoad );
			Controls.Add( BtnSoundPlay );
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
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private RadioButton radioButton3;
		private RadioButton radioButton4;
		private RadioButton radioButton5;
	}
}