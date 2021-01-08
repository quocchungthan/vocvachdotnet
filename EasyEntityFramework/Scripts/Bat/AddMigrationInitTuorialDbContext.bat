@echo off 
cd ../../
dotnet ef migrations add Init --context EFTutorialDbContext -o "EFDbContext\EFTutorial\Migrations" --verbose