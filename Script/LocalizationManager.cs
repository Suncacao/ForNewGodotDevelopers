using Godot;
using System;

public partial class LocalizationManager : Node
{
	public void RefreshAll(){
		EmitSignal(SignalName.LanguageChanged);
	}
	
	[Signal]
	public delegate void LanguageChangedEventHandler();
}
