﻿namespace VirtualPlayerSetting
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
			PbIcon =  new PictureBox() ;
			BtnIconAdd =  new Button() ;
			LbSounds =  new ListBox() ;
			BtnSoundAdd =  new Button() ;
			BtnSoundDel =  new Button() ;
			BtnLoad =  new Button() ;
			BtnSave =  new Button() ;
			TbName =  new TextBox() ;
			BtnSoundPlay =  new Button() ;
			PbCutin =  new PictureBox() ;
			BtnCutinAdd =  new Button() ;
			BtnCutinDel =  new Button() ;
			Rb1 =  new RadioButton() ;
			Rb2 =  new RadioButton() ;
			Rb3 =  new RadioButton() ;
			Rb4 =  new RadioButton() ;
			Rb5 =  new RadioButton() ;
			BtnNew =  new Button() ;
			BtnSoundStop =  new Button() ;
			label1 =  new Label() ;
			label2 =  new Label() ;
			label3 =  new Label() ;
			label4 =  new Label() ;
			label5 =  new Label() ;
			( (System.ComponentModel.ISupportInitialize) PbIcon  ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) PbCutin  ).BeginInit();
			SuspendLayout();
			// 
			// PbIcon
			// 
			PbIcon.BorderStyle =  BorderStyle.FixedSingle ;
			PbIcon.Location =  new Point( 12, 92 ) ;
			PbIcon.Name =  "PbIcon" ;
			PbIcon.Size =  new Size( 128, 128 ) ;
			PbIcon.SizeMode =  PictureBoxSizeMode.Zoom ;
			PbIcon.TabIndex =  0 ;
			PbIcon.TabStop =  false ;
			// 
			// BtnIconAdd
			// 
			BtnIconAdd.Location =  new Point( 12, 226 ) ;
			BtnIconAdd.Name =  "BtnIconAdd" ;
			BtnIconAdd.Size =  new Size( 75, 23 ) ;
			BtnIconAdd.TabIndex =  1 ;
			BtnIconAdd.Text =  "Add" ;
			BtnIconAdd.UseVisualStyleBackColor =  true ;
			BtnIconAdd.Click +=  BtnIconAdd_Click ;
			// 
			// LbSounds
			// 
			LbSounds.FormattingEnabled =  true ;
			LbSounds.ItemHeight =  15 ;
			LbSounds.Location =  new Point( 163, 122 ) ;
			LbSounds.Name =  "LbSounds" ;
			LbSounds.SelectionMode =  SelectionMode.MultiExtended ;
			LbSounds.Size =  new Size( 399, 244 ) ;
			LbSounds.TabIndex =  2 ;
			LbSounds.DoubleClick +=  LbSounds_DoubleClick ;
			// 
			// BtnSoundAdd
			// 
			BtnSoundAdd.Location =  new Point( 163, 372 ) ;
			BtnSoundAdd.Name =  "BtnSoundAdd" ;
			BtnSoundAdd.Size =  new Size( 75, 23 ) ;
			BtnSoundAdd.TabIndex =  1 ;
			BtnSoundAdd.Text =  "Add" ;
			BtnSoundAdd.UseVisualStyleBackColor =  true ;
			BtnSoundAdd.Click +=  BtnSoundAdd_Click ;
			// 
			// BtnSoundDel
			// 
			BtnSoundDel.Location =  new Point( 244, 372 ) ;
			BtnSoundDel.Name =  "BtnSoundDel" ;
			BtnSoundDel.Size =  new Size( 47, 23 ) ;
			BtnSoundDel.TabIndex =  1 ;
			BtnSoundDel.Text =  "Del" ;
			BtnSoundDel.UseVisualStyleBackColor =  true ;
			BtnSoundDel.Click +=  BtnSoundDel_Click ;
			// 
			// BtnLoad
			// 
			BtnLoad.Location =  new Point( 12, 36 ) ;
			BtnLoad.Name =  "BtnLoad" ;
			BtnLoad.Size =  new Size( 128, 23 ) ;
			BtnLoad.TabIndex =  1 ;
			BtnLoad.Text =  "Load" ;
			BtnLoad.UseVisualStyleBackColor =  true ;
			BtnLoad.Click +=  BtnLoad_Click ;
			// 
			// BtnSave
			// 
			BtnSave.Anchor =    AnchorStyles.Bottom  |  AnchorStyles.Right   ;
			BtnSave.Location =  new Point( 488, 416 ) ;
			BtnSave.Name =  "BtnSave" ;
			BtnSave.Size =  new Size( 75, 23 ) ;
			BtnSave.TabIndex =  1 ;
			BtnSave.Text =  "Save" ;
			BtnSave.UseVisualStyleBackColor =  true ;
			BtnSave.Click +=  BtnSave_Click ;
			// 
			// TbName
			// 
			TbName.ImeMode =  ImeMode.Disable ;
			TbName.Location =  new Point( 204, 12 ) ;
			TbName.Name =  "TbName" ;
			TbName.Size =  new Size( 357, 23 ) ;
			TbName.TabIndex =  3 ;
			TbName.KeyPress +=  TbName_KeyPress ;
			// 
			// BtnSoundPlay
			// 
			BtnSoundPlay.Location =  new Point( 463, 372 ) ;
			BtnSoundPlay.Name =  "BtnSoundPlay" ;
			BtnSoundPlay.Size =  new Size( 47, 23 ) ;
			BtnSoundPlay.TabIndex =  1 ;
			BtnSoundPlay.Text =  "Play" ;
			BtnSoundPlay.UseVisualStyleBackColor =  true ;
			BtnSoundPlay.Click +=  BtnSoundPlay_Click ;
			// 
			// PbCutin
			// 
			PbCutin.BorderStyle =  BorderStyle.FixedSingle ;
			PbCutin.Location =  new Point( 12, 281 ) ;
			PbCutin.Name =  "PbCutin" ;
			PbCutin.Size =  new Size( 128, 128 ) ;
			PbCutin.SizeMode =  PictureBoxSizeMode.Zoom ;
			PbCutin.TabIndex =  4 ;
			PbCutin.TabStop =  false ;
			// 
			// BtnCutinAdd
			// 
			BtnCutinAdd.Location =  new Point( 12, 415 ) ;
			BtnCutinAdd.Name =  "BtnCutinAdd" ;
			BtnCutinAdd.Size =  new Size( 75, 23 ) ;
			BtnCutinAdd.TabIndex =  1 ;
			BtnCutinAdd.Text =  "Add" ;
			BtnCutinAdd.UseVisualStyleBackColor =  true ;
			BtnCutinAdd.Click +=  BtnCutinAdd_Click ;
			// 
			// BtnCutinDel
			// 
			BtnCutinDel.Location =  new Point( 93, 415 ) ;
			BtnCutinDel.Name =  "BtnCutinDel" ;
			BtnCutinDel.Size =  new Size( 47, 23 ) ;
			BtnCutinDel.TabIndex =  1 ;
			BtnCutinDel.Text =  "Del" ;
			BtnCutinDel.UseVisualStyleBackColor =  true ;
			BtnCutinDel.Click +=  BtnCutinDel_Click ;
			// 
			// Rb1
			// 
			Rb1.Appearance =  Appearance.Button ;
			Rb1.Checked =  true ;
			Rb1.Location =  new Point( 163, 92 ) ;
			Rb1.Name =  "Rb1" ;
			Rb1.Size =  new Size( 55, 24 ) ;
			Rb1.TabIndex =  5 ;
			Rb1.TabStop =  true ;
			Rb1.Text =  "Startup" ;
			Rb1.TextAlign =  ContentAlignment.MiddleCenter ;
			Rb1.UseVisualStyleBackColor =  true ;
			Rb1.CheckedChanged +=  SoundSelect_CheckedChanged ;
			// 
			// Rb2
			// 
			Rb2.Appearance =  Appearance.Button ;
			Rb2.Location =  new Point( 224, 92 ) ;
			Rb2.Name =  "Rb2" ;
			Rb2.Size =  new Size( 55, 25 ) ;
			Rb2.TabIndex =  5 ;
			Rb2.Text =  "Attack" ;
			Rb2.TextAlign =  ContentAlignment.MiddleCenter ;
			Rb2.UseVisualStyleBackColor =  true ;
			Rb2.CheckedChanged +=  SoundSelect_CheckedChanged ;
			// 
			// Rb3
			// 
			Rb3.Appearance =  Appearance.Button ;
			Rb3.Location =  new Point( 285, 92 ) ;
			Rb3.Name =  "Rb3" ;
			Rb3.Size =  new Size( 55, 25 ) ;
			Rb3.TabIndex =  5 ;
			Rb3.Text =  "Skill" ;
			Rb3.TextAlign =  ContentAlignment.MiddleCenter ;
			Rb3.UseVisualStyleBackColor =  true ;
			Rb3.CheckedChanged +=  SoundSelect_CheckedChanged ;
			// 
			// Rb4
			// 
			Rb4.Appearance =  Appearance.Button ;
			Rb4.Location =  new Point( 346, 92 ) ;
			Rb4.Name =  "Rb4" ;
			Rb4.Size =  new Size( 55, 25 ) ;
			Rb4.TabIndex =  5 ;
			Rb4.Text =  "Die" ;
			Rb4.TextAlign =  ContentAlignment.MiddleCenter ;
			Rb4.UseVisualStyleBackColor =  true ;
			Rb4.CheckedChanged +=  SoundSelect_CheckedChanged ;
			// 
			// Rb5
			// 
			Rb5.Appearance =  Appearance.Button ;
			Rb5.Location =  new Point( 407, 92 ) ;
			Rb5.Name =  "Rb5" ;
			Rb5.Size =  new Size( 55, 25 ) ;
			Rb5.TabIndex =  5 ;
			Rb5.Text =  "Win" ;
			Rb5.TextAlign =  ContentAlignment.MiddleCenter ;
			Rb5.UseVisualStyleBackColor =  true ;
			Rb5.CheckedChanged +=  SoundSelect_CheckedChanged ;
			// 
			// BtnNew
			// 
			BtnNew.Location =  new Point( 12, 12 ) ;
			BtnNew.Name =  "BtnNew" ;
			BtnNew.Size =  new Size( 128, 23 ) ;
			BtnNew.TabIndex =  1 ;
			BtnNew.Text =  "New" ;
			BtnNew.UseVisualStyleBackColor =  true ;
			BtnNew.Click +=  BtnNew_Click ;
			// 
			// BtnSoundStop
			// 
			BtnSoundStop.Location =  new Point( 516, 372 ) ;
			BtnSoundStop.Name =  "BtnSoundStop" ;
			BtnSoundStop.Size =  new Size( 47, 23 ) ;
			BtnSoundStop.TabIndex =  1 ;
			BtnSoundStop.Text =  "Stop" ;
			BtnSoundStop.UseVisualStyleBackColor =  true ;
			BtnSoundStop.Click +=  BtnSoundStop_Click ;
			// 
			// label1
			// 
			label1.AutoSize =  true ;
			label1.Location =  new Point( 160, 15 ) ;
			label1.Name =  "label1" ;
			label1.Size =  new Size( 38, 15 ) ;
			label1.TabIndex =  6 ;
			label1.Text =  "Name" ;
			// 
			// label2
			// 
			label2.AutoSize =  true ;
			label2.Location =  new Point( 12, 72 ) ;
			label2.Name =  "label2" ;
			label2.Size =  new Size( 30, 15 ) ;
			label2.TabIndex =  6 ;
			label2.Text =  "Icon" ;
			// 
			// label3
			// 
			label3.AutoSize =  true ;
			label3.Location =  new Point( 12, 263 ) ;
			label3.Name =  "label3" ;
			label3.Size =  new Size( 35, 15 ) ;
			label3.TabIndex =  6 ;
			label3.Text =  "Cutin" ;
			// 
			// label4
			// 
			label4.AutoSize =  true ;
			label4.Location =  new Point( 163, 72 ) ;
			label4.Name =  "label4" ;
			label4.Size =  new Size( 41, 15 ) ;
			label4.TabIndex =  6 ;
			label4.Text =  "Sound" ;
			// 
			// label5
			// 
			label5.AutoSize =  true ;
			label5.Location =  new Point( 204, 40 ) ;
			label5.Name =  "label5" ;
			label5.Size =  new Size( 159, 15 ) ;
			label5.TabIndex =  6 ;
			label5.Text =  "- Alphabets or numbers only." ;
			// 
			// FrmMain
			// 
			AutoScaleDimensions =  new SizeF( 7F, 15F ) ;
			AutoScaleMode =  AutoScaleMode.Font ;
			ClientSize =  new Size( 573, 451 ) ;
			Controls.Add( label3 );
			Controls.Add( label2 );
			Controls.Add( label4 );
			Controls.Add( label5 );
			Controls.Add( label1 );
			Controls.Add( Rb5 );
			Controls.Add( Rb4 );
			Controls.Add( Rb3 );
			Controls.Add( Rb2 );
			Controls.Add( Rb1 );
			Controls.Add( PbCutin );
			Controls.Add( TbName );
			Controls.Add( LbSounds );
			Controls.Add( BtnCutinDel );
			Controls.Add( BtnSoundDel );
			Controls.Add( BtnSave );
			Controls.Add( BtnNew );
			Controls.Add( BtnLoad );
			Controls.Add( BtnSoundStop );
			Controls.Add( BtnSoundPlay );
			Controls.Add( BtnSoundAdd );
			Controls.Add( BtnCutinAdd );
			Controls.Add( BtnIconAdd );
			Controls.Add( PbIcon );
			FormBorderStyle =  FormBorderStyle.FixedSingle ;
			MaximizeBox =  false ;
			MinimizeBox =  false ;
			Name =  "FrmMain" ;
			StartPosition =  FormStartPosition.CenterScreen ;
			Text =  "VPS" ;
			FormClosed +=  FrmMain_FormClosed ;
			Load +=  Form1_Load ;
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
		private RadioButton Rb1;
		private RadioButton Rb2;
		private RadioButton Rb3;
		private RadioButton Rb4;
		private RadioButton Rb5;
		private Button BtnNew;
		private Button BtnSoundStop;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
	}
}