import { CheckBox } from "./CheckBox";
import { ContainerElement } from "./ContainerElement";
import { DataSelectElement } from "./DataSelect";
import { DatePicker } from "./DatePicker";
import { DateTimePicker } from "./DateTimePicker";
import { EnumSelect } from "./EnumSelect";
import { NumberInput } from "./NumberInput";
import { SuperContainerElement } from "./SuperContainerElement";
import { TextElement } from "./TextElement";

export class ArrayContainerElement extends SuperContainerElement {
  protected seftNewArray(
    schema: string,
    type: string,
    name: string
  ): SuperContainerElement {
    return new ArrayContainerElement(schema, type, name);
  }
  protected seftNew(
    schema: string,
    type: string,
    name: string
  ): SuperContainerElement {
    return new ContainerElement(schema, type, name);
  }

  constructor(schema: string, name?: string, label?: string) {
    super(schema, name, label);
    this.type = "array";
  }

  protected calculating() {
    const actualName = this.name.replace(/[\[\]]/gi, "");
    if (this.isSubContainer(actualName)) {
      this.innerHTML = [new ContainerElement(this.schema, actualName, null)];
    }

    if (this.isEnumSelection(actualName)) {
      this.innerHTML = [new EnumSelect(this.schema, actualName, this.label)];
    }



    if (actualName === "DateTime") {
      this.innerHTML = [new DateTimePicker(this.label)];
    }

    if (actualName === "Date") {
      this.innerHTML = [new DatePicker(this.label)];
    }

    if (actualName === "Int" || actualName === "Decimal") {
      this.innerHTML = [new NumberInput(this.label)];
    }

    if (actualName === "Boolean") {
      this.innerHTML = [new CheckBox(this.label)];
    }

    if (actualName === "String") {
      this.innerHTML = [new TextElement(this.label)];
    }

    if (actualName === "ID") {
      this.innerHTML = [new DataSelectElement(this.label)];
    }
  }
}
