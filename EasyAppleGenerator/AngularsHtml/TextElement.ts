import { Element } from "./Element";

export class TextElement extends Element {
  constructor(fieldName: string) {
    super();
    this.type = "text";
    this.label = this.toLabel(fieldName);
  }
}
