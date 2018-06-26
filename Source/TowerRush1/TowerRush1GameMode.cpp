// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "TowerRush1GameMode.h"
#include "TowerRush1HUD.h"
#include "TowerRush1Character.h"
#include "UObject/ConstructorHelpers.h"

ATowerRush1GameMode::ATowerRush1GameMode()
	: Super()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnClassFinder(TEXT("/Game/FirstPersonCPP/Blueprints/FirstPersonCharacter"));
	DefaultPawnClass = PlayerPawnClassFinder.Class;

	// use our custom HUD class
	HUDClass = ATowerRush1HUD::StaticClass();
}
