using Godot;
using System;

public partial class ConfigFileHandler : Node2D
{
	Godot.Collections.Dictionary score_data = new Godot.Collections.Dictionary();
	Godot.ConfigFile config = new ConfigFile();
	string SETTING_FILE_PATH = "user://setting.ini";//set file name
	
	//SettingData↓
	float bgmVolume;
	float sfxVolume;
	bool isFullscreen;
	int languageNO;
	//SettingData↑
	
	public override void _Ready(){
		LoadSettings();
	}
	
	private void LoadSettings(){
		Error err = config.Load(SETTING_FILE_PATH);
		if(err == Error.FileNotFound){//if can't found file,create new file
			GD.Print("Empty Config!");
			config.SetValue("video","fullscreen",true);
			config.SetValue("video","Resolution",1920);
			config.SetValue("sound","BGMVolume",1f);
			config.SetValue("sound","SFXVolume",1f);
			config.SetValue("game","Language",1);
			config.Save(SETTING_FILE_PATH);//apply setting
		}else if(err != Error.Ok){//if it has some error!
			GD.Print("This Config can't used!");
			return;
		}
		
		foreach (String config_video in config.GetSections()){//take value from file
			switch(config_video){
				case "video":
					isFullscreen = (bool)config.GetValue(config_video, "fullscreen");
					if(isFullscreen == true){
						DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
					}else{
						DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
					}
					var testtext2 = (int)config.GetValue(config_video, "Resolution");
					if(testtext2 == 1366){
						DisplayServer.WindowSetSize(new Vector2I(1366, 768));
					}else if(testtext2 == 1280){
						DisplayServer.WindowSetSize(new Vector2I(1280, 720));
					}else{
						DisplayServer.WindowSetSize(new Vector2I(1920, 1080));
					}
				break;
				case "sound":
					bgmVolume = (float)config.GetValue(config_video, "BGMVolume");
					sfxVolume = (float)config.GetValue(config_video, "SFXVolume");
				break;
				case "game":
					languageNO = (int)config.GetValue(config_video, "Language");
				break;
			}
			
		}
	}
	
	public float load_settings_BGMVolum(){
		return bgmVolume;
	}
	
	public float load_settings_SFXVolum(){
		return sfxVolume;
	}
	
	public float edit_settings_editBGMVolum(int style){
		switch(style){
			case 0:
				if(bgmVolume <= 0.1f){
					bgmVolume = 0f;
				}else{
					bgmVolume -= 0.1f;
				}
			break;
			case 1:
				if(bgmVolume >= 0.9f){
					bgmVolume = 1f;
				}else{
					bgmVolume += 0.1f;
				}
			break;
		}
		config.SetValue("sound","BGMVolume",bgmVolume);
		config.Save(SETTING_FILE_PATH);
		return bgmVolume;
	}
	
	public float edit_settings_editSFXVolum(int style){
		switch(style){
			case 0:
				if(sfxVolume <= 0.1f){
					sfxVolume = 0f;
				}else{
					sfxVolume -= 0.1f;
				}
			break;
			case 1:
				if(sfxVolume >= 0.9f){
					sfxVolume = 1f;
				}else{
					sfxVolume += 0.1f;
				}
			break;
		}
		config.SetValue("sound","SFXVolume",sfxVolume);
		config.Save(SETTING_FILE_PATH);
		return sfxVolume;
	}
	
	public void edit_settings_fullscreen(){
		if(isFullscreen == true){
			isFullscreen = false;
			config.SetValue("video","fullscreen",isFullscreen);
		}else{
			isFullscreen = true;
			config.SetValue("video","fullscreen",isFullscreen);
		}
		config.Save(SETTING_FILE_PATH);
		LoadSettings();
		GD.Print("Useing!");
	}
	
	public void edit_settings_Resolution(int inputSize){
		switch(inputSize){
			case 1280:
				config.SetValue("video","Resolution",inputSize);
				config.Save(SETTING_FILE_PATH);
				LoadSettings();
			break;
			case 1366:
				config.SetValue("video","Resolution",inputSize);
				config.Save(SETTING_FILE_PATH);
				LoadSettings();
			break;
			case 1920:
				config.SetValue("video","Resolution",inputSize);
				config.Save(SETTING_FILE_PATH);
				LoadSettings();
			break;
		}
	}
	
	public int load_settings_language(){
		return languageNO;
	}
	
	public int edit_settings_language(){
		switch(languageNO){
			case 1:
				languageNO = 2;
			break;
			case 2:
				languageNO = 3;
			break;
			case 3:
				languageNO = 1;
			break;
		}
		return languageNO;
	}
}
