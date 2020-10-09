import * as fs from 'fs';

class FileWritingService {
    public async forceWriteFile(fileName: string, fileContent: string): Promise<void> {
        await this.writeFileAsync(fileName, fileContent);
    }

    private async writeFileAsync(fileName: string, fileContent: string): Promise<void> {
        return new Promise<void>((resolve, reject) => {
            fs.writeFile(fileName, fileContent, (err) => {
                if (!err) {
                    resolve();
                } else {
                    reject(err);
                }
            })
        });
    }

}

export const fileWritingService = new FileWritingService();