import { angularHtmlElementService } from "./AngularsHtml/AngularsHtmlElementService";
import { calculatingService } from "./AngularsHtml/CalculatingService";
import { configService } from "./Configurations/ConfigService";
import { fileWritingService } from "./FileIO/FileWritingService";

console.log(
  "\x1b[33m%s\x1b[0m",
  "This tool provides code generating features: code dotnet & angular forms"
);

async function bootstrapping(): Promise<number> {
  await configService.loadConfigAsync(__dirname);
  const calculated = calculatingService.seperatedCalculation();
  const html = angularHtmlElementService.initHtmlPage(
    JSON.stringify(calculated)
  );
  await fileWritingService.forceWriteFile("index.html", html);
  return 0;
}

bootstrapping().then((numberOfErrors) => {
  console.log("Errors: ", numberOfErrors);
});
