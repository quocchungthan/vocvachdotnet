import { DataSelectElement } from "./DataSelect";
import { Element } from "./Element";
import { EnumSelect } from "./EnumSelect";
import { ICalcOutput } from "./ICalcOutput";
import { TextElement } from "./TextElement";

export abstract class SuperContainerElement extends Element {
  protected schema: string;

  constructor(schema: string, name?: string, label?: string) {
    super();
    this.name = name;
    this.label = label;
    this.schema = schema;
    this.type = "container";
    if (name == undefined) {
      this.name = this.getEntryInputSchema(schema);
    }
    this.calculating();
    delete this.schema;
  }

  protected calculating(): void {
    const fields = this.getFormFieldsAsStringsByName(this.name);
    this.innerHTML = fields.map((x) => this.child(x)).filter((x) => x);

    // if (fields != null) {
    //   const result: ICalcOutput = {
    //     type: "container",
    //     innerHTML: fields
    //       .map((x) => this.calculatingByFieldName(schema, x))
    //       .filter((x) => x),
    //   };
    //   return result;
    // } else {
    //   const result: ICalcOutput = {
    //     type: "select",
    //   };
    //   return result;
    // }
  }

  private child(field: string): ICalcOutput {
    const fieldPattern = /(\w+)\: (\w+|\[\w+\])(\!?)( = (\w+))?/gi;
    const [input, fieldName, fieldType] = fieldPattern.exec(field) || [];

    if (!fieldName || fieldName === "id") {
      // Id should not be showed on forms
      return null;
    }
    // text box
    if (fieldType === "String") {
      return new TextElement(fieldName);
    }

    if (fieldType === "ID") {
      return new DataSelectElement(fieldName);
    }

    if (this.isSubContainer(fieldType)) {
      return this.seftNew(this.schema, fieldType, fieldName);
    }

    if (this.isEnumSelection(fieldType)) {
      return new EnumSelect(this.schema, fieldType, fieldName);
    }

    if (this.isArray(fieldType)) {
      return this.seftNewArray(this.schema, fieldType, fieldName);
    }

    console.log(
      "\x1b[33m%s\x1b[0m",
      "Can not resolve ",
      fieldName,
      " with type ",
      fieldType
    );

    return null;
  }

  protected isArray(fieldType: string): boolean {
    return fieldType[0] === "[";
  }

  protected isSubContainer(fieldType: string): boolean {
    const containerPattern = `input ${fieldType} {`;
    return this.schema.includes(containerPattern);
  }

  protected isEnumSelection(fieldType: string): boolean {
    const containerPattern = `enum ${fieldType} {`;
    return this.schema.includes(containerPattern);
  }

  protected abstract seftNew(
    schema: string,
    type: string,
    name: string
  ): SuperContainerElement;

  protected abstract seftNewArray(
    schema: string,
    type: string,
    name: string
  ): SuperContainerElement;

  //   private calculatingByFieldName(
  //     schema: string,
  //     fieldSchema: string
  //   ): ICalcOutput {
  //     const fieldPattern = /(\w+)\: (\w+|\[\w+\])(\!?)( = (\w+))?/gi;
  //     const matches = fieldPattern.exec(fieldSchema);

  //     // Id should not be showed on forms
  //     if (!matches || matches[1] == "id") {
  //       return null;
  //     }

  //     const controlType = this.getControlType(matches[2]);

  //     if (controlType === "container" || controlType === "array") {
  //       const calculated = this.calculatingByInputName(schema, matches[2]);
  //       return {
  //         ...calculated,
  //         label: this.toLabel(matches[1]),
  //         type: calculated.type === "select" ? calculated.type : controlType,
  //       };
  //     }

  //     return {
  //       type: this.getControlType(matches[2]),
  //       label: this.toLabel(matches[1]),
  //     };
  //   }

  private getFormFieldsAsStringsByName(name: string): string[] {
    const formPattern = new RegExp(
      "input " + name.replace(/[\[\]]/gi, "") + " {([^{}]+)}",
      "gi"
    );
    // const enumPattern = new RegExp("enum " + name + " {([^{}]+)}", "gi");
    const matches = this.collectMatchs(this.schema, formPattern)?.[0];

    if (!matches) {
      return null;
    }

    return matches.split("\n").filter(this.notSpacesOnly);
  }
}
