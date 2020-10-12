import { Element } from "./Element";

export class CheckBox extends Element {
    constructor(fieldName: string) {
        super();
        this.type = "checkBox";
        this.label = this.toLabel(fieldName);
        this.size = 2;
    }
}
