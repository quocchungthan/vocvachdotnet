import { Element } from "./Element";

export class DateTimePicker extends Element {
    constructor(fieldName: string) {
        super();
        this.type = "dateTimePicker";
        this.label = this.toLabel(fieldName);
    }
}
