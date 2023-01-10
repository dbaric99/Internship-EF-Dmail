using Dmail.Presentation.Extensions;
using Dmail.Presentation.Factories;

var mainMenuActions = MainMenuFactory.CreateActions();
mainMenuActions.PrintActionsAndOpen();