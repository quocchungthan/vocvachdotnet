import { Element } from "./Element";

interface KeyValues {
  [key: string]: string;
}

export class EnumSelect extends Element {
  private schema: string;
  private options: KeyValues = {};
  constructor(schema: string, name?: string, label?: string) {
    super();
    this.name = name;
    this.label = label;
    this.schema = schema;
    this.type = "select";
    this.calculating();
    this.schema = null;
  }
  private calculating() {
    // find options here
  }
}
