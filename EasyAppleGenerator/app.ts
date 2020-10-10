import { angularHtmlElementService } from "./AngularsHtml/AngularsHtmlElementService";
import { calculatingService } from "./AngularsHtml/CalculatingService";
import { configService } from "./Configurations/ConfigService";
import { fileWritingService } from "./FileIO/FileWritingService";
import { angularGenerator } from "./typechan-support/AngularGenerator";

console.log(
  "\x1b[33m%s\x1b[0m",
  "This tool provides code generating features: code dotnet & angular forms"
);

async function bootstrapping(): Promise<number> {
  await configService.loadConfigAsync(__dirname);
  const calculated = calculatingService.seperatedCalculation();
  // we may have many entries in one schema
  // const input =
  //   "\n" +
  //   calculated.map((x) => angularHtmlElementService.build(x)).join("\n") +
  //   "\n";
  // const container = angularHtmlElementService.createSuperContainer(input);
  // const html = angularHtmlElementService.initHtmlPage(container);
  // await fileWritingService.forceWriteFile("index.html", html);
  for (const m of calculated) {
    await angularGenerator.generateComponentAsync(m);
  }
  return 0;
}

bootstrapping().then((numberOfErrors) => {
  console.log("Errors: ", numberOfErrors);
});
