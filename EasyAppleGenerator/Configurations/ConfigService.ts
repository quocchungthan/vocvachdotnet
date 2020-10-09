import { findAndReadConfig } from "read-config-file";
import { IConfiguration } from "./IConfiguration";

class ConfigService {
    private _config: IConfiguration;

    public get Config() {
        return this._config;
    }

    public async loadConfigAsync(): Promise<void> {
        const x = await findAndReadConfig<IConfiguration>({
            configFilename: "project-configuration",
            projectDir: "C:/Users/tqchung/source/repos/vocvachdotnet/EasyAppleGenerator/",
            packageKey: "nsot98er",
            packageMetadata: null
        });
        this._config = x.result;
    }
}

export const configService = new ConfigService();