using Godot;
using NathanHoad;// from SoundManager
using System;

public partial class StartScene : Node2D
{
	[Export]
  	public AudioStream MusicSample = null;//set BGM file,can't work .wav
	[Export]
  	public AudioStream SoundbtnmoveSample = null;//set SFXbtnmove
	[Export]
  	public AudioStream SoundseletedSample = null;//set SFXseleted
	
	Button SMPlayBGM;
	Button SMPauseBGM;
	Button SMResumeBGM;
	Button stopMusicButton;
	
	Button bgmAddPower;
	Button bgmLessPower;
	Label bgmVolumeLabel;
	Button sfxAddPower;
	Button sfxLessPower;
	Label sfxVolumeLabel;
	
	Button languageChange;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		
		var highwin = this.GetNode<Button>("DemoCanvasLayer/Control_LeftBOT/1920X1080");
		highwin.Connect("pressed",new Callable(this,"ResolutionLV1"));
		var midwin = this.GetNode<Button>("DemoCanvasLayer/Control_LeftBOT/1366X768");
		midwin.Connect("pressed",new Callable(this,"ResolutionLV2"));
		var littlewin = this.GetNode<Button>("DemoCanvasLayer/Control_LeftBOT/1280X720");
		littlewin.Connect("pressed",new Callable(this,"ResolutionLV3"));
		var fullBTN = this.GetNode<Button>("DemoCanvasLayer/Control_LeftBOT/ChangeFullScreen");
		fullBTN.Connect("pressed",new Callable(this,"FullScreenEvent"));
		
		SoundManager.SetMusicVolume(gameManager.load_settings_BGMVolum());
		GD.Print("SMBGM:" + SoundManager.GetMusicVolume());
		bgmVolumeLabel = GetNode<Label>("DemoCanvasLayer/Control_RightTOP/BGMLayOut/Value");
		SoundManager.SetSoundVolume(gameManager.load_settings_SFXVolum());
		GD.Print("SMSFX:" + SoundManager.GetSoundVolume());
		sfxVolumeLabel = GetNode<Label>("DemoCanvasLayer/Control_RightTOP/SFXLayOut/Value");
		bgmVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_BGMVolum() * 100)}";
		sfxVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_SFXVolum() * 100)}";
		
		SoundManager.PlayMusic(MusicSample);//play BGM
		
		SMPlayBGM = GetNode<Button>("DemoCanvasLayer/Control_RightBOT/SoundTestControl/PlayBGM");
		SMPlayBGM.Pressed += () =>
		{
		  	SoundManager.PlayMusic(MusicSample);
			SoundManager.PlaySound(SoundseletedSample);
		};
		SMPauseBGM = GetNode<Button>("DemoCanvasLayer/Control_RightBOT/SoundTestControl/PauseBGM");
		SMPauseBGM.Pressed += () =>
		{
		  	SoundManager.PauseMusic();
			SoundManager.PlaySound(SoundseletedSample);
		};
		
		SMResumeBGM = GetNode<Button>("DemoCanvasLayer/Control_RightBOT/SoundTestControl/ResumeBGM");
		SMResumeBGM.Pressed += () =>
		{
		  	SoundManager.ResumeMusic();
			SoundManager.PlaySound(SoundseletedSample);
		};
		
		stopMusicButton = GetNode<Button>("DemoCanvasLayer/Control_RightBOT/SoundTestControl/StopBGM");
		stopMusicButton.Pressed += () =>
		{
		  	SoundManager.StopMusic();
			SoundManager.PlaySound(SoundseletedSample);
		};
		
		bgmAddPower = GetNode<Button>("DemoCanvasLayer/Control_RightTOP/BGMLayOut/AddPower");
		bgmAddPower.Pressed += () =>
		{
			SoundManager.SetMusicVolume(gameManager.edit_settings_editBGMVolum(1));
			bgmVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_BGMVolum() * 100)}";
			SoundManager.PlaySound(SoundseletedSample);
		};
		bgmLessPower = GetNode<Button>("DemoCanvasLayer/Control_RightTOP/BGMLayOut/LessPower");
		bgmLessPower.Pressed += () =>
		{
			SoundManager.SetMusicVolume(gameManager.edit_settings_editBGMVolum(0));
			bgmVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_BGMVolum() * 100)}";
			SoundManager.PlaySound(SoundseletedSample);
		};
		
		sfxAddPower = GetNode<Button>("DemoCanvasLayer/Control_RightTOP/SFXLayOut/AddPower");
		sfxAddPower.Pressed += () =>
		{
			SoundManager.SetSoundVolume(gameManager.edit_settings_editSFXVolum(1));
			sfxVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_SFXVolum() * 100)}";
			SoundManager.PlaySound(SoundseletedSample);
		};
		sfxLessPower = GetNode<Button>("DemoCanvasLayer/Control_RightTOP/SFXLayOut/LessPower");
		sfxLessPower.Pressed += () =>
		{
			SoundManager.SetSoundVolume(gameManager.edit_settings_editSFXVolum(0));
			sfxVolumeLabel.Text = $"{Math.Round(gameManager.load_settings_SFXVolum() * 100)}";
			SoundManager.PlaySound(SoundseletedSample);
		};
		
		languageChange = GetNode<Button>("DemoCanvasLayer/Control_LeftTOP/ChangeLanguage");
		languageChange.Pressed += () =>
		{
			gameManager.edit_settings_language();
			var lm = GetNode<LocalizationManager>("/root/LocalizationManager");
			lm.RefreshAll();//Refresh all Node if they use LoadLangforLable.cs
			SoundManager.PlaySound(SoundseletedSample);
		};
	}
	
	public void ResolutionLV1(){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		gameManager.edit_settings_Resolution(1920);
		SoundManager.PlaySound(SoundseletedSample);
	}
	public void ResolutionLV2(){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		gameManager.edit_settings_Resolution(1366);
		SoundManager.PlaySound(SoundseletedSample);
	}
	public void ResolutionLV3(){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		gameManager.edit_settings_Resolution(1280);
		SoundManager.PlaySound(SoundseletedSample);
	}
	public void FullScreenEvent(){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		gameManager.edit_settings_fullscreen();
		SoundManager.PlaySound(SoundseletedSample);
	}
	
	public void MouseEnterEvent(){
		SoundManager.PlaySound(SoundbtnmoveSample);
	}
}
