import { ContainerElement } from "./ContainerElement";
import { EnumSelect } from "./EnumSelect";
import { SuperContainerElement } from "./SuperContainerElement";

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
  }
}
