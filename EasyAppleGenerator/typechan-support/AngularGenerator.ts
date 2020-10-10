import { ICalcOutput } from "../AngularsHtml/ICalcOutput";
import { exec } from "child_process";
import { configService } from "../Configurations/ConfigService";

class AngularGenerator {
  public generateComponentAsync(model: ICalcOutput): Promise<number> {
    const path = configService.Config.typechan.projectDir;
    const module = configService.Config.typechan.module;
    return new Promise<number>((resolve, reject) => {
      exec(
        `cd ${path} && ng g c ${model.name} --module=${module}`,
        (e, out, err) => {
          console.log(out);
          if (e) {
            reject(err);
          } else {
            resolve(0);
          }
        }
      );
    });
  }
}

export const angularGenerator = new AngularGenerator();
