import { angularHtmlElementService } from "./AngularsHtml/AngularsHtmlElementService";
import { configService } from "./Configurations/ConfigService";
import { fileWritingService } from "./FileIO/FileWritingService";

console.log('This tool provides code generating features: code dotnet & angular forms');

async function bootstrapping(): Promise<number> {
    await configService.loadConfigAsync();
    const input1 = angularHtmlElementService.createInputTextForm();
    await fileWritingService.forceWriteFile("ignored/dist/index.html", input1);
    return 0;
}

bootstrapping()
    .then(numberOfErrors => {
        console.log("Errors: ", numberOfErrors);
    });