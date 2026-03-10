using Godot;
using System;

public partial class LoadLangforLable : Label
{
	[Export]
	public string loadKey { get; set; }
	private Label _myLabel;
	
	private LocalizationManager _localizationManager;
	
	public override void _Ready(){
		_localizationManager = GetNode<LocalizationManager>("/root/LocalizationManager");//take LocalizationManager
		if (_localizationManager != null){//if it found LocalizationManager,let work!
			_localizationManager.LanguageChanged += UpdateText;//added event
		}else{
			GD.PrintErr("can't found LocalizationManager!!!");
		}
		UpdateText();
	}
	
	protected void UpdateText(){
		var languageManager = GetNode<LanguageManager>("/root/LanguageManager");
		Text = languageManager.LoadText(loadKey);//take self's Label and load Text
	}
	
	public override void _ExitTree(){
		if (_localizationManager != null){
			_localizationManager.LanguageChanged -= UpdateText;//leave event
		}
	}
}
