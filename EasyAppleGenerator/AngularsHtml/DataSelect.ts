import { Element } from "./Element";

export class DataSelectElement extends Element {
  constructor(fieldName: string) {
    super();
    this.type = "select";
    this.label = this.toLabel(fieldName);
  }
}
