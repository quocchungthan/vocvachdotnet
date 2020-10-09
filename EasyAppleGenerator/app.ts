import { configService } from "./Configurations/ConfigService";

console.log('This tool provides code generating features: code dotnet & angular forms');
configService.loadConfigAsync().then(() => {
    console.log(configService.Config);
});