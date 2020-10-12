import { Element } from "./Element";

export class NumberInput extends Element {
    constructor(fieldName: string) {
        super();
        this.type = "numberInput";
        this.label = this.toLabel(fieldName);
    }
}
