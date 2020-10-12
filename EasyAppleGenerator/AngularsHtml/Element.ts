import { ICalcOutput } from "./ICalcOutput";

export abstract class Element implements ICalcOutput {
  innerHTML?: ICalcOutput[];
  type: "container" | "text" | "select" | "array" | "datePicker" | 'dateTimePicker' | 'checkBox' | 'numberInput';
  label?: string;
  row?: number;
  size?: number;
  offset?: number;
  name: string;

  protected getEntryInputSchema(schema: string): string {
    const pattern = /input (\w+) \{/gi;
    const formPattern = /input \w+ \{([^{}]+)\}/gi;
    const inputNames = this.collectMatchs(schema, pattern);
    const inputForms = this.collectMatchs(schema, formPattern);
    // It's business
    return inputNames.find(
      (name) => !inputForms.find((form) => form.includes(name))
    );
  }

  protected collectMatchs(input: string, pattern: RegExp): string[] {
    return input.match(pattern)?.map((x) => x.replace(pattern, "$1"));
  }

  protected notSpacesOnly(str: string): boolean {
    return !str.match(/^\s*$/);
  }

  protected toLabel(camelName: string): string {
    const namePattern = /([A-Z]+[a-z]*)$/g;
    let name = camelName;
    const words = [];

    while (name.match(/[A-Z]/)) {
      words.push(namePattern.exec(name)[1]);
      name = name.replace(namePattern, "");
    }

    return [...words, name].reverse().join(" ");
  }
}
