using Godot;
using System.Collections.Generic;
using System.Text.Json;

public partial class LanguageManager : Node
{
	string languageAllText;
	JsonLang saveLangData;
	public JsonLang LoadItemData(string path){
		using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		if (FileAccess.GetOpenError() != Error.Ok){
			GD.PrintErr($"Failed to open file: {path}");
			return null;
		}

		languageAllText = file.GetAsText();
		
		try{
			JsonLang data = JsonSerializer.Deserialize<JsonLang>(languageAllText);//check can it work?
			return data;
		}catch (JsonException e){
			GD.PrintErr($"Failed to parse JSON: {e.Message}");
			return null;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		saveLangData = LoadItemData("res://Script/Language.json");//load language.json file
	}
	
	public string LoadText(string Cons){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		string OutText = "|" + Cons + "|empty";
		for (int index = 0;index < saveLangData.Langdata.Length; index++){
			if(saveLangData.Langdata[index].Content == Cons){
				if(gameManager.load_settings_language() == 1){
					OutText = saveLangData.Langdata[index].NA_text;
				}else if (gameManager.load_settings_language() == 2){
					OutText = saveLangData.Langdata[index].TW_text;
				}else{
					OutText = saveLangData.Langdata[index].JP_text;
				}
			}
		}
		return OutText;
	}
	
	public string FindKey(string Cons){
		var gameManager = GetNode<ConfigFileHandler>("/root/ConfigFileHandler");
		string OutText = "|" + Cons + "|empty";
		for (int index = 0;index < saveLangData.Langdata.Length; index++){
			if(saveLangData.Langdata[index].Content == Cons){
				if(gameManager.load_settings_language() == 1){
					OutText = saveLangData.Langdata[index].NA_text;
				}else if(gameManager.load_settings_language() == 2){
					OutText = saveLangData.Langdata[index].TW_text;
				}else{
					OutText = saveLangData.Langdata[index].JP_text;
				}
			}
		}
		return OutText;
	}
}
