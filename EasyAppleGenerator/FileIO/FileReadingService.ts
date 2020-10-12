import * as fs from "fs";
import { configService } from "../Configurations/ConfigService";
import * as path from "path";

class FileReadingService {

    public async readFileByAbsolutePathAsync(
        pathFile: string
    ): Promise<string> {
        const content = await this.readFileAsync(pathFile);

        // const occurrences = content.match(/(\w+)\: (\w+|\[\w+\])(\!?)( = (\w+))?/gi).map(
        //     x => x.replace(/(\w+)\: (\w+|\[\w+\])(\!?)( = (\w+))?/gi, '$2').replace(/[\[\]]/gi, '')
        // ).filter((v, i, a) => a.indexOf(v) === i).filter(x => {
        //     return !content.match(new RegExp("\\w+ " + x + " \{", "gi"));
        // });

        // console.log(occurrences);

        return content;
    }

    private async readFileAsync(
        fileName: string
    ): Promise<string> {
        return new Promise<string>((resolve, reject) => {
            fs.readFile(fileName, {
                encoding: 'UTF-8'
            }, (err, data) => {
                if (!err) {
                    resolve(data);
                } else {
                    reject(err);
                }
            });
        });
    }
}

export const fileReadingService = new FileReadingService();
