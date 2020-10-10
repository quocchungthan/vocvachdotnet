import { ArrayContainerElement } from "./ArrayContainerElement";
import { SuperContainerElement } from "./SuperContainerElement";

export class ContainerElement extends SuperContainerElement {
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
}
