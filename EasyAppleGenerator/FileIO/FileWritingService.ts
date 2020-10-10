import * as fs from "fs";
import { configService } from "../Configurations/ConfigService";
import * as path from "path";

class FileWritingService {
  public async forceWriteFile(
    fileName: string,
    fileContent: string
  ): Promise<void> {
    await this.writeFileAsync(
      path.join(configService.Config.path, fileName),
      fileContent
    );
  }

  public async forceWriteFileWithAbsolutePath(
    filePath: string,
    fileContent: string
  ): Promise<void> {
    await this.writeFileAsync(filePath, fileContent);
  }

  private async writeFileAsync(
    fileName: string,
    fileContent: string
  ): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      fs.writeFile(fileName, fileContent, (err) => {
        if (!err) {
          resolve();
        } else {
          reject(err);
        }
      });
    });
  }
}

export const fileWritingService = new FileWritingService();
