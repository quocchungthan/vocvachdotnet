import { angularHtmlElementService } from "./AngularsHtml/AngularsHtmlElementService";
import { configService } from "./Configurations/ConfigService";
import { fileWritingService } from "./FileIO/FileWritingService";

console.log(
  "\x1b[33m%s\x1b[0m",
  "This tool provides code generating features: code dotnet & angular forms"
);

async function bootstrapping(): Promise<number> {
  await configService.loadConfigAsync(__dirname);
  const input1 = angularHtmlElementService.createInputTextForm();
  await fileWritingService.forceWriteFile("index.html", input1);
  return 0;
}

bootstrapping().then((numberOfErrors) => {
  console.log("Errors: ", numberOfErrors);
});
