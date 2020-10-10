import { Element } from "./Element";

interface KeyValues {
  [key: string]: string;
}

export class EnumSelect extends Element {
  private schema: string;
  public options: KeyValues = {};
  constructor(schema: string, name?: string, label?: string) {
    super();
    this.name = name;
    this.label = label;
    this.schema = schema;
    this.type = "select";
    this.size = 3;
    this.calculating();
    delete this.schema;
  }
  private calculating() {
    for (const f of this.getFormFieldsAsStringsByName(this.name)) {
      this.options[f] = this.toLabel(f).toLocaleLowerCase();
    }
  }

  private getFormFieldsAsStringsByName(name: string): string[] {
    const formPattern = new RegExp(
      "enum " + name.replace(/[\[\]]/gi, "") + " {([^{}]+)}",
      "gi"
    );
    const matches = this.collectMatchs(this.schema, formPattern)?.[0];

    if (!matches) {
      return null;
    }

    return matches.split("\n").filter(this.notSpacesOnly);
  }
}
