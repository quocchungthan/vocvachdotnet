import { Element } from "./Element";

export class DatePicker extends Element {
    constructor(fieldName: string) {
        super();
        this.type = "datePicker";
        this.label = this.toLabel(fieldName);
    }
}
